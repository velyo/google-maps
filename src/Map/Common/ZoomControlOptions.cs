using System.Collections.Generic;

namespace Velyo.Google.Map.UI
{
    /// <summary>
    /// Options for the rendering of the zoom control. 
    /// </summary>
    public class ZoomControlOptions : IScriptDataConverter
    {
        /// <summary>
        /// Position id. Used to specify the position of the control on the map. The default position is TOP_LEFT.
        /// </summary>
        /// <value>The position.</value>
        public ControlPosition Position { get; set; }

        /// <summary>
        /// Style id. Used to select what style of zoom control to display.
        /// </summary>
        /// <value>The style.</value>
        public ZoomControlStyle Style { get; set; }


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static ZoomControlOptions FromScriptData(object scriptObject)
        {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                object value;
                var options = new ZoomControlOptions();

                if (data.TryGetValue("position", out value)) options.Position = (ControlPosition)value;
                if (data.TryGetValue("style", out value)) options.Style = (ZoomControlStyle)value;

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
            return new Dictionary<string, object> { { "position", this.Position }, { "style", this.Style } };
        }
    }
}
