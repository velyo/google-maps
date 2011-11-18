using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using Artem.Google.Serialization;

[assembly: WebResource("Artem.Google.Directions.GoogleDirectionsBehavior.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Directions.GoogleDirectionsBehavior.min.js", "text/javascript")]

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GoogleDirections runat=server></{0}:GoogleDirections>")]
    public class GoogleDirections : ExtenderControl, IPostBackEventHandler {

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [avoid highways].
        /// If <code>true</code> directions will attempt to exclude highways when computing directions. Optional.
        /// Note that directions may still include highways if there are no viable alternatives.
        /// </summary>
        /// <value><c>true</c> if [avoid highways]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("If true, instructs the Directions service to avoid highways where possible. Optional.")]
        [DefaultValue(false)]
        public bool? AvoidHighways { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [avoid tolls].
        /// If <code>true</code>, instructs the Directions service to avoid toll roads where possible. Optional.
        /// </summary>
        /// <value><c>true</c> if [avoid tolls]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("If true, instructs the Directions service to avoid toll roads where possible. Optional.")]
        [DefaultValue(false)]
        public bool? AvoidTolls { get; set; }

        /// <summary>
        /// Location of destination. This can be specified as either a string to be geocoded or a LatLng. Required.
        /// </summary>
        /// <value>The destination.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Location of destination. This can be specified as either a string to be geocoded or a LatLng. Required.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Location Destination {
            get { return _destination ?? (_destination = new Location()); }
            set { _destination = value; }
        }
        Location _destination;

        // TODO
        ///// <summary>
        ///// The directions to display on the map and/or in a <div> panel, 
        ///// retrieved as a DirectionsResult object from DirectionsService.
        ///// </summary>
        ///// <value>The directions.</value>
        //public DirectionsResult[] Directions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleDirections"/> is draggable.
        /// If true, allows the user to drag and modify the paths of routes rendered by this DirectionsRenderer.
        /// </summary>
        /// <value><c>true</c> if draggable; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Behavior")]
        [Description("If true, allows the user to drag and modify the paths of routes rendered by this DirectionsRenderer.")]
        [DefaultValue(false)]
        public bool Draggable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [hide route list].
        /// This property indicates whether the renderer should provide UI to select amongst alternative routes. 
        /// By default, this flag is false and a user-selectable list of routes will be shown in the directions' associated panel. 
        /// To hide that list, set hideRouteList to true.
        /// </summary>
        /// <value><c>true</c> if [hide route list]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("This property indicates whether the renderer should provide UI to select amongst alternative routes. To hide that list, set hideRouteList to true.")]
        [DefaultValue(false)]
        public bool HideRouteList { get; set; }

        // TODO
        ///// <summary>
        ///// The InfoWindow in which to render text information when a marker is clicked. 
        ///// Existing info window content will be overwritten and its position moved. 
        ///// If no info window is specified, the DirectionsRenderer will create and use its own info window. 
        ///// This property will be ignored if suppressInfoWindows is set to true.
        ///// </summary>
        ///// <value>The info window.</value>
        //public InfoWindow InfoWindow { get; set; }

        /// <summary>
        /// Options for the markers. All markers rendered by the DirectionsRenderer will use these options.
        /// </summary>
        /// <value>The marker options.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Options for the markers. All markers rendered by the DirectionsRenderer will use these options.")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerOptions MarkerOptions {
            get { return _markerOptions ?? (_markerOptions = new MarkerOptions()); }
            set { _markerOptions = value; }
        }
        MarkerOptions _markerOptions;

        /// <summary>
        /// Gets or sets a value indicating whether [optimize waypoints].
        /// If set to true, the DirectionService will attempt to re-order the supplied intermediate waypoints to minimize overall cost of the route. 
        /// If waypoints are optimized, inspect DirectionsRoute.waypoint_order in the response to determine the new ordering.
        /// </summary>
        /// <value><c>true</c> if [optimize waypoints]; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("If true, will attempt to re-order the supplied intermediate waypoints to minimize overall cost of the route.")]
        [DefaultValue(false)]
        public bool? OptimizeWaypoints { get; set; }

        /// <summary>
        /// Location of origin. This can be specified as either a string to be geocoded or a LatLng. Required.
        /// </summary>
        /// <value>The origin.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Location of origin. This can be specified as either a string to be geocoded or a LatLng. Required.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Location Origin {
            get { return _origin ?? (_origin = new Location()); }
            set { _origin = value; }
        }
        Location _origin;

        /// <summary>
        /// The &lt;div&gt; in which to display the directions steps.
        /// </summary>
        /// <value>The panel.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The &lt;div&gt; in which to display the directions steps.")]
        public string PanelID { get; set; }

        /// <summary>
        /// Options for the polylines. All polylines rendered by the DirectionsRenderer will use these options.
        /// </summary>
        /// <value>The polyline options.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Options for the polylines. All polylines rendered by the DirectionsRenderer will use these options.")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public PolylineOptions PolylineOptions {
            get { return _polylineOptions ?? (_polylineOptions = new PolylineOptions()); }
            set { _polylineOptions = value; }
        }
        PolylineOptions _polylineOptions;


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleDirections"/> should alter the viewport.
        /// By default, the input map is centered and zoomed to the bounding box of this set of directions. 
        /// If this option is set to true, the viewport is left unchanged, unless the map's center and zoom were never set.
        /// </summary>
        /// <value><c>true</c> to preserve; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("If this option is set to true, the viewport is left unchanged, unless the map's center and zoom were never set.")]
        public bool PreserveViewport { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [provide route alternatives].
        /// Whether or not route alternatives should be provided. Optional.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [provide route alternatives]; otherwise, <c>false</c>.
        /// </value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Whether or not route alternatives should be provided. Optional.")]
        [DefaultValue(false)]
        public bool? ProvideRouteAlternatives { get; set; }

        /// <summary>
        /// Region code used as a bias for geocoding requests. Optional.
        /// </summary>
        /// <value>The region.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Region code used as a bias for geocoding requests. Optional.")]
        public string Region { get; set; }

        /// <summary>
        /// The index of the route within the DirectionsResult object. The default value is 0.
        /// </summary>
        /// <value>The index of the route.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The index of the route within the DirectionsResult object. The default value is 0.")]
        public int RouteIndex { get; set; }

        /// <summary>
        /// Suppress the rendering of the BicyclingLayer when bicycling directions are requested.
        /// </summary>
        /// <value>The suppress bicycling layer.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Suppress the rendering of the BicyclingLayer when bicycling directions are requested.")]
        public bool? SuppressBicyclingLayer { get; set; }

        /// <summary>
        /// Suppress the rendering of info windows.
        /// </summary>
        /// <value>The suppress info windows.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Suppress the rendering of info windows.")]
        public bool? SuppressInfoWindows { get; set; }

        /// <summary>
        /// Suppress the rendering of markers.
        /// </summary>
        /// <value>The suppress markers.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Suppress the rendering of markers.")]
        public bool? SuppressMarkers { get; set; }

        /// <summary>
        /// Suppress the rendering of polylines
        /// </summary>
        /// <value>The suppress polylines.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Suppress the rendering of polylines")]
        public bool? SuppressPolylines { get; set; }

        /// <summary>
        /// Gets or sets the travel mode.
        /// The mode of travel, such as driving (default) or walking. 
        /// Note that if you specify walking directions, 
        /// you will need to specify a &lt;div&gt; panel to hold a warning notice to users.
        /// </summary>
        /// <value>The travel mode.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Type of routing requested. Required.")]
        public TravelMode TravelMode { get; set; }

        /// <summary>
        /// Preferred unit system to use when displaying distance. 
        /// Defaults to the unit system used in the country of origin.
        /// </summary>
        /// <value>The unit system.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Preferred unit system to use when displaying distance. Defaults to the unit system used in the country of origin.")]
        public UnitSystem? UnitSystem { get; set; }

        // TODO
        ///// <summary>
        ///// Array of intermediate waypoints. Directions will be calculated from the origin to the destination by way of each waypoint in this array. Optional.
        ///// </summary>
        ///// <value>The waypoints.</value>
        //public DirectionsWaypoint[] Waypoints { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// This server-side event is fired when the rendered directions change, either when a new DirectionsResult is set or when the user finishes dragging a change to the directions path.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the rendered directions change, either when a new DirectionsResult is set or when the user finishes dragging a change to the directions path.")]
        public event EventHandler<DirectionsChangedEventArgs> Changed;

        /// <summary>
        /// Gets or sets the on client changed handler.
        /// </summary>
        /// <value>The on client changed.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side changed handler.")]
        public string OnClientChanged { get; set; }

        #endregion

        #region Ctor

        ///// <summary>
        ///// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        ///// </summary>
        ///// <param name="query">The query.</param>
        ///// <param name="routePanelId">The route panel id.</param>
        ///// <param name="locale">The locale.</param>
        ///// <param name="preserveViewport">if set to <c>true</c> [preserve viewport].</param>
        //public GoogleDirections(string query, string routePanelId, string locale, bool preserveViewport) {
        //    this.Query = query;
        //    this.RoutePanelId = routePanelId;
        //    this.Locale = (locale != null) ? locale : "en_US";
        //    this.PreserveViewport = preserveViewport;
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        ///// </summary>
        ///// <param name="query">The query.</param>
        ///// <param name="routePanelId">The route panel id.</param>
        ///// <param name="locale">The locale.</param>
        //public GoogleDirections(string query, string routePanelId, string locale)
        //    : this(query, routePanelId, locale, false) {
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        ///// </summary>
        ///// <param name="query">The query.</param>
        ///// <param name="routePanelId">The route panel id.</param>
        //public GoogleDirections(string query, string routePanelId)
        //    : this(query, routePanelId, null, false) {
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        ///// </summary>
        ///// <param name="query">The query.</param>
        //public GoogleDirections(string query)
        //    : this(query, null, null, false) {
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        /// </summary>
        public GoogleDirections() {
            //: this(null, null, null, false) {
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

            var descriptor = new ScriptBehaviorDescriptor("Artem.Google.DirectionsBehavior", targetControl.ClientID);

            // props
            descriptor.AddProperty("name", this.UniqueID);

            // directions servise properties
            if (this.AvoidHighways.HasValue)
                descriptor.AddProperty("avoidHighways", this.AvoidHighways.Value);
            if (this.AvoidTolls.HasValue)
                descriptor.AddProperty("avoidTolls", this.AvoidTolls.Value);
            if (_destination != null)
                descriptor.AddProperty("destination", _destination.Value);
            if (this.OptimizeWaypoints.HasValue)
                descriptor.AddProperty("optimizeWaypoints", this.OptimizeWaypoints.Value);
            if (_origin != null)
                descriptor.AddProperty("origin", _origin.Value);
            if (this.ProvideRouteAlternatives.HasValue)
                descriptor.AddProperty("provideRouteAlternatives", this.ProvideRouteAlternatives.Value);
            if (this.Region != null)
                descriptor.AddProperty("region", this.Region);
            descriptor.AddProperty("travelMode", this.TravelMode);
            if (UnitSystem.HasValue)
                descriptor.AddProperty("unitSystem", this.UnitSystem.Value);
            //descriptor.AddProperty("waypoints", this.waypoints);

            // directions renderer properties
            descriptor.AddProperty("draggable", this.Draggable);
            descriptor.AddProperty("hideRouteList", this.HideRouteList);
            if (_markerOptions != null)
                descriptor.AddProperty("markerOptions", _markerOptions.ToScriptData());
            if (this.PanelID != null)
                descriptor.AddProperty("panelId", this.PanelID);
            if (_polylineOptions != null)
                descriptor.AddProperty("polylineOptions", _polylineOptions.ToScriptData());
            descriptor.AddProperty("preserveViewport", this.PreserveViewport);
            descriptor.AddProperty("routeIndex", this.RouteIndex);
            if (this.SuppressBicyclingLayer.HasValue)
                descriptor.AddProperty("suppressBicyclingLayer", this.SuppressBicyclingLayer.Value);
            if (this.SuppressInfoWindows.HasValue)
                descriptor.AddProperty("suppressInfoWindows", this.SuppressInfoWindows.Value);
            if (SuppressMarkers.HasValue)
                descriptor.AddProperty("suppressMarkers", this.SuppressMarkers.Value);
            if (SuppressPolylines.HasValue)
                descriptor.AddProperty("suppressPolylines", this.SuppressPolylines.Value);

            // events
            if (this.Changed != null)
                descriptor.AddEvent("changed", "Artem.Google.DirectionsBehavior.raiseServerChanged");
            else if (this.OnClientChanged != null)
                descriptor.AddEvent("changed", this.OnClientChanged);

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
            yield return new ScriptReference("Artem.Google.Directions.GoogleDirectionsBehavior.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Directions.GoogleDirectionsBehavior.min.js", assembly);
#endif
        }

        /// <summary>
        /// Raises the <see cref="E:Changed"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.DirectionsChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnChanged(DirectionsChangedEventArgs e) {
            if (this.Changed != null) this.Changed(this, e);
        }

        /// <summary>
        /// When implemented by a class, enables a server control to process an evePnt raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        public void RaisePostBackEvent(string eventArgument) {

            var ser = new JavaScriptSerializer();
            dynamic args = ser.DeserializeObject(eventArgument);
            if (args != null) {
                string name = args["name"];
                if (args["route"] != null) {
                    var e = DirectionsChangedEventArgs.FromScriptData(args["route"]);
                    switch (name) {
                        case "change":
                            this.OnChanged(e);
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
