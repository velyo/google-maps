using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// LatLng is a point in geographical coordinates, latitude and longitude.
    /// Notice that although usual map projections associate longitude with the x-coordinate of the map, and latitude with the y-coordinate, the latitude coordinate is always written first, followed by the longitude.
    /// Notice also that you cannot modify the coordinates of a LatLng. If you want to compute another point, you have to create a new one.
    /// </summary>
    public class LatLng : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static LatLng FromScriptData(IDictionary<string, object> data) {

            if (data != null) {
                var result = new LatLng();
                object value;

                if (data.TryGetValue("lat", out value)) result.Latitude = (double)(decimal)value;
                if (data.TryGetValue("lng", out value)) result.Longitude = (double)(decimal)value;

                return result;
            }
            return null;
        }

        /// <summary>
        /// Parses the specified pair.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static LatLng Parse(string point) {

            double lat = 0D;
            double lng = 0D;

            if (!string.IsNullOrEmpty(point)) {
                point = point.Trim('(', ')');
                string[] pair = point.Split(',');
                if (pair.Length >= 2) {
                    lat = JsUtil.ToDouble(pair[0]);
                    lng = JsUtil.ToDouble(pair[1]);
                }
            }

            return new LatLng(lat, lng);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.LatLng"/>.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator LatLng(string point) {
            return Parse(point);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the latitude in degrees.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude in degrees.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }

        #endregion

        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public LatLng() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        public LatLng(double lat, double lng) {
            Latitude = lat;
            Longitude = lng;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="source">The source.</param>
        public LatLng(LatLng source) {
            Latitude = source.Latitude;
            Longitude = source.Longitude;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            return new Dictionary<string, object> { { "lat", Latitude }, { "lng", Longitude } };
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return string.Format("{0},{1}",
                JsUtil.Encode(this.Latitude), JsUtil.Encode(this.Longitude));
        }
        #endregion
    }
}
