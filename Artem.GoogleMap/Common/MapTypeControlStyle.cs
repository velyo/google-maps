using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Identifiers for common MapTypesControls.
    /// </summary>
    public enum MapTypeControlStyle {
        /// <summary>
        /// Uses the default map type control. 
        /// The control which DEFAULT maps to will vary according to window size and other factors. 
        /// It may change in future versions of the API.
        /// </summary>
        Default,
        /// <summary>
        /// A dropdown menu for the screen realestate conscious.
        /// </summary>
        DropdownMenu,
        /// <summary>
        /// The standard horizontal radio buttons bar.
        /// </summary>
        HorizontalBar
    }
}
