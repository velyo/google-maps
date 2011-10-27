using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class Size : IScriptDataConverter {

        #region Static Fields

        public static readonly Size DefaultMarkerIconSize = new Size(16, 16);
        public static readonly Size DefaultMarkerShadowSize = new Size(16, 16);

        #endregion

        #region Static Methods

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Size a, Size b) {
            return object.ReferenceEquals(a, null)
                ? object.ReferenceEquals(b, null) : a.Equals(b);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Size a, Size b) {
            return !(a == b);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.UI.Size"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Size(string value) {
            return Parse(value);
        }

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static Size FromScriptData(object scriptObject) {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                var size = new Size();
                object value;
                if (data.TryGetValue("width", out value)) size.Width = (int)value;
                if (data.TryGetValue("height", out value)) size.Height = (int)value;
                return size;
            }
            return null;
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Size Parse(string value) {

            int width = 0;
            int height = 0;

            if (!string.IsNullOrEmpty(value)) {
                string[] pair = value.Split(',');
                if (pair.Length >= 2) {
                    width = JsUtil.ToInt(pair[0]);
                    height = JsUtil.ToInt(pair[1]);
                }
            }

            return new Size(width, height);
        }
        #endregion

        #region Properties

        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Size(int width, int height) {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        public Size() { }

        #endregion

        #region Methods

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) {
            return (obj is Size) ? this.Equals(obj as Size) : false;
        }

        /// <summary>
        /// Equalses the specified size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public bool Equals(Size size) {
            return !object.ReferenceEquals(size, null)
                ? ((this.Width == size.Width) && (this.Height == size.Height))
                : false;
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
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            return new Dictionary<string, object> { { "width", this.Width }, { "height", this.Height } };
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
