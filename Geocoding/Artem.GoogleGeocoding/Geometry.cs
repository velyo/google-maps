using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.Net {

    /// <summary>
    /// 
    /// </summary>
    public class Geometry {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public GeoBounds Bounds { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public GeoLocation Location { get; set; }

        /// <summary>
        /// Gets or sets the type of the location.
        /// </summary>
        /// <value>The type of the location.</value>
        public GeoLocationType LocationType { get; set; }

        /// <summary>
        /// Gets or sets the viewport.
        /// </summary>
        /// <value>The viewport.</value>
        public GeoBounds Viewport { get; set; }

        #endregion
    }
}
