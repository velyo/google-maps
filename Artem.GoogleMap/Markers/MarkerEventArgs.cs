using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Class for containing marker event data.
    /// </summary>
    public class MarkerEventArgs : EventArgs, IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static MarkerEventArgs FromScriptData(object scriptObject) {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                var args = new MarkerEventArgs();
                object value;
                if (data.TryGetValue("index", out value)) args.Index = (int)value;
                if (data.TryGetValue("position", out value)) args.Position = LatLng.FromScriptData(value);
                return args;
            }
            return null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the marker index.
        /// </summary>
        /// <value>The index.</value>
        public int? Index { get; private set; }

        /// <summary>
        /// Gets the marker position.
        /// </summary>
        /// <value>The position.</value>
        public LatLng Position { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            var data = new Dictionary<string, object>();
            if (this.Index.HasValue) data["index"] = this.Index.Value;
            if (this.Position != null) data["position"] = this.Position.ToScriptData();
            return data;
        }
        #endregion
    }
}
