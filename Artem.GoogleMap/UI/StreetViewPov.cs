using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// A point of view object which specifies the camera's orientation at the Street View panorama's position. 
    /// The point of view is defined as heading, pitch and zoom.
    /// </summary>
    public class StreetViewPov {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// The camera heading in degrees relative to true north. 
        /// True north is 0°, east is 90°, south is 180°, west is 270°.
        /// </summary>
        /// <value>The heading.</value>
        public int Heading { get; set; }

        /// <summary>
        /// The camera pitch in degrees, relative to the street view vehicle. 
        /// Ranges from 90° (directly upwards) to -90° (directly downwards).
        /// </summary>
        /// <value>The pitch.</value>
        public int Pitch { get; set; }

        /// <summary>
        /// The zoom level. Fully zoomed-out is level 0, zooming in increases the zoom level.
        /// </summary>
        /// <value>The zoom.</value>
        public int Zoom { get; set; }

        #endregion
    }
}
