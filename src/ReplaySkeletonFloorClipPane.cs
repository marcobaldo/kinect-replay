using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplaySkeletonFrameFloorClipPane : ISerializable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public ReplaySkeletonFrameFloorClipPane() { }

        public ReplaySkeletonFrameFloorClipPane(SerializationInfo info, StreamingContext context)
        {
            this.X = (float)info.GetValue("X", typeof(float));
            this.Y = (float)info.GetValue("Y", typeof(float));
            this.Z = (float)info.GetValue("Z", typeof(float));
            this.W = (float)info.GetValue("W", typeof(float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", this.X);
            info.AddValue("Y", this.Y);
            info.AddValue("Z", this.Z);
            info.AddValue("W", this.W);
        }

        public static ReplaySkeletonFrameFloorClipPane FromTuple(Tuple<float, float, float, float> floorClipPane)
        {
            return new ReplaySkeletonFrameFloorClipPane()
            {
                X = floorClipPane.Item1,
                Y = floorClipPane.Item2,
                Z = floorClipPane.Item3,
                W = floorClipPane.Item4
            };
        }
    }
}
