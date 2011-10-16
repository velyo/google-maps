using System;
using System.Collections.Generic;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum GoogleMarkerBehaviour {
        /// <summary>
        /// 
        /// </summary>
        AutoPan         = 0x0001,
        /// <summary>
        /// 
        /// </summary>
        Bouncy          = 0x0002,
        /// <summary>
        /// 
        /// </summary>
        Clickable       = 0x0004,
        /// <summary>
        /// 
        /// </summary>
        Draggable       = 0x0008,
        /// <summary>
        /// 
        /// </summary>
        DragCrossMove   = 0x0010,
        /// <summary>
        /// 
        /// </summary>
        DefaultSet      = AutoPan | Clickable
    }
}
