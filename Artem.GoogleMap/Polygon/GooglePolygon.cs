using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("Artem.Google.Polygon.GooglePolygonBehavior.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Polygon.GooglePolygonBehavior.min.js", "text/javascript")]

namespace Artem.Google.UI {

    /// <summary>
    /// Polygon (like a polyline) defines a series of connected coordinates in an ordered sequence; 
    /// additionally, polygons form a closed loop and define a filled region.
    /// </summary>
    [ParseChildren(true, "Points")]
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GooglePolygon runat=server></{0}:GooglePolygon>")]
    public class GooglePolygon : ExtenderControl, IPostBackEventHandler {

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        List<LatLng> _points;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        #region Appearance

        /// <summary>
        /// The fill color in HTML hex style, ie. "#00AAFF"
        /// </summary>
        /// <value>The color of the fill.</value>
        [Category("Appearance")]
        public Color FillColor { get; set; }

        /// <summary>
        /// The fill opacity between 0.0 and 1.0
        /// </summary>
        /// <value>The fill opacity.</value>
        [Category("Appearance")]
        public float FillOpacity { get; set; }

        /// <summary>
        ///The stroke color in HTML hex style, ie. "#FFAA00"
        /// </summary>
        /// <value>The color of the stroke.</value>
        [Category("Appearance")]
        public Color StrokeColor { get; set; }

        /// <summary>
        /// The stroke opacity between 0.0 and 1.0
        /// </summary>
        /// <value>The stroke opacity.</value>
        [Category("Appearance")]
        public float StrokeOpacity { get; set; }

        /// <summary>
        /// The stroke width in pixels.
        /// </summary>
        /// <value>The stroke weight.</value>
        [Category("Appearance")]
        public int StrokeWeight { get; set; }

        /// <summary>
        /// The zIndex compared to other polys.
        /// </summary>
        /// <value>The index of the Z.</value>
        [Category("Appearance")]
        public int ZIndex { get; set; }

        #endregion

        #region Behavior

        /// <summary>
        /// Indicates whether this Polygon handles click events. Defaults to true.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is clickable; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool IsClickable { get; set; }

        /// <summary>
        /// Render each edge as a geodesic (a segment of a "great circle"). 
        /// A geodesic is the shortest path between two points along the surface of the Earth.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is geodesic; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool IsGeodesic { get; set; }

        #endregion

        #region Data

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>The points.</value>
        [Browsable(true)]
        [Category("Data")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<LatLng> Points {
            get {
                if (_points == null) {
                    _points = new List<LatLng>();
                }
                return _points;
            }
            set {
                _points = value;
            }
        }
        #endregion

        #region Not Yet Supported in GoogleMaps API v3

        /// <summary>
        /// Gets or sets the bounds of the polygon. 
        /// Have in mind it requires an additional post back after polygon is loaded.
        /// </summary>
        /// <value>The bounds.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public GoogleBounds Bounds { get; set; }

        /// <summary>
        /// Maps the <c>GPolyEditingOptions</c> <c>fromStart</c> property.
        /// This property specifies whether enableDrawing should add points from the start 
        /// rather than from the end, which is the default.
        /// </summary>
        /// <value>From start.</value>
        [Category("Behavior")]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public bool? EditingFromStart { get; set; }

        /// <summary>
        /// Maps the <c>GPolyEditingOptions</c> <c>maxVertices</c> property.
        /// This property specifies the maximum number of vertices permitted for this polyline. 
        /// Once this number is reached, no more may be added.
        /// </summary>
        /// <value>The max vertices.</value>
        [Category("Behavior")]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public int? EditingMaxVertices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable drawing].
        /// Allows a user to construct a GPolygon object by clicking on additional points on the map. 
        /// The Polygon must already be added to the map, even if the polygon is initially unpopulated and contains no vertices. 
        /// Each click adds an additional vertex to the polygon boundary, and drawing may be terminated through either 
        /// a double-click, or clicking on the first point to complete the shape, at which point an "endline" event will be 
        /// triggered if the polygon was successfully completed; otherwise, a "cancelline" event will be triggered, 
        /// but the polygon will not be removed from the map. 
        /// </summary>
        /// <value><c>true</c> if [enable drawing]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public bool EnableDrawing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable editing].
        /// Allows modification of an existing GPolygon boundary. 
        /// When enabled, users may select and drag existing vertices. 
        /// The Polygon must already be added to the map via GMap2.addOverlay(). 
        /// Unless a vertex limit less than current number of vertices is specified by maxVertices within EditingOptions, 
        /// "ghost" points will also be added at the midpoints of polygon sections, 
        /// allowing users to interpolate new vertices by clicking and dragging these additional vertices. 
        /// A "lineupdated" event will be triggered whenever vertex is added or moved. 
        /// </summary>
        /// <value><c>true</c> if [enable editing]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public bool EnableEditing { get; set; }

        #endregion
        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePolygon"/> class.
        /// </summary>
        public GooglePolygon() {
            this.FillOpacity = .5F;
            this.IsClickable = true;
            this.StrokeOpacity = .5F;
            this.StrokeWeight = 5;
        }
        #endregion

        #region Methods

        /// <summary>
        /// When overridden in a derived class, registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control to which the extender is associated.</param>
        /// <returns>
        /// An enumeration of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl) {

            var descriptor = new ScriptBehaviorDescriptor("Artem.Google.PolygonBehavior", targetControl.ClientID);
            yield return descriptor;
        }

        /// <summary>
        /// When overridden in a derived class, registers the script libraries for the control.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="T:System.Collections.IEnumerable"/> interface and that contains ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences() {

            string assembly = this.GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Artem.Google.Polygon.GooglePolygonBehavior.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Polyline.GooglePolygonBehavior.min.js", assembly);
#endif
        }

        public void RaisePostBackEvent(string eventArgument) {
            throw new NotImplementedException();
        }
        #endregion
    }
}