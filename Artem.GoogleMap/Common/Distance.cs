using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// A representation of distance as a numeric value and a display string.
    /// </summary>
    public class Distance {

        #region Fields

        /// <summary>
        /// A string representation of the distance value, using the UnitSystem specified in the request.
        /// </summary>
        public string text;

        /// <summary>
        /// The distance in meters.
        /// </summary>
        public int value;

        #endregion
    }
}
