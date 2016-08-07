using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

public partial class markers_OnlyOneInfoWindow : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        var map = new GoogleMap(new LatLng(42.1229, 24.7879), 6);
        map.ID = "GoogleMap1";
        map.EnableScrollWheelZoom = true;
        map.DisableMultipleInfoWindows = true;
        map.CssClass = "map";
        map.Markers.Add(new Marker { Position = new LatLng(42.1229, 24.7879), Info = "<a href='http://www.google.com'>Google.com</a>" });
        map.Markers.Add(new Marker { Position = new LatLng(42.7, 23.3), Info = "<a href='http://www.microsoft.com'>Microsoft.com</a>" });
        this.pnlControls.Controls.Add(map);
    }
}