    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Class for containing mouse event data.
    /// </summary>
    public class MouseEventArgs : EventArgs, IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static MouseEventArgs FromScriptData(object scriptObject) {
            return new MouseEventArgs(LatLng.FromScriptData(scriptObject));
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the mouse position.
        /// </summary>
        /// <value>The position.</value>
        public LatLng Position { get; protected set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        /// <param name="latlng">The latlng.</param>
        public MouseEventArgs(LatLng latlng) {
            this.Position = latlng;
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
            return this.Position.ToScriptData();
        }
        #endregion
    }
}
