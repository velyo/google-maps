﻿using System.Collections.Generic;

namespace Velyo.Google.Maps
{
    /// <summary>
    /// 
    /// </summary>
    public class Point : IScriptDataConverter
    {
        private static readonly Point DefaultMarkerIconAnchor = new Point(8, 16);


        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public Point() { }


        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>The X.</value>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>The Y.</value>
        public int Y { get; set; }


        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Point a, Point b)
        {
            return object.ReferenceEquals(a, null)
                ? object.ReferenceEquals(b, null) : a.Equals(b);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Velyo.Google.UI.Point"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Point(string value)
        {
            return Parse(value);
        }

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static Point FromScriptData(object scriptObject)
        {
            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
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
        public static Point Parse(string value)
        {
            int x = 0;
            int y = 0;

            if (!string.IsNullOrEmpty(value))
            {
                string[] pair = value.Split(',');
                if (pair.Length >= 2)
                {
                    x = JsUtility.ToInt(pair[0]);
                    y = JsUtility.ToInt(pair[1]);
                }
            }
            return new Point(x, y);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is Point) ? Equals(obj as Point) : false;
        }

        /// <summary>
        /// Equalses the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public virtual bool Equals(Point point)
        {
            return !object.ReferenceEquals(point, null)
                ? (X == point.X && Y == point.Y) : false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            return new Dictionary<string, object> { { "x", X }, { "y", Y } };
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0},{1}", X.ToString(), Y.ToString());
        }
    }
}