using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Artem.Google.UI;

public partial class polygon_GoogleCirclePolygon : Page {

    #region Methods /////////////////////////////////////////////////////////////////

    protected void HandleDrawClick(object sender, EventArgs e) {

        GoogleLocation location = GoogleLocation.Parse(_txtPoint.Text);
        int radius;
        if (int.TryParse(_txtRadius.Text, out radius)) {
            GoogleMap1.Polygons.Clear();
            GoogleCirclePolygon pg = new GoogleCirclePolygon();
            pg.FillColor = Color.Blue;
            pg.FillOpacity = .5F;
            pg.StrokeColor = Color.FromArgb(0x0000080);
            pg.StrokeOpacity = .75F;
            pg.StrokeWeight = 2;
            pg.Latitude = location.Latitude;
            pg.Longitude = location.Longitude;
            pg.Radius = radius;
            //
            GoogleMap1.Latitude = location.Latitude;
            GoogleMap1.Longitude = location.Longitude;
            GoogleMap1.Polygons.Add(pg);
        }
    } 
    #endregion
}
