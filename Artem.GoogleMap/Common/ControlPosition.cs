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
        TopLeft = 0,            
        TopCenter,
        TopRight,
        BottomCenter,
        BottomLeft,
        BottomRight,
        LeftBottom,
        LeftCenter,
        LeftTop,
        RightBottom,
        RightCenter,
        RightTop
    }
}
