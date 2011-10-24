using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Animations that can be played on a marker. Use the setAnimation method on Marker or the animation option to play an animation.
    /// </summary>
    public enum MarkerAnimation {
        /// <summary>
        /// Marker bounces until animation is stopped.
        /// </summary>
        Bounce = 1,
        /// <summary>
        /// Marker falls from the top of the map ending with a small bounce.
        /// </summary>
        Drop = 2
    }
}
