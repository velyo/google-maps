using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
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
using System.Web.Script.Serialization;

[assembly: WebResource("Artem.Google.Map.GoogleMap.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Map.GoogleMap.min.js", "text/javascript")]

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [Designer("Artem.Google.UI.GoogleMapDesigner, Artem.Google, Version=6.0.0.0, Culture=neutral, PublicKeyToken=fc8d6190a3aeb01c")]
    [ToolboxData("<{0}:GoogleMap runat=\"server\"></{0}:GoogleMap>")]
    public partial class GoogleMap : ScriptControl, IPostBackEventHandler {

        #region Static Fields

        /// <summary>
        /// The GoogleMaps API script URL. 
        /// The property is not longer readonly in order to provide ability for changing it per application.
        /// For example, if it is changed in the future this property could be set in Global.asax per appliation.
        /// The protocol should be omitted from the specified URL in order to allow 
        /// control to automatically switch to HTTPS when requested under SSL.
        /// </summary>
        public static string ApiUrl = "maps.googleapis.com/maps/api/js?";

        /// <summary>
        /// The Static Maps API script URL.
        /// The protocol should be omitted from the specified URL in order to allow 
        /// control to automatically switch to HTTPS when requested under SSL.
        /// </summary>
        public static string StaticApiUrl = "maps.googleapis.com/maps/api/staticmap?";

        #endregion

        #region Properties

        /// <summary>
        /// The address to geocode and set the initial map center.
        /// </summary>
        /// <value>The address.</value>
        [Category("Data")]
        [Description("The address to geocode and set the initial map center.")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Google Maps API version.
        /// You can indicate which version of the API to load within your application.
        /// </summary>
        /// <value>The maps API version.</value>
        [Category("Google")]
        [Description("You can indicate which version of the API to load within your application.")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// The initial Bounds of the map. 
        /// This or Zoom is required in order to show the map.
        /// </summary>
        [Category("Appearance")]
        [Description("The initial Bounds of the map. This or Zoom is required in order to show the map.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Bounds Bounds { get; set; }

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
        [Description("The initial LatLng map center. This is required in order to show the map.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLng Center {
            get { return _center ?? (_center = new LatLng()); }
            set { _center = value; }
        }
        LatLng _center;

        /// <summary>
        /// The address to geocode and set as initial map center, when the provided <c>Address</c> 
        /// is not valid or failed to geocode.
        /// This property can be used to avoid "gray" maps, when the address set to the controls is not valid.
        /// </summary>
        /// <value>The default address.</value>
        [Category("Data")]
        [Description("The address to geocode and set as initial map center, when the provided Address is not valid or failed to geocode.")]
        public string DefaultAddress { get; set; }

        /// <summary>
        /// If true, do not clear the contents of the Map div.
        /// </summary>
        /// <value><c>true</c> if [disable clear]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("If true, do not clear the contents of the Map div.")]
        public bool DisableClear { get; set; }

        /// <summary>
        /// Enables/disables all default UI. May be overridden individually.
        /// </summary>
        /// <value><c>true</c> if [disable default UI]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("Enables/disables all default UI. May be overridden individually.")]
        public bool DisableDefaultUI { get; set; }

        /// <summary>
        /// Enables/disables zoom and center on double click. Enabled by default.
        /// </summary>
        /// <value><c>true</c> if [double click zoom]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("Enables/disables zoom and center on double click. Enabled by default.")]
        public bool DisableDoubleClickZoom { get; set; }

        /// <summary>
        /// If false, prevents the map from being controlled by the keyboard. 
        /// Keyboard shortcuts are enabled by default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [disable keyboard shortcuts]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("If false, prevents the map from being controlled by the keyboard. Keyboard shortcuts are enabled by default.")]
        public bool DisableKeyboardShortcuts { get; set; }

        /// <summary>
        /// If false, prevents the map from being dragged. Dragging is enabled by default.
        /// </summary>
        /// <value><c>true</c> if [enable dragging]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("If false, prevents the map from being dragged. Dragging is enabled by default.")]
        public bool Draggable { get; set; }

        /// <summary>
        /// The name or url of the cursor to display on a draggable object.
        /// </summary>
        /// <value>The draggable cursor.</value>
        [Category("Behavior")]
        [Description("The name or url of the cursor to display on a draggable object.")]
        public string DraggableCursor { get; set; }

        /// <summary>
        /// The name or url of the cursor to display when an object is dragging.
        /// </summary>
        /// <value>The dragging cursor.</value>
        [Category("Behavior")]
        [Description("The name or url of the cursor to display when an object is dragging.")]
        public string DraggingCursor { get; set; }

        /// <summary>
        /// The initial enabled/disabled state of the Map type control.
        /// By default it is set to <c>true</c> and map type control is visible.
        /// </summary>
        /// <value><c>true</c> if [show map type control]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [Description("The initial enabled/disabled state of the Map type control.")]
        public bool EnableMapTypeControl { get; set; }

        /// <summary>
        /// The enabled/disabled state of the Overview Map control.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show overview map control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Overview Map control.")]
        public bool EnableOverviewMapControl { get; set; }

        /// <summary>
        /// The enabled/disabled state of the Pan control.
        /// </summary>
        /// <value><c>true</c> if [pan control]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Pan control.")]
        public bool EnablePanControl { get; set; }

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
        [Description("Value indicating whether reverse geocoding (address lookup) is enabled.")]
        public bool EnableReverseGeocoding { get; set; }

        /// <summary>
        /// The enabled/disabled state of the Rotate control.
        /// </summary>
        /// <value><c>true</c> if [rotate control]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Rotate control.")]
        public bool EnableRotateControl { get; set; }

        /// <summary>
        /// The initial enabled/disabled state of the Scale control.
        /// </summary>
        /// <value><c>true</c> if [enable scale control]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("The initial enabled/disabled state of the Scale control.")]
        public bool EnableScaleControl { get; set; }

        /// <summary>
        /// If false, disables scrollwheel zooming on the map. The scrollwheel is enabled by default.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enable scroll wheel zoom]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("If false, disables scrollwheel zooming on the map. The scrollwheel is enabled by default.")]
        public bool EnableScrollWheelZoom { get; set; }

        /// <summary>
        /// The initial enabled/disabled state of the Street View Pegman control. 
        /// This control is part of the default UI, and should be set to false when displaying a map type 
        /// on which the Street View road overlay should not appear (e.g. a non-Earth map type).
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show street view control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The initial enabled/disabled state of the Street View pegman control.")]
        public bool EnableStreetViewControl { get; set; }

        /// <summary>
        /// The enabled/disabled state of the Zoom control.
        /// </summary>
        /// <value><c>true</c> if [enable zoom control]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Zoom control.")]
        public bool EnableZoomControl { get; set; }

        /// <summary>
        /// Gets or sets the client enterprise key.
        /// </summary>
        /// <value>The key.</value>
        [Category("Google")]
        [Description("The Enterprise key obtained from google premier maps.")]
        public string EnterpriseKey { get; set; }

        /// <summary>
        /// The heading for aerial imagery in degrees measured clockwise from cardinal direction North. 
        /// Headings are snapped to the nearest available angle for which imagery is available.
        /// </summary>
        /// <value>The heading.</value>
        [Category("Appearance")]
        [Description("The heading for aerial imagery in degrees measured clockwise from cardinal direction North.")]
        public int? Heading { get; set; }

        /// <summary>
        /// Use of the Google Maps API requires that you indicate whether your application 
        /// is using a sensor (such as a GPS locator) to determine the user's location. 
        /// This is especially important for mobile devices. 
        /// Applications must pass a required sensor parameter to the Maps API javascript code, 
        /// indicating whether or not your application is using a sensor device.
        /// </summary>
        /// <value><c>true</c> if this instance is sensor; otherwise, <c>false</c>.</value>
        [Category("Google")]
        [Description("Use of the Google Maps API requires that you indicate whether your application is using a sensor (such as a GPS locator) to determine the user's location.")]
        // TODO make this auto detecting feature
        public bool IsSensor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is static.
        /// </summary>
        /// <value><c>true</c> if this instance is static; otherwise, <c>false</c>.</value>
        [Category("Google")]
        [Description("Value indicating whether this instance is static.")]
        public bool IsStatic { get; set; }

        /// <summary>
        /// All Maps API applications* should load the Maps API using an API key. 
        /// Using an API key enables you to monitor your application's Maps API usage, and ensures that Google can contact you about your application if necessary. 
        /// If your application's Maps API usage exceeds the Usage Limits (https://developers.google.com/maps/documentation/javascript/usage#usage_limits), 
        /// you must load the Maps API using an API key in order to purchase additional quota.
        /// <b>
        /// Google Maps API for Business developers must not include a key in their requests. 
        /// Please refer to Loading the Google Maps JavaScript API for Business-specific instructions(https://developers.google.com/maps/documentation/business/clientside#MapsJS).
        /// </b>
        /// To create your API key:
        /// <list type="number">
        /// <item>
        ///     <description>
        ///         Visit the APIs Console at https://code.google.com/apis/console and log in with your Google Account.
        ///     </description>
        /// </item>
        /// <item>
        ///     <description>
        ///         Click the Services link from the left-hand menu.
        ///     </description>
        /// </item>
        /// <item>
        ///     <description>
        ///         Activate the Google Maps API v3 service.
        ///     </description>
        /// </item>
        /// <item>
        ///     <description>
        ///         Click the API Access link from the left-hand menu. Your API key is available from the API Access page, in the Simple API Access section. Maps API applications use the Key for browser apps.
        ///     </description>
        /// </item>
        /// </list>
        /// </summary>
        [Category("Google")]
        [DefaultValue("")]
        [Description("The key obtained from Google Maps API.")]
        public string Key
        {
            get
            {
                return (_key != null)
                    ? _key : WebConfigurationManager.AppSettings["GoogleMapKey"];
            }
            set { _key = value; }
        }
        string _key;


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
        /// Gets or sets the initial map center latitude.
        /// This property is kept for backward compatability, concider using the new <c>Center</c> property.
        /// </summary>
        /// <value>The latitude.</value>
        [Category("Data")]
        public double Latitude {
            get { return this.Center.Latitude; }
            set { this.Center.Latitude = value; }
        }

        /// <summary>
        /// Gets or sets the initial map center longitude.
        /// This property is kept for backward compatability, concider using the new <c>Center</c> property.
        /// </summary>
        /// <value>The longitude.</value>
        [Category("Data")]
        public double Longitude {
            get { return this.Center.Longitude; }
            set { this.Center.Longitude = value; }
        }

        /// <summary>
        /// The initial Map mapTypeId. Required.
        /// You must specifically set an initial map type to see appropriate tiles.
        /// </summary>
        /// <value>The type of the map.</value>
        [Category("Appearance")]
        [Description("The initial Map mapTypeId. Required.")]
        public MapType MapType { get; set; }

        /// <summary>
        /// The initial display options for the Map type control.
        /// </summary>
        /// <value>The map type control options.</value>
        [Category("Appearance")]
        [Description("The initial display options for the Map type control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MapTypeControlOptions MapTypeControlOptions {
            get {
                return _mapTypeControlOptions ?? (_mapTypeControlOptions = new MapTypeControlOptions());
            }
            set { _mapTypeControlOptions = value; }
        }
        MapTypeControlOptions _mapTypeControlOptions;


        /// <summary>
        /// The maximum zoom level which will be displayed on the map. 
        /// If omitted, or set to null, the maximum zoom from the current map type is used instead.
        /// </summary>
        /// <value>The max zoom.</value>
        [Category("Appearance")]
        [Description("The maximum zoom level which will be displayed on the map. If omitted, or set to null, the maximum zoom from the current map type is used instead.")]
        public int? MaxZoom { get; set; }

        /// <summary>
        /// The minimum zoom level which will be displayed on the map. 
        /// If omitted, or set to null, the minimum zoom from the current map type is used instead.
        /// </summary>
        /// <value>The min zoom.</value>
        [Category("Appearance")]
        [Description("The minimum zoom level which will be displayed on the map. If omitted, or set to null, the minimum zoom from the current map type is used instead.")]
        public int? MinZoom { get; set; }

        /// <summary>
        /// The display options for the Overview Map control.
        /// </summary>
        /// <value>The overview map control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Overview Map control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public OverviewMapControlOptions OverviewMapControlOptions {
            get {
                return _overviewMapControlOptions
                    ?? (_overviewMapControlOptions = new OverviewMapControlOptions());
            }
            set { _overviewMapControlOptions = value; }
        }
        OverviewMapControlOptions _overviewMapControlOptions;

        /// <summary>
        /// The display options for the Pan control.
        /// </summary>
        /// <value>The pan control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Pan control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PanControlOptions PanControlOptions {
            get {
                return _panControlOptions ?? (_panControlOptions = new PanControlOptions());
            }
            set { _panControlOptions = value; }
        }
        PanControlOptions _panControlOptions;

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
        [Description("The Maps API serves map tiles and biases application behavior, by default, using the country of the host domain from which the API is loaded (which is the USA for maps.google.com).")]
        public string Region { get; set; }

        /// <summary>
        /// The display options for the Rotate control.
        /// </summary>
        /// <value>The rotate control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Rotate control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public RotateControlOptions RotateControlOptions {
            get {
                return _rotateControlOptions ?? (_rotateControlOptions = new RotateControlOptions());
            }
            set { _rotateControlOptions = value; }
        }
        RotateControlOptions _rotateControlOptions;

        /// <summary>
        /// The initial display options for the Scale control.
        /// </summary>
        /// <value>The scale control options.</value>
        [Category("Appearance")]
        [Description("The initial display options for the Scale control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ScaleControlOptions ScaleControlOptions {
            get {
                return _scaleControlOptions ?? (_scaleControlOptions = new ScaleControlOptions());
            }
            set { _scaleControlOptions = value; }
        }
        ScaleControlOptions _scaleControlOptions;

        /// <summary>
        /// Gets or sets a value indicating whether [show traffic].
        /// </summary>
        /// <value><c>true</c> if [show traffic]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        [Description("Gets or sets a value indicating whether show traffic.")]
        public bool ShowTraffic { get; set; }

        /// <summary>
        /// Scale (zoom) value used to multiply the static map image size to define the output size in pixels.
        /// </summary>
        /// <value>The static scale.</value>
        [Category("Google")]
        [Description("Scale (zoom) value used to multiply the static map image size to define the output size in pixels.")]
        public int StaticScale { get; set; }

        /// <summary>
        /// Images may be returned in several common web graphics formats: GIF, JPEG and PNG. 
        /// </summary>
        /// <value>The static format.</value>
        [Category("Google")]
        [Description("Images may be returned in several common web graphics formats: GIF, JPEG and PNG.")]
        public StaticImageFormats StaticFormat { get; set; }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey {
            get {
                return !this.IsStatic ? HtmlTextWriterTag.Div : HtmlTextWriterTag.Img;
            }
        }

        /// <summary>
        /// The angle of incidence of the map as measured in degrees from the viewport plane to the map plane. 
        /// The only currently supported values are 0, indicating no angle of incidence (no tilt), and 45, 
        /// indicating a tilt of 45deg;. 45deg; imagery is only available for SATELLITE and HYBRID map types, 
        /// within some locations, and at some zoom levels.
        /// </summary>
        /// <value>The tilt.</value>
        [Category("Appearance")]
        [Description("The angle of incidence of the map as measured in degrees from the viewport plane to the map plane.")]
        public int Tilt { get; set; }

        /// <summary>
        /// The initial Map zoom level. Required.
        /// </summary>
        /// <value>The zoom.</value>
        [Category("Appearance")]
        [Description("The initial Map zoom level. Required.")]
        public int Zoom { get; set; }

        /// <summary>
        /// The initial zoom level of the map.
        /// This or Bounds is required in order to show the map.
        /// </summary>
        /// <value>The zoom control options.</value>
        [Category("Appearance")]
        [Description("The initial zoom level of the map. This or Bounds is required in order to show the map.")]
        public ZoomControlOptions ZoomControlOptions {
            get {
                return _zoomControlOptions ?? (_zoomControlOptions = new ZoomControlOptions());
            }
            set { _zoomControlOptions = value; }
        }
        ZoomControlOptions _zoomControlOptions;

        #endregion

        #region Collections

        /// <summary>
        /// Gets the directions.
        /// </summary>
        /// <value>The directions.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<GoogleDirections> Directions {
            get {
                return _directions ??
                    (_directions = new List<GoogleDirections>());
            }
        }
        List<GoogleDirections> _directions;

        /// <summary>
        /// Gets the markers.
        /// </summary>
        /// <value>The markers.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<Marker> Markers {
            get {
                return _markers ?? (_markers = new List<Marker>());
            }
        }
        List<Marker> _markers;

        /// <summary>
        /// Gets the polygons.
        /// </summary>
        /// <value>The polygons.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<Overlay> Overlays {
            get {
                return _overlays ?? (_overlays = new List<Overlay>());
            }
        }
        List<Overlay> _overlays;

        /// <summary>
        /// Gets the polylines.
        /// </summary>
        /// <value>The polylines.</value>
        [Category("Google")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public List<GooglePolyline> Polylines {
            get {
                return _polylines ?? (_polylines = new List<GooglePolyline>());
            }
        }
        List<GooglePolyline> _polylines;

        #endregion

        #region Events

        /// <summary>
        /// This event is fired when the viewport bounds have changed.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the viewport bounds have changed.")]
        public event EventHandler<MapEventArgs> BoundsChanged;
        /// <summary>
        /// Gets or sets the client bounds changed handler.
        /// </summary>
        /// <value>The on client bounds changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client bounds changed handler.")]
        public string OnClientBoundsChanged { get; set; }

        /// <summary>
        /// This event is fired when the map center property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map center property changes.")]
        public event EventHandler<MapEventArgs> CenterChanged;
        /// <summary>
        /// Gets or sets the client center changed handler.
        /// </summary>
        /// <value>The on client center changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client center changed handler.")]
        public string OnClientCenterChanged { get; set; }

        /// <summary>
        /// This event is fired when the user clicks on the map (but not when they click on a marker or infowindow).
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user clicks on the map (but not when they click on a marker or infowindow).")]
        public event EventHandler<MouseEventArgs> Click;
        /// <summary>
        /// Gets or sets the client click handler.
        /// </summary>
        /// <value>The on client click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client click handler.")]
        public string OnClientClick { get; set; }

        /// <summary>
        /// This event is fired when the user double-clicks on the map. Note that the click event will also fire, right before this one.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user double-clicks on the map. Note that the click event will also fire, right before this one.")]
        public event EventHandler<MouseEventArgs> DoubleClick;
        /// <summary>
        /// Gets or sets the client double click handler.
        /// </summary>
        /// <value>The on client double click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client double click handler.")]
        public string OnClientDoubleClick { get; set; }

        /// <summary>
        /// This event is repeatedly fired while the user drags the map.
        /// </summary>
        [Category("Google")]
        [Description("This event is repeatedly fired while the user drags the map.")]
        public event EventHandler<MapEventArgs> Drag;
        /// <summary>
        /// Gets or sets the client drag handler.
        /// </summary>
        /// <value>The on client drag.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag handler.")]
        public string OnClientDrag { get; set; }

        /// <summary>
        /// This event is fired when the user stops dragging the map.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user stops dragging the map.")]
        public event EventHandler<MapEventArgs> DragEnd;
        /// <summary>
        /// Gets or sets the client drag end handler.
        /// </summary>
        /// <value>The on client drag end.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag end handler.")]
        public string OnClientDragEnd { get; set; }

        /// <summary>
        /// This event is fired when the user starts dragging the map.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user starts dragging the map.")]
        public event EventHandler<MapEventArgs> DragStart;
        /// <summary>
        /// Gets or sets the client drag start handler.
        /// </summary>
        /// <value>The on client drag start.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag start handler.")]
        public string OnClientDragStart { get; set; }

        /// <summary>
        /// This event is fired when the map heading property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map heading property changes.")]
        public event EventHandler HeadingChanged;
        /// <summary>
        /// Gets or sets the client heading changed handler.
        /// </summary>
        /// <value>The on client heading changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client heading changed handler.")]
        public string OnClientHeadingChanged { get; set; }

        /// <summary>
        /// This event is fired when the map becomes idle after panning or zooming.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map becomes idle after panning or zooming.")]
        public event EventHandler Idle;
        /// <summary>
        /// Gets or sets the client idle handler.
        /// </summary>
        [Category("Client Event")]
        [Description("Gets or sets the client idle handler.")]
        public string OnClientIdle;

        /// <summary>
        /// This event is fired when the mapTypeId property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the mapTypeId property changes.")]
        public event EventHandler<MapEventArgs> MapTypeChanged;
        /// <summary>
        /// Gets or sets the client map type changed handler.
        /// </summary>
        /// <value>The on client map type changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client map type changed handler.")]
        public string OnClientMapTypeChanged { get; set; }

        /// <summary>
        /// This event is fired whenever the user's mouse moves over the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired whenever the user's mouse moves over the map container.")]
        public event EventHandler<MouseEventArgs> MouseMove;
        /// <summary>
        /// Gets or sets the client mouse move handler.
        /// </summary>
        /// <value>The on client mouse move.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse move handler.")]
        public string OnClientMouseMove { get; set; }

        /// <summary>
        /// This event is fired when the user's mouse exits the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user's mouse exits the map container.")]
        public event EventHandler<MouseEventArgs> MouseOut;
        /// <summary>
        /// Gets or sets the client mouse out handler.
        /// </summary>
        /// <value>The on client mouse out.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse out handler.")]
        public string OnClientMouseOut { get; set; }

        /// <summary>
        /// This event is fired when the user's mouse enters the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user's mouse enters the map container.")]
        public event EventHandler<MouseEventArgs> MouseOver;
        /// <summary>
        /// Gets or sets the client mouse over handler.
        /// </summary>
        /// <value>The on client mouse over.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse over handler.")]
        public string OnClientMouseOver { get; set; }

        /// <summary>
        /// This event is fired when the projection has changed.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the projection has changed.")]
        public event EventHandler ProjectionChanged;
        /// <summary>
        /// Gets or sets the client projection changed handler.
        /// </summary>
        /// <value>The on client projection changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client projection changed handler.")]
        public string OnClientProjectionChanged { get; set; }

        /// <summary>
        /// This event is fired on the map when the div changes size.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired on the map when the div changes size.")]
        public event EventHandler<MapEventArgs> Resize;
        /// <summary>
        /// Gets or sets the client resize handler.
        /// </summary>
        /// <value>The on resize.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client resize handler.")]
        public string OnClientResize { get; set; }

        /// <summary>
        /// This event is fired when the DOM contextmenu event is fired on the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM contextmenu event is fired on the map container.")]
        public event EventHandler<MouseEventArgs> RightClick;
        /// <summary>
        /// Gets or sets the client right click handler.
        /// </summary>
        /// <value>The on client right click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client right click handler.")]
        public string OnClientRightClick { get; set; }

        /// <summary>
        /// This event is fired when the visible tiles have finished loading.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the visible tiles have finished loading.")]
        public event EventHandler TilesLoaded;
        /// <summary>
        /// Gets or sets the client tiles loaded handler.
        /// </summary>
        /// <value>The on client tiles loaded.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client tiles loaded handler.")]
        public string OnClientTilesLoaded { get; set; }

        /// <summary>
        /// This event is fired when the map tilt property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map tilt property changes.")]
        public event EventHandler TiltChanged;
        /// <summary>
        /// Gets or sets the client tilt changed handler.
        /// </summary>
        /// <value>The on client tilt changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client tilt changed handler.")]
        public string OnClientTiltChanged { get; set; }

        /// <summary>
        /// This event is fired when the map zoom property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map zoom property changes.")]
        public event EventHandler<MapEventArgs> ZoomChanged;
        /// <summary>
        /// Gets or sets the client zoom changed handler.
        /// </summary>
        /// <value>The on client zoom changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client zoom changed handler.")]
        public string OnClientZoomChanged { get; set; }

        #endregion

        #region Ctor

        ///
        public GoogleMap(LatLng center)
        {
            this.Center = center;

            this.BackColor = Color.Gray;
            this.Draggable = true;
            this.EnableMapTypeControl = true;
            this.EnableOverviewMapControl = true;
            //this.EnablePanControl = true;
            this.EnableScaleControl = true;
            this.EnableScrollWheelZoom = true;
            this.EnableStreetViewControl = true;
            this.EnableZoomControl = true;
            this.StaticScale = 1;
            this.Width = new Unit("640px");
            this.Height = new Unit("480px");
        }

        ///
        public GoogleMap(LatLng center, int zoom)
            : this(center)
        {
            this.Zoom = zoom;
        }

        ///
        public GoogleMap(Bounds bounds, int zoom)
            : this((LatLng)null)
        {
            this.Bounds = bounds;
            this.Zoom = zoom;
        }

        ///
        public GoogleMap(Bounds bounds)
            : this((LatLng)null)
        {
            this.Bounds = bounds;
        }

        /// 
        public GoogleMap(int zoom)
            : this((LatLng)null)
        {
            this.Zoom = zoom;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMap"/> class.
        /// </summary>
        public GoogleMap() : this(4) {
        }
        #endregion

        #region Methods

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls() {

            this.Controls.Clear();

            if (_directions != null) {
                for (int i = 0; i < _directions.Count; i++) {
                    _directions[i].ID = this.ID + "_GoogleDirections" + (i + 1).ToString();
                    _directions[i].TargetControlID = this.ID;
                    this.Controls.Add(_directions[i]);
                }
            }
            if (_markers != null) {
                this.Controls.Add(new GoogleMarkers { 
                    ID = this.ID + "_GoogleMarkers",
                    TargetControlID = this.ID,
                    Markers = _markers
                });
            }
            if (_overlays != null) {
                for (int i = 0; i < _overlays.Count; i++) {
                    _overlays[i].ID = this.ID + "_GooglePolygon" + (i + 1).ToString();
                    _overlays[i].TargetControlID = this.ID;
                    this.Controls.Add(_overlays[i]);
                }
            }
            if (_polylines != null) {
                for (int i = 0; i < _polylines.Count; i++) {
                    _polylines[i].ID = this.ID + "_GooglePolyline" + (i + 1).ToString();
                    _polylines[i].TargetControlID = this.ID;
                    this.Controls.Add(_polylines[i]);
                }
            }

            this.ClearChildViewState();
        }

        /// <summary>
        /// Gets the script descriptors.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable"/> collection of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors() {

            var descriptor = new ScriptControlDescriptor("Artem.Google.Map", this.ClientID);

            #region properties

            if (this.Address != null)
                descriptor.AddProperty("address", this.Address);
            if (_center != null)
                descriptor.AddProperty("center", _center.ToScriptData());
            if (this.DefaultAddress != null)
                descriptor.AddProperty("defaultAddress", this.DefaultAddress);
            if (this.Bounds != null)
                descriptor.AddProperty("bounds", this.Bounds.ToScriptData());
            descriptor.AddProperty("mapType", this.MapType);
            descriptor.AddProperty("zoom", this.Zoom);
            descriptor.AddProperty("name", this.UniqueID);
            descriptor.AddProperty("shortID", this.ID);

            descriptor.AddProperty("backgroundColor", ColorTranslator.ToHtml(this.BackColor));
            descriptor.AddProperty("noClear", this.DisableClear);
            descriptor.AddProperty("disableDefaultUI", this.DisableDefaultUI);
            descriptor.AddProperty("disableDoubleClickZoom", this.DisableDoubleClickZoom);
            descriptor.AddProperty("keyboardShortcuts", this.DisableKeyboardShortcuts);
            descriptor.AddProperty("draggable", this.Draggable);
            if (this.DraggableCursor != null)
                descriptor.AddProperty("draggableCursor", this.DraggableCursor);
            if (this.DraggingCursor != null)
                descriptor.AddProperty("draggingCursor", this.DraggingCursor);
            descriptor.AddProperty("mapTypeControl", this.EnableMapTypeControl);
            descriptor.AddProperty("overviewMapControl", this.EnableOverviewMapControl);
            descriptor.AddProperty("panControl", this.EnablePanControl);
            descriptor.AddProperty("enableReverseGeocoding", this.EnableReverseGeocoding);
            descriptor.AddProperty("rotateControl", this.EnableRotateControl);
            descriptor.AddProperty("scaleControl", this.EnableScaleControl);
            descriptor.AddProperty("scrollwheel", this.EnableScrollWheelZoom);
            descriptor.AddProperty("streetViewControl", this.EnableStreetViewControl);
            descriptor.AddProperty("zoomControl", this.EnableZoomControl);
            if (this.Heading.HasValue)
                descriptor.AddProperty("heading", this.Heading);
            if (this.Language != null)
                descriptor.AddProperty("language", this.Language);
            if (this.MapTypeControlOptions != null)
                descriptor.AddProperty("mapTypeControlOptions", this.MapTypeControlOptions.ToScriptData());
            if (this.MaxZoom.HasValue)
                descriptor.AddProperty("maxZoom", this.MaxZoom.Value);
            if (this.MinZoom.HasValue)
                descriptor.AddProperty("minZoom", this.MinZoom.Value);
            if (this.OverviewMapControlOptions != null)
                descriptor.AddProperty("overviewMapControlOptions", this.OverviewMapControlOptions.ToScriptData());
            if (this.PanControlOptions != null)
                descriptor.AddProperty("panControlOptions", this.PanControlOptions.ToScriptData());
            if (this.Region != null)
                descriptor.AddProperty("region", this.Region);
            if (this.RotateControlOptions != null)
                descriptor.AddProperty("rotateControlOptions", this.RotateControlOptions.ToScriptData());
            if (this.ScaleControlOptions != null)
                descriptor.AddProperty("scaleControlOptions", this.ScaleControlOptions.ToScriptData());
            descriptor.AddProperty("showTraffic", this.ShowTraffic);
            descriptor.AddProperty("tilt", this.Tilt);
            if (this.ZoomControlOptions != null)
                descriptor.AddProperty("zoomControlOptions", this.ZoomControlOptions.ToScriptData());

            #endregion

            #region events

            if (this.BoundsChanged != null)
                descriptor.AddEvent("boundsChanged", "Artem.Google.Map.raiseServerBoundsChanged");
            else if (this.OnClientBoundsChanged != null)
                descriptor.AddEvent("boundsChanged", this.OnClientBoundsChanged);

            if (this.CenterChanged != null)
                descriptor.AddEvent("centerChanged", "Artem.Google.Map.raiseServerCenterChanged");
            else if (this.OnClientCenterChanged != null)
                descriptor.AddEvent("centerChanged", this.OnClientCenterChanged);

            if (this.Click != null)
                descriptor.AddEvent("click", "Artem.Google.Map.raiseServerClick");
            else if (this.OnClientClick != null)
                descriptor.AddEvent("click", this.OnClientClick);

            if (this.DoubleClick != null)
                descriptor.AddEvent("doubleClick", "Artem.Google.Map.raiseServerDoubleClick");
            else if (this.OnClientDoubleClick != null)
                descriptor.AddEvent("doubleClick", this.OnClientDoubleClick);

            if (this.Drag != null)
                descriptor.AddEvent("drag", "Artem.Google.Map.raiseServerDrag");
            else if (this.OnClientDrag != null)
                descriptor.AddEvent("drag", this.OnClientDrag);

            if (this.DragEnd != null)
                descriptor.AddEvent("dragEnd", "Artem.Google.Map.raiseServerDragEnd");
            else if (this.OnClientDragEnd != null)
                descriptor.AddEvent("dragEnd", this.OnClientDragEnd);

            if (this.DragStart != null)
                descriptor.AddEvent("dragStart", "Artem.Google.Map.raiseServerDragStart");
            else if (this.OnClientDragStart != null)
                descriptor.AddEvent("dragStart", this.OnClientDragStart);

            if (this.HeadingChanged != null)
                descriptor.AddEvent("headingChanged", "Artem.Google.Map.raiseServerHeadingChanged");
            else if (this.OnClientHeadingChanged != null)
                descriptor.AddEvent("headingChanged", this.OnClientHeadingChanged);

            if (this.Idle != null)
                descriptor.AddEvent("idle", "Artem.Google.Map.raiseServerIdle");
            else if (this.OnClientIdle != null)
                descriptor.AddEvent("idle", this.OnClientIdle);

            if (this.MapTypeChanged != null)
                descriptor.AddEvent("mapTypeChanged", "Artem.Google.Map.raiseServerMapTypeChanged");
            else if (this.OnClientMapTypeChanged != null)
                descriptor.AddEvent("mapTypeChanged", this.OnClientMapTypeChanged);

            if (this.MouseMove != null)
                descriptor.AddEvent("mouseMove", "Artem.Google.Map.raiseServerMouseMove");
            else if (this.OnClientMouseMove != null)
                descriptor.AddEvent("mouseMove", this.OnClientMouseMove);

            if (this.MouseOut != null)
                descriptor.AddEvent("mouseOut", "Artem.Google.Map.raiseServerMouseOut");
            else if (this.OnClientMouseMove != null)
                descriptor.AddEvent("mouseOut", this.OnClientMouseOut);

            if (this.MouseOver != null)
                descriptor.AddEvent("mouseOver", "Artem.Google.Map.raiseServerMouseOver");
            else if (this.OnClientMouseOver != null)
                descriptor.AddEvent("mouseOver", this.OnClientMouseOver);

            if (this.ProjectionChanged != null)
                descriptor.AddEvent("projectionChanged", "Artem.Google.Map.raiseServerProjectionChanged");
            else if (this.OnClientProjectionChanged != null)
                descriptor.AddEvent("projectionChanged", this.OnClientProjectionChanged);

            if (this.Resize != null)
                descriptor.AddEvent("resize", "Artem.Google.Map.raiseServerResize");
            else if (this.OnClientResize != null)
                descriptor.AddEvent("resize", this.OnClientResize);

            if (this.RightClick != null)
                descriptor.AddEvent("rightClick", "Artem.Google.Map.raiseServerRightClick");
            else if (this.OnClientRightClick != null)
                descriptor.AddEvent("rightClick", this.OnClientRightClick);

            if (this.TilesLoaded != null)
                descriptor.AddEvent("tilesLoaded", "Artem.Google.Map.raiseServerTilesLoaded");
            else if (this.OnClientTilesLoaded != null)
                descriptor.AddEvent("tilesLoaded", this.OnClientTilesLoaded);

            if (this.TiltChanged != null)
                descriptor.AddEvent("tiltChanged", "Artem.Google.Map.raiseServerTiltChanged");
            else if (this.OnClientTiltChanged != null)
                descriptor.AddEvent("tiltChanged", this.OnClientTiltChanged);

            if (this.ZoomChanged != null)
                descriptor.AddEvent("zoomChanged", "Artem.Google.Map.raiseServerZoomChanged");
            else if (this.OnClientZoomChanged != null)
                descriptor.AddEvent("zoomChanged", this.OnClientZoomChanged);

            #endregion

            yield return descriptor;

        }

        /// <summary>
        /// Gets the script references.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable"/> collection that contains ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences() {

            string assembly = this.GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Artem.Google.Map.GoogleMap.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Map.GoogleMap.min.js", assembly);
#endif
        }

        /// <summary>
        /// Gets the static URL.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetStaticUrl() {

            string proto = this.Page.Request.IsSecureConnection ? "https" : "http";
            string url = string.Format("{0}://{1}", proto, StaticApiUrl);
            StringBuilder buffer = new StringBuilder(url);
            string center = null;
            string format = (this.StaticFormat != StaticImageFormats.JpgBaseline)
                ? this.StaticFormat.ToString().ToLower() : "jpg-baseline";

            if (this.Center != null) {
                center = this.Center.ToString();
            }
            else {
                string address = this.Address ?? this.DefaultAddress;
                if (address != null)
                    center = HttpUtility.UrlEncode(address);
            }

            buffer.AppendFormat("center={0}", center);
            buffer.AppendFormat("&zoom={0}", this.Zoom.ToString());
            buffer.AppendFormat("&size={0}x{1}", this.Width.Value, this.Height.Value);
            buffer.AppendFormat("&sensor={0}", this.IsSensor.ToString().ToLower());
            buffer.AppendFormat("&maptype={0}", this.MapType.ToString().ToLower());
            buffer.AppendFormat("&format={0}", format);
            if (!string.IsNullOrEmpty(this.Language))
                buffer.AppendFormat("&language={0}", this.Language);
            if (this.StaticScale > 1)
                buffer.AppendFormat("&scale={0}", this.StaticScale.ToString());

            // TODO add markers 
            // TODO add paths -> polylines
            // TODO add styles - features, elements, rules

            return buffer.ToString();
        }

        /// <summary>
        /// Raises the <see cref="M:System.Web.UI.Control.OnPreRender(System.EventArgs)"/> event and registers the script control with the <see cref="T:System.Web.UI.ScriptManager"/> control.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            if (!this.IsStatic) this.RegisterGoogleReference();
        }

        /// <summary>
        /// Registers the GoogleMaps API reference.
        /// </summary>
        protected virtual void RegisterGoogleReference() {

            string proto = this.Page.Request.IsSecureConnection ? "https" : "http";
            string url = string.Format("{0}://{1}", proto, ApiUrl);
            StringBuilder buffer = new StringBuilder(url);

            // business or standard api key
            if(!string.IsNullOrEmpty(this.EnterpriseKey))
                buffer.AppendFormat("client={0}&", this.EnterpriseKey);
            else if (!string.IsNullOrEmpty(this.Key))
                buffer.AppendFormat("key={0}&", this.Key);
            // version
            if (!string.IsNullOrEmpty(this.ApiVersion))
                buffer.AppendFormat("v={0}&", this.ApiVersion);
            // sensor
            buffer.AppendFormat("sensor={0}", this.IsSensor.ToString().ToLower());
            // language
            if (!string.IsNullOrEmpty(this.Language))
                buffer.AppendFormat("&language={0}", this.Language);
            // region
            if (!string.IsNullOrEmpty(this.Region))
                buffer.AppendFormat("&region={0}", this.Region);

            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), "maps.google.com", buffer.ToString());
        }

        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer) {

            if (!this.IsStatic) {
                base.RenderBeginTag(writer);
            }
            else {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "map");
                writer.AddAttribute(HtmlTextWriterAttribute.Src, this.GetStaticUrl());
                writer.RenderBeginTag(this.TagKey);
            }
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Raises the <see cref="E:BoundsChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.BoundsEventArgs"/> instance containing the event data.</param>
        protected virtual void OnBoundsChanged(MapEventArgs e) {
            if (this.BoundsChanged != null) this.BoundsChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:CenterChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCenterChanged(MapEventArgs e) {
            if (this.CenterChanged != null) this.CenterChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(MouseEventArgs e) {
            if (this.Click != null) this.Click(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DoubleClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDoubleClick(MouseEventArgs e) {
            if (this.DoubleClick != null) this.DoubleClick(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Drag"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.BoundsEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDrag(MapEventArgs e) {
            if (this.Drag != null) this.Drag(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DragEnd"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.BoundsEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDragEnd(MapEventArgs e) {
            if (this.DragEnd != null) this.DragEnd(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DragStart"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.BoundsEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDragStart(MapEventArgs e) {
            if (this.DragStart != null) this.DragStart(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:HeadingChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnHeadingChanged(EventArgs e) {
            if (this.HeadingChanged != null) this.HeadingChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Idle"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnIdle(EventArgs e) {
            if (this.Idle != null) this.Idle(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MapTypeChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MapEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMapTypeChanged(MapEventArgs e) {
            if (this.MapTypeChanged != null) this.MapTypeChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseMove(MouseEventArgs e) {
            if (this.MouseMove != null) this.MouseMove(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseOut"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseOut(MouseEventArgs e) {
            if (this.MouseOut != null) this.MouseOut(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseOver"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseOver(MouseEventArgs e) {
            if (this.MouseOver != null) this.MouseOver(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:ProjectionChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnProjectionChanged(EventArgs e) {
            if (this.ProjectionChanged != null) this.ProjectionChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Resize"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MapEventArgs"/> instance containing the event data.</param>
        protected virtual void OnResize(MapEventArgs e) {
            if (this.Resize != null) this.Resize(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:RightClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnRightClick(MouseEventArgs e) {
            if (this.RightClick != null) this.RightClick(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:TilesLoaded"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTilesLoaded(EventArgs e) {
            if (this.TilesLoaded != null) this.TilesLoaded(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:TiltChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnTiltChanged(EventArgs e) {
            if (this.TiltChanged != null) this.TiltChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:ZoomChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MapEventArgs"/> instance containing the event data.</param>
        protected virtual void OnZoomChanged(MapEventArgs e) {
            if (this.ZoomChanged != null) this.ZoomChanged(this, e);
        }

        /// <summary>
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {

            var ser = new JavaScriptSerializer();
            dynamic args = ser.DeserializeObject(eventArgument);
            if (args != null) {
                string name = args["name"];
                switch (name) {
                    case "boundsChanged":
                        this.OnBoundsChanged(MapEventArgs.FromScriptData(args));
                        break;
                    case "centerChanged":
                        this.OnCenterChanged(MapEventArgs.FromScriptData(args));
                        break;
                    case "click":
                        this.OnClick(MouseEventArgs.FromScriptData(args));
                        break;
                    case "doubleClick":
                        this.OnDoubleClick(MouseEventArgs.FromScriptData(args));
                        break;
                    case "drag":
                        this.OnDrag(MapEventArgs.FromScriptData(args));
                        break;
                    case "dragEnd":
                        this.OnDragEnd(MapEventArgs.FromScriptData(args));
                        break;
                    case "dragStart":
                        this.OnDragStart(MapEventArgs.FromScriptData(args));
                        break;
                    case "headingChanged":
                        this.OnHeadingChanged(EventArgs.Empty);
                        break;
                    case "idle":
                        this.OnIdle(EventArgs.Empty);
                        break;
                    case "mapTypeChanged":
                        this.OnMapTypeChanged(MapEventArgs.FromScriptData(args));
                        break;
                    case "mouseMove":
                        this.OnMouseMove(MouseEventArgs.FromScriptData(args));
                        break;
                    case "mouseOut":
                        this.OnMouseOut(MouseEventArgs.FromScriptData(args));
                        break;
                    case "mouseOver":
                        this.OnMouseOver(MouseEventArgs.FromScriptData(args));
                        break;
                    case "projectionChanged":
                        this.OnProjectionChanged(EventArgs.Empty);
                        break;
                    case "resize":
                        this.OnResize(MapEventArgs.FromScriptData(args));
                        break;
                    case "rightClick":
                        this.OnRightClick(MouseEventArgs.FromScriptData(args));
                        break;
                    case "tilesLoaded":
                        this.OnTilesLoaded(EventArgs.Empty);
                        break;
                    case "tiltChanged":
                        this.OnTiltChanged(EventArgs.Empty);
                        break;
                    case "zoomChanged":
                        this.OnZoomChanged(MapEventArgs.FromScriptData(args));
                        break;
                }
            }
        }
        #endregion
    }
}