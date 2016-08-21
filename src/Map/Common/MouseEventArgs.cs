using System;
using System.Collections.Generic;

namespace Velyo.Google.Map.UI
{
    /// <summary>
    /// Class for containing mouse event data.
    /// </summary>
    public class MouseEventArgs : EventArgs, IScriptDataConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        /// <param name="latlng">The latlng.</param>
        public MouseEventArgs(LatLng latlng)
        {
            Position = latlng;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        public MouseEventArgs(double lat, double lng) : this(new LatLng(lat, lng)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseEventArgs"/> class.
        /// </summary>
        public MouseEventArgs() : this(null) { }


        /// <summary>
        /// Gets the mouse position.
        /// </summary>
        /// <value>The position.</value>
        public LatLng Position { get; protected set; }


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static MouseEventArgs FromScriptData(object scriptObject)
        {
            return new MouseEventArgs(LatLng.FromScriptData(scriptObject));
        }

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            return Position.ToScriptData();
        }
    }
}
