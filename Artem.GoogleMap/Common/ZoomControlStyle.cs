using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Identifiers for the zoom control.
    /// </summary>
    public enum ZoomControlStyle {
        /// <summary>
        /// The default zoom control. 
        /// The control which DEFAULT maps to will vary according to map size and other factors. 
        /// It may change in future versions of the API.
        /// </summary>
        Default,
        /// <summary>
        /// The larger control, with the zoom slider in addition to +/- buttons.
        /// </summary>
        Large,
        /// <summary>
        /// A small control with buttons to zoom in and out.
        /// </summary>
        Small
    }

}
