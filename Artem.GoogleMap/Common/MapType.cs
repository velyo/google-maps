using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Identifiers for common MapTypes.
    /// </summary>
    public enum MapType {
        /// <summary>
        /// This map type displays a transparent layer of major streets on satellite images.
        /// </summary>
        Hybrid,
        /// <summary>
        /// This map type displays a normal street map.
        /// </summary>
        Roadmap,
        /// <summary>
        /// This map type displays satellite images.
        /// </summary>
        Satellite,
        /// <summary>
        /// This map type displays maps with physical features such as terrain and vegetation.
        /// </summary>
        Terrain
    }
}
