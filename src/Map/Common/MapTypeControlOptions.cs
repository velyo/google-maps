using System.Collections.Generic;

namespace Velyo.Google.Map.UI
{
    /// <summary>
    /// Options for the rendering of the map type control. 
    /// </summary>
    public class MapTypeControlOptions : IScriptDataConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapTypeControlOptions"/> class.
        /// </summary>
        public MapTypeControlOptions()
        {
            Position = ControlPosition.TopRight;
        }


        /// <summary>
        /// IDs of map types to show in the control.
        /// </summary>
        /// <value>The map types.</value>
        public MapType[] MapTypes { get; set; }

        /// <summary>
        /// Position id. Used to specify the position of the control on the map. 
        /// The default position is <c>TopRight</c>.
        /// </summary>
        /// <value>The position.</value>
        public ControlPosition Position { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public MapTypeControlStyle ViewStyle { get; set; }


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The value.</param>
        /// <returns></returns>
        public static MapTypeControlOptions FromScriptData(object scriptObject)
        {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                MapTypeControlOptions options = new MapTypeControlOptions();
                object value;

                if (data.TryGetValue("mapTypeIds", out value)) options.MapTypes = (MapType[])value;
                if (data.TryGetValue("position", out value)) options.Position = (ControlPosition)value;
                if (data.TryGetValue("style", out value)) options.ViewStyle = (MapTypeControlStyle)value;

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

            var data = new Dictionary<string, object>
            {
                {"position", Position},
                {"style", ViewStyle}
            };
            if (MapTypes != null) data["mapTypeIds"] = MapTypes;
            return data;
        }
    }
}
