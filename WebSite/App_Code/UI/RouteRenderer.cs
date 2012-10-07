using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Artem.Google.UI;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Artem.GoogleMap.WebSite.UI {

    /// <summary>
    /// Summary description for RouteRenderer
    /// </summary>
    public class RouteRenderer : WebControl {

        #region Properties

        public DirectionsChangedEventArgs EventArgs { get; set; }

        protected override HtmlTextWriterTag TagKey { get { return HtmlTextWriterTag.Fieldset; } }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteRenderer"/> class.
        /// </summary>
        /// <param name="args">The <see cref="Artem.Google.UI.DirectionsChangedEventArgs"/> instance containing the event data.</param>
        public RouteRenderer(DirectionsChangedEventArgs args) {
            this.EventArgs = args;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        protected override void RenderContents(HtmlTextWriter writer) {

            if (this.EventArgs != null) {

                writer.RenderTag(HtmlTextWriterTag.Legend, "Server side rendered content");

                // start address/location
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "#EEE");
                using (writer.BeginTag(HtmlTextWriterTag.Div)) {
                    writer.RenderTag(HtmlTextWriterTag.B, "Start address: ");
                    writer.Write(this.EventArgs.StartAddress);
                    writer.RenderTag(HtmlTextWriterTag.B, " / Start location: ");
                    writer.Write(this.EventArgs.StartLocation.ToString());
                }

                // steps
                foreach (var step in this.EventArgs.Steps) {
                    writer.AddStyleAttribute("border-bottom", "solid 1px #CCC");
                    using (writer.BeginTag(HtmlTextWriterTag.Div)) {
                        writer.Write(step.Instructions);
                        writer.Write(" | ");
                        writer.RenderTag(HtmlTextWriterTag.B, "Distance: ");
                        writer.Write(step.Distance.Text);
                        writer.Write(" | ");
                        writer.RenderTag(HtmlTextWriterTag.B, "Duration: ");
                        writer.Write(step.Duration.Text);
                    }
                }

                // end address/location
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "#EEE");
                using (writer.BeginTag(HtmlTextWriterTag.Div)) {
                    writer.RenderTag(HtmlTextWriterTag.B, "End address: ");
                    writer.Write(this.EventArgs.EndAddress);
                    writer.RenderTag(HtmlTextWriterTag.B, " / End location: ");
                    writer.Write(this.EventArgs.EndLocation.ToString());
                }

                // distance
                using (writer.BeginTag(HtmlTextWriterTag.Div)) {
                    writer.RenderTag(HtmlTextWriterTag.B, "Total Distance: ");
                    writer.Write(this.EventArgs.Distance.Text);
                }
                // durarion
                using (writer.BeginTag(HtmlTextWriterTag.Div)) {
                    writer.RenderTag(HtmlTextWriterTag.B, "Total Duration: ");
                    writer.Write(this.EventArgs.Duration.Text);
                }
            }
        }
        #endregion
    }
}