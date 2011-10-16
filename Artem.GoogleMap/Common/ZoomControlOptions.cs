using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Identifiers for the zoom control.
    /// </summary>
    public enum ZoomControlStyle {
        /// <summary>
        /// The default zoom control. 
        /// The control which DEFAULT maps to will vary according to map size and other factors. 
        /// It may change in future versions of the API.
        /// </summary>
        Default,
        /// <summary>
        /// The larger control, with the zoom slider in addition to +/- buttons.
        /// </summary>
        Large,
        /// <summary>
        /// A small control with buttons to zoom in and out.
        /// </summary>
        Small
    }

    /// <summary>
    /// Options for the rendering of the zoom control. 
    /// </summary>
    public class ZoomControlOptions : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static ZoomControlOptions FromScriptData(object scriptObject) {

            ZoomControlOptions options = null;
            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                object value;
                options = new ZoomControlOptions();
                if (data.TryGetValue("position", out value)) options.Position = (ControlPosition)value;
                if (data.TryGetValue("style", out value)) options.Style = (ZoomControlStyle)value;
            }
            return options;
        }
        #endregion

        #region Properties

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

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            return new Dictionary<string, object> { { "position", this.Position }, { "style", this.Style } };
        }
        #endregion
    }
}
