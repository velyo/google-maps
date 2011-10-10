///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="http://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Artem.Google");

// Directions class 
Artem.Google.Directions = function (map, config) {
    /// <param name="config" type="Artem.Google.Map"></param>
    /// <param name="config"></param>

    this.create(map, config);
};

// Common
(function (proto) {

    // properties

    var map = null;
    proto.get_map = function () { return map; };

    var state = null;
    proto.get_state = function () { return state; };
    proto.set_state = function (value) { state = value; };

    var pane = null;
    proto.get_pane = function () { return pane; };

    // public methods
    proto.create = function (parent, config) {

        map = parent;
        state = config;

        if (state.RoutePanelId)
            pane = $get(state.RoutePanelId) || null;
        this.set_gdirections(new GDirections(map.get_map(), pane));

        this.load();
    };

    proto.dispose = function () {
        google.maps.event.clearInstanceListeners(this.get_gdirections());
        this.clear();
    };

    proto.save = function () {

        return {
            Bounds: new Artem.Google.Bounds(this.getBounds()),
            Distance: new Artem.Google.Distance(this.getDistance()),
            Duration: new Artem.Google.Duration(this.getDuration())
        }
    };

} (Artem.Google.Directions.prototype));

// GoogleMaps API Wraps
(function (proto) {

    // properties
    var gdirections;
    proto.get_gdirections = function () { return gdirections; };
    proto.set_gdirections = function (value) { gdirections = value; };

    // public methods

    proto.clear = function () {
        gdirections.clear();
    };

    proto.getBounds = function () {
        return gdirections.getBounds();
    };

    proto.getCopyrightsHtml = function () {
        return gdirections.getCopyrightsHtml();
    };

    proto.getDistance = function () {
        return gdirections.getDistance();
    };

    proto.getDuration = function () {
        return gdirections.getDuration();
    };

    proto.getGeocode = function (i) {
        return gdirections.getGeocode(i);
    };

    proto.getMarker = function (i) {
        return gdirections.getMarker(i);
    };

    proto.getNumGeocodes = function () {
        return gdirections.getNumGeocodes();
    };

    proto.getNumRoutes = function () {
        return gdirections.getNumRoutes();
    };

    proto.getPolyline = function () {
        return gdirections.getPolyline();
    };

    proto.getRoute = function (i) {
        return gdirections.getRoute(i);
    };

    proto.getSummaryHtml = function () {
        return gdirections.getSummaryHtml();
    };

    proto.getStatus = function () {
        return gdirections.getStatus();
    };

    proto.load = function (query, options) {

        var state = this.get_state();

        if (!query)
            query = state.Query;
        if (!options)
            options = new {};
        //                avoidHighways: state.AvoidHighways,
        //                if (this.GetPolyline) state.getPolyline = this.GetPolyline;
        //                if (this.GetSteps) state.getSteps = this.GetSteps;
        //                state.locale = this.Locale;
        //                state.preserveViewport = this.PreserveViewport;
        //                state.travelMode = ((this.TravelMode == 0) ? G_TRAVEL_MODE_DRIVING : G_TRAVEL_MODE_WALKING);
        //            };

        gdirections.load(query, options);
    };

    proto.loadFromWaypoints = function (waypoints, options) {
        gdirections.loadFromWaypoints(waypoints, options);
    };

} (Artem.Google.Directions.prototype));

Artem.Google.Directions.registerClass("Artem.Google.Directions");
