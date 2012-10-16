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
    public class ReplaySkeleton : ISerializable
    {
        public int TrackingId { get; set; }
        public Dictionary<JointType, ReplayBoneOrientation> BoneOrientations { get; set; }
        public FrameEdges ClippedEdges { get; set; }
        public ReplaySkeletonPoint Position { get; set; }
        public Dictionary<JointType, ReplayJoint> Joints { get; set; }
        public Dictionary<JointType, Point> JointToDepthMapping { get; set; }
        public SkeletonTrackingState TrackingState { get; set; }

        public ReplaySkeleton() { }

        public ReplaySkeleton(SerializationInfo info, StreamingContext context)
        {
            this.TrackingId = (int)info.GetValue("TrackingId", typeof(int));
            this.ClippedEdges = (FrameEdges)info.GetValue("ClippedEdges", typeof(FrameEdges));
            this.Position = (ReplaySkeletonPoint)info.GetValue("Position", typeof(ReplaySkeletonPoint));
            this.Joints = (Dictionary<JointType, ReplayJoint>)info.GetValue("Joints", typeof(Dictionary<JointType, ReplayJoint>));
            this.JointToDepthMapping = (Dictionary<JointType, Point>)info.GetValue("JointToDepthMapping", typeof(Dictionary<JointType, Point>));
            this.TrackingState = (SkeletonTrackingState)info.GetValue("TrackingState", typeof(SkeletonTrackingState));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TrackingId", this.TrackingId);
            info.AddValue("ClippedEdges", this.ClippedEdges);
            info.AddValue("Position", this.Position);
            info.AddValue("Joints", this.Joints);
            info.AddValue("JointToDepthMapping", this.JointToDepthMapping);
            info.AddValue("TrackingState", this.TrackingState);
        }

        public static ReplaySkeleton FromSkeleton(Skeleton skeleton)
        {
            Dictionary<JointType, ReplayJoint> joints = new Dictionary<JointType, ReplayJoint>();
            foreach (Joint joint in skeleton.Joints)
            {
                joints.Add(joint.JointType, ReplayJoint.FromJoint(joint));
            }

            Dictionary<JointType, ReplayBoneOrientation> boneOrientations = new Dictionary<JointType, ReplayBoneOrientation>();
            foreach (BoneOrientation boneOrientation in skeleton.BoneOrientations)
            {
                boneOrientations.Add(boneOrientation.EndJoint, ReplayBoneOrientation.FromBoneOrientation(boneOrientation));
            }

            return new ReplaySkeleton()
            {
                ClippedEdges = skeleton.ClippedEdges,
                Joints = joints,
                JointToDepthMapping = new Dictionary<JointType,Point>(),
                Position = ReplaySkeletonPoint.FromSkeletonPoint(skeleton.Position),
                TrackingId = skeleton.TrackingId,
                TrackingState = skeleton.TrackingState
            };
        }
    }
}
