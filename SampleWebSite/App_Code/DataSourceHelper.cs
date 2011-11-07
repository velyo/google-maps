using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.ComponentModel;

namespace Artem.GoogleMap.WebSite {

    /// <summary>
    /// Summary description for DataSourceHelper
    /// </summary>
    [DataObject(true)]
    public class DataSourceHelper {

        #region Static Methods //////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the markers data.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static GoogleMarkerData[] GetMarkersData() {
            return new GoogleMarkerData[] {
                new GoogleMarkerData("sofia bulgaria", "Here is Sofia."),
                new GoogleMarkerData("athens greece", "Here is Athens"),
                new GoogleMarkerData("plovdiv", "Here is Plovdiv")
            };
        }

        /// <summary>
        /// Gets the map data.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static GoogleMapData GetMapData() {
            return new GoogleMapData(42.1229, 24.7879, 8);
        }
        #endregion
    }

    public struct GoogleMarkerData {

        string _address;
        string _description;

        public string Address {
            get { return _address; }
            set { _address = value; }
        }

        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMarkerData"/> struct.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="description">The description.</param>
        public GoogleMarkerData(string address, string description) {
            _address = address;
            _description = description;
        }
    }

    public struct GoogleMapData {

        public double _latitude;
        public double _longitude;
        public int _zoom;

        public double Latitude {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public double Longitude {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public int Zoom {
            get { return _zoom; }
            set { _zoom = value; }
        }

        public GoogleMapData(double latitude, double longitude, int zoom) {
            _latitude = latitude;
            _longitude = longitude;
            _zoom = zoom;
        }
    }
}