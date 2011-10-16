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

[assembly: WebResource("Artem.Google.Map.GoogleMap.js", "text/javascript")]
[assembly: WebResource("Artem.Google.map.GoogleMap.min.js", "text/javascript")]

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(GoogleMapDesigner))]
    [ToolboxData("<{0}:GoogleMap runat=\"server\"></{0}:GoogleMap>")]
    public partial class GoogleMap : ScriptControl, INamingContainer, IPostBackEventHandler {//DataBoundControl, 

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

        #region Fields

        LatLng _center;
        //string _key;
        //bool _loading;
        //GoogleMarkerEvents _markerEvents;
        //List<GoogleMarker> _markers;
        //GoogleMarkerStyle _markerStyle;
        //GooglePolygonEvents _polygonEvents;
        //List<GooglePolygon> _polygons;
        //List<GooglePolyline> _polylines;
        //HtmlGenericControl _templateContainer;

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
        [Description("The initial LatLng map center.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLng Center {
            get {
                return _center ?? (_center = new LatLng());
            }
            set {
                _center = value;
            }
        }

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
            get {
                return this.Center.Latitude;
            }
            set {
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
                this.Center.Longitude = value;
            }
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
        public MapTypeControlOptions MapTypeControlOptions { get; set; }

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
        public OverviewMapControlOptions OverviewMapControlOptions { get; set; }

        /// <summary>
        /// The display options for the Pan control.
        /// </summary>
        /// <value>The pan control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Pan control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PanControlOptions PanControlOptions { get; set; }

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
        public RotateControlOptions RotateControlOptions { get; set; }

        /// <summary>
        /// The initial display options for the Scale control.
        /// </summary>
        /// <value>The scale control options.</value>
        [Category("Appearance")]
        [Description("The initial display options for the Scale control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ScaleControlOptions ScaleControlOptions { get; set; }

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
        /// The display options for the Zoom control.
        /// </summary>
        /// <value>The zoom control options.</value>
        [Category("Appearance")]
        [Description("The display options for the Zoom control.")]
        public ZoomControlOptions ZoomControlOptions { get; set; }

        #endregion

        #region Events


        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMap"/> class.
        /// </summary>
        public GoogleMap() {

            this.BackColor = Color.Gray;
            this.Draggable = true;
            this.EnableMapTypeControl = true;
            this.EnableOverviewMapControl = true;
            this.EnablePanControl = true;
            this.EnableScaleControl = true;
            this.EnableScrollWheelZoom = true;
            this.EnableStreetViewControl = true;
            this.EnableZoomControl = true;
            this.Zoom = 4;

            this.StaticScale = 1;

            this.Width = new Unit("640px");
            this.Height = new Unit("480px");
        }
        #endregion

        #region Methods

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
            descriptor.AddProperty("mapType", this.MapType);
            descriptor.AddProperty("zoom", this.Zoom);

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
            yield return new ScriptReference("Artem.Google.Scripts.GoogleMap.min.js", assembly);
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
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {

            //if (!string.IsNullOrEmpty(eventArgument)) {
            //    string[] pair = eventArgument.Split('$');
            //    if (pair.Length > 0) {
            //        string[] header = pair[0].Split(':');
            //        string type = header[0];
            //        string key = (header.Length > 1) ? header[1] : null;
            //        string args = (pair.Length > 1) ? pair[1] : null;

            //        switch (type) {
            //            case "map":
            //                MapEvents.RaiseEvent(this, key, args);
            //                break;
            //            case "direction":
            //                // TODO
            //                break;
            //            case "marker":
            //                MarkerEvents.RaiseEvent(this, key, args);
            //                break;
            //            case "polygon":
            //                //PolygonEvents.RaiseEvent(this, key, args);
            //                break;
            //            case "polyline":
            //                //PolylineEvents.RaiseEvent(this, key, args);
            //                break;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Registers the GoogleMaps API reference.
        /// </summary>
        protected virtual void RegisterGoogleReference() {

            //var clientScript = this.Page.ClientScript;
            //if (!clientScript.IsClientScriptIncludeRegistered("maps.google.com")) {
            string proto = this.Page.Request.IsSecureConnection ? "https" : "http";
            string url = string.Format("{0}://{1}", proto, ApiUrl);
            StringBuilder buffer = new StringBuilder(url);

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

            //if (!string.IsNullOrEmpty(this.EnterpriseKey))
            //    buffer.AppendFormat("&client={0}", this.EnterpriseKey);

            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), "maps.google.com", buffer.ToString());
            //    clientScript.RegisterClientScriptInclude("maps.google.com", buffer.ToString());
            //}
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

        ///// <summary>
        ///// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        ///// </summary>
        //protected override void CreateChildControls() {
        //    base.CreateChildControls();

        //    _templateContainer = new HtmlGenericControl("div");
        //    _templateContainer.ID = "Templates";
        //    _templateContainer.Style[HtmlTextWriterStyle.Display] = "none";

        //    if (_markers.IsNotNullOrEmpty()) {
        //        GoogleMarker marker;
        //        for (int i = 0; i < _markers.Count; i++) {
        //            marker = _markers[i];
        //            if (marker.InfoContent.Controls.Count > 0) {
        //                marker.InfoContent.ID = string.Format("{0}_MarkerInfo{1}", this.ClientID, i.ToString());
        //                _templateContainer.Controls.Add(marker.InfoContent);
        //            }
        //            else if (marker.InfoWindowTemplate != null) {
        //                var container = new GoogleMarker.TemplateContainer();
        //                container.ID = string.Format("{0}_MarkerInfo{1}", this.ClientID, i.ToString());
        //                marker.InfoWindowTemplate.InstantiateIn(container);
        //                _templateContainer.Controls.Add(container);
        //            }
        //        }
        //    }

        //    this.Controls.Add(_templateContainer);
        //    this.ClearChildViewState();
        //}

        #region DataBinding Methods

        ///// <summary>
        ///// Gets or sets the data address field.
        ///// </summary>
        ///// <value>The data address field.</value>
        //[Category("Data")]
        //public string DataAddressField { get; set; }

        ///// <summary>
        ///// Gets or sets the data latitude field.
        ///// </summary>
        ///// <value>The data latitude field.</value>
        //[Category("Data")]
        //public string DataLatitudeField { get; set; }

        ///// <summary>
        ///// Gets or sets the data longitude field.
        ///// </summary>
        ///// <value>The data longitude field.</value>
        //[Category("Data")]
        //public string DataLongitudeField { get; set; }

        ///// <summary>
        ///// Gets or sets the data text field.
        ///// </summary>
        ///// <value>The data text field.</value>
        //[Category("Data")]
        //public string DataTextField { get; set; }

        ///// <summary>
        ///// When overridden in a derived class, binds data from the data source to the control.
        ///// </summary>
        ///// <param name="data">The <see cref="T:System.Collections.IEnumerable"/> list of data returned from a <see cref="M:System.Web.UI.WebControls.DataBoundControl.PerformSelect"/> method call.</param>
        //protected override void PerformDataBinding(IEnumerable data) {
        //    base.PerformDataBinding(data);

        //    if (data != null) {
        //        bool hasAddressDataField = !string.IsNullOrEmpty(DataAddressField);
        //        bool hasLatitudeDataField = !string.IsNullOrEmpty(DataLatitudeField);
        //        bool hasLongitudeDataField = !string.IsNullOrEmpty(DataLongitudeField);
        //        bool hasTextDataField = !string.IsNullOrEmpty(DataTextField);
        //        GoogleMarker marker;
        //        foreach (object dataItem in data) {
        //            marker = new GoogleMarker();
        //            if (hasAddressDataField)
        //                marker.Address = DataBinder.Eval(dataItem, DataAddressField, "");
        //            if (hasLatitudeDataField)
        //                marker.Latitude = JsUtil.ToDouble(DataBinder.Eval(dataItem, DataLatitudeField, ""));
        //            if (hasLongitudeDataField)
        //                marker.Longitude = JsUtil.ToDouble(DataBinder.Eval(dataItem, DataLongitudeField, ""));
        //            if (hasTextDataField)
        //                marker.Text = DataBinder.Eval(dataItem, DataTextField, "");
        //            this.Markers.Add(marker);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Retrieves data from the associated data source.
        ///// </summary>
        //protected override void PerformSelect() {

        //    if (IsBoundUsingDataSourceID)
        //        this.OnDataBinding(EventArgs.Empty);

        //    DataSourceView view = GetData();
        //    view.Select(
        //        CreateDataSourceSelectArguments(),
        //        this.OnDataSourceViewSelectCallback);
        //    // The PerformDataBinding method has completed.
        //    RequiresDataBinding = false;
        //    MarkAsDataBound();
        //    // Raise the DataBound event.
        //    OnDataBound(EventArgs.Empty);
        //}

        ///// <summary>
        ///// Called when [data source view select callback].
        ///// </summary>
        ///// <param name="retrievedData">The retrieved data.</param>
        //void OnDataSourceViewSelectCallback(IEnumerable retrievedData) {

        //    if (IsBoundUsingDataSourceID)
        //        OnDataBinding(EventArgs.Empty);
        //    PerformDataBinding(retrievedData);
        //}
        #endregion
    }
}