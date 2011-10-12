using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Drawing;
using System.Runtime.Serialization;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GoogleCirclePolygon : GooglePolygon {

        #region Fields  /////////////////////////////////////////////////////////////////

        double _latitude;
        double _longitude;
        double _radius;

        #endregion

        #region Properties  /////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        [DataMember]
        public double Latitude {
            get { return _latitude; }
            set {
                if (_latitude != value) {
                    _latitude = value;
                    BuildPoints();
                }
            }
        }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        [DataMember]
        public double Longitude {
            get { return _longitude; }
            set {
                if (_longitude != value) {
                    _longitude = value;
                    BuildPoints();
                }
            }
        }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        [DataMember]
        public double Radius {
            get { return _radius; }
            set {
                if (_radius != value) {
                    _radius = value;
                    BuildPoints();
                }
            }
        }
        #endregion

        #region Construct  //////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public GoogleCirclePolygon() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        public GoogleCirclePolygon(double lat, double lng, int radius) {
            _latitude = lat;
            _longitude = lng;
            _radius = radius;
        }
        #endregion

        #region Methods /////////////////////////////////////////////////////////////////

        /// <summary>
        /// Builds the points.
        /// </summary>
        void BuildPoints() {

            bool canBuild = (Latitude !=0 && Longitude != 0 && Radius != 0);
            if (canBuild) {
                this.Points.Clear();
                double d2r = Math.PI / 180.0D; // degree to radian
                double r2d = 180.0D / Math.PI;
                double lat = ((double)Radius / 3963.0D) * r2d;
                double lng = lat / Math.Cos(Latitude * d2r);
                double theta, x, y;
                LatLng firstPoint = null;
                for (int i = 0; i < 33; i++) {
                    theta = (double)Math.PI * ((double)i / 16.0D);
                    x = Latitude + (lat * Math.Sin(theta));
                    y = Longitude + (lng * Math.Cos(theta));
                    if (firstPoint != null) {
                        this.Points.Add(new LatLng(x, y));
                    }
                    else {
                        this.Points.Add(firstPoint = new LatLng(x, y));
                    }
                }
                this.Points.Add(firstPoint);
            }
        }

        ///// <summary>
        ///// Toes the json string.
        ///// </summary>
        ///// <returns></returns>
        //public override string ToJsonString() {
        //    return JsonSerializer<GoogleCirclePolygon>.Serialize(this);
        //}
        #endregion
    }
}
