using System.Collections.Generic;

namespace Velyo.Google.Maps
{
    /// <summary>
    /// 
    /// </summary>
    public class Marker : MarkerOptions
    {
        /// <summary>
        /// The address to geocode and set the initial marker position.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? AutoOpen { get; set; }

        /// <summary>
        /// The text content to show in marker's InfoWindow.
        /// </summary>
        /// <value>The info.</value>
        public string Info { get; set; }


        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, object> ToScriptData()
        {
            var data = base.ToScriptData();
            if (Address != null) data["address"] = Address;
            if (AutoOpen.HasValue) data["autoOpen"] = AutoOpen.Value;
            if (Info != null) data["info"] = Info;
            return data;
        }
    }
}
