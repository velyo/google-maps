using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace Artem.Google.Web.Demo.Markers {

    public partial class MarkerManagerPage : System.Web.UI.Page {

        //#region Static Fields /////////////////////////////////////////////////////////////////////

        //static readonly string[] Images = { "sun", "rain", "snow", "storm" };

        //#endregion

        //#region Methods ///////////////////////////////////////////////////////////////////////////

        ///// <summary>
        ///// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
        ///// </summary>
        ///// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        //protected override void OnLoad(EventArgs e) {
        //    base.OnLoad(e);

        //    if (!this.IsPostBack)
        //        this.SetupWeatherMarkers(200);
        //}

        ///// <summary>
        ///// Setups the weather markers.
        ///// </summary>
        ///// <param name="count">The count.</param>
        //private void SetupWeatherMarkers(int count) {

        //    for (int i = 0; i < count; i++) {
        //        GoogleMap1.Markers.Add(this.GenMarker());
        //        Thread.Sleep(10);
        //    }
        //}

        ///// <summary>
        ///// Gens the marker.
        ///// </summary>
        ///// <returns></returns>
        //private GoogleMarker GenMarker() {

        //    GoogleMarker marker = new GoogleMarker();
        //    Random r = new Random();

        //    marker.Latitude = 48.25 + (r.NextDouble() - 0.5) * 14.5;
        //    marker.Longitude = 11.00 + (r.NextDouble() - 0.5) * 36.0;
        //    marker.Draggable = true;

        //    int i = r.Next(0, Images.Length);
        //    string iconName = Images[i];

        //    marker.IconAnchor = new GooglePoint(16, 16);
        //    marker.IconSize = new GoogleSize(32, 32);
        //    marker.IconUrl = string.Format("/images/marker-manager/{0}.png", iconName);
        //    marker.ShadowSize = new GoogleSize(59, 32);
        //    marker.ShadowUrl = string.Format("/images/marker-manager/{0}-shadow.png", iconName);

        //    return marker;
        //}
        //#endregion
    }
}