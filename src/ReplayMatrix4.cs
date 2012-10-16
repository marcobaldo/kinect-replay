using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Kinect;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplayMatrix4 : ISerializable
    {
        public float M11 { get; set; }
        public float M12 { get; set; }
        public float M13 { get; set; }
        public float M14 { get; set; }
        public float M21 { get; set; }
        public float M22 { get; set; }
        public float M23 { get; set; }
        public float M24 { get; set; }
        public float M31 { get; set; }
        public float M32 { get; set; }
        public float M33 { get; set; }
        public float M34 { get; set; }
        public float M41 { get; set; }
        public float M42 { get; set; }
        public float M43 { get; set; }
        public float M44 { get; set; }

        public ReplayMatrix4() { }

        public ReplayMatrix4(SerializationInfo info, StreamingContext context)
        {
            this.M11 = (float)info.GetValue("M11", typeof(float));
            this.M12 = (float)info.GetValue("M12", typeof(float));
            this.M13 = (float)info.GetValue("M13", typeof(float));
            this.M14 = (float)info.GetValue("M14", typeof(float));
            this.M21 = (float)info.GetValue("M21", typeof(float));
            this.M22 = (float)info.GetValue("M22", typeof(float));
            this.M23 = (float)info.GetValue("M23", typeof(float));
            this.M24 = (float)info.GetValue("M24", typeof(float));
            this.M31 = (float)info.GetValue("M31", typeof(float));
            this.M32 = (float)info.GetValue("M32", typeof(float));
            this.M33 = (float)info.GetValue("M33", typeof(float));
            this.M34 = (float)info.GetValue("M34", typeof(float));
            this.M41 = (float)info.GetValue("M41", typeof(float));
            this.M42 = (float)info.GetValue("M42", typeof(float));
            this.M43 = (float)info.GetValue("M43", typeof(float));
            this.M44 = (float)info.GetValue("M44", typeof(float));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("M11", this.M11);
            info.AddValue("M12", this.M12);
            info.AddValue("M13", this.M13);
            info.AddValue("M14", this.M14);
            info.AddValue("M21", this.M21);
            info.AddValue("M22", this.M22);
            info.AddValue("M23", this.M23);
            info.AddValue("M24", this.M24);
            info.AddValue("M31", this.M31);
            info.AddValue("M32", this.M32);
            info.AddValue("M33", this.M33);
            info.AddValue("M34", this.M34);
            info.AddValue("M41", this.M41);
            info.AddValue("M42", this.M42);
            info.AddValue("M43", this.M43);
            info.AddValue("M44", this.M44);
        }

        public static ReplayMatrix4 FromMatrix4(Matrix4 matrix4)
        {
            return new ReplayMatrix4()
            {
                M11 = matrix4.M11,
                M12 = matrix4.M12,
                M13 = matrix4.M13,
                M14 = matrix4.M14,
                M21 = matrix4.M21,
                M22 = matrix4.M22,
                M23 = matrix4.M23,
                M24 = matrix4.M24,
                M31 = matrix4.M31,
                M32 = matrix4.M32,
                M33 = matrix4.M33,
                M34 = matrix4.M34,
                M41 = matrix4.M41,
                M42 = matrix4.M42,
                M43 = matrix4.M43,
                M44 = matrix4.M44
            };
        }
    }
}
