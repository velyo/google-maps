using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Options for the rendering of the map type control. 
    /// </summary>
    public class MapTypeControlOptions : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The value.</param>
        /// <returns></returns>
        public static MapTypeControlOptions FromScriptData(object scriptObject) {
            
            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                MapTypeControlOptions options = new MapTypeControlOptions();
                object value;

                if (data.TryGetValue("mapTypeIds", out value)) options.MapTypes = (MapType[])value;
                if (data.TryGetValue("position", out value)) options.Position = (ControlPosition)value;
                if (data.TryGetValue("style", out value)) options.ViewStyle = (MapTypeControlStyle)value;

                return options;
            }
            return null;
        }
        #endregion

        #region Properties

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

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MapTypeControlOptions"/> class.
        /// </summary>
        public MapTypeControlOptions() {
            this.Position = ControlPosition.TopRight;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {

            var data = new Dictionary<string, object>{ 
                {"position", this.Position},
                {"style", this.ViewStyle}
            };
            if (this.MapTypes != null) data["mapTypeIds"] = this.MapTypes;
            return data;
        }
        #endregion
    }
}
