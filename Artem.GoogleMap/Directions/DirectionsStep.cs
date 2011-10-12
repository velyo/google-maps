using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {
    
    public class DirectionsStep {

        #region Fields

        public GoogleDistance distance;
        public GoogleDuration duration;
        public LatLng end_location;
        public string instructions;
        public LatLng start_location;

        #endregion
    }
}
