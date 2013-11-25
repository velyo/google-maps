using System.Collections.Generic;

namespace Artem.Google.UI
{
    /// <summary>
    /// Options for the rendering of the search box control. 
    /// </summary>
    public class SearchBoxControlOptions : IScriptDataConverter {

        private ControlPosition _position = ControlPosition.TopLeft;
        private string _style = "margin-top: 6px; border: 1px solid transparent; border-radius: 2px 0 0 2px; box-sizing: border-box; -moz-box-sizing: border-box; height: 32px; outline: none; box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3); background-color: #fff; padding: 0 11px 0 13px; width: 200px; font-family: Roboto; font-size: 15px; font-weight: 300; text-overflow: ellipsis;";
        private string _text = "Search";

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static SearchBoxControlOptions FromScriptData(object scriptObject)
        {
            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                object value;
                var options = new SearchBoxControlOptions();

                if (data.TryGetValue("position", out value)) options.Position = (ControlPosition)value;
                if (data.TryGetValue("style", out value)) options.Style = (string)value;
                if (data.TryGetValue("text", out value)) options.Text = (string)value;

                return options;
            }
            return null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Position id. Used to specify the position of the control on the map. The default position is TOP_LEFT.
        /// </summary>
        /// <value>The position.</value>
        public ControlPosition Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// The style used in the search control
        /// </summary>
        /// <value>The style.</value>
        public string Style
        {
            get { return _style; }
            set { _style = value; }
        }

        /// <summary>
        /// The text used as placeholder
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            return new Dictionary<string, object> { { "position", this.Position }, { "style", this.Style }, { "text", this.Text } };
        }
        #endregion
    }
}