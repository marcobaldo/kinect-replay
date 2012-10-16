using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Runtime.Serialization;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplaySkeletonFrame : ISerializable
    {
        public int FrameNumber { get; set; }
        public int SkeletonArrayLength { get; set; }

        public ReplaySkeletonFrameFloorClipPane FloorClipPane { get; set; }
        public ReplaySkeleton[] SkeletonData { get; set; }
        public SkeletonTrackingMode TrackingMode { get; set; }

        public ReplaySkeletonFrame() { }

        public ReplaySkeletonFrame(SerializationInfo info, StreamingContext context)
        {
            this.FrameNumber = (int)info.GetValue("FrameNumber", typeof(int));
            this.SkeletonArrayLength = (int)info.GetValue("SkeletonArrayLength", typeof(int));
            this.FloorClipPane = (ReplaySkeletonFrameFloorClipPane)info.GetValue("FloorClipPane", typeof(ReplaySkeletonFrameFloorClipPane));
            this.SkeletonData = (ReplaySkeleton[])info.GetValue("SkeletonData", typeof(ReplaySkeleton[]));
            this.TrackingMode = (SkeletonTrackingMode)info.GetValue("TrackingMode", typeof(SkeletonTrackingMode));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FrameNumber", this.FrameNumber);
            info.AddValue("SkeletonArrayLength", this.SkeletonArrayLength);
            info.AddValue("FloorClipPane", this.FloorClipPane);
            info.AddValue("SkeletonData", this.SkeletonData);
            info.AddValue("TrackingMode", this.TrackingMode);
        }

        public static ReplaySkeletonFrame FromSkeletonFrame(SkeletonFrame frame)
        {
            ReplaySkeleton[] skeletonData = new ReplaySkeleton[frame.SkeletonArrayLength];
            Skeleton[] frameSkeletonData = new Skeleton[frame.SkeletonArrayLength];
            frame.CopySkeletonDataTo(frameSkeletonData);

            for (int i = 0; i < frame.SkeletonArrayLength; i++)
            {
                Skeleton skeleton = frameSkeletonData[i];
                skeletonData[i] = ReplaySkeleton.FromSkeleton(skeleton);
            }

            return new ReplaySkeletonFrame()
            {
                FrameNumber = frame.FrameNumber,
                FloorClipPane = ReplaySkeletonFrameFloorClipPane.FromTuple(frame.FloorClipPlane),
                SkeletonArrayLength = frame.SkeletonArrayLength,
                SkeletonData = skeletonData,
                TrackingMode = frame.TrackingMode
            };
        }
    }   
}
