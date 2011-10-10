using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.Net {

    /// <summary>
    /// 
    /// </summary>
    public class GeoBounds {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the north east.
        /// </summary>
        /// <value>The north east.</value>
        public GeoLocation NorthEast { get; set; }

        /// <summary>
        /// Gets or sets the south west.
        /// </summary>
        /// <value>The south west.</value>
        public GeoLocation SouthWest { get; set; }

        #endregion
    }
}
