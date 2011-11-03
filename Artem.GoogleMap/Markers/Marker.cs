using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class Marker : MarkerOptions {

        #region Properties

        /// <summary>
        /// The address to geocode and set the initial marker position.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// The text content to show in marker's InfoWindow.
        /// </summary>
        /// <value>The info.</value>
        public string Info { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, object> ToScriptData() {

            var data = base.ToScriptData();
            if (this.Address != null) data["address"] = this.Address;
            if (this.Info != null) data["info"] = this.Info;
            return data;
        }
        #endregion
    }
}
