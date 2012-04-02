using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.Net {

    /// <summary>
    /// 
    /// </summary>
    public class GeoAddress {

        #region Properties

        /// <summary>
        /// Gets or sets the long name.
        /// </summary>
        /// <value>The long name.</value>
        public string LongName { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the types.
        /// </summary>
        /// <value>The types.</value>
        public string[] Types { get; set; }

        #endregion
    }
}
