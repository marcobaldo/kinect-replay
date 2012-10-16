using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Kinect;

namespace Codewisp.Research.KinectReplay
{
    [Serializable()]
    public class ReplayJoint : ISerializable
    {
        public JointType JointType { get; set; }
        public ReplaySkeletonPoint Position { get; set; }
        public JointTrackingState TrackingState { get; set; }

        public ReplayJoint() { }

        public ReplayJoint(SerializationInfo info, StreamingContext context)
        {
            this.JointType = (JointType)info.GetValue("JointType", typeof(JointType));
            this.Position = (ReplaySkeletonPoint)info.GetValue("Position", typeof(ReplaySkeletonPoint));
            this.TrackingState = (JointTrackingState)info.GetValue("TrackingState", typeof(JointTrackingState));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("JointType", this.JointType);
            info.AddValue("Position", this.Position);
            info.AddValue("TrackingState", this.TrackingState);
        }

        public static ReplayJoint FromJoint(Joint joint)
        {
            return new ReplayJoint()
            {
                JointType = joint.JointType,
                Position = ReplaySkeletonPoint.FromSkeletonPoint(joint.Position),
                TrackingState = joint.TrackingState
            };
        }

        public double DistanceFromJoint(ReplayJoint joint)
        {
            return Math.Abs(this.Position.X - joint.Position.X);
        }
    }
}
