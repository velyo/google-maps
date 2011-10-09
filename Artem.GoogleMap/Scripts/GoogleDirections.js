///<reference name="MicrosoftAjax.debug.js"/>

Type.registerNamespace("Artem.Google");

//#> Directions class 

Artem.Google.Directions = function Artem_Google_Directions(map, config) {
    /// <param name="config" type="Artem.Google.Map"></param>
    /// <param name="config" type="Artem.Google.Directions"></param>

    this.AvoidHighways = config.AvoidHighways;
    this.GetPolyline = config.GetPolyline;
    this.GetSteps = config.GetSteps;
    this.Locale = config.Locale;
    this.Query = config.Query;
    this.PreserveViewport = config.PreserveViewport;
    this.RoutePanelId = config.RoutePanelId;
    this.TravelMode = config.TravelMode;

    var pane = (this.RoutePanelId) ? $get(this.RoutePanelId) : null;
    var directions = new GDirections(map.get_map(), pane);

    this.get_map = function () { return map; };
    this.get_directions = function () { return directions; };
    this.get_pane = function () { return pane; };

    // load
    var options = new Object();
    options.avoidHighways = this.AvoidHighways;
    if (this.GetPolyline) options.getPolyline = this.GetPolyline;
    if (this.GetSteps) options.getSteps = this.GetSteps;
    options.locale = this.Locale;
    options.preserveViewport = this.PreserveViewport;
    options.travelMode = ((this.TravelMode == 0) ? G_TRAVEL_MODE_DRIVING : G_TRAVEL_MODE_WALKING);

    this.load(this.Query, options);
};

Artem.Google.Directions.prototype = {

    //#region Fields ------------------------------------------------------------------------------

    AvoidHighways: null,
    Bounds: null,
    Distance: null,
    Duration: null,
    Geocodes: null,
    GetPolyline: null,
    GetSteps: null,
    Locale: null,
    Query: null,
    PreserveViewport: null,
    RoutePanelId: null,
    TravelMode: null,
    // TODO
    //    Polyline: null,
    //    Markers: null,
    //    Routes: null,
    //    Geocodes: null,

    //#endregion

    //#region Properties --------------------------------------------------------------------------

    get_directions: null,
    get_map: null,
    get_pane: null,

    //#endregion

    //#region Methods -----------------------------------------------------------------------------

    dispose: function Artem_Google_Directions$dispose() {
        google.maps.event.clearInstanceListeners(this.get_directions());
        this.clear();
    },

    save: function Artem_Google_Directions$save() {
        this.Bounds = new Artem.Google.Bounds(this.getBounds());
        this.Distance = new Artem.Google.Distance(this.getDistance());
        this.Duration = new Artem.Google.Duration(this.getDuration());
    },
    //#endregion

    //#region Google Maps API Wrapped -------------------------------------------------------------

    clear: function Artem_Google_Directions$clear() {
        this.get_directions().clear();
    },

    getBounds: function Artem_Google_Directions$getBounds() {
        return this.get_directions().getBounds();
    },

    getCopyrightsHtml: function Artem_Google_Directions$getCopyrightsHtml() {
        return this.get_directions().getCopyrightsHtml();
    },

    getDistance: function Artem_Google_Directions$getDistance() {
        return this.get_directions().getDistance();
    },

    getDuration: function Artem_Google_Directions$getDuration() {
        return this.get_directions().getDuration();
    },

    getGeocode: function Artem_Google_Directions$getGeocode(i) {
        return this.get_directions().getGeocode(i);
    },

    getMarker: function Artem_Google_Directions$getMarker(i) {
        return this.get_directions().getMarker(i);
    },

    getNumGeocodes: function Artem_Google_Directions$getNumGeocodes() {
        return this.get_directions().getNumGeocodes();
    },

    getNumRoutes: function Artem_Google_Directions$getNumRoutes() {
        return this.get_directions().getNumRoutes();
    },

    getPolyline: function Artem_Google_Directions$getPolyline() {
        return this.get_directions().getPolyline();
    },

    getRoute: function Artem_Google_Directions$getRoute(i) {
        return this.get_directions().getRoute(i);
    },

    getSummaryHtml: function Artem_Google_Directions$getSummaryHtml() {
        return this.get_directions().getSummaryHtml();
    },

    getStatus: function Artem_Google_Directions$getStatus() {
        return this.get_directions().getStatus();
    },

    load: function Artem_Google_Directions$load(query, options) {
        this.get_directions().load(query, options);
    },

    loadFromWaypoints: function Artem_Google_Directions$loadFromWaypoints(waypoints, options) {
        this.get_directions().loadFromWaypoints(waypoints, options);
    }
    //#endregion
};
//#<

Artem.Google.Directions.registerClass("Artem.Google.Directions");
