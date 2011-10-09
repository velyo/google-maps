using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class map_InUpdatePanel : System.Web.UI.Page {

    #region Methods /////////////////////////////////////////////////////////////////

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
