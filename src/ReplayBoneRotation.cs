using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Kinect;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplayBoneRotation : ISerializable
    {
        public ReplayMatrix4 Matrix { get; set; }
        public ReplayVector4 Quaternion { get; set; }

        public ReplayBoneRotation() { }

        public ReplayBoneRotation(SerializationInfo info, StreamingContext context)
        {
            this.Matrix = (ReplayMatrix4)info.GetValue("Matrix", typeof(ReplayMatrix4));
            this.Quaternion = (ReplayVector4)info.GetValue("Quaternion", typeof(ReplayVector4));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Matrix", this.Matrix);
            info.AddValue("Quaternion", this.Quaternion);
        }

        public static ReplayBoneRotation FromBoneRotation(BoneRotation boneRotation)
        {
            return new ReplayBoneRotation()
            {
                Matrix = ReplayMatrix4.FromMatrix4(boneRotation.Matrix),
                Quaternion = ReplayVector4.FromVector4(boneRotation.Quaternion)
            };
        }
    }
}
