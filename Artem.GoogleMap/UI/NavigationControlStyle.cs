using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Identifiers for common types of navigation controls.
    /// </summary>
    public enum NavigationControlStyle {
        /// <summary>
        /// The default navigation control. 
        /// The control which DEFAULT maps to will vary according to map size and other factors. 
        /// It may change in future versions of the API.
        /// </summary>
        Default = 0,
        /// <summary>
        /// The larger control, with the zoom slider and pan directional pad.
        /// </summary>
        ZoomPan = 1,
        /// <summary>
        /// The small, zoom only control.
        /// </summary>
        Small = 2,
        /// <summary>
        /// The small zoom control similar to the one used by the native Maps application on Android.
        /// </summary>
        Android = 3
    }
}
