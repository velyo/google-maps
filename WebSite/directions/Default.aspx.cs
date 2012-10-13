using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Artem.Google.UI;

namespace Artem.GoogleMap.WebSite.Directions {

    /// <summary>
    /// Summary description for Default
    /// </summary>
    public partial class Default : Page {

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
                GoogleDirections1.Destination.Address = destination;
                GoogleDirections1.Origin.Address = origin;
            }
        }
        #endregion
    }
}