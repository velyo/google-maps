using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class ScaleControlOptions {

         #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Position id. Used to specify the position of the control on the map. 
        /// The default position is <c>BottomLeft</c>
        /// </summary>
        /// <value>The position.</value>
        public ControlPosition Position { get; set; }

        /// <summary>
        /// Style id. Used to select what style of navigation control to display.
        /// </summary>
        /// <value>The style.</value>
        public ScaleControlStyle ViewStyle { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationControlOptions"/> class.
        /// </summary>
        public ScaleControlOptions() {
            this.Position = ControlPosition.BottomLeft;
        }
        #endregion
    }
}
