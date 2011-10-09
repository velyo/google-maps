using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Artem.Google.UI;

public partial class polygon_ClientEvents : Page {

    #region Fields  /////////////////////////////////////////////////////////////////

    CultureInfo _culture = CultureInfo.GetCultureInfo("en-US");
    int _index;
    GoogleLocation[] _points; 

    #endregion

    #region Properties  /////////////////////////////////////////////////////////////

    /// <summary>
    /// Gets the points.
    /// </summary>
    /// <value>The points.</value>
    public GoogleLocation[] Points {
        get {
            if (_points == null)
                _points = new GoogleLocation[2];
            return _points;
        }
    } 
    #endregion

    #region Methods /////////////////////////////////////////////////////////////////

    /// <summary>
    /// Raises the <see cref="E:Init"/> event.
    /// </summary>
    /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected override void OnInit(EventArgs args) {
        base.OnInit(args);
        //
        RegisterRequiresControlState(this);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Load"/> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs"/> object that contains the event data.</param>
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        //
        double lat = 0;
        double lng = 0;

        if (!string.IsNullOrEmpty(_lat.Value))
            lat = Convert.ToDouble(_lat.Value, _culture.NumberFormat);
        if (!string.IsNullOrEmpty(_lng.Value))
            lng = Convert.ToDouble(_lng.Value, _culture.NumberFormat);
        if (lat > 0 && lng > 0) {
            Points[_index] = new GoogleLocation(lat, lng);
            _index = (_index == 0) ? 1 : 0;
        }
        //
        if (Points[0] != null && Points[1] != null) {
            GoogleMap1.Polygons.Clear();
            GooglePolygon polygon = new GooglePolygon();
            polygon.FillColor = Color.Red;
            polygon.FillOpacity = .8F;
            polygon.StrokeColor = Color.Blue;
            polygon.StrokeWeight = 1;
            polygon.Points.Add(Points[0]);
            polygon.Points.Add(new GoogleLocation(Points[0].Latitude, Points[1].Longitude));
            polygon.Points.Add(Points[1]);
            polygon.Points.Add(new GoogleLocation(Points[1].Latitude, Points[0].Longitude));
            polygon.Points.Add(Points[0]);
            GoogleMap1.Polygons.Add(polygon);
        }
    }

    #region - Control State -

    /// <summary>
    /// Restores control-state information from a previous page request that was saved by the <see cref="M:System.Web.UI.Control.SaveControlState"/> method.
    /// </summary>
    /// <param name="savedState">An <see cref="T:System.Object"/> that represents the control state to be restored.</param>
    protected override void LoadControlState(object savedState) {

        Triplet state = savedState as Triplet;
        if (state != null) {
            base.LoadControlState(state.First);
            _index = (int)state.Second;
            string points = state.Third as string;
            if (!string.IsNullOrEmpty(points)) {
                double lat;
                double lng;
                int index = 0;
                string[] ps = points.Split(';');
                foreach (string p in ps) {
                    lat = 0;
                    lng = 0;
                    string[] pair = p.Split(':');
                    if (!string.IsNullOrEmpty(pair[0]))
                        lat = Convert.ToDouble(pair[0], _culture.NumberFormat);
                    if (!string.IsNullOrEmpty(pair[1]))
                        lng = Convert.ToDouble(pair[1], _culture.NumberFormat);
                    if (lat > 0 && lng > 0) {
                        Points[index++] = new GoogleLocation(lat, lng);
                    }
                }
            }
            //_points = (GooglePoint[])state.Third;
        }
        else
            base.LoadControlState(savedState);
    }

    /// <summary>
    /// Saves any server control state changes that have occurred since the time the page was posted back to the server.
    /// </summary>
    /// <returns>
    /// Returns the server control's current state. If there is no state associated with the control, this method returns null.
    /// </returns>
    protected override object SaveControlState() {

        StringBuilder buff = new StringBuilder();
        foreach (GoogleLocation point in Points) {
            if (point != null)
                buff.AppendFormat("{0}:{1};",
                    Convert.ToString(point.Latitude, _culture.NumberFormat),
                    Convert.ToString(point.Longitude, _culture.NumberFormat));
        }
        if (buff.Length > 0) buff.Length--;
        return new Triplet(base.SaveControlState(), _index, buff.ToString());
    } 
    #endregion 
    #endregion
}
