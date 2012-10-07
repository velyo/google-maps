using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_TestControl : System.Web.UI.UserControl {

    #region Methods

    /// <summary>
    /// Handles the show click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleShowClick(object sender, EventArgs e) {

        string point = txtPoint.Text;
        if (!string.IsNullOrEmpty(point)) {
            string[] pair = point.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (pair.Length == 2) {
                double lat, lng;

                if (double.TryParse(pair[0], out lat)) {
                    if (double.TryParse(pair[1], out lng)) {
                        GoogleMap1.Center.Latitude = lat;
                        GoogleMap1.Center.Longitude = lng;
                    }
                }
            }
        }
        else {
            string address = txtAddress.Text;
            if (!string.IsNullOrEmpty(address)) {
                GoogleMap1.Address = address;
            }
        }

        txtAddress.Text = null;
        txtPoint.Text = null;
    }
    #endregion

    #region Methods ///////////////////////////////////////////////////////////////////////////

    ///// <summary>
    ///// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
    ///// </summary>
    ///// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    //protected override void OnInit(EventArgs e) {
    //    base.OnInit(e);

    //    GoogleMap1.Markers[2].InfoContent.Controls.Add(new LiteralControl("Content from code behind."));
    //}

    ///// <summary>
    ///// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
    ///// </summary>
    ///// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    //protected override void OnLoad(EventArgs e) {
    //    base.OnLoad(e);
    //    if(this.IsPostBack){
    //        string address = GoogleMap1.Address;
    //    }
    //}
    #endregion
}