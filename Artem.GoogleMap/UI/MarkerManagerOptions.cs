using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class MarkerManagerOptions {//: IJsonObject {

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        double? _borderPadding;
        double? _maxZoom;
        bool? _trackMarkers;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Specifies, in pixels, the extra padding outside the map's current viewport monitored by a manager. 
        /// Markers that fall within this padding are added to the map, even if they are not fully visible.
        /// </summary>
        /// <value>The border padding.</value>
        [DataMember]
        public double? borderPadding {
            get { return _borderPadding; }
            set { _borderPadding = value; }
        }

        /// <summary>
        /// Sets the maximum zoom level monitored by a marker manager. 
        /// If not given, the manager assumes the maximum map zoom level. 
        /// This value is also used when markers are added to the manager without the optional maxZoom parameter.
        /// </summary>
        /// <value>The max zoom.</value>
        [DataMember]
        public double? maxZoom {
            get { return _maxZoom; }
            set { _maxZoom = value; }
        }

        /// <summary>
        /// Indicates whether or not a marker manager should track markers' movements. 
        /// If you wish to move managed markers using the setPoint/setLatLng methods, this option should be set to true. 
        /// The default value is false.
        /// </summary>
        /// <value><c>true</c> if [track markers]; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool? trackMarkers {
            get { return _trackMarkers; }
            set { _trackMarkers = value; }
        }
        #endregion
    }
}
