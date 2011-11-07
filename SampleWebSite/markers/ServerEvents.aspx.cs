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
        /// Handles the animation changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleAnimationChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("AnimationChanged", e);
        }

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
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleClick(object sender, MarkerEventArgs e) {
            this.PrintEvent("Click", e);
        }

        /// <summary>
        /// Handles the clickable changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleClickableChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("ClickableChanged", e);
        }

        /// <summary>
        /// Handles the cursor changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleCursorChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("CursorChanged", e);
        }

        /// <summary>
        /// Handles the double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleDoubleClick(object sender, MarkerEventArgs e) {
            this.PrintEvent("DoubleClick", e);
        }

        /// <summary>
        /// Handles the drag.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleDrag(object sender, MarkerEventArgs e) {
            this.PrintEvent("Drag", e);
        }

        /// <summary>
        /// Handles the drag end.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleDragEnd(object sender, MarkerEventArgs e) {
            this.PrintEvent("DragEnd", e);
        }

        /// <summary>
        /// Handles the draggable changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleDraggableChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("DraggableChanged", e);
        }

        /// <summary>
        /// Handles the drag start.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleDragStart(object sender, MarkerEventArgs e) {
            this.PrintEvent("DragStart", e);
        }

        /// <summary>
        /// Handles the flat changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleFlatChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("FlatChanged", e);
        }

        /// <summary>
        /// Handles the icon changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleIconChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("IconChanged", e);
        }

        /// <summary>
        /// Handles the mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseDown(object sender, MarkerEventArgs e) {
            this.PrintEvent("MouseDown", e);
        }

        /// <summary>
        /// Handles the mouse out.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseOut(object sender, MarkerEventArgs e) {
            this.PrintEvent("MouseOut", e);
        }

        /// <summary>
        /// Handles the mouse over.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseOver(object sender, MarkerEventArgs e) {
            this.PrintEvent("MouseOver", e);
        }

        /// <summary>
        /// Handles the mouse up.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleMouseUp(object sender, MarkerEventArgs e) {
            this.PrintEvent("MouseUp", e);
        }

        /// <summary>
        /// Handles the position changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandlePositionChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("PositionChanged", e);
        }

        /// <summary>
        /// Handles the right click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleRightClick(object sender, MarkerEventArgs e) {
            this.PrintEvent("RightClick", e);
        }

        /// <summary>
        /// Handles the shadow changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleShadowChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("ShadowChanged", e);
        }

        /// <summary>
        /// Handles the shape changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleShapeChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("ShapeChanged", e);
        }

        /// <summary>
        /// Handles the title changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleTitleChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("TitleChanged", e);
        }

        /// <summary>
        /// Handles the visible changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleVisibleChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("VisibleChanged", e);
        }

        /// <summary>
        /// Handles the Z index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void HandleZIndexChanged(object sender, MarkerEventArgs e) {
            this.PrintEvent("ZIndexChanged", e);
        }

        /// <summary>
        /// Prints the event.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected void PrintEvent(string name, MarkerEventArgs e) {
            lbEvents.Items.Add(
                string.Format("{0} event was fired by marker [index: {1}] at position [lat: {2}, lng: {3}].",
                    name, e.Index, e.Position.Latitude, e.Position.Longitude));
        }
        #endregion
    }
}