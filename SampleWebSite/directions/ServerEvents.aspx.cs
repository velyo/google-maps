using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;
using Artem.GoogleMap.WebSite.UI;

namespace Artem.GoogleMap.WebSite.Directions {

    public partial class ServerEvents : Page {

        #region Methods

        /// <summary>
        /// Handles the directions changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HandleDirectionsChanged(object sender, DirectionsChangedEventArgs e) {
            phRoutes.Controls.Clear();
            phRoutes.Controls.Add(new RouteRenderer(e));
        }
        #endregion
    }
}