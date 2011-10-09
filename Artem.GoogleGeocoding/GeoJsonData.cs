using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.Net {

    /// <summary>
    /// 
    /// </summary>
    public class JsonGeoData {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public GeoStatus status { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>The results.</value>
        public JsonResult[] results { get; set; }

        #endregion

        #region Nested Types //////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        public class JsonAddress {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public GeoAddressType[] types { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class JsonBounds {
            public JsonLocation northeast;
            public JsonLocation southwest;
        }

        /// <summary>
        /// 
        /// </summary>
        public class JsonGeometry {
            public JsonBounds bounds { get; set; }
            public JsonLocation location { get; set; }
            public GeoLocationType location_type { get; set; }
            public JsonBounds viewport { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class JsonLocation {
            public double lat;
            public double lng;
        }

        /// <summary>
        /// 
        /// </summary>
        public class JsonResult {
            public JsonAddress[] address_components { get; set; }
            public string formatted_address { get; set; }
            public JsonGeometry geometry { get; set; }
            public string partial_match { get; set; }
            public GeoAddressType[] types { get; set; }
        }
        #endregion
    }
}
