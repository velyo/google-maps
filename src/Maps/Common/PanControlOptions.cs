using System.Collections.Generic;

namespace Velyo.Google.Maps
{
    /// <summary>
    /// Options for the rendering of the pan control. 
    /// </summary>
    public class PanControlOptions : IScriptDataConverter
    {
        /// <summary>
        /// Position id. Used to specify the position of the control on the map. The default position is TOP_LEFT.
        /// </summary>
        /// <value>The position.</value>
        public ControlPosition Position { get; set; }


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static PanControlOptions FromScriptData(object scriptObject)
        {
            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                var options = new PanControlOptions();
                object value;
                if (data.TryGetValue("position", out value)) options.Position = (ControlPosition)value;
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
            return new Dictionary<string, object> { { "position", this.Position } };
        }
    }
}
