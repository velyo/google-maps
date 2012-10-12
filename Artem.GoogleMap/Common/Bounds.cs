using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// A LatLngBounds instance represents a rectangle in geographical coordinates, including one that crosses the 180 degrees longitudinal meridian.
    /// </summary>
    public class Bounds : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance of Bounds from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns>The new Bounds filled with the script data</returns>
        public static Bounds FromScriptData(object scriptObject) {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                var result = new Bounds();
                object value;

                if (data.TryGetValue("sw", out value))
                    result.SouthWest = LatLng.FromScriptData(value);
                if (data.TryGetValue("ne", out value))
                    result.NorthEast = LatLng.FromScriptData(value);

                return result;
            }
            return null;
        }

        /// <summary>
        /// Parses the specified bounds.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <returns></returns>
        public static Bounds Parse(string bounds) {

            double swlat = 0D;
            double swlng = 0D;
            double nelat = 0D;
            double nelng = 0D;

            if (!string.IsNullOrEmpty(bounds)) {
                bounds = bounds.Trim('(', ')');
                string[] pair = bounds.Split(':');
                if (pair.Length == 2) {
                    string[] p = pair[0].Split(',');
                    if (p.Length == 2) {
                        swlat = JsUtil.ToDouble(p[0]);
                        swlng = JsUtil.ToDouble(p[1]);
                    }

                    p = pair[1].Split(',');
                    if (p.Length == 2) {
                        nelat = JsUtil.ToDouble(p[0]);
                        nelng = JsUtil.ToDouble(p[1]);
                    }
                }
            }

            return new Bounds {
                SouthWest = new LatLng(swlat, swlng),
                NorthEast = new LatLng(nelat, nelng)
            };
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.UI.Bounds"/>.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Bounds(string bounds) {
            return Parse(bounds);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the south west point of bounds.
        /// </summary>
        /// <value>The south west.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLng SouthWest {
            get { return _southWest ?? (_southWest = new LatLng()); }
            set { _southWest = value; }
        }
        LatLng _southWest;

        /// <summary>
        /// Gets or sets the north east point of bounds.
        /// </summary>
        /// <value>The north east.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLng NorthEast {
            get { return _northEast ?? (_northEast = new LatLng()); }
            set { _northEast = value; }
        }
        LatLng _northEast;

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {

            var data = new Dictionary<string, object>();
            if (_northEast != null) data["ne"] = _northEast.ToScriptData();
            if (_southWest != null) data["sw"] = _southWest.ToScriptData();
            return data;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString() {
            return string.Format("{0},{1}:{2},{3}",
               JsUtil.Encode(this.SouthWest.Latitude), JsUtil.Encode(this.SouthWest.Longitude),
               JsUtil.Encode(this.NorthEast.Latitude), JsUtil.Encode(this.NorthEast.Longitude));
        }
        #endregion
    }
}
