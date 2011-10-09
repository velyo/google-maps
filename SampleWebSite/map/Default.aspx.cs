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

public partial class map_GoogleMap : Page {

    #region Methods /////////////////////////////////////////////////////////////////

    /// <summary>
    /// Handles any.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleClick(object sender, GoogleLocationEventArgs e) {
        double lat = e.Location.Latitude;
        double lng = e.Location.Longitude;
        // TODO: store the values in my database
    }

    /// <summary>
    /// Handles the show click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleShowClick(object sender, EventArgs e) {

        string address = _txtAddress.Text;
        if (!string.IsNullOrEmpty(address)) {
            GoogleMap1.Address = address;
        }
    }
    #endregion
}
