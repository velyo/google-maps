using System;
using System.Collections.Generic;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public struct GoogleZoomPair {

        #region Static Methods ////////////////////////////////////////////////////////////////////

        ///// <summary>
        ///// Parses the specified value.
        ///// </summary>
        ///// <param name="value">The value.</param>
        ///// <returns></returns>
        //public static GoogleZoomPair Parse(string value) {

        //    double ov = 0D;
        //    double nv = 0D;

        //    if (!string.IsNullOrEmpty(value)) {
        //        value = value.Trim('(', ')');
        //        string[] pair = value.Split(',');
        //        if (pair.Length >= 2) {
        //            ov = JsUtil.ToDouble(pair[0]);
        //            nv = JsUtil.ToDouble(pair[1]);
        //        }
        //    }

        //    return new GoogleZoomPair(ov, nv);
        //}
        #endregion

        #region Fields  /////////////////////////////////////////////////////////////////

        public double OldLevel;
        public double NewLevel;

        #endregion

        #region Construct  //////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public GoogleZoomPair(double oldLevel, double newLevel) {
            this.OldLevel = oldLevel;
            this.NewLevel = newLevel;
        }
        #endregion
    }
}
