using System.Collections.Generic;

namespace Velyo.Google.Maps
{
    /// <summary>
    /// Options for the rendering of the pan control. 
    /// </summary>
    public class OverviewMapControlOptions : IScriptDataConverter
    {
        /// <summary>
        /// Whether the control should display in opened mode or collapsed (minimized) mode. By default, the control is closed.
        /// </summary>
        /// <value><c>true</c> if opened; otherwise, <c>false</c>.</value>
        public bool Opened { get; set; }


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script value.</param>
        /// <returns></returns>
        public static OverviewMapControlOptions FromScriptData(object scriptObject)
        {
            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                var options = new OverviewMapControlOptions();
                object value;
                if (data.TryGetValue("opened", out value)) options.Opened = (bool)value;
                return options;
            }
            return null;
        }

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            return new Dictionary<string, object> { { "opened", this.Opened } };
        }
    }
}
