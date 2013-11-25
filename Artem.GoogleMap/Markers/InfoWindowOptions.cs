using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// The options for the markers' info window.
    /// </summary>
    public class InfoWindowOptions : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static InfoWindowOptions FromScriptData(object scriptObject) {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                var options = new InfoWindowOptions();
                object value;

                if (data.TryGetValue("disableAutoPan", out value)) options.DisableAutoPan = (bool)value;
                if (data.TryGetValue("maxWidth", out value)) options.MaxWidth = (int)value;
                if (data.TryGetValue("pixelOffset", out value)) options.PixelOffset = Size.FromScriptData(value);
                if (data.TryGetValue("position", out value)) options.Position = LatLng.FromScriptData(value);
                if (data.TryGetValue("zIndex", out value)) options.ZIndex = (int)value;

                return options;
            }
            return null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Disable auto-pan on open. 
        /// By default, the info window will pan the map so that it is fully visible when it opens.
        /// </summary>
        /// <value><c>true</c> if [disable auto pan]; otherwise, <c>false</c>.</value>
        public bool? DisableAutoPan { get; set; }

        /// <summary>
        /// Maximum width of the infowindow, regardless of content's width. 
        /// </summary>
        /// <value>The width of the max.</value>
        public int? MaxWidth { get; set; }

        /// <summary>
        /// The offset, in pixels, of the tip of the info window from the point on the map at whose geographical 
        /// coordinates the info window is anchored. If an InfoWindow is opened with an anchor, the pixelOffset 
        /// will be calculated from the top-center of the anchor's bounds.
        /// </summary>
        /// <value>The pixel offset.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Size PixelOffset {
            get { return _pixelOffset ?? (_pixelOffset = new Size()); }
            set { _pixelOffset = value; }
        }
        Size _pixelOffset;

        /// <summary>
        /// The LatLng at which to display this InfoWindow. 
        /// If the InfoWindow is opened with an anchor, the anchor's position will be used instead.
        /// </summary>
        /// <value>The position.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLng Position {
            get { return _position ?? (_position = new LatLng()); }
            set { _position = value; }
        }
        LatLng _position;

        /// <summary>
        /// All InfoWindows are displayed on the map in order of their zIndex, with higher values displaying 
        /// in front of InfoWindows with lower values. 
        /// By default, InfoWinodws are displayed according to their latitude, with InfoWindows of lower 
        /// latitudes appearing in front of InfoWindows at higher latitudes. 
        /// InfoWindows are always displayed in front of markers.
        /// </summary>
        /// <value>The index of the Z.</value>
        public int? ZIndex { get; set; }
      

        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {

            var data = new Dictionary<string, object>();

            if (this.DisableAutoPan.HasValue) data["disableAutoPan"] = this.DisableAutoPan.Value;
            if (this.MaxWidth.HasValue) data["maxWidth"] = this.MaxWidth.Value;
            if (_pixelOffset != null) data["pixelOffset"] = _pixelOffset.ToScriptData();
            if (_position != null) data["position"] = _position.ToScriptData();
            if (this.ZIndex.HasValue) data["zIndex"] = this.ZIndex.Value;

            return data;
        }
        #endregion
    }
}
