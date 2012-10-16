using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Kinect;
using System.Windows;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplaySkeletonPoint : ISerializable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public ReplaySkeletonPoint() { }

        public ReplaySkeletonPoint(SerializationInfo info, StreamingContext context)
        {
            this.X = (float)info.GetValue("X", typeof(float));
            this.Y = (float)info.GetValue("Y", typeof(float));
            this.Z = (float)info.GetValue("Z", typeof(float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", this.X);
            info.AddValue("Y", this.Y);
            info.AddValue("Z", this.Z);
        }

        public SkeletonPoint ToSkeletonPoint()
        {
            return new SkeletonPoint()
            {
                X = this.X,
                Y = this.Y,
                Z = this.Z
            };
        }

        public static ReplaySkeletonPoint FromSkeletonPoint(SkeletonPoint skeletonPoint)
        {
            return new ReplaySkeletonPoint()
            {
                X = skeletonPoint.X,
                Y = skeletonPoint.Y,
                Z = skeletonPoint.Z
            };
        }
    }
}
