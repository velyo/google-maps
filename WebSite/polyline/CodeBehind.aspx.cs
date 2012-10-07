using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

namespace Artem.GoogleMap.WebSite.Polylines {

    public partial class CodeBehind : System.Web.UI.Page {

        #region Methods

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            GoogleMap1.Polylines.Add(new GooglePolyline {
                Clickable = true,
                OnClientClick = "handleClick",
                StrokeWeight = 10,
                Path = new List<LatLng>{
                    new LatLng(42.14304, 24.74967),
                    new LatLng(42.69649, 23.32601)
                }
            });
        }
        #endregion
    }
}