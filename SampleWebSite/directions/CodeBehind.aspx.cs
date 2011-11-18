using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

namespace Artem.GoogleMap.WebSite.Directions {

    public partial class CodeBehind : System.Web.UI.Page {

        #region Methods

        /// <summary>
        /// Handles the show click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HandleShowClick(object sender, EventArgs e) {

            string destination = txtDestination.Text;
            string origin = txtOrigin.Text;
            if ((origin != null) && (destination != null)) {
                GoogleMap1.Directions.Add(new GoogleDirections { 
                    Destination = new Location(destination),
                    Origin = new Location(origin),
                    Draggable = true,
                    PanelID = "route"
                });
            }
        }
        #endregion
    }
}