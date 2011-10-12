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

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true, "Points")]
    public class GooglePolyline {

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        //PolyEditingOptions _editingOptions;
        List<LatLng> _points;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        #region Appearance

        /// <summary>
        /// Gets or sets a value for color of the polyline. 
        /// The color is given as a string that contains the color in hexadecimal numeric HTML style, i.e. #RRGGBB.
        /// </summary>
        /// <value>The color.</value>
        [Category("Appearance")]
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets the opacity of polyline.
        /// The opacity is given as a number between 0 and 1. The line will be antialiased and semitransparent.
        /// </summary>
        /// <value>The opacity.</value>
        [Category("Appearance")]
        public float Opacity { get; set; }

        /// <summary>
        /// Gets or sets the weight of polyline.
        /// The weight is the width of the line in pixels.
        /// </summary>
        /// <value>The weight.</value>
        [Category("Appearance")]
        public int Weight { get; set; }

        /// <summary>
        /// The zIndex compared to other polys.
        /// </summary>
        /// <value>The index of the Z.</value>
        [Category("Appearance")]
        public int ZIndex { get; set; }

        #endregion

        #region Behavior

        /// <summary>
        /// Gets or sets a value indicating whether this polyline is clickable.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is clickable; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool IsClickable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this polyline is geodesic.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is geodesic; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool IsGeodesic { get; set; }

        #endregion

        #region Data

        /// <summary>
        /// Gets or sets the points of polyline.
        /// </summary>
        /// <value>The points.</value>
        [Browsable(true)]
        [Category("Data")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
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
        /// Gets or sets the bounds of the polyline.
        /// Have in mind it requires an additional post back after polyline is loaded.
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
        /// Gets or sets a value indicating whether [enable drowing].
        /// Allows a user to construct (or modify) a <c>GooglePolyline</c> object by clicking on additional points on the map. 
        /// The <c>GooglePolyline</c> must already be added to the map, 
        /// even if the polyline is initially unpopulated and contains no vertices. 
        /// Each click adds an additional vertex to the polyline chain, 
        /// and drawing may be terminated through either a double-click or clicking again on the last point added, 
        /// at which point an "endline" event will be triggered if the polyline was successfully completed; 
        /// otherwise, a "cancelline" event will be triggered, but the polyline will not be removed from the map. 
        /// If modifying an existing Polyline, vertices are connected from either the starting or ending points 
        /// of the existing polyline, specified in the optional GPolyEditingOptions.fromStart parameter. 
        /// </summary>
        /// <value><c>true</c> if [enable drowing]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public bool EnableDrawing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable editing].
        /// Allows modification of an existing <c>GooglePolyline</c> chain of points. 
        /// When enabled, users may select and drag existing vertices. 
        /// The <c>GogglePolyline</c> must already be added to the map. 
        /// Unless a vertex limit less than current number of vertices is specified by maxVertices within GPolyEditingOptions, 
        /// "ghost" points will also be added at the midpoints of polyline sections, 
        /// allowing users to interpolate new vertices by clicking and dragging these additional vertices. 
        /// A "lineupdated" event will be triggered whenever vertex is added or moved. 
        /// </summary>
        /// <value><c>true</c> if [enable editing]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public bool EnableEditing { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// Returns the length (in meters) of the polyline along the surface of a spherical Earth.
        /// </summary>
        /// <value>The length.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public double? Length { get; set; }

        /// <summary>
        /// Gets or sets the mouse out tolerance.
        /// This property contains the distance (in pixels) for a mouse cursor 
        /// to move orthogonal to the polyline before the mouseout event fires. 
        /// </summary>
        /// <value>The mouse out tolerance.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        public int MouseOutTolerance { get; set; }

        #endregion
        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePolyline"/> class.
        /// </summary>
        public GooglePolyline() {
            this.IsClickable = true;
            this.Opacity = .5F;
            this.Weight = 5;
        }
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////
        #endregion
    }
}
