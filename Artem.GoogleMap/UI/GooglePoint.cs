using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GooglePoint {

        #region Static Fields ///////////////////////////////////////////////////////////

        public static readonly GooglePoint DefaultMarkerIconAnchor = new GooglePoint(8, 16);

        #endregion

        #region Static Methods //////////////////////////////////////////////////////////

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(GooglePoint a, GooglePoint b) {
            return ((a.X == b.X) && (a.Y == b.Y));
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(GooglePoint a, GooglePoint b) {
            return !(a == b);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.UI.GooglePoint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator GooglePoint(string value) {
            return Parse(value);
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static GooglePoint Parse(string value) {

            int x = 0;
            int y = 0;

            if (!string.IsNullOrEmpty(value)) {
                string[] pair = value.Split(',');
                if (pair.Length >= 2) {
                    x = JsUtil.ToInt(pair[0]);
                    y = JsUtil.ToInt(pair[1]);
                }
            }
            return new GooglePoint(x, y);
        }
        #endregion

        #region Properties ////////////////////////////////////////////////////////////////////////

        public int X { get; set; }

        public int Y { get; set; }

        #endregion

        #region Construct  //////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePoint"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public GooglePoint(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePoint"/> class.
        /// </summary>
        public GooglePoint() { }

        #endregion

        #region Methods /////////////////////////////////////////////////////////////////

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) {

            if (!(obj is GooglePoint)) return false;
            GooglePoint point = (GooglePoint)obj;
            return ((point.X == this.X) && (point.Y == this.Y));
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString() {
            return string.Format("{0},{1}", X.ToString(), Y.ToString());
        }
        #endregion
    }
}