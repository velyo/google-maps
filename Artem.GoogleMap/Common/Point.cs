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
    public class Point : IScriptDataConverter {

        #region Static Fields

        public static readonly Point DefaultMarkerIconAnchor = new Point(8, 16);

        #endregion

        #region Static Methods

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Point a, Point b) {
            return object.ReferenceEquals(a, null)
                ? object.ReferenceEquals(b, null) : a.Equals(b);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Point a, Point b) {
            return !(a == b);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.UI.Point"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Point(string value) {
            return Parse(value);
        }

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static Point FromScriptData(IDictionary<string, object> data) {

            if (data != null) {
                var result = new Point();
                object value;

                if (data.TryGetValue("x", out value)) result.X = (int)value;
                if (data.TryGetValue("y", out value)) result.Y = (int)value;

                return result;
            }
            return null;
        }

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Point Parse(string value) {

            int x = 0;
            int y = 0;

            if (!string.IsNullOrEmpty(value)) {
                string[] pair = value.Split(',');
                if (pair.Length >= 2) {
                    x = JsUtil.ToInt(pair[0]);
                    y = JsUtil.ToInt(pair[1]);
                }
            }
            return new Point(x, y);
        }
        #endregion

        #region Properties

        public int X { get; set; }

        public int Y { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Point(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public Point() { }

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
            return (obj is Point) ? this.Equals(obj as Point) : false;
        }

        /// <summary>
        /// Equalses the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public virtual bool Equals(Point point) {
            return !object.ReferenceEquals(point, null)
                ? (this.X == point.X && this.Y == point.Y) : false;
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
            return new Dictionary<string, object> { { "x", this.X }, { "y", this.Y } };
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