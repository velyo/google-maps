using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Artem.Google.UI;
using System.Web.UI.WebControls;

namespace Artem.GoogleMap.WebSite {

    /// <summary>
    /// Summary description for DataBound
    /// </summary>
    public partial class DataBound : Page {

        #region Fields

        Bounds _bounds;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the marker count.
        /// </summary>
        /// <value>The marker count.</value>
        protected int MarkerCount {
            get {
                var value = this.ViewState["MarkerCount"];
                return (value != null) ? (int)value : 20;
            }
            set {
                this.ViewState["MarkerCount"] = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Handles the map event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MapEventArgs"/> instance containing the event data.</param>
        protected void HandleMapEvent(object sender, MapEventArgs e) {

            _bounds = e.Bounds;
            GoogleMap1.Center = e.Center;
            GoogleMap1.MapType = e.MapType;
            GoogleMap1.Zoom = e.Zoom;
            GoogleMarkers1.DataBind();
        }

        /// <summary>
        /// Handles the data selecting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/> instance containing the event data.</param>
        protected void HandleDataSelecting(object sender, ObjectDataSourceSelectingEventArgs e) {
            e.InputParameters["bounds"] = _bounds;
            e.InputParameters["count"] = this.MarkerCount;
        }

        /// <summary>
        /// Handles the text count changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HandleTextCountChanged(object sender, EventArgs e) {

            var textBox = sender as TextBox;
            if (textBox != null) {
                int count = 20;
                string value = textBox.Text;
                if (value != null) {
                    if (int.TryParse(value, out count))
                        this.MarkerCount = count;
                }
            }
        }
        #endregion
    }
}