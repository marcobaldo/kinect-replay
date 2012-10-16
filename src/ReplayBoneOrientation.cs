using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Kinect;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplayBoneOrientation : ISerializable
    {
        public ReplayBoneRotation AbsoluteRotation { get; set; }
        public ReplayBoneRotation HierarchicalRotation { get; set; }
        public JointType StartJoint { get; set; }
        public JointType EndJoint { get; set; }

        public ReplayBoneOrientation() { }

        public ReplayBoneOrientation(SerializationInfo info, StreamingContext context)
        {
            this.AbsoluteRotation = (ReplayBoneRotation)info.GetValue("AbsoluteRotation", typeof(ReplayBoneRotation));
            this.HierarchicalRotation = (ReplayBoneRotation)info.GetValue("HierarchicalRotation", typeof(ReplayBoneRotation));
            this.StartJoint = (JointType)info.GetValue("StartJoint", typeof(JointType));
            this.EndJoint = (JointType)info.GetValue("EndJoint", typeof(JointType));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AbsoluteRotation", this.AbsoluteRotation);
            info.AddValue("HierarchicalRotation", this.HierarchicalRotation);
            info.AddValue("StartJoint", this.StartJoint);
            info.AddValue("EndJoint", this.EndJoint);
        }

        public static ReplayBoneOrientation FromBoneOrientation(BoneOrientation boneOrientation)
        {
            return new ReplayBoneOrientation()
            {
                AbsoluteRotation = ReplayBoneRotation.FromBoneRotation(boneOrientation.AbsoluteRotation),
                HierarchicalRotation = ReplayBoneRotation.FromBoneRotation(boneOrientation.HierarchicalRotation),
                StartJoint = boneOrientation.StartJoint,
                EndJoint = boneOrientation.EndJoint
            };
        }
    }
}
