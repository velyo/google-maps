using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Location {

        #region Static Methods

        /// <summary>
        /// Parses the specified pair.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static Location Parse(string point) {

            //double lat = 0D;
            //double lng = 0D;

            //if (!string.IsNullOrEmpty(point)) {
            //    point = point.Trim('(', ')');
            //    string[] pair = point.Split(',');
            //    if (pair.Length >= 2) {
            //        lat = JsUtil.ToDouble(pair[0]);
            //        lng = JsUtil.ToDouble(pair[1]);
            //    }
            //}

            return new Location(point);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        /// <value>The point.</value>
        public LatLng Point { get; set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value {
            get {
                return (object)this.Point ?? (object)this.Address;
            }
        }
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public Location() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public Location(string address) {
            this.Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        public Location(double lat, double lng) {
            this.Point = new LatLng(lat, lng);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="point">The point.</param>
        public Location(LatLng point) {
            this.Point = point;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="source">The source.</param>
        public Location(Location source) {
            this.Address = source.Address;
            this.Point = source.Point;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {

            return (this.Point != null)
                ? string.Format("{0},{1}", JsUtil.Encode(this.Point.Latitude), JsUtil.Encode(this.Point.Longitude))
                : this.Address;
        }
        #endregion
    }
}
