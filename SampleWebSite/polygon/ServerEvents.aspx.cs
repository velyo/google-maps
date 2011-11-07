using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Artem.Google.UI;

namespace Artem.GoogleMap.WebSite.Polygons {

    /// <summary>
    /// Summary description for ServerEvents
    /// </summary>
    public partial class ServerEvents : Page {

        #region Methods

        /// <summary>
        /// Handles the clear click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HandleClearClick(object sender, EventArgs e) {
            lbEvents.Items.Clear();
        }

        /// <summary>
        /// Handles the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void HandleClick(object sender, MouseEventArgs e) {
            this.PrintEvent("Click", e);
        }

        /// <summary>
        /// Handles the double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void HandleDoubleClick(object sender, MouseEventArgs e) {
            this.PrintEvent("DoubleClick", e);
        }
        /// <summary>
        /// Handles the mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseDown(object sender, MouseEventArgs e) {
            this.PrintEvent("MouseDown", e);
        }

        // Too eften fired, that's why omitted.
        ///// <summary>
        ///// Handles the mouse move.
        ///// </summary>
        ///// <param name="sender">The sender.</param>
        ///// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        //protected void HandleMouseMove(object sender, MouseEventArgs e) {
        //    this.PrintEvent("MouseMove", e);
        //}

        /// <summary>
        /// Handles the mouse out.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseOut(object sender, MouseEventArgs e) {
            this.PrintEvent("MouseOut", e);
        }

        /// <summary>
        /// Handles the mouse over.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseOver(object sender, MouseEventArgs e) {
            this.PrintEvent("MouseOver", e);
        }

        /// <summary>
        /// Handles the mouse up.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseUp(object sender, MouseEventArgs e) {
            this.PrintEvent("MouseUp", e);
        }

        /// <summary>
        /// Handles the right click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void HandleRightClick(object sender, MouseEventArgs e) {
            this.PrintEvent("RightClick", e);
        }

        /// <summary>
        /// Prints the event.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected void PrintEvent(string name, MouseEventArgs e) {
            lbEvents.Items.Add(
                string.Format("{0} event was fired (lat: {1}, lng: {2}).",
                    name, e.Position.Latitude, e.Position.Longitude));
        }
        #endregion
    }
}