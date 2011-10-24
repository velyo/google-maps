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

        public string Info { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, object> ToScriptData() {

            var data = base.ToScriptData();
            if (this.Info != null) data["info"] = this.Info;
            return data;
        }
        #endregion
    }
}
