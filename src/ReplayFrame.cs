using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using Codewisp.Research.KinectReplay;
using System.Runtime.Serialization;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplayFrame : ISerializable
    {
        public int FrameNumber { get; set; }
        public long Timestamp { get; set; }
        public ReplaySkeletonFrame SkeletonFrame { get; set; }
        public ReplayDepthImageFrame DepthImageFrame { get; set; }

        public ReplayFrame()
        {
            FrameNumber = 0;
        }

        public ReplayFrame(SerializationInfo info, StreamingContext context)
        {
            this.FrameNumber = (int)info.GetValue("FrameNumber", typeof(int));
            this.Timestamp = (long)info.GetValue("Timestamp", typeof(long));
            this.SkeletonFrame = (ReplaySkeletonFrame)info.GetValue("SkeletonFrame", typeof(ReplaySkeletonFrame));
            this.DepthImageFrame = (ReplayDepthImageFrame)info.GetValue("DepthImageFrame", typeof(ReplayDepthImageFrame));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FrameNumber", this.FrameNumber);
            info.AddValue("Timestamp", this.Timestamp);
            info.AddValue("SkeletonFrame", this.SkeletonFrame);
            info.AddValue("DepthImageFrame", this.DepthImageFrame);
        }
    }
}
