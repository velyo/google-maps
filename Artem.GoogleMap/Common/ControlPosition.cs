using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Identifiers used to specify the placement of controls on the map. 
    /// Controls are positioned relative to other controls in the same layout position. 
    /// Controls that are added first are positioned closer to the edge of the map. 
    /// +----------------+ 
    /// + TL    TC    TR + 
    /// + LT          RT + 
    /// +                + 
    /// + LC          RC + 
    /// +                + 
    /// + LB          RB + 
    /// + BL    BC    BR + 
    /// +----------------+ 
    /// Elements in the top or bottom row flow towards the middle. Elements at the left or right sides flow downwards.
    /// </summary>
    public enum ControlPosition {
        /// <summary>
        /// Represents the top left position.
        /// </summary>
        TopLeft = 1,
        /// <summary>
        /// Represents the top center position.
        /// </summary>
        TopCenter = 2,
        /// <summary>
        /// Represents the top right position.
        /// </summary>
        TopRight = 3,
        /// <summary>
        /// Represents the bottom center position.
        /// </summary>
        BottomCenter = 11,
        /// <summary>
        /// Represents the bottom left position.
        /// </summary>
        BottomLeft = 10,
        /// <summary>
        /// Represents the bottom right position.
        /// </summary>
        BottomRight = 12,
        /// <summary>
        /// Represents the left bottom position.
        /// </summary>
        LeftBottom = 6,
        /// <summary>
        /// Represents the left center position.
        /// </summary>
        LeftCenter = 4,
        /// <summary>
        /// Represents the left top position.
        /// </summary>
        LeftTop = 5,
        /// <summary>
        /// Represents the right bottom position.
        /// </summary>
        RightBottom = 9,
        /// <summary>
        /// Represents the right center position.
        /// </summary>
        RightCenter = 8,
        /// <summary>
        /// Represents the right top position.
        /// </summary>
        RightTop = 7,
        /// <summary>
        /// Represents the center position.
        /// </summary>
        Center = 13
    }
}
