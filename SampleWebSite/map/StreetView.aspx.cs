using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

public partial class map_StreetView : Page {

    #region Methods ///////////////////////////////////////////////////////////////////////////

    ///// <summary>
    ///// Handles the street mode changed.
    ///// </summary>
    ///// <param name="sender">The sender.</param>
    ///// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    //protected void HandleStreetModeChanged(object sender, EventArgs e) {
    //}

    ///// <summary>
    ///// Handles the street view changed.
    ///// </summary>
    ///// <param name="sender">The sender.</param>
    ///// <param name="?">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    //protected void HandleStreetViewChanged(object sender, EventArgs e) {

    //    CheckBox chk = sender as CheckBox;
    //    if (chk != null) {
    //        GoogleMap1.IsStreetView = chk.Checked;
    //    }
    //}

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    protected override void OnPreRender(EventArgs e) {
        base.OnPreRender(e);

        bool flag = chkStreetView.Checked;
        //GoogleMap1.IsStreetView = flag;
        ddlStreetViewMode.Visible = flag;
        chkExternal.Visible = false;
        ltrInfo.Visible = false;

        //if (flag) {
        //    GoogleMap1.StreetViewMode = (StreetViewMode)Enum.Parse(typeof(StreetViewMode), ddlStreetViewMode.SelectedValue);
        //    if (GoogleMap1.StreetViewMode == StreetViewMode.Overlay) {
        //        chkExternal.Visible = true;
        //        ltrInfo.Visible = true;
        //        if (chkExternal.Checked) GoogleMap1.StreetViewPanoID = "pano";
        //    }
        //}
    }
    #endregion
}