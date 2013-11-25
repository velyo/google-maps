using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("Artem.Google.Map.GoogleMap.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Map.GoogleMap.min.js", "text/javascript")]

namespace Artem.Google.UI
{
    /// <summary>
    /// </summary>
    [Designer("Artem.Google.UI.GoogleMapDesigner, Artem.Google, Version=6.0.0.0, Culture=neutral, PublicKeyToken=fc8d6190a3aeb01c")]
    [ToolboxData("<{0}:GoogleMap runat=\"server\"></{0}:GoogleMap>")]
    public class GoogleMap : ScriptControl, IPostBackEventHandler
    {
        #region Static Fields

        /// <summary>
        ///     The GoogleMaps API script URL.
        ///     The property is not longer readonly in order to provide ability for changing it per application.
        ///     For example, if it is changed in the future this property could be set in Global.asax per appliation.
        ///     The protocol should be omitted from the specified URL in order to allow
        ///     control to automatically switch to HTTPS when requested under SSL.
        /// </summary>
        public static string ApiUrl = "maps.googleapis.com/maps/api/js?";

        /// <summary>
        ///     The Static Maps API script URL.
        ///     The protocol should be omitted from the specified URL in order to allow
        ///     control to automatically switch to HTTPS when requested under SSL.
        /// </summary>
        public static string StaticApiUrl = "maps.googleapis.com/maps/api/staticmap?";

        #endregion

        #region Properties

        /// <summary>
        ///     The address to geocode and set the initial map center.
        /// </summary>
        /// <value>The address.</value>
        [Category("Data")]
        [Description("The address to geocode and set the initial map center.")]
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the Google Maps API version.
        ///     You can indicate which version of the API to load within your application.
        /// </summary>
        /// <value>The maps API version.</value>
        [Category("Google")]
        [Description("You can indicate which version of the API to load within your application.")]
        public string ApiVersion { get; set; }

