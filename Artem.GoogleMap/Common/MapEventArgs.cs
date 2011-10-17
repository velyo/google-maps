using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    public class MapEventArgs : EventArgs, IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static MapEventArgs FromScriptData(object scriptObject) {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                var args = new MapEventArgs();
                object value;

                if (data.TryGetValue("bounds", out value)) args.Bounds = Bounds.FromScriptData(value);
                if (data.TryGetValue("center", out value)) args.Center = LatLng.FromScriptData(value);
                if (data.TryGetValue("mapType", out value)) {
                    string name = value as string;
                    if (name != null) {
                        MapType type;
                        if (Enum.TryParse<MapType>(name, true, out type)) args.MapType = type;
                    }
                }
                if (data.TryGetValue("zoom", out value)) args.Zoom = (int)value;

                return args;
            }
            return null;
        }
        #endregion

        #region Properties

        public Bounds Bounds { get; protected set; }
        public LatLng Center { get; protected set; }
        public MapType MapType { get; protected set; }
        public int Zoom { get; protected set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {

            var data = new Dictionary<string, object>();

            if (this.Bounds != null) data["bounds"] = this.Bounds.ToScriptData();
            if (this.Center != null) data["center"] = this.Center.ToScriptData();
            data["mapType"] = this.MapType;
            data["zoom"] = this.Zoom;

            return data;
        }
        #endregion
    }
}
