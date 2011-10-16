using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Options for the rendering of the Street View address control. 
    /// </summary>
    public class StreetViewAddressControlOptions {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Position id. This id is used to specify the position of the control on the map. 
        /// The default position is <c>TopLeft</c>.
        /// </summary>
        /// <value>The position.</value>
        public ControlPosition Position { get; set; }

        /// <summary>
        /// CSS styles to apply to the Street View address control. 
        /// For example, {backgroundColor: 'red'}.
        /// </summary>
        /// <value>The style.</value>
        public string ViewStyle { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="StreetViewAddressControlOptions"/> class.
        /// </summary>
        public StreetViewAddressControlOptions() {
            this.Position = ControlPosition.TopLeft;
        }
        #endregion
    }
}
