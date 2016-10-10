using System;
using System.Collections.Generic;

namespace Velyo.Google.Maps
{
    /// <summary>
    /// Class for containing marker event data.
    /// </summary>
    public class MarkerEventArgs : EventArgs, IScriptDataConverter
    {
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


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static MarkerEventArgs FromScriptData(object scriptObject)
        {
            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                var args = new MarkerEventArgs();
                object value;
                if (data.TryGetValue("index", out value)) args.Index = (int)value;
                if (data.TryGetValue("position", out value)) args.Position = LatLng.FromScriptData(value);
                return args;
            }
            return null;
        }

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            var data = new Dictionary<string, object>();
            if (Index.HasValue) data["index"] = Index.Value;
            if (Position != null) data["position"] = Position.ToScriptData();
            return data;
        }
    }
}
