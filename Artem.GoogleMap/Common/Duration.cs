using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// A representation of duration as a numeric value and a display string.
    /// </summary>
    public class Duration : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static Duration FromScriptData(object scriptObject) {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                var duration = new Duration();
                object value;

                if (data.TryGetValue("text", out value)) duration.Text = (string)value;
                if (data.TryGetValue("value", out value)) duration.Value = (int)value;

                return duration;
            }
            return null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// A string representation of the duration value.
        /// </summary>
        public string Text;

        /// <summary>
        /// The duration in seconds.
        /// </summary>
        public int Value;

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            return new Dictionary<string, object> { { "text", Text }, { "value", Value } };
        }
        #endregion
    }
}
