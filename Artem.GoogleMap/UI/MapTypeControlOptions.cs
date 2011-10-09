using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    public class MapTypeControlOptions {

        #region Properties  ///////////////////////////////////////////////////////////////////////


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

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="MapTypeControlOptions"/> class.
        /// </summary>
        public MapTypeControlOptions() {
            this.Position = ControlPosition.TopRight;
        }
        #endregion
    }
}
