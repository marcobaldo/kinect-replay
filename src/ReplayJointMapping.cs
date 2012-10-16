using System.Windows;

namespace Codewisp.Research.KinectReplay
{
    /// <summary>
    /// This class is used to map points between skeleton and color/depth
    /// </summary>
    public class ReplayJointMapping
    {
        /// <summary>
        /// Gets or sets the joint at which we we are looking
        /// </summary>
        public ReplayJoint Joint { get; set; }

        /// <summary>
        /// Gets or sets the point mapped into the target display
        /// </summary>
        public Point MappedPoint { get; set; }
    }
}
