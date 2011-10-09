using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// The options for the markers' info window.
    /// </summary>
    public class InfoWindowOptions {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Disable auto-pan on open. 
        /// By default, the info window will pan the map so that it is fully visible when it opens.
        /// </summary>
        /// <value><c>true</c> if [disable auto pan]; otherwise, <c>false</c>.</value>
        public bool DisableAutoPan { get; set; }

        /// <summary>
        /// Maximum width of the infowindow, regardless of content's width. 
        /// </summary>
        /// <value>The width of the max.</value>
        public int? MaxWidth { get; set; }

        /// <summary>
        /// The offset, in pixels, of the tip of the info window from the point on the map at whose geographical 
        /// coordinates the info window is anchored. If an InfoWindow is opened with an anchor, the pixelOffset 
        /// will be calculated from the top-center of the anchor's bounds.
        /// </summary>
        /// <value>The pixel offset.</value>
        public GoogleSize PixelOffset { get; set; }

        /// <summary>
        /// All InfoWindows are displayed on the map in order of their zIndex, with higher values displaying 
        /// in front of InfoWindows with lower values. 
        /// By default, InfoWinodws are displayed according to their latitude, with InfoWindows of lower 
        /// latitudes appearing in front of InfoWindows at higher latitudes. 
        /// InfoWindows are always displayed in front of markers.
        /// </summary>
        /// <value>The index of the Z.</value>
        public int? ZIndex { get; set; }

        #endregion
    }
}
