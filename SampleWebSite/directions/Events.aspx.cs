﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

public partial class directions_Events : System.Web.UI.Page {

    #region Methods /////////////////////////////////////////////////////////////////

    /// <summary>
    /// Handles the show directions click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleShowDirectionsClick(object sender, EventArgs e) {

        string query = _txtQuery.Text;
        if (string.IsNullOrEmpty(query))
            query = "from: San Francisco, CA to: Mountain View, CA";
        string locale = _txtLocale.Text;
        GoogleMap1.Directions.Clear();
        //GoogleMap1.Directions.Add(new GoogleDirections(query, "route", locale));
    }

    /// <summary>
    /// Handles the show extra data.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void HandleShowExtraData(object sender, EventArgs e) {

        //if (GoogleMap1.Directions.Count > 0) {
        //    GoogleDirections dir = GoogleMap1.Directions[0];
        //    _ltrInfo.Text = string.Format("Bounds: {0}<br/>Distance: {1}<br/>Duration: {2}",
        //        dir.Bounds.ToString(), dir.Distance.Html, dir.Duration.Html);
        //}
    }

    #endregion
}