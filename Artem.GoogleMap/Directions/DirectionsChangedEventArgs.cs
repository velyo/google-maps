using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    public class DirectionsChangedEventArgs : EventArgs {

        #region Static Methods

        public static readonly DirectionsChangedEventArgs Empty = new DirectionsChangedEventArgs();

        #endregion

        #region Properties

        public Distance distance;
        public Duration duration;
        public string end_address;
        public LatLng end_location;
        public string start_address;
        public LatLng start_location;
        public DirectionsStep[] steps;

        #endregion
    }
}
