using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {
    
    /// <summary>
    /// 
    /// </summary>
    public class LatLng {

        #region Static Methods ////////////////////////////////////////////////////////////////////

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

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        private double _latitude;
        private double _longitude;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude {
            get { return _latitude; }
            set { _latitude = value; }
        }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude {
            get { return _longitude; }
            set { _longitude = value; }
        }
        #endregion

        #region Construct  ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePoint"/> class.
        /// </summary>
        public LatLng() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePoint"/> struct.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        public LatLng(double lat, double lng) {
            _latitude = lat;
            _longitude = lng;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePoint"/> struct.
        /// </summary>
        /// <param name="source">The source.</param>
        public LatLng(LatLng source) {
            _latitude = source.Latitude;
            _longitude = source.Longitude;
        }
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

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
