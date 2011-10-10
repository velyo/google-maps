using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Artem.Google.Net {

    [Serializable]
    public class GeoLocation : IEquatable<GeoLocation> {

        #region Static Methods ////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(GeoLocation x, GeoLocation y) {

            return (!object.ReferenceEquals(x, null))
                ? x.Equals(y) // if x not null then compare
                : object.ReferenceEquals(y, null); // else equals only if y is null too
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(GeoLocation x, GeoLocation y) {
            return !(x == y);
        }

        /// <summary>
        /// Parses the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static GeoLocation Parse(string point) {

            if (point == null)
                throw new ArgumentNullException("point");

            if (!string.IsNullOrEmpty(point)) {

                point = point.Trim('(', ')');
                string[] pair = point.Split(',');
                if (pair.Length >= 2) {
                    var format = CultureInfo.GetCultureInfo("en").NumberFormat;
                    double lat = Convert.ToDouble(pair[0], format);
                    double lng = Convert.ToDouble(pair[1], format);

                    return new GeoLocation(lat, lng);
                }

            }
            throw new ArgumentException("Invalid GeoLocation string format.");

        }
        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocation"/> class.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public GeoLocation(double latitude, double longitude) {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocation"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public GeoLocation(GeoLocation source)
            : this(source.Latitude, source.Longitude) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeoLocation"/> class.
        /// </summary>
        public GeoLocation()
            : this(0, 0) { }

        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) {
            GeoLocation location = obj as GeoLocation;
            return location != null && this.Equals(location);
        }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(GeoLocation other) {

            return other != null &&
                this.Latitude == other.Latitude &&
                this.Longitude == other.Longitude;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() {
            return this.Latitude.GetHashCode() ^ this.Longitude.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString() {

            var format = CultureInfo.GetCultureInfo("en").NumberFormat;
            return string.Format("{0},{1}",
                this.Latitude.ToString(format), this.Longitude.ToString(format));
        }
        #endregion
    }
}
