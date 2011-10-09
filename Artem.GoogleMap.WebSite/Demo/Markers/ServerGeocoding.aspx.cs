using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

namespace Artem.Google.Web.Demo.Markers {

    public partial class ServerGeocodingPage : System.Web.UI.Page {

        protected void HandleGeoLoaded(object sender, GoogleEventArgs e) {
        }


        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            if (!IsPostBack) {
                GoogleMarker marker = new GoogleMarker("sofia bulgaria");
                GoogleMap1.Markers.Add(marker);
            }
        }
    }
}