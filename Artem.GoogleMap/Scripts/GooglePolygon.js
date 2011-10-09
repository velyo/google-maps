///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="GoogleCommons.js"/>
///<reference path="GoogleMap.js"/>

Type.registerNamespace("Artem.Google");

//#region Polygon class

Artem.Google.Polygon = function Artem_Google_Polygon(map, state) {
    /// <param name="map" type="Artem.Google.Map"></param>
    /// <param name="state" type="Artem.Google.Polygon"></param>

    this.Bounds = state.Bounds;
    this.EditingFromStart = state.EditingFromStart;
    this.EditingMaxVertices = state.EditingMaxVertices;
    this.EnableDrawing = state.EnableDrawing;
    this.EnableEditing = state.EnableEditing;
    this.FillColor = state.FillColor;
    this.FillOpacity = state.FillOpacity;
    this.IsClickable = state.IsClickable;
    this.IsGeodesic = state.IsGeodesic;
    this.Points = state.Points;
    this.StrokeColor = state.StrokeColor;
    this.StrokeOpacity = state.StrokeOpacity
    this.StrokeWeight = state.StrokeWeight;
    this.ZIndex = state.ZIndex;

    this.get_map = function () { return map; };

    this.initialize();
}
Artem.Google.Polygon.prototype = {

    //#region Fields ------------------------------------------------------------------------------

    Bounds: null,
    EditingFromStart: null,
    EditingMaxVertices: null,
    EnableDrawing: null,
    EnableEditing: null,
    FillColor: null,
    FillOpacity: null,
    IsClickable: null,
    IsGeodesic: null,
    Points: null,
    StrokeColor: null,
    StrokeOpacity: null,
    StrokeWeight: null,
    ZIndex: null,

    //#endregion

    //#region Properties --------------------------------------------------------------------------

    get_map: null,
    get_polygon: null,

    //#endregion

    //#region Methods -----------------------------------------------------------------------------

    initialize: function Artem_Google_Polygon$initialize() {

        var options = {
            clickable: this.IsClickable,
            fillColor: null,
            fillOpacity: this.FillOpacity,
            geodesic: this.IsGeodesic,
            map: this.get_map().get_map(),
            paths: null,
            strokeColor: null,
            strokeOpacity: this.StrokeOpacity,
            strokeWeight: this.StrokeWeight,
            zIndex: this.ZIndex
        };

        if (this.FillColor)
            options.fillColor = this.FillColor.HtmlValue;
        if (this.StrokeColor)
            options.strokeColor = this.StrokeColor.HtmlValue;
        if (this.Points) {
            options.paths = new Array();
            var point;
            for (var i = 0; i < this.Points.length; i++) {
                point = this.Points[i];
                options.paths.push(new google.maps.LatLng(point.Latitude, point.Longitude));
            }
        }

        var polygon = new google.maps.Polygon(options);
        this.get_polygon = function () { return polygon; };
    },

    dispose: function Artem_Google_Polygon$dispose() {
        // first dispose the event listeners
        google.maps.event.clearInstanceListeners(this.get_polygon());

        delete this.get_polygon;
        delete this.get_map;

        delete this.Bounds;
        delete this.EditingFromStart;
        delete this.EditingMaxVertices;
        delete this.EnableDrawing;
        delete this.EnableEditing;
        delete this.FillColor;
        delete this.FillOpacity;
        delete this.IsGeodesic;
        delete this.IsClickable;
        delete this.Points;
        delete this.StrokeColor;
        delete this.StrokeOpacity;
        delete this.StrokeWeight;
        delete this.ZIndex;
    },

    save: function Artem_Google_Polygon$save() {
        // TODO - this is not yet implemented/available in GoogleMaps API v3
        //        this.Bounds = this.getBounds();
    },
    //#endregion

    //#region Google Maps API Wrapped -------------------------------------------------------------

    getMap: function Artem_Google_Polygon$getMap() {
        return this.get_polygon().getMap();
    },

    getPath: function Artem_Google_Polygon$getPath() {
        return this.get_polygon().getPath();
    },

    getPaths: function Artem_Google_Polygon$getPaths() {
        return this.get_polygon().getPaths();
    },

    setMap: function Artem_Google_Polygon$setMap(map) {
        this.get_polygon().setMap(map);
    },

    setOptions: function Artem_Google_Polygon$setOptions(options) {
        this.get_polygon().setOptions(options);
    },

    setPath: function Artem_Google_Polygon$setPath(path) {
        this.get_polygon().setPath(path);
    },

    setPaths: function Artem_Google_Polygon$setPaths(paths) {
        this.get_polygon().setPaths(paths);
    }
    //#endregion
}
//#<

Artem.Google.Polygon.registerClass("Artem.Google.Polygon");