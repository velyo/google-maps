using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.GoogleMap.WebSite;

public partial class examples_ListDataBound : Page {

    #region Methods ///////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Handles the item data bound.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.DataListItemEventArgs"/> instance containing the event data.</param>
    protected void HandleItemDataBound(object sender, DataListItemEventArgs e) {

        Artem.Google.UI.GoogleMap map = e.Item.FindControl("crtGooleMap") as Artem.Google.UI.GoogleMap;
        if (map != null) {
            GoogleMapData dataItem = (GoogleMapData)e.Item.DataItem;
            map.Latitude = dataItem.Latitude;
            map.Longitude = dataItem.Longitude;
            map.Zoom = dataItem.Zoom;
        }
    } 
    #endregion
}
