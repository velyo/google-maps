using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

namespace Artem.GoogleMap.WebSite.Markers {

    public partial class CodeBehind : System.Web.UI.Page {

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            GoogleMap1.Markers.Add(new Marker { Position = new LatLng(42.1229, 24.7879) });
            GoogleMap1.Markers.Add(new Marker { Position = new LatLng(42.7, 23.3) });
        }
    }
}