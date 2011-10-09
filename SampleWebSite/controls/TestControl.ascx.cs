using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_TestControl : System.Web.UI.UserControl {

    #region Methods ///////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);

        GoogleMap1.Markers[2].InfoContent.Controls.Add(new LiteralControl("Content from code behind."));
    }

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if(this.IsPostBack){
            string address = GoogleMap1.Address;
        }
    }
    #endregion
}