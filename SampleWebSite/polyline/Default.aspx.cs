using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Artem.Google.UI;

public partial class polyline_GooglePolyline : Page {

    #region Methods /////////////////////////////////////////////////////////////////

    protected void HandlePolylineClick(object sender, EventArgs e) {
    }

    /// <summary>
    /// Handles the show polyline click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleShowPolylineClick(object sender, EventArgs e) {

        string value = this.Request["__points"];
        if (!string.IsNullOrEmpty(value)) {
            GooglePolyline line = new GooglePolyline();
            line.Color = Color.Blue;
            line.Weight = 2;
            string[] points = value.Split(';');
            foreach (string point in points) {
                line.Points.Add(GoogleLocation.Parse(point));
            }
            GoogleMap1.Polylines.Clear();
            GoogleMap1.Polylines.Add(line);
        }
    }

    /// <summary>
    /// Handles the show extra data click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleShowExtraDataClick(object sender, EventArgs e) {

        //if (GoogleMap1.Polylines.Count > 0) {
        //    StringBuilder buffer = new StringBuilder();
        //    foreach (var line in GoogleMap1.Polylines) {
        //        buffer.AppendFormat("Bounds: {0}, Length: {1}<br/>", line.Bounds.ToString(), line.Length.ToString());
        //    }
        //    _ltrInfo.Text = buffer.ToString();
        //}
    }
    #endregion
}
