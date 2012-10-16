using System.IO;
using System.Threading;
using System;
using Codewisp.Research.KinectReplay;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Codewisp.Research.KinectReplay
{
    public class KinectReplayer : IDisposable
    {
        private Stream stream;
        private BinaryReader reader;
        private TaskScheduler dispatcherScheduler;
        private CancellationTokenSource cancellationTokenSource;

        public readonly List<ReplayFrame> Frames = new List<ReplayFrame>();

        public event EventHandler<ReplayFrameReadyEventArgs> ReplayFrameReady;
        public event EventHandler<ReplayFrameReadyEventArgs> PlaybackEnded;
        public bool IsFinished { get; internal set; }
        public bool IsPlaying { get; internal set; }
        public bool LoopPlayback { get; set; }

        public KinectReplayer(string fileName, TaskScheduler dispatcherScheduler)
        {
            this.stream = new FileStream(fileName, FileMode.Open);
            this.reader = new BinaryReader(stream);
            this.dispatcherScheduler = dispatcherScheduler;

            this.LoopPlayback = false;
            this.IsFinished = false;
            this.IsPlaying = false;

            BinaryFormatter formatter = new BinaryFormatter();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                ReplayFrame frame = (ReplayFrame)formatter.Deserialize(this.stream);
                Frames.Add(frame);
            }
        }

        public ReplayFrame GetFrame(int frameNumber)
        {
            return Frames[frameNumber];
        }

        public void Start()
        {
            if (IsPlaying)
            {
                throw new Exception("KinectReplay is already started.");
            }

            IsPlaying = true;

            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < Frames.Count; )
                {
                    ReplayFrame frame = Frames[i];
                    Thread.Sleep(TimeSpan.FromMilliseconds(frame.Timestamp));

                    if (token.IsCancellationRequested)
                        break;

                    Task.Factory.StartNew(() =>
                    {
                        OnFrameReady(frame);
                    }, CancellationToken.None, TaskCreationOptions.None, dispatcherScheduler);

                    i++;

                    if (LoopPlayback && i == Frames.Count)
                    {
                        i = 0;
                        Task.Factory.StartNew(() =>
                        {
                            OnPlaybackEnded(frame);
                        }, CancellationToken.None, TaskCreationOptions.None, dispatcherScheduler);
                    }
                }
            }, token);
        }

        public void Stop()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
            }

            IsPlaying = false;
        }

        public void Dispose()
        {
            Stop();

            if (reader != null)
            {
                reader.Dispose();
                reader = null;
            }

            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }

        protected virtual void OnFrameReady(ReplayFrame frame)
        {
            if (ReplayFrameReady != null)
            {
                ReplayFrameReadyEventArgs e = new ReplayFrameReadyEventArgs()
                {
                    ReplayFrame = frame
                };
                ReplayFrameReady(this, e);
            }
        }

        protected virtual void OnPlaybackEnded(ReplayFrame frame)
        {
            if (PlaybackEnded != null)
            {
                ReplayFrameReadyEventArgs e = new ReplayFrameReadyEventArgs()
                {
                    ReplayFrame = frame
                };
                PlaybackEnded(this, e);
            }
        }
    }
}