        /// <summary>
        ///     The initial Bounds of the map.
        ///     This or Zoom is required in order to show the map.
        /// </summary>
        [Category("Appearance")]
        [Description("The initial Bounds of the map. This or Zoom is required in order to show the map.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Bounds Bounds { get; set; }

        /// <summary>
        ///     The initial LatLng map center.
        ///     This is a new property which handles the <c>Latitude</c> and <c>Longitude</c> values.
        ///     The initial map center LatLng can be set through <c>Latitude</c> and <c>Longitude</c> properties of
        ///     <c>Center</c> or by comma seprated values pair string.
        ///     For example:
        ///     <c>
        ///         GoogleMap1.Center.Latitude = 42.1229;
        ///         GoogleMap1.Center.Longitude = 24.7879;
        ///     </c>
        ///     or
        ///     <c>GoogleMap1.Center = "42.1229,24.7879";</c>
        /// </summary>
        /// <value>The center.</value>
        [Category("Data")]
        [Description("The initial LatLng map center. This is required in order to show the map.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLng Center
        {
            get { return _center ?? (_center = new LatLng()); }
            set { _center = value; }
        }

        private LatLng _center;

        /// <summary>
        ///     The address to geocode and set as initial map center, when the provided <c>Address</c>
        ///     is not valid or failed to geocode.
        ///     This property can be used to avoid "gray" maps, when the address set to the controls is not valid.
        /// </summary>
        /// <value>The default address.</value>
        [Category("Data")]
        [Description("The address to geocode and set as initial map center, when the provided Address is not valid or failed to geocode.")]
        public string DefaultAddress { get; set; }

        /// <summary>
        ///     If true, do not clear the contents of the Map div.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [disable clear]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("If true, do not clear the contents of the Map div.")]
        public bool DisableClear { get; set; }

        /// <summary>
        ///     Enables/disables all default UI. May be overridden individually.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [disable default UI]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("Enables/disables all default UI. May be overridden individually.")]
        public bool DisableDefaultUI { get; set; }

        /// <summary>
        ///     Enables/disables zoom and center on double click. Enabled by default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [double click zoom]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("Enables/disables zoom and center on double click. Enabled by default.")]
        public bool DisableDoubleClickZoom { get; set; }

        /// <summary>
        ///     If false, prevents the map from being controlled by the keyboard.
        ///     Keyboard shortcuts are enabled by default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [disable keyboard shortcuts]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("If false, prevents the map from being controlled by the keyboard. Keyboard shortcuts are enabled by default.")]
        public bool DisableKeyboardShortcuts { get; set; }

        /// <summary>
        ///     If false, prevents the map from being dragged. Dragging is enabled by default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [enable dragging]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("If false, prevents the map from being dragged. Dragging is enabled by default.")]
        public bool Draggable { get; set; }

        /// <summary>
        ///     The name or url of the cursor to display on a draggable object.
        /// </summary>
        /// <value>The draggable cursor.</value>
        [Category("Behavior")]
        [Description("The name or url of the cursor to display on a draggable object.")]
        public string DraggableCursor { get; set; }

        /// <summary>
        ///     The name or url of the cursor to display when an object is dragging.
        /// </summary>
        /// <value>The dragging cursor.</value>
        [Category("Behavior")]
        [Description("The name or url of the cursor to display when an object is dragging.")]
        public string DraggingCursor { get; set; }

        /// <summary>
        ///     The initial enabled/disabled state of the Map type control.
        ///     By default it is set to <c>true</c> and map type control is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show map type control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("The initial enabled/disabled state of the Map type control.")]
        public bool EnableMapTypeControl { get; set; }

        /// <summary>
        ///     The enabled/disabled state of the Overview Map control.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show overview map control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Overview Map control.")]
        public bool EnableOverviewMapControl { get; set; }

        /// <summary>
        ///     The enabled/disabled state of the Pan control.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [pan control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Pan control.")]
        public bool EnablePanControl { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether reverse geocoding (address lookup) is enabled.
        ///     When the reverse geocoding is enabled the intial map center location is translated to
        ///     a human-readable address, known as reverse geocoding.
        ///     Once the location is translated to a human-readable address, its value is saved in the
        ///     <c>Address</c> property of the GoogleMap Control and persisted during the postback.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [enable reverse geocoding]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [Description("Value indicating whether reverse geocoding (address lookup) is enabled.")]
        public bool EnableReverseGeocoding { get; set; }

        /// <summary>
        ///     The enabled/disabled state of the Rotate control.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [rotate control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Rotate control.")]
        public bool EnableRotateControl { get; set; }

        /// <summary>
        ///     The initial enabled/disabled state of the Scale control.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [enable scale control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The initial enabled/disabled state of the Scale control.")]
        public bool EnableScaleControl { get; set; }

        /// <summary>
        ///     If false, disables scrollwheel zooming on the map. The scrollwheel is enabled by default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [enable scroll wheel zoom]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("If false, disables scrollwheel zooming on the map. The scrollwheel is enabled by default.")]
        public bool EnableScrollWheelZoom { get; set; }

        /// <summary>
        ///     The initial enabled/disabled state of the Street View Pegman control.
        ///     This control is part of the default UI, and should be set to false when displaying a map type
        ///     on which the Street View road overlay should not appear (e.g. a non-Earth map type).
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show street view control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The initial enabled/disabled state of the Street View pegman control.")]
        public bool EnableStreetViewControl { get; set; }

        /// <summary>
        ///     The enabled/disabled state of the Zoom control.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [enable zoom control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the Zoom control.")]
        public bool EnableZoomControl { get; set; }

        /// <summary>
        ///     Gets or sets the client enterprise key.
        /// </summary>
        /// <value>The key.</value>
        [Category("Google")]
        [Description("The Enterprise key obtained from google premier maps.")]
        public string EnterpriseKey { get; set; }

        /// <summary>
        ///     The heading for aerial imagery in degrees measured clockwise from cardinal direction North.
        ///     Headings are snapped to the nearest available angle for which imagery is available.
        /// </summary>
        /// <value>The heading.</value>
        [Category("Appearance")]
        [Description("The heading for aerial imagery in degrees measured clockwise from cardinal direction North.")]
        public int? Heading { get; set; }

        /// <summary>
        ///     Use of the Google Maps API requires that you indicate whether your application
        ///     is using a sensor (such as a GPS locator) to determine the user's location.
        ///     This is especially important for mobile devices.
        ///     Applications must pass a required sensor parameter to the Maps API javascript code,
        ///     indicating whether or not your application is using a sensor device.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is sensor; otherwise, <c>false</c>.
        /// </value>
        [Category("Google")]
        [Description("Use of the Google Maps API requires that you indicate whether your application is using a sensor (such as a GPS locator) to determine the user's location.")]
        // TODO make this auto detecting feature
        public bool IsSensor { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is static.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is static; otherwise, <c>false</c>.
        /// </value>
        [Category("Google")]
        [Description("Value indicating whether this instance is static.")]
        public bool IsStatic { get; set; }

        /// <summary>
        ///     All Maps API applications* should load the Maps API using an API key.
        ///     Using an API key enables you to monitor your application's Maps API usage, and ensures that Google can contact you about your application if necessary.
        ///     If your application's Maps API usage exceeds the Usage Limits (https://developers.google.com/maps/documentation/javascript/usage#usage_limits),
        ///     you must load the Maps API using an API key in order to purchase additional quota.
        ///     <b>
        ///         Google Maps API for Business developers must not include a key in their requests.
        ///         Please refer to Loading the Google Maps JavaScript API for Business-specific instructions(https://developers.google.com/maps/documentation/business/clientside#MapsJS).
        ///     </b>
        ///     To create your API key:
        ///     <list type="number">
        ///         <item>
        ///             <description>
        ///                 Visit the APIs Console at https://code.google.com/apis/console and log in with your Google Account.
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 Click the Services link from the left-hand menu.
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 Activate the Google Maps API v3 service.
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 Click the API Access link from the left-hand menu. Your API key is available from the API Access page, in the Simple API Access section. Maps API applications use the Key for browser apps.
        ///             </description>
        ///         </item>
        ///     </list>
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

        private string _key;


        /// <summary>
        ///     The Google Maps API uses the browser's preferred language setting when displaying
        ///     textual information such as the names for controls, copyright notices,
        ///     driving directions and labels on maps. In most cases, this is preferable;
        ///     you usually do not wish to override the user's preferred language setting.
        ///     However, if you wish to change the Maps API to ignore the browser's language
        ///     setting and force it to display information in a particular language,
        ///     you can specifying the language to use.
        /// </summary>
        /// <value>The language.</value>
        [Category("Appearance")]
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the initial map center latitude.
        ///     This property is kept for backward compatability, concider using the new <c>Center</c> property.
        /// </summary>
        /// <value>The latitude.</value>
        [Category("Data")]
        public double Latitude
        {
            get { return Center.Latitude; }
            set { Center.Latitude = value; }
        }

        /// <summary>
        ///     Gets or sets the initial map center longitude.
        ///     This property is kept for backward compatability, concider using the new <c>Center</c> property.
        /// </summary>
        /// <value>The longitude.</value>
        [Category("Data")]
        public double Longitude
        {
            get { return Center.Longitude; }
            set { Center.Longitude = value; }
        }

        /// <summary>
        ///     The initial Map mapTypeId. Required.
        ///     You must specifically set an initial map type to see appropriate tiles.
        /// </summary>
        /// <value>The type of the map.</value>
        [Category("Appearance")]
        [Description("The initial Map mapTypeId. Required.")]
        public MapType MapType { get; set; }

        /// <summary>
        ///     The initial display options for the Map type control.
        /// </summary>
        /// <value>The map type control options.</value>
        [Category("Appearance")]
        [Description("The initial display options for the Map type control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MapTypeControlOptions MapTypeControlOptions
        {
            get { return _mapTypeControlOptions ?? (_mapTypeControlOptions = new MapTypeControlOptions()); }
            set { _mapTypeControlOptions = value; }
        }

        private MapTypeControlOptions _mapTypeControlOptions;


        /// <summary>
        ///     The maximum zoom level which will be displayed on the map.
        ///     If omitted, or set to null, the maximum zoom from the current map type is used instead.
        /// </summary>
        /// <value>The max zoom.</value>
        [Category("Appearance")]
        [Description("The maximum zoom level which will be displayed on the map. If omitted, or set to null, the maximum zoom from the current map type is used instead.")]
        public int? MaxZoom { get; set; }

        /// <summary>
        ///     The minimum zoom level which will be displayed on the map.
        ///     If omitted, or set to null, the minimum zoom from the current map type is used instead.
        /// </summary>
        /// <value>The min zoom.</value>
        [Category("Appearance")]
        [Description("The minimum zoom level which will be displayed on the map. If omitted, or set to null, the minimum zoom from the current map type is used instead.")]
        public int? MinZoom { get; set; }

        /// <summary>
        ///     The display options for the Overview Map control.
        /// </summary>
        /// <value>The overview map control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Overview Map control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public OverviewMapControlOptions OverviewMapControlOptions
        {
            get
            {
                return _overviewMapControlOptions
                       ?? (_overviewMapControlOptions = new OverviewMapControlOptions());
            }
            set { _overviewMapControlOptions = value; }
        }

        private OverviewMapControlOptions _overviewMapControlOptions;

        /// <summary>
        ///     The display options for the Pan control.
        /// </summary>
        /// <value>The pan control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Pan control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PanControlOptions PanControlOptions
        {
            get { return _panControlOptions ?? (_panControlOptions = new PanControlOptions()); }
            set { _panControlOptions = value; }
        }

        private PanControlOptions _panControlOptions;

        /// <summary>
        ///     The Maps API serves map tiles and biases application behavior, by default, using the
        ///     country of the host domain from which the API is loaded (which is the USA for maps.google.com).
        ///     If you wish to alter your application to serve different map tiles or bias the
        ///     application (such as biasing geocoding results towards the region), you can override
        ///     this default behavior by adding a region parameter to the Maps API javascript code.
        ///     The region parameter accepts Unicode region subtag identifiers which (generally)
        ///     have a one-to-one mapping to country code Top-Level Domains (ccTLDs).
        ///     Most Unicode region identifiers are identical to ISO 3166-1 codes, with some notable exceptions.
        ///     For example, Great Britain's ccTLD is "uk" (corresponding to the domain .co.uk)
        ///     while its region identifier is "GB."
        ///     For example, to use a Maps API application localized to the United Kingdom, add this settings to the code-behind as shown below:
        ///     <code>GoogleMap1.Region = "GB";</code>
        /// </summary>
        /// <value>The region.</value>
        [Category("Appearance")]
        [Description("The Maps API serves map tiles and biases application behavior, by default, using the country of the host domain from which the API is loaded (which is the USA for maps.google.com).")]
        public string Region { get; set; }

        /// <summary>
        ///     The display options for the Rotate control.
        /// </summary>
        /// <value>The rotate control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Rotate control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public RotateControlOptions RotateControlOptions
        {
            get { return _rotateControlOptions ?? (_rotateControlOptions = new RotateControlOptions()); }
            set { _rotateControlOptions = value; }
        }

        private RotateControlOptions _rotateControlOptions;

        /// <summary>
        ///     The initial display options for the Scale control.
        /// </summary>
        /// <value>The scale control options.</value>
        [Category("Appearance")]
        [Description("The initial display options for the Scale control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ScaleControlOptions ScaleControlOptions
        {
            get { return _scaleControlOptions ?? (_scaleControlOptions = new ScaleControlOptions()); }
            set { _scaleControlOptions = value; }
        }

        private ScaleControlOptions _scaleControlOptions;

        /// <summary>
        ///     Gets or sets a value indicating whether [show traffic].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show traffic]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("Gets or sets a value indicating whether show traffic.")]
        public bool ShowTraffic { get; set; }

        /// <summary>
        ///     Scale (zoom) value used to multiply the static map image size to define the output size in pixels.
        /// </summary>
        /// <value>The static scale.</value>
        [Category("Google")]
        [Description("Scale (zoom) value used to multiply the static map image size to define the output size in pixels.")]
        public int StaticScale { get; set; }

        /// <summary>
        ///     Images may be returned in several common web graphics formats: GIF, JPEG and PNG.
        /// </summary>
        /// <value>The static format.</value>
        [Category("Google")]
        [Description("Images may be returned in several common web graphics formats: GIF, JPEG and PNG.")]
        public StaticImageFormats StaticFormat { get; set; }

        /// <summary>
        ///     Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag" /> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///     One of the <see cref="T:System.Web.UI.HtmlTextWriterTag" /> enumeration values.
        /// </returns>
        protected override HtmlTextWriterTag TagKey
        {
            get { return !IsStatic ? HtmlTextWriterTag.Div : HtmlTextWriterTag.Img; }
        }

        /// <summary>
        ///     The angle of incidence of the map as measured in degrees from the viewport plane to the map plane.
        ///     The only currently supported values are 0, indicating no angle of incidence (no tilt), and 45,
        ///     indicating a tilt of 45deg;. 45deg; imagery is only available for SATELLITE and HYBRID map types,
        ///     within some locations, and at some zoom levels.
        /// </summary>
        /// <value>The tilt.</value>
        [Category("Appearance")]
        [Description("The angle of incidence of the map as measured in degrees from the viewport plane to the map plane.")]
        public int Tilt { get; set; }

        /// <summary>
        ///     The initial Map zoom level. Required.
        /// </summary>
        /// <value>The zoom.</value>
        [Category("Appearance")]
        [Description("The initial Map zoom level. Required.")]
        public int Zoom { get; set; }

        /// <summary>
        ///     The initial zoom level of the map.
        ///     This or Bounds is required in order to show the map.
        /// </summary>
        /// <value>The zoom control options.</value>
        [Category("Appearance")]
        [Description("The initial zoom level of the map. This or Bounds is required in order to show the map.")]
        public ZoomControlOptions ZoomControlOptions
        {
            get { return _zoomControlOptions ?? (_zoomControlOptions = new ZoomControlOptions()); }
            set { _zoomControlOptions = value; }
        }

        private ZoomControlOptions _zoomControlOptions;

        /// <summary>
        ///     If true, when one infowindow is shown, all others are hidden
        /// </summary>
        [Category("Behavior")]
        [Description("If true, when one infowindow is shown, all others are hidden")]
        public bool? DisableMultipleInfoWindows { get; set; }


        /// <summary>
        ///     The enabled/disabled state of the search box control
        /// </summary>
        /// <value>
        ///     <c>true</c> if [rotate control]; otherwise, <c>false</c>.
        /// </value>
        [Category("Appearance")]
        [Description("The enabled/disabled state of the search box control.")]
        public bool EnableSearchBoxControl { get; set; }

        /// <summary>
        ///     Options for the rendering of the search box control. 
        /// </summary>
        /// <value>The zoom control options.</value>
        [Category("Appearance")]
        [Description("Options for the rendering of the search box control if it is enabled")]
        public SearchBoxControlOptions SearchBoxControlOptions
        {
            get { return _searchBoxControlOptions ?? (_searchBoxControlOptions = new SearchBoxControlOptions()); }
            set { _searchBoxControlOptions = value; }
        }
        private SearchBoxControlOptions _searchBoxControlOptions;


        #endregion

        #region Collections

        /// <summary>
        ///     Gets the directions.
        /// </summary>
        /// <value>The directions.</value>
        [Category("Google")]
        [Editor(typeof (CollectionEditor), typeof (UITypeEditor))]
        public List<GoogleDirections> Directions
        {
            get
            {
                return _directions ??
                       (_directions = new List<GoogleDirections>());
            }
        }

        private List<GoogleDirections> _directions;

        /// <summary>
        ///     Gets the markers.
        /// </summary>
        /// <value>The markers.</value>
        [Category("Google")]
        [Editor(typeof (CollectionEditor), typeof (UITypeEditor))]
        public List<Marker> Markers
        {
            get { return _markers ?? (_markers = new List<Marker>()); }
        }

        private List<Marker> _markers;

        /// <summary>
        ///     Gets the polygons.
        /// </summary>
        /// <value>The polygons.</value>
        [Category("Google")]
        [Editor(typeof (CollectionEditor), typeof (UITypeEditor))]
        public List<Overlay> Overlays
        {
            get { return _overlays ?? (_overlays = new List<Overlay>()); }
        }

        private List<Overlay> _overlays;

        /// <summary>
        ///     Gets the polylines.
        /// </summary>
        /// <value>The polylines.</value>
        [Category("Google")]
        [Editor(typeof (CollectionEditor), typeof (UITypeEditor))]
        public List<GooglePolyline> Polylines
        {
            get { return _polylines ?? (_polylines = new List<GooglePolyline>()); }
        }

        private List<GooglePolyline> _polylines;


        /// <summary>
        ///     List of libraries used in this map. For example: places, panoramio
        /// </summary>
        [Category("Google")]
        [Editor(typeof (CollectionEditor), typeof (UITypeEditor))]
        public HashSet<GoogleMapLibrary> Libraries
        {
            get { return _libraries ?? (_libraries = new HashSet<GoogleMapLibrary>()); }
        }

        private HashSet<GoogleMapLibrary> _libraries;

        #endregion

        #region Events

        /// <summary>
        ///     This event is fired when the viewport bounds have changed.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the viewport bounds have changed.")]
        public event EventHandler<MapEventArgs> BoundsChanged;

        /// <summary>
        ///     Gets or sets the client bounds changed handler.
        /// </summary>
        /// <value>The on client bounds changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client bounds changed handler.")]
        public string OnClientBoundsChanged { get; set; }

        /// <summary>
        ///     This event is fired when the map center property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map center property changes.")]
        public event EventHandler<MapEventArgs> CenterChanged;

        /// <summary>
        ///     Gets or sets the client center changed handler.
        /// </summary>
        /// <value>The on client center changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client center changed handler.")]
        public string OnClientCenterChanged { get; set; }

        /// <summary>
        ///     This event is fired when the user clicks on the map (but not when they click on a marker or infowindow).
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user clicks on the map (but not when they click on a marker or infowindow).")]
        public event EventHandler<MouseEventArgs> Click;

        /// <summary>
        ///     Gets or sets the client click handler.
        /// </summary>
        /// <value>The on client click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client click handler.")]
        public string OnClientClick { get; set; }

        /// <summary>
        ///     This event is fired when the user double-clicks on the map. Note that the click event will also fire, right before this one.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user double-clicks on the map. Note that the click event will also fire, right before this one.")]
        public event EventHandler<MouseEventArgs> DoubleClick;

        /// <summary>
        ///     Gets or sets the client double click handler.
        /// </summary>
        /// <value>The on client double click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client double click handler.")]
        public string OnClientDoubleClick { get; set; }

        /// <summary>
        ///     This event is repeatedly fired while the user drags the map.
        /// </summary>
        [Category("Google")]
        [Description("This event is repeatedly fired while the user drags the map.")]
        public event EventHandler<MapEventArgs> Drag;

        /// <summary>
        ///     Gets or sets the client drag handler.
        /// </summary>
        /// <value>The on client drag.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag handler.")]
        public string OnClientDrag { get; set; }

        /// <summary>
        ///     This event is fired when the user stops dragging the map.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user stops dragging the map.")]
        public event EventHandler<MapEventArgs> DragEnd;

        /// <summary>
        ///     Gets or sets the client drag end handler.
        /// </summary>
        /// <value>The on client drag end.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag end handler.")]
        public string OnClientDragEnd { get; set; }

        /// <summary>
        ///     This event is fired when the user starts dragging the map.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user starts dragging the map.")]
        public event EventHandler<MapEventArgs> DragStart;

        /// <summary>
        ///     Gets or sets the client drag start handler.
        /// </summary>
        /// <value>The on client drag start.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag start handler.")]
        public string OnClientDragStart { get; set; }

        /// <summary>
        ///     This event is fired when the map heading property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map heading property changes.")]
        public event EventHandler HeadingChanged;

        /// <summary>
        ///     Gets or sets the client heading changed handler.
        /// </summary>
        /// <value>The on client heading changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client heading changed handler.")]
        public string OnClientHeadingChanged { get; set; }

        /// <summary>
        ///     This event is fired when the map becomes idle after panning or zooming.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map becomes idle after panning or zooming.")]
        public event EventHandler Idle;

        /// <summary>
        ///     Gets or sets the client idle handler.
        /// </summary>
        [Category("Client Event")] [Description("Gets or sets the client idle handler.")] public string OnClientIdle;

        /// <summary>
        ///     This event is fired when the mapTypeId property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the mapTypeId property changes.")]
        public event EventHandler<MapEventArgs> MapTypeChanged;

        /// <summary>
        ///     Gets or sets the client map type changed handler.
        /// </summary>
        /// <value>The on client map type changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client map type changed handler.")]
        public string OnClientMapTypeChanged { get; set; }

        /// <summary>
        ///     This event is fired whenever the user's mouse moves over the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired whenever the user's mouse moves over the map container.")]
        public event EventHandler<MouseEventArgs> MouseMove;

        /// <summary>
        ///     Gets or sets the client mouse move handler.
        /// </summary>
        /// <value>The on client mouse move.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse move handler.")]
        public string OnClientMouseMove { get; set; }

        /// <summary>
        ///     This event is fired when the user's mouse exits the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user's mouse exits the map container.")]
        public event EventHandler<MouseEventArgs> MouseOut;

        /// <summary>
        ///     Gets or sets the client mouse out handler.
        /// </summary>
        /// <value>The on client mouse out.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse out handler.")]
        public string OnClientMouseOut { get; set; }

        /// <summary>
        ///     This event is fired when the user's mouse enters the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user's mouse enters the map container.")]
        public event EventHandler<MouseEventArgs> MouseOver;

        /// <summary>
        ///     Gets or sets the client mouse over handler.
        /// </summary>
        /// <value>The on client mouse over.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse over handler.")]
        public string OnClientMouseOver { get; set; }

        /// <summary>
        ///     This event is fired when the projection has changed.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the projection has changed.")]
        public event EventHandler ProjectionChanged;

        /// <summary>
        ///     Gets or sets the client projection changed handler.
        /// </summary>
        /// <value>The on client projection changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client projection changed handler.")]
        public string OnClientProjectionChanged { get; set; }

        /// <summary>
        ///     This event is fired on the map when the div changes size.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired on the map when the div changes size.")]
        public event EventHandler<MapEventArgs> Resize;

        /// <summary>
        ///     Gets or sets the client resize handler.
        /// </summary>
        /// <value>The on resize.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client resize handler.")]
        public string OnClientResize { get; set; }

        /// <summary>
        ///     This event is fired when the DOM contextmenu event is fired on the map container.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM contextmenu event is fired on the map container.")]
        public event EventHandler<MouseEventArgs> RightClick;

        /// <summary>
        ///     Gets or sets the client right click handler.
        /// </summary>
        /// <value>The on client right click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client right click handler.")]
        public string OnClientRightClick { get; set; }

        /// <summary>
        ///     This event is fired when the visible tiles have finished loading.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the visible tiles have finished loading.")]
        public event EventHandler TilesLoaded;

        /// <summary>
        ///     Gets or sets the client tiles loaded handler.
        /// </summary>
        /// <value>The on client tiles loaded.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client tiles loaded handler.")]
        public string OnClientTilesLoaded { get; set; }

        /// <summary>
        ///     This event is fired when the map tilt property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map tilt property changes.")]
        public event EventHandler TiltChanged;

        /// <summary>
        ///     Gets or sets the client tilt changed handler.
        /// </summary>
        /// <value>The on client tilt changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client tilt changed handler.")]
        public string OnClientTiltChanged { get; set; }

        /// <summary>
        ///     This event is fired when the map zoom property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the map zoom property changes.")]
        public event EventHandler<MapEventArgs> ZoomChanged;

        /// <summary>
        ///     Gets or sets the client zoom changed handler.
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
            Center = center;

            BackColor = Color.Gray;
            Draggable = true;
            EnableMapTypeControl = true;
            EnableOverviewMapControl = true;
            //this.EnablePanControl = true;
            EnableScaleControl = true;
            EnableScrollWheelZoom = true;
            EnableStreetViewControl = true;
            EnableZoomControl = true;
            StaticScale = 1;
            Width = new Unit("640px");
            Height = new Unit("480px");
        }

        ///
        public GoogleMap(LatLng center, int zoom)
            : this(center)
        {
            Zoom = zoom;
        }

        ///
        public GoogleMap(Bounds bounds, int zoom)
            : this((LatLng) null)
        {
            Bounds = bounds;
            Zoom = zoom;
        }

        ///
        public GoogleMap(Bounds bounds)
            : this((LatLng) null)
        {
            Bounds = bounds;
        }

        /// 
        public GoogleMap(int zoom)
            : this((LatLng) null)
        {
            Zoom = zoom;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GoogleMap" /> class.
        /// </summary>
        public GoogleMap() : this(4)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();

            if (_directions != null)
            {
                for (int i = 0; i < _directions.Count; i++)
                {
                    _directions[i].ID = ID + "_GoogleDirections" + (i + 1).ToString();
                    _directions[i].TargetControlID = ID;
                    Controls.Add(_directions[i]);
                }
            }
            if (_markers != null)
            {
                Controls.Add(new GoogleMarkers
                    {
                        ID = ID + "_GoogleMarkers",
                        TargetControlID = ID,
                        Markers = _markers
                    });
            }
            if (_overlays != null)
            {
                for (int i = 0; i < _overlays.Count; i++)
                {
                    _overlays[i].ID = ID + "_GooglePolygon" + (i + 1).ToString();
                    _overlays[i].TargetControlID = ID;
                    Controls.Add(_overlays[i]);
                }
            }
            if (_polylines != null)
            {
                for (int i = 0; i < _polylines.Count; i++)
                {
                    _polylines[i].ID = ID + "_GooglePolyline" + (i + 1).ToString();
                    _polylines[i].TargetControlID = ID;
                    Controls.Add(_polylines[i]);
                }
            }

            if (EnableSearchBoxControl)
            {
                Libraries.Add(GoogleMapLibrary.Places);
                Controls.Add(new TextBox {ID = ID + "_SearchBox"});
            }

            ClearChildViewState();
        }

        /// <summary>
        ///     Gets the script descriptors.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.IEnumerable" /> collection of <see cref="T:System.Web.UI.ScriptDescriptor" /> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            var descriptor = new ScriptControlDescriptor("Artem.Google.Map", ClientID);

            #region properties

            if (Address != null)
                descriptor.AddProperty("address", Address);
            if (_center != null)
                descriptor.AddProperty("center", _center.ToScriptData());
            if (DefaultAddress != null)
                descriptor.AddProperty("defaultAddress", DefaultAddress);
            if (Bounds != null)
                descriptor.AddProperty("bounds", Bounds.ToScriptData());
            descriptor.AddProperty("mapType", MapType);
            descriptor.AddProperty("zoom", Zoom);
            descriptor.AddProperty("name", UniqueID);
            descriptor.AddProperty("shortID", ID);

            descriptor.AddProperty("backgroundColor", ColorTranslator.ToHtml(BackColor));
            descriptor.AddProperty("noClear", DisableClear);
            descriptor.AddProperty("disableDefaultUI", DisableDefaultUI);
            descriptor.AddProperty("disableDoubleClickZoom", DisableDoubleClickZoom);
            descriptor.AddProperty("keyboardShortcuts", DisableKeyboardShortcuts);
            descriptor.AddProperty("draggable", Draggable);
            if (DraggableCursor != null)
                descriptor.AddProperty("draggableCursor", DraggableCursor);
            if (DraggingCursor != null)
                descriptor.AddProperty("draggingCursor", DraggingCursor);
            descriptor.AddProperty("mapTypeControl", EnableMapTypeControl);
            descriptor.AddProperty("overviewMapControl", EnableOverviewMapControl);
            descriptor.AddProperty("panControl", EnablePanControl);
            descriptor.AddProperty("enableReverseGeocoding", EnableReverseGeocoding);
            descriptor.AddProperty("rotateControl", EnableRotateControl);
            descriptor.AddProperty("scaleControl", EnableScaleControl);
            descriptor.AddProperty("scrollwheel", EnableScrollWheelZoom);
            descriptor.AddProperty("streetViewControl", EnableStreetViewControl);
            descriptor.AddProperty("zoomControl", EnableZoomControl);
            if (Heading.HasValue)
                descriptor.AddProperty("heading", Heading);
            if (Language != null)
                descriptor.AddProperty("language", Language);
            if (MapTypeControlOptions != null)
                descriptor.AddProperty("mapTypeControlOptions", MapTypeControlOptions.ToScriptData());
            if (MaxZoom.HasValue)
                descriptor.AddProperty("maxZoom", MaxZoom.Value);
            if (MinZoom.HasValue)
                descriptor.AddProperty("minZoom", MinZoom.Value);
            if (OverviewMapControlOptions != null)
                descriptor.AddProperty("overviewMapControlOptions", OverviewMapControlOptions.ToScriptData());
            if (PanControlOptions != null)
                descriptor.AddProperty("panControlOptions", PanControlOptions.ToScriptData());
            if (Region != null)
                descriptor.AddProperty("region", Region);
            if (RotateControlOptions != null)
                descriptor.AddProperty("rotateControlOptions", RotateControlOptions.ToScriptData());
            if (ScaleControlOptions != null)
                descriptor.AddProperty("scaleControlOptions", ScaleControlOptions.ToScriptData());
            descriptor.AddProperty("showTraffic", ShowTraffic);
            descriptor.AddProperty("tilt", Tilt);
            if (ZoomControlOptions != null)
                descriptor.AddProperty("zoomControlOptions", ZoomControlOptions.ToScriptData());
            if (DisableMultipleInfoWindows != null)
                descriptor.AddProperty("disableMultipleInfoWindows", DisableMultipleInfoWindows);
            descriptor.AddProperty("searchBoxControl", EnableSearchBoxControl);
            if (EnableSearchBoxControl && SearchBoxControlOptions != null)
                descriptor.AddProperty("searchBoxControlOptions", SearchBoxControlOptions.ToScriptData());

            #endregion

            #region events

            if (BoundsChanged != null)
                descriptor.AddEvent("boundsChanged", "Artem.Google.Map.raiseServerBoundsChanged");
            else if (OnClientBoundsChanged != null)
                descriptor.AddEvent("boundsChanged", OnClientBoundsChanged);

            if (CenterChanged != null)
                descriptor.AddEvent("centerChanged", "Artem.Google.Map.raiseServerCenterChanged");
            else if (OnClientCenterChanged != null)
                descriptor.AddEvent("centerChanged", OnClientCenterChanged);

            if (Click != null)
                descriptor.AddEvent("click", "Artem.Google.Map.raiseServerClick");
            else if (OnClientClick != null)
                descriptor.AddEvent("click", OnClientClick);

            if (DoubleClick != null)
                descriptor.AddEvent("doubleClick", "Artem.Google.Map.raiseServerDoubleClick");
            else if (OnClientDoubleClick != null)
                descriptor.AddEvent("doubleClick", OnClientDoubleClick);

            if (Drag != null)
                descriptor.AddEvent("drag", "Artem.Google.Map.raiseServerDrag");
            else if (OnClientDrag != null)
                descriptor.AddEvent("drag", OnClientDrag);

            if (DragEnd != null)
                descriptor.AddEvent("dragEnd", "Artem.Google.Map.raiseServerDragEnd");
            else if (OnClientDragEnd != null)
                descriptor.AddEvent("dragEnd", OnClientDragEnd);

            if (DragStart != null)
                descriptor.AddEvent("dragStart", "Artem.Google.Map.raiseServerDragStart");
            else if (OnClientDragStart != null)
                descriptor.AddEvent("dragStart", OnClientDragStart);

            if (HeadingChanged != null)
                descriptor.AddEvent("headingChanged", "Artem.Google.Map.raiseServerHeadingChanged");
            else if (OnClientHeadingChanged != null)
                descriptor.AddEvent("headingChanged", OnClientHeadingChanged);

            if (Idle != null)
                descriptor.AddEvent("idle", "Artem.Google.Map.raiseServerIdle");
            else if (OnClientIdle != null)
                descriptor.AddEvent("idle", OnClientIdle);

            if (MapTypeChanged != null)
                descriptor.AddEvent("mapTypeChanged", "Artem.Google.Map.raiseServerMapTypeChanged");
            else if (OnClientMapTypeChanged != null)
                descriptor.AddEvent("mapTypeChanged", OnClientMapTypeChanged);

            if (MouseMove != null)
                descriptor.AddEvent("mouseMove", "Artem.Google.Map.raiseServerMouseMove");
            else if (OnClientMouseMove != null)
                descriptor.AddEvent("mouseMove", OnClientMouseMove);

            if (MouseOut != null)
                descriptor.AddEvent("mouseOut", "Artem.Google.Map.raiseServerMouseOut");
            else if (OnClientMouseMove != null)
                descriptor.AddEvent("mouseOut", OnClientMouseOut);

            if (MouseOver != null)
                descriptor.AddEvent("mouseOver", "Artem.Google.Map.raiseServerMouseOver");
            else if (OnClientMouseOver != null)
                descriptor.AddEvent("mouseOver", OnClientMouseOver);

            if (ProjectionChanged != null)
                descriptor.AddEvent("projectionChanged", "Artem.Google.Map.raiseServerProjectionChanged");
            else if (OnClientProjectionChanged != null)
                descriptor.AddEvent("projectionChanged", OnClientProjectionChanged);

            if (Resize != null)
                descriptor.AddEvent("resize", "Artem.Google.Map.raiseServerResize");
            else if (OnClientResize != null)
                descriptor.AddEvent("resize", OnClientResize);

            if (RightClick != null)
                descriptor.AddEvent("rightClick", "Artem.Google.Map.raiseServerRightClick");
            else if (OnClientRightClick != null)
                descriptor.AddEvent("rightClick", OnClientRightClick);

            if (TilesLoaded != null)
                descriptor.AddEvent("tilesLoaded", "Artem.Google.Map.raiseServerTilesLoaded");
            else if (OnClientTilesLoaded != null)
                descriptor.AddEvent("tilesLoaded", OnClientTilesLoaded);

            if (TiltChanged != null)
                descriptor.AddEvent("tiltChanged", "Artem.Google.Map.raiseServerTiltChanged");
            else if (OnClientTiltChanged != null)
                descriptor.AddEvent("tiltChanged", OnClientTiltChanged);

            if (ZoomChanged != null)
                descriptor.AddEvent("zoomChanged", "Artem.Google.Map.raiseServerZoomChanged");
            else if (OnClientZoomChanged != null)
                descriptor.AddEvent("zoomChanged", OnClientZoomChanged);

            #endregion

            yield return descriptor;
        }

        /// <summary>
        ///     Gets the script references.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.IEnumerable" /> collection that contains ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            string assembly = GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Artem.Google.Map.GoogleMap.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Map.GoogleMap.min.js", assembly);
#endif
        }

        /// <summary>
        ///     Gets the static URL.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetStaticUrl()
        {
            string proto = Page.Request.IsSecureConnection ? "https" : "http";
            string url = string.Format("{0}://{1}", proto, StaticApiUrl);
            StringBuilder buffer = new StringBuilder(url);
            string center = null;
            string format = (StaticFormat != StaticImageFormats.JpgBaseline)
                                ? StaticFormat.ToString().ToLower() : "jpg-baseline";

            if (Center != null)
            {
                center = Center.ToString();
            }
            else
            {
                string address = Address ?? DefaultAddress;
                if (address != null)
                    center = HttpUtility.UrlEncode(address);
            }

            buffer.AppendFormat("center={0}", center);
            buffer.AppendFormat("&zoom={0}", Zoom.ToString());
            buffer.AppendFormat("&size={0}x{1}", Width.Value, Height.Value);
            buffer.AppendFormat("&sensor={0}", IsSensor.ToString().ToLower());
            buffer.AppendFormat("&maptype={0}", MapType.ToString().ToLower());
            buffer.AppendFormat("&format={0}", format);
            if (!string.IsNullOrEmpty(Language))
                buffer.AppendFormat("&language={0}", Language);
            if (StaticScale > 1)
                buffer.AppendFormat("&scale={0}", StaticScale.ToString());
            if (Libraries != null && Libraries.Any())
                buffer.AppendFormat("&libraries={0}", String.Join(",", Libraries.Select(l => l.ToString().ToLowerInvariant())));

            // TODO add markers 
            // TODO add paths -> polylines
            // TODO add styles - features, elements, rules

            return buffer.ToString();
        }

        /// <summary>
        ///     Raises the <see cref="M:System.Web.UI.Control.OnPreRender(System.EventArgs)" /> event and registers the script control with the
        ///     <see
        ///         cref="T:System.Web.UI.ScriptManager" />
        ///     control.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> object that contains the event data.
        /// </param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!IsStatic) RegisterGoogleReference();
        }

        /// <summary>
        ///     Registers the GoogleMaps API reference.
        /// </summary>
        protected virtual void RegisterGoogleReference()
        {
            string proto = Page.Request.IsSecureConnection ? "https" : "http";
            string url = string.Format("{0}://{1}", proto, ApiUrl);
            StringBuilder buffer = new StringBuilder(url);

            // business or standard api key
            if (!string.IsNullOrEmpty(EnterpriseKey))
                buffer.AppendFormat("client={0}&", EnterpriseKey);
            else if (!string.IsNullOrEmpty(Key))
                buffer.AppendFormat("key={0}&", Key);
            // version
            if (!string.IsNullOrEmpty(ApiVersion))
                buffer.AppendFormat("v={0}&", ApiVersion);
            // sensor
            buffer.AppendFormat("sensor={0}", IsSensor.ToString().ToLower());
            // language
            if (!string.IsNullOrEmpty(Language))
                buffer.AppendFormat("&language={0}", Language);
            // region
            if (!string.IsNullOrEmpty(Region))
                buffer.AppendFormat("&region={0}", Region);
            // libraries
            if (Libraries != null && Libraries.Any())
                buffer.AppendFormat("&libraries={0}", String.Join(",", Libraries.Select(l => l.ToString().ToLowerInvariant())));

            ScriptManager.RegisterClientScriptInclude(Page, GetType(), "maps.google.com", buffer.ToString());
        }


        /// <summary>
        ///     Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">
        ///     A <see cref="T:System.Web.UI.HtmlTextWriter" /> that represents the output stream to render HTML content on the client.
        /// </param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (!IsStatic)
            {
                base.RenderBeginTag(writer);
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "map");
                writer.AddAttribute(HtmlTextWriterAttribute.Src, GetStaticUrl());
                writer.RenderBeginTag(TagKey);
            }
        }

        #endregion

        #region Event Methods

        /// <summary>
        ///     Raises the <see cref="E:BoundsChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.BoundsEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnBoundsChanged(MapEventArgs e)
        {
            if (BoundsChanged != null) BoundsChanged(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:CenterChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnCenterChanged(MapEventArgs e)
        {
            if (CenterChanged != null) CenterChanged(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:Click" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnClick(MouseEventArgs e)
        {
            if (Click != null) Click(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:DoubleClick" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnDoubleClick(MouseEventArgs e)
        {
            if (DoubleClick != null) DoubleClick(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:Drag" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.BoundsEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnDrag(MapEventArgs e)
        {
            if (Drag != null) Drag(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:DragEnd" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.BoundsEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnDragEnd(MapEventArgs e)
        {
            if (DragEnd != null) DragEnd(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:DragStart" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.BoundsEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnDragStart(MapEventArgs e)
        {
            if (DragStart != null) DragStart(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:HeadingChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnHeadingChanged(EventArgs e)
        {
            if (HeadingChanged != null) HeadingChanged(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:Idle" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnIdle(EventArgs e)
        {
            if (Idle != null) Idle(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:MapTypeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MapEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnMapTypeChanged(MapEventArgs e)
        {
            if (MapTypeChanged != null) MapTypeChanged(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnMouseMove(MouseEventArgs e)
        {
            if (MouseMove != null) MouseMove(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:MouseOut" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnMouseOut(MouseEventArgs e)
        {
            if (MouseOut != null) MouseOut(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:MouseOver" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnMouseOver(MouseEventArgs e)
        {
            if (MouseOver != null) MouseOver(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:ProjectionChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnProjectionChanged(EventArgs e)
        {
            if (ProjectionChanged != null) ProjectionChanged(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MapEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnResize(MapEventArgs e)
        {
            if (Resize != null) Resize(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:RightClick" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnRightClick(MouseEventArgs e)
        {
            if (RightClick != null) RightClick(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:TilesLoaded" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnTilesLoaded(EventArgs e)
        {
            if (TilesLoaded != null) TilesLoaded(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:TiltChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnTiltChanged(EventArgs e)
        {
            if (TiltChanged != null) TiltChanged(this, e);
        }

        /// <summary>
        ///     Raises the <see cref="E:ZoomChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///     The <see cref="Artem.Google.UI.MapEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnZoomChanged(MapEventArgs e)
        {
            if (ZoomChanged != null) ZoomChanged(this, e);
        }

        /// <summary>
        ///     When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">
        ///     A <see cref="T:System.String" /> that represents an optional event argument to be passed to the event handler.
        /// </param>
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            var ser = new JavaScriptSerializer();
            dynamic args = ser.DeserializeObject(eventArgument);
            if (args != null)
            {
                string name = args["name"];
                switch (name)
                {
                    case "boundsChanged":
                        OnBoundsChanged(MapEventArgs.FromScriptData(args));
                        break;
                    case "centerChanged":
                        OnCenterChanged(MapEventArgs.FromScriptData(args));
                        break;
                    case "click":
                        OnClick(MouseEventArgs.FromScriptData(args));
                        break;
                    case "doubleClick":
                        OnDoubleClick(MouseEventArgs.FromScriptData(args));
                        break;
                    case "drag":
                        OnDrag(MapEventArgs.FromScriptData(args));
                        break;
                    case "dragEnd":
                        OnDragEnd(MapEventArgs.FromScriptData(args));
                        break;
                    case "dragStart":
                        OnDragStart(MapEventArgs.FromScriptData(args));
                        break;
                    case "headingChanged":
                        OnHeadingChanged(EventArgs.Empty);
                        break;
                    case "idle":
                        OnIdle(EventArgs.Empty);
                        break;
                    case "mapTypeChanged":
                        OnMapTypeChanged(MapEventArgs.FromScriptData(args));
                        break;
                    case "mouseMove":
                        OnMouseMove(MouseEventArgs.FromScriptData(args));
                        break;
                    case "mouseOut":
                        OnMouseOut(MouseEventArgs.FromScriptData(args));
                        break;
                    case "mouseOver":
                        OnMouseOver(MouseEventArgs.FromScriptData(args));
                        break;
                    case "projectionChanged":
                        OnProjectionChanged(EventArgs.Empty);
                        break;
                    case "resize":
                        OnResize(MapEventArgs.FromScriptData(args));
                        break;
                    case "rightClick":
                        OnRightClick(MouseEventArgs.FromScriptData(args));
                        break;
                    case "tilesLoaded":
                        OnTilesLoaded(EventArgs.Empty);
                        break;
                    case "tiltChanged":
                        OnTiltChanged(EventArgs.Empty);
                        break;
                    case "zoomChanged":
                        OnZoomChanged(MapEventArgs.FromScriptData(args));
                        break;
                }
            }
        }

        #endregion
    }
}