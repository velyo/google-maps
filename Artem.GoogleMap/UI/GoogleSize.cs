using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GoogleSize {

        #region Static Fields ///////////////////////////////////////////////////////////

        public static readonly GoogleSize DefaultMarkerIconSize = new GoogleSize(16, 16);
        public static readonly GoogleSize DefaultMarkerShadowSize = new GoogleSize(16, 16);

        #endregion

        #region Static Methods //////////////////////////////////////////////////////////

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(GoogleSize a, GoogleSize b) {
            return ((a.Width == b.Width) && (a.Height == b.Height));
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(GoogleSize a, GoogleSize b) {
            return !(a == b);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.UI.GoogleSize"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator GoogleSize(string value) {
            return Parse(value);
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static GoogleSize Parse(string value) {

            int width = 0;
            int height = 0;

            if (!string.IsNullOrEmpty(value)) {
                string[] pair = value.Split(',');
                if (pair.Length >= 2) {
                    width = JsUtil.ToInt(pair[0]);
                    height = JsUtil.ToInt(pair[1]);
                }
            }

            return new GoogleSize(width, height);
        }
        #endregion

        #region Fields  /////////////////////////////////////////////////////////////////

        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        #endregion

        #region Construct  //////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleSize"/> struct.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public GoogleSize(int width, int height) {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleSize"/> struct.
        /// </summary>
        public GoogleSize() { }

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

            if (!(obj is GoogleSize)) return false;
            GoogleSize size = (GoogleSize)obj;
            return ((size.Width == this.Width) && (size.Height == this.Height));
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
            return string.Format("{0},{1}", Width.ToString(), Height.ToString());
        }
        #endregion
    }
}
