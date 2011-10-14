using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    //[Designer(typeof(GoogleMapDesigner))]
    [ToolboxData("<{0}:GoogleMap runat=\"server\"></{0}:GoogleMap>")]
    public partial class GoogleMap : DataBoundControl, INamingContainer, IPostBackEventHandler, IScriptControl {

        #region Fields

        string _address;
        LatLng _center;
        List<GoogleDirections> _directions;
        string _key;
        bool _loading;
        GoogleMarkerEvents _markerEvents;
        List<GoogleMarker> _markers;
        GoogleMarkerStyle _markerStyle;
        //GooglePolygonEvents _polygonEvents;
        List<GooglePolygon> _polygons;
        List<GooglePolyline> _polylines;
        HtmlGenericControl _templateContainer;

        #endregion

        #region Properties

        #region Appearance

        /// <summary>
        /// The Google Maps API uses the browser's preferred language setting when displaying 
        /// textual information such as the names for controls, copyright notices, 
        /// driving directions and labels on maps. In most cases, this is preferable; 
        /// you usually do not wish to override the user's preferred language setting. 
        /// However, if you wish to change the Maps API to ignore the browser's language 
        /// setting and force it to display information in a particular language, 
        /// you can specifying the language to use.
        /// </summary>
        /// <value>The language.</value>
        [Category("Appearance")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the type of the map.
        /// Unlike in the Google Maps V2 API, there is no default map type. 
        /// You must specifically set an initial map type to see appropriate tiles.
        /// </summary>
        /// <value>The type of the map.</value>
        [Category("Appearance")]
        public MapType MapType { get; set; }

        /// <summary>
        /// The initial display options for the Map type control.
        /// </summary>
        /// <value>The map type control options.</value>
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MapTypeControlOptions MapTypeControlOptions { get; set; }

        /// <summary>
        /// The initial display options for the navigation control.
        /// </summary>
        /// <value>The navigation control options.</value>
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public NavigationControlOptions NavigationControlOptions { get; set; }

        /// <summary>
        /// The Maps API serves map tiles and biases application behavior, by default, using the 
        /// country of the host domain from which the API is loaded (which is the USA for maps.google.com). 
        /// If you wish to alter your application to serve different map tiles or bias the 
        /// application (such as biasing geocoding results towards the region), you can override 
        /// this default behavior by adding a region parameter to the Maps API javascript code.
        /// The region parameter accepts Unicode region subtag identifiers which (generally) 
        /// have a one-to-one mapping to country code Top-Level Domains (ccTLDs). 
        /// Most Unicode region identifiers are identical to ISO 3166-1 codes, with some notable exceptions. 
        /// For example, Great Britain's ccTLD is "uk" (corresponding to the domain .co.uk) 
        /// while its region identifier is "GB."
        /// For example, to use a Maps API application localized to the United Kingdom, add this settings to the code-behind as shown below:
        /// <code>GoogleMap1.Region = "GB";</code>
        /// </summary>
        /// <value>The region.</value>
        [Category("Appearance")]
        public string Region { get; set; }

        /// <summary>
        /// The initial display options for the scale control.
        /// </summary>
        /// <value>The scale control options.</value>
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ScaleControlOptions ScaleControlOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show traffic].
        /// </summary>
        /// <value><c>true</c> if [show traffic]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        public bool ShowTraffic { get; set; }

        /// <summary>
        /// A StreetViewPanorama to display when the Street View pegman is dropped on the map.
        /// If no panorama is specified, a default StreetViewPanorama will be displayed in the map's div
        /// when the pegman is dropped.
        /// </summary>
        /// <value>The street view.</value>
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public StreetViewPanorama StreetView { get; set; }

        /// <summary>
        /// The initial Map zoom level. Required.
        /// </summary>
        /// <value>The zoom.</value>
        [Category("Appearance")]
        public int Zoom { get; set; }

        #endregion

        #region Behavior

        /// <summary>
        /// The address to geocode and set as initial map center, when the provided <c>Address</c> 
        /// is not valid or failed to geocode.
        /// This property can be used to avoid "gray" maps, when the address set to the controls is not valid.
        /// </summary>
        /// <value>The default address.</value>
        [Category("Behavior")]
        public string DefaultAddress { get; set; }

        /// <summary>
        /// If true, do not clear the contents of the Map div.
        /// </summary>
        /// <value><c>true</c> if [disable clear]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool DisableClear { get; set; }

        /// <summary>
        /// Enables/disables all default UI. May be overridden individually.
        /// </summary>
        /// <value><c>true</c> if [disable default UI]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool DisableDefaultUI { get; set; }

        /// <summary>
        /// Enables/disables zoom and center on double click. Enabled by default.
        /// </summary>
        /// <value><c>true</c> if [double click zoom]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool DisableDoubleClickZoom { get; set; }

        /// <summary>
        /// If false, prevents the map from being controlled by the keyboard. 
        /// Keyboard shortcuts are enabled by default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [disable keyboard shortcuts]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool DisableKeyboardShortcuts { get; set; }

        /// <summary>
        /// If false, prevents the map from being dragged. Dragging is enabled by default.
        /// </summary>
        /// <value><c>true</c> if [enable dragging]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool Draggable { get; set; }

        /// <summary>
        /// The name or url of the cursor to display on a draggable object.
        /// </summary>
        /// <value>The draggable cursor.</value>
        [Category("Behavior")]
        public string DraggableCursor { get; set; }

        /// <summary>
        /// The name or url of the cursor to display when an object is dragging.
        /// </summary>
        /// <value>The dragging cursor.</value>
        [Category("Behavior")]
        public string DraggingCursor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether reverse geocoding (address lookup) is enabled.
        /// When the reverse geocoding is enabled the intial map center location is translated to 
        /// a human-readable address, known as reverse geocoding.
        /// Once the location is translated to a human-readable address, its value is saved in the 
        /// <c>Address</c> property of the GoogleMap Control and persisted during the postback.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enable reverse geocoding]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool EnableReverseGeocoding { get; set; }

        /// <summary>
        /// If false, disables scrollwheel zooming on the map. The scrollwheel is enabled by default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enable scroll wheel zoom]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool EnableScrollWheelZoom { get; set; }

        /// <summary>
        /// Gets or sets the render mode.
        /// </summary>
        /// <value>The render mode.</value>
        [Category("Behavior")]
        public MapRenderMode RenderMode { get; set; }

        /// <summary>
        /// The initial enabled/disabled state of the Map type control.
        /// By default it is set to <c>true</c> and map type control is visible.
        /// </summary>
        /// <value><c>true</c> if [show map type control]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool ShowMapTypeControl { get; set; }

        /// <summary>
        /// The initial enabled/disabled state of the navigation control.
        /// By default, this is set to <c>true</c> and navigation control is visible.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show navigation control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool ShowNavigationControl { get; set; }

        /// <summary>
        /// The initial enabled/disabled state of the scale control.
        /// By default it is set to <c>true</c> and scale control is visible.
        /// </summary>
        /// <value><c>true</c> if [show scale control]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool ShowScaleControl { get; set; }

        /// <summary>
        /// The initial enabled/disabled state of the Street View pegman control. 
        /// The Street View pegman control is enabled by default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show street view control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public bool ShowStreetViewControl { get; set; }

        #endregion

        #region Data

        /// <summary>
        /// The address to geocode and set the initial map center.
        /// When <c>Latitude</c> and <c>Longitude</c> (or <c>Center</c>) are set they will be used prior.
        /// Have in mind, after the <c>Latitude</c> and <c>Longitude</c> for the address are resolved through geocode 
        /// or, if at some point <c>Latitude</c> and <c>Longitude</c> are set, the <c>Address</c> will not be used to 
        /// set the initial map center.
        /// </summary>
        /// <value>The address.</value>
        [Category("Data")]
        public string Address {
            get {
                return _address;
            }
            set {
                if (_address != value) {
                    _address = value;
                    if (!_loading) this._center = null;
                }
            }
        }

        /// <summary>
        /// The initial LatLng map center.
        /// This is a new property which handles the <c>Latitude</c> and <c>Longitude</c> values.
        /// The initial map center LatLng can be set through <c>Latitude</c> and <c>Longitude</c> properties of
        /// <c>Center</c> or by comma seprated values pair string.
        /// For example:
        /// <c>GoogleMap1.Center.Latitude = 42.1229;
        /// GoogleMap1.Center.Longitude = 24.7879;</c>
        /// or
        /// <c>GoogleMap1.Center = "42.1229,24.7879";</c>
        /// </summary>
        /// <value>The center.</value>
        [Category("Data")]
        public LatLng Center {
            get {
                return _center ?? (_center = new LatLng());
            }
            set {
                _center = value;
            }
        }

        /// <summary>
        /// Gets or sets the data address field.
        /// </summary>
        /// <value>The data address field.</value>
        [Category("Data")]
        public string DataAddressField { get; set; }

        /// <summary>
        /// Gets or sets the data latitude field.
        /// </summary>
        /// <value>The data latitude field.</value>
        [Category("Data")]
        public string DataLatitudeField { get; set; }

        /// <summary>
        /// Gets or sets the data longitude field.
        /// </summary>
        /// <value>The data longitude field.</value>
        [Category("Data")]
        public string DataLongitudeField { get; set; }

        /// <summary>
        /// Gets or sets the data text field.
        /// </summary>
        /// <value>The data text field.</value>
        [Category("Data")]
        public string DataTextField { get; set; }

        /// <summary>
        /// Gets or sets the initial map center latitude.
        /// This property is kept for backward compatability, concider using the new <c>Center</c> property.
        /// </summary>
        /// <value>The latitude.</value>
        [Category("Data")]
        public double Latitude {
            get {
                return this.Center.Latitude;
            }
            set {
                //if (this.Center == null) this.Center = new LatLng();
                this.Center.Latitude = value;
            }
        }

        /// <summary>
        /// Gets or sets the initial map center longitude.
        /// This property is kept for backward compatability, concider using the new <c>Center</c> property.
        /// </summary>
        /// <value>The longitude.</value>
        [Category("Data")]
        public double Longitude {
            get {
                return this.Center.Longitude;
            }
            set {
                //if (this.Center == null) this.Center = new LatLng();
                this.Center.Longitude = value;
            }
        }

        #endregion

        #region Google

        /// <summary>
        /// Gets or sets the Google Maps API version.
        /// You can indicate which version of the API to load within your application.
        /// </summary>
        /// <value>The maps API version.</value>
        [Category("Google")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets the directions.
        /// </summary>
        /// <value>The directions.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<GoogleDirections> Directions {
            get {
                return this._directions ??
                    (_directions = new List<GoogleDirections>());
            }
            set {
                this._directions = value;
            }
        }

        /// <summary>
        /// Gets or sets the client enterprise key.
        /// </summary>
        /// <value>The key.</value>
        [Category("Google")]
        [DefaultValue("")]
        [Description("The Enterprise key obtained from google premier maps.")]
        public string EnterpriseKey { get; set; }

        /// <summary>
        /// Use of the Google Maps API requires that you indicate whether your application 
        /// is using a sensor (such as a GPS locator) to determine the user's location. 
        /// This is especially important for mobile devices. 
        /// Applications must pass a required sensor parameter to the Maps API javascript code, 
        /// indicating whether or not your application is using a sensor device.
        /// </summary>
        /// <value><c>true</c> if this instance is sensor; otherwise, <c>false</c>.</value>
        [Category("Google")]
        public bool IsSensor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is static.
        /// </summary>
        /// <value><c>true</c> if this instance is static; otherwise, <c>false</c>.</value>
        [Category("Google")]
        public bool IsStatic { get; set; }

        /// <summary>
        /// The Google Maps API lets you embed Google Maps in your own web pages. 
        /// A single Maps API key is valid for a single "directory" or domain. 
        /// You must have a Google Account to get a Maps API key, 
        /// and your API key will be connected to your Google Account.
        /// Follow the "Sign Up for the Google Maps API" instructions at 
        /// http://code.google.com/apis/maps/signup.html
        /// </summary>
        /// <value>The key.</value>
        [Category("Google")]
        [Obsolete("The version 3 of the Google Maps JavaScript API no longer needs API keys!")]
        public string Key {
            get {
                return this._key ??
                    (_key = WebConfigurationManager.AppSettings["GoogleMapKey"]);
            }
            set {
                this._key = value;
            }
        }

        /// <summary>
        /// Gets the markers.
        /// </summary>
        /// <value>The markers.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<GoogleMarker> Markers {
            get {
                return this._markers ??
                    (_markers = new List<GoogleMarker>());
            }
            set {
                this._markers = value;
            }
        }

        /// <summary>
        /// Gets or sets the marker style.
        /// </summary>
        /// <value>The marker style.</value>
        [Category("Google")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public GoogleMarkerStyle MarkerStyle {
            get {
                return _markerStyle;
            }
            set {
                if (_markerStyle != value) {
                    _markerStyle = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the polygons.
        /// </summary>
        /// <value>The polygons.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<GooglePolygon> Polygons {
            get {
                return this._polygons ??
                    (this._polygons = new List<GooglePolygon>());
            }
            protected internal set {
                this._polygons = value;
            }
        }

        /// <summary>
        /// Gets or sets the polylines.
        /// </summary>
        /// <value>The polylines.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<GooglePolyline> Polylines {
            get {
                return this._polylines ??
                    (_polylines = new List<GooglePolyline>());
            }
            protected internal set {
                this._polylines = value;
            }
        }

        /// <summary>
        /// Scale (zoom) value used to multiply the static map image size to define the output size in pixels.
        /// </summary>
        /// <value>The static scale.</value>
        [Category("Google")]
        public int StaticScale { get; set; }

        /// <summary>
        /// Gets or sets the static format.
        /// </summary>
        /// <value>The static format.</value>
        public StaticImageFormats StaticFormat { get; set; }

        #endregion

        #region Non-Browsable

        ///// <summary>
        ///// Gets the actions recorder.
        ///// </summary>
        ///// <value>The actions.</value>
        //protected internal IList<string> Actions {
        //    get {
        //        if (_actions == null)
        //            _actions = new List<string>();
        //        return _actions;
        //    }
        //}

        /// <summary>
        /// Gets or sets the bound.
        /// </summary>
        /// <value>The bound.</value>
        [Browsable(false)]
        public GoogleBounds Bounds {
            get;
            protected internal set;
        }
        #endregion



        #region Not Complete

        /// <summary>
        /// Gets or sets the marker events.
        /// </summary>
        /// <value>The marker events.</value>
        [Browsable(true)]
        [Category("Google")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public GoogleMarkerEvents MarkerEvents {
            get {
                return _markerEvents ??
                    (_markerEvents = new GoogleMarkerEvents());
            }
            set {
                _markerEvents = value;
            }
        }

        ///// <summary>
        ///// Gets or sets the marker manager options.
        ///// </summary>
        ///// <value>The marker manager options.</value>
        //[Browsable(true)]
        //[Category("Google")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //public MarkerManagerOptions MarkerManagerOptions {
        //    get {
        //        return this._markerManagerOptions ??
        //            (_markerManagerOptions = new MarkerManagerOptions());
        //    }
        //    set {
        //        this._markerManagerOptions = value;
        //    }
        //}

        ///// <summary>
        ///// Gets or sets the polygon events.
        ///// </summary>
        ///// <value>The polygon events.</value>
        //[Browsable(true)]
        //[Category("Google")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //public GooglePolygonEvents PolygonEvents {
        //    get {
        //        return _polygonEvents ??
        //            (_polygonEvents = new GooglePolygonEvents());
        //    }
        //    protected internal set {
        //        _polygonEvents = value;
        //    }
        //}

        #endregion

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMap"/> class.
        /// </summary>
        public GoogleMap() {

            this.Draggable = true;
            this.MapType = MapType.HYBRID;
            this.EnableScrollWheelZoom = true;
            this.ShowMapTypeControl = true;
            this.ShowNavigationControl = true;
            this.ShowScaleControl = true;
            this.ShowStreetViewControl = true;
            this.Zoom = 4;

            this.StaticScale = 1;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls() {
            base.CreateChildControls();

            _templateContainer = new HtmlGenericControl("div");
            _templateContainer.ID = "Templates";
            _templateContainer.Style[HtmlTextWriterStyle.Display] = "none";

            if (_markers.IsNotNullOrEmpty()) {
                GoogleMarker marker;
                for (int i = 0; i < _markers.Count; i++) {
                    marker = _markers[i];
                    if (marker.InfoContent.Controls.Count > 0) {
                        marker.InfoContent.ID = string.Format("{0}_MarkerInfo{1}", this.ClientID, i.ToString());
                        _templateContainer.Controls.Add(marker.InfoContent);
                    }
                    else if (marker.InfoWindowTemplate != null) {
                        var container = new GoogleMarker.TemplateContainer();
                        container.ID = string.Format("{0}_MarkerInfo{1}", this.ClientID, i.ToString());
                        marker.InfoWindowTemplate.InstantiateIn(container);
                        _templateContainer.Controls.Add(container);
                    }
                }
            }

            this.Controls.Add(_templateContainer);
            this.ClearChildViewState();
        }


        /// <summary>
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {

            if (!string.IsNullOrEmpty(eventArgument)) {
                string[] pair = eventArgument.Split('$');
                if (pair.Length > 0) {
                    string[] header = pair[0].Split(':');
                    string type = header[0];
                    string key = (header.Length > 1) ? header[1] : null;
                    string args = (pair.Length > 1) ? pair[1] : null;

                    switch (type) {
                        case "map":
                            MapEvents.RaiseEvent(this, key, args);
                            break;
                        case "direction":
                            // TODO
                            break;
                        case "marker":
                            MarkerEvents.RaiseEvent(this, key, args);
                            break;
                        case "polygon":
                            //PolygonEvents.RaiseEvent(this, key, args);
                            break;
                        case "polyline":
                            //PolylineEvents.RaiseEvent(this, key, args);
                            break;
                    }
                }
            }
        }
        #endregion

        #region DataBinding Methods

        /// <summary>
        /// When overridden in a derived class, binds data from the data source to the control.
        /// </summary>
        /// <param name="data">The <see cref="T:System.Collections.IEnumerable"/> list of data returned from a <see cref="M:System.Web.UI.WebControls.DataBoundControl.PerformSelect"/> method call.</param>
        protected override void PerformDataBinding(IEnumerable data) {
            base.PerformDataBinding(data);

            if (data != null) {
                bool hasAddressDataField = !string.IsNullOrEmpty(DataAddressField);
                bool hasLatitudeDataField = !string.IsNullOrEmpty(DataLatitudeField);
                bool hasLongitudeDataField = !string.IsNullOrEmpty(DataLongitudeField);
                bool hasTextDataField = !string.IsNullOrEmpty(DataTextField);
                GoogleMarker marker;
                foreach (object dataItem in data) {
                    marker = new GoogleMarker();
                    if (hasAddressDataField)
                        marker.Address = DataBinder.Eval(dataItem, DataAddressField, "");
                    if (hasLatitudeDataField)
                        marker.Latitude = JsUtil.ToDouble(DataBinder.Eval(dataItem, DataLatitudeField, ""));
                    if (hasLongitudeDataField)
                        marker.Longitude = JsUtil.ToDouble(DataBinder.Eval(dataItem, DataLongitudeField, ""));
                    if (hasTextDataField)
                        marker.Text = DataBinder.Eval(dataItem, DataTextField, "");
                    this.Markers.Add(marker);
                }
            }
        }

        /// <summary>
        /// Retrieves data from the associated data source.
        /// </summary>
        protected override void PerformSelect() {

            if (IsBoundUsingDataSourceID)
                this.OnDataBinding(EventArgs.Empty);

            DataSourceView view = GetData();
            view.Select(
                CreateDataSourceSelectArguments(),
                this.OnDataSourceViewSelectCallback);
            // The PerformDataBinding method has completed.
            RequiresDataBinding = false;
            MarkAsDataBound();
            // Raise the DataBound event.
            OnDataBound(EventArgs.Empty);
        }

        /// <summary>
        /// Called when [data source view select callback].
        /// </summary>
        /// <param name="retrievedData">The retrieved data.</param>
        void OnDataSourceViewSelectCallback(IEnumerable retrievedData) {

            if (IsBoundUsingDataSourceID)
                OnDataBinding(EventArgs.Empty);
            PerformDataBinding(retrievedData);
        }
        #endregion
    }
}