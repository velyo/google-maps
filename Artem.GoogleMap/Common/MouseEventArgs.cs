using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    public class MouseEventArgs : EventArgs, IScriptDataConverter {

        #region Static Fields

        public static readonly MouseEventArgs Empty = new MouseEventArgs();

        #endregion

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static MouseEventArgs FromScriptData(IDictionary<string, object> data) {
            return new MouseEventArgs(LatLng.FromScriptData(data));
        }
        #endregion

        #region Properties

        public LatLng LatLng { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        /// <param name="latlng">The latlng.</param>
        public MouseEventArgs(LatLng latlng) {
            this.LatLng = latlng;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        public MouseEventArgs(double lat, double lng)
            : this(new LatLng(lat, lng)) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        public MouseEventArgs()
            : this(null) {
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            return this.LatLng.ToScriptData();
        }
        #endregion
    }
}
