using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// Displays the panorama for a given LatLng or panorama ID. 
    /// A StreetViewPanorama object provides a Street View "viewer" 
    /// which can be stand-alone within a separate &lt;div&gt; or bound to a Map. 
    /// </summary>
    public class StreetViewPanorama : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance of GoogleStreetViewPanorama from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static GoogleStreetViewPanorama FromScriptData(object scriptObject) {

            GoogleStreetViewPanorama pano = null;
            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                //object value;
                pano = new GoogleStreetViewPanorama();
                // TODO
            }
            return pano;
        }
        #endregion

        #region Properties

        /// <summary>
        /// The display options for the address control.
        /// </summary>
        /// <value>The address control options.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public StreetViewAddressControlOptions AddressControlOptions { get; set; }

        /// <summary>
        /// The enabled/disabled state of the address control.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enable address control]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableAddressControl { get; set; }

        /// <summary>
        /// If true, the close button is displayed. Disabled by default.
        /// </summary>
        /// <value><c>true</c> if [enable close button]; otherwise, <c>false</c>.</value>
        public bool EnableCloseButton { get; set; }

        /// <summary>
        /// The enabled/disabled state of the links control.
        /// </summary>
        /// <value><c>true</c> if [enable link control]; otherwise, <c>false</c>.</value>
        public bool EnableLinksControl { get; set; }

        /// <summary>
        /// The enabled/disabled state of the navigation control.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enable navigation control]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableNavigationControl { get; set; }

        /// <summary>
        /// The display options for the navigation control.
        /// </summary>
        /// <value>The navigation control options.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public NavigationControlOptions NavigationControlOptions { get; set; }

        /// <summary>
        /// The panorama ID, which should be set when specifying a custom panorama.
        /// </summary>
        /// <value>The pano.</value>
        public string Pano { get; set; }

        // TODO
        //public string PanoProvider { get; set; }

        /// <summary>
        /// The LatLng position of the Street View panorama.
        /// </summary>
        /// <value>The position.</value>
        public LatLng Position { get; set; }

        /// <summary>
        /// The camera orientation, specified as heading, pitch, and zoom, for the panorama.
        /// </summary>
        /// <value>The pov.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public StreetViewPov Pov { get; set; }

        /// <summary>
        /// If true, the Street View panorama is visible on load.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="StreetViewPanorama"/> class.
        /// </summary>
        public StreetViewPanorama() {
            this.EnableAddressControl = true;
            this.EnableCloseButton = false;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            throw new NotImplementedException();
        }
        #endregion
    }
}
