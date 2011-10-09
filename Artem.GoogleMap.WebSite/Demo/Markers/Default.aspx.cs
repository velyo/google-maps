using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Artem.Google;
using Artem.Google.UI;

namespace Artem.Google.Web.Demo.Markers {

    public partial class DefaultPage : Page {

        #region Methods /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Handles the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HandleClick(object sender, EventArgs e) {
        }

        /// <summary>
        /// Handles the clear click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HandleClearClick(object sender, EventArgs e) {
            GoogleMap1.Markers.Clear();
            SaveMarkers();
        }

        protected void HandleLoadClick(object sender, EventArgs e) {
            LoadMarkers();
        }

        protected void HandleSaveClick(object sender, EventArgs e) {
            SaveMarkers();
        }

        protected void HandleMakeStaticClick(object sender, EventArgs e) {
            GoogleMap1.IsStatic = true;
        }

        protected void LoadMarkers() {

            string state = this.Session["__Markers"] as string;
            if (!string.IsNullOrEmpty(state)) {
                GoogleMap1.Markers.Clear();
                string[] points = state.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string point in points) {
                    string[] pair = point.Split(',');
                    GoogleMap1.Markers.Add(new GoogleMarker(JsUtil.ToDouble(pair[0]), JsUtil.ToDouble(pair[1])));
                }
            }
        }

        protected void SaveMarkers() {

            StringBuilder state = new StringBuilder();
            foreach (GoogleMarker marker in GoogleMap1.Markers) {
                state.AppendFormat("{0},{1};", JsUtil.Encode(marker.Latitude), JsUtil.Encode(marker.Longitude));
            }
            this.Session["__Markers"] = state.ToString();
        }
        #endregion
    }
}