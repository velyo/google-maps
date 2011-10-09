using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

public partial class marker_InfoContent : System.Web.UI.Page {

    #region Methods ///////////////////////////////////////////////////////////////////////////

    protected void HandleMapDoubleClick(object sender, GoogleLocationEventArgs e) {

        GoogleMarker marker = new GoogleMarker(e.Location.Latitude, e.Location.Longitude);
        GoogleMap1.Markers.Add(marker);
    }

    protected override void OnPreRender(EventArgs e) {
        base.OnPreRender(e);

        foreach (GoogleMarker marker in GoogleMap1.Markers) {
            marker.InfoContent.Controls.Add(LoadControl("~/controls/TestInfoContent.ascx"));
        }
    }
    #endregion
}
