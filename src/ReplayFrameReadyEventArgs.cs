using System;
using Codewisp.Research.KinectReplay;

namespace Codewisp.Research.KinectReplay
{
    public class ReplayFrameReadyEventArgs : EventArgs
    {
        public ReplayFrame ReplayFrame { get; set; }
    }
}
