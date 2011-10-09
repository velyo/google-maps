using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class map_Dynamic : System.Web.UI.Page {

    #region Methods ///////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e) {

        string key = ConfigurationManager.AppSettings["GoogleMapKey"];
        double latitude = 42.1229;
        double longitude = 24.7879;

        Artem.Google.UI.GoogleMap map = new Artem.Google.UI.GoogleMap();
        map.ID = "googleMap";
        map.Key = key;
        map.Latitude = latitude;
        map.Longitude = longitude;
        map.Height = new Unit("250px");
        map.Width = new Unit("250px");
        map.Zoom = 9;
        phMap.Controls.Add(map);
    } 
    #endregion
}
