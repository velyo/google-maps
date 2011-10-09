using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Artem.Google.UI;

public partial class map_PostbackPersistence : Page {

    #region Methods /////////////////////////////////////////////////////////////////

    protected void HandleClick(object sender, EventArgs e) {
    }

    /// <summary>
    /// Handles the save click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleSaveClick(object sender, EventArgs e) {
        //Session["__View"] = ((int)GoogleMap1.DefaultMapView).ToString();
        Session["__Lat"] = GoogleMap1.Latitude.ToString();
        Session["__Lng"] = GoogleMap1.Longitude.ToString();
        Session["__Zoom"] = GoogleMap1.Zoom.ToString();
    }

    /// <summary>
    /// Handles the restore click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleRestoreClick(object sender, EventArgs e) {

        double lat, lng;
        int zoom, view;

        //if (Session["__View"] != null)
        //    if(int.TryParse(Convert.ToString(Session["__View"]), out view))
        //        GoogleMap1.DefaultMapView = (GoogleMapView)view;
        if (Session["__Lat"] != null)
            if (double.TryParse(Convert.ToString(Session["__Lat"]), out lat))
                GoogleMap1.Latitude = lat;
        if (Session["__Lng"] != null)
            if (double.TryParse(Convert.ToString(Session["__Lng"]), out lng))
                GoogleMap1.Longitude = lng;
        if (Session["__Zoom"] != null)
            if (int.TryParse(Convert.ToString(Session["__Zoom"]), out zoom))
                GoogleMap1.Zoom = zoom;
    }
    #endregion
}
