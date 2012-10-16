using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Kinect;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplayVector4 : ISerializable
    {
        public float W { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public ReplayVector4() { }

        public ReplayVector4(SerializationInfo info, StreamingContext context)
        {
            this.W = (float)info.GetValue("W", typeof(float));
            this.X = (float)info.GetValue("X", typeof(float));
            this.Y = (float)info.GetValue("Y", typeof(float));
            this.Z = (float)info.GetValue("Z", typeof(float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("W", this.W);
            info.AddValue("X", this.X);
            info.AddValue("Y", this.Y);
            info.AddValue("Z", this.Z);
        }

        public static ReplayVector4 FromVector4(Vector4 vector4)
        {
            return new ReplayVector4()
            {
                W = vector4.W,
                X = vector4.X,
                Y = vector4.Y,
                Z = vector4.Z
            };
        }
    }
}
