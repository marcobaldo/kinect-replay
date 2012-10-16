using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Runtime.Serialization;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplayDepthImageFrame : ISerializable
    {
        public int FrameNumber { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int BytesPerPixel { get; set; }
        public int PixelDataLength { get; set; }
        public long Timestamp { get; set; }
        public short[] PixelData { get; set; }

        public ReplayDepthImageFrame() { }

        public ReplayDepthImageFrame(SerializationInfo info, StreamingContext context)
        {
            this.FrameNumber = (int)info.GetValue("FrameNumber", typeof(int));
            this.Width = (int)info.GetValue("Width", typeof(int));
            this.Height = (int)info.GetValue("Height", typeof(int));
            this.BytesPerPixel = (int)info.GetValue("BytesPerPixel", typeof(int));
            this.PixelDataLength = (int)info.GetValue("PixelDataLength", typeof(int));
            this.Timestamp = (long)info.GetValue("Timestamp", typeof(long));
            this.PixelData = (short[])info.GetValue("PixelData", typeof(short[]));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FrameNumber", this.FrameNumber);
            info.AddValue("Width", this.Width);
            info.AddValue("Height", this.Height);
            info.AddValue("BytesPerPixel", this.BytesPerPixel);
            info.AddValue("PixelDataLength", this.PixelDataLength);
            info.AddValue("Timestamp", this.Timestamp);
            info.AddValue("PixelData", this.PixelData);
        }

        public static ReplayDepthImageFrame FromDepthImageFrame(DepthImageFrame frame)
        {
            short[] pixelData = new short[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);

            return new ReplayDepthImageFrame()
            {
                FrameNumber = frame.FrameNumber,
                BytesPerPixel = frame.BytesPerPixel,
                PixelDataLength = frame.PixelDataLength,
                Width = frame.Width,
                Height = frame.Height,
                Timestamp = frame.Timestamp,
                PixelData = pixelData
            };
        }
    }
}
