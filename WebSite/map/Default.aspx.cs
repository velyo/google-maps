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

namespace Artem.GoogleMap.WebSite.Maps {

    public partial class Default : Page {

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
                    GoogleMap1.Center = null;
                }
            }

            txtAddress.Text = null;
            txtPoint.Text = null;
        }
        #endregion
    }
}