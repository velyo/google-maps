using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Options for the rendering of the pan control. 
    /// </summary>
    public class OverviewMapControlOptions : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptValue">The script value.</param>
        /// <returns></returns>
        public static OverviewMapControlOptions FromScriptData(object scriptValue) {

            OverviewMapControlOptions options = null;
            var data = scriptValue as IDictionary<string, object>;
            if (data != null) {
                object value;
                options = new OverviewMapControlOptions();
                if (data.TryGetValue("opened", out value)) options.Opened = (bool)value;
            }
            return options;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Whether the control should display in opened mode or collapsed (minimized) mode. By default, the control is closed.
        /// </summary>
        /// <value><c>true</c> if opened; otherwise, <c>false</c>.</value>
        public bool Opened { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            return new Dictionary<string, object> { { "opened", this.Opened } };
        }
        #endregion
    }
}
