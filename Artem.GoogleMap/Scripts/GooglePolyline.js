///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="GoogleCommons.js"/>
///<reference path="GoogleMap.js"/>

Type.registerNamespace("Artem.Google");

//#> Polyline class

Artem.Google.Polyline = function Artem_Google_Polyline(map, state) {
    /// <param name="map" type="Artem.Google.Map"></param>
    /// <param name="state" type="Artem.Google.Polyline"></param>

    this.Color = state.Color;
    this.EditingFromStart = state.EditingFromStart;
    this.EditingMaxVertices = state.EditingMaxVertices;
    this.EnableDrawing = state.EnableDrawing;
    this.EnableEditing = state.EnableEditing;
    this.IsClickable = state.IsClickable;
    this.IsGeodesic = state.IsGeodesic;
    this.MouseOutTolerance = state.MouseOutTolerance;
    this.Opacity = state.Opacity;
    this.Points = state.Points;
    this.Weight = state.Weight;
    this.ZIndex = state.ZIndex;

    this.get_map = function () { return map; };

    this.initialize();
}
Artem.Google.Polyline.prototype = {

    //#region Fields ------------------------------------------------------------------------------

    Color: null,
    EditingFromStart: null,
    EditingMaxVertices: null,
    EnableDrawing: null,
    EnableEditing: null,
    IsClickable: null,
    IsGeodesic: null,
    MouseOutTolerance: null,
    Opacity: null,
    Points: null,
    Weight: null,
    ZIndex: null,

    Bounds: null,
    Length: null,

    //#endregion

    //#region Properties --------------------------------------------------------------------------

    get_map: null,
    get_polyline: null,

    //#endregion

    //#region Methods -----------------------------------------------------------------------------

    initialize: function Artem_Google_Polyline$initialize() {

        var options = {
            clickable: this.IsClickable,
            geodesic: this.IsGeodesic,
            map: this.get_map().get_map(),
            path: null,
            strokeColor: null,
            strokeOpacity: this.Opacity,
            strokeWeight: this.Weight,
            zIndex: this.ZIndex
        };

        if (this.Color)
            options.strokeColor = this.Color.HtmlValue;
        if (this.Points) {
            options.path = new Array();
            var point;
            for (var i = 0; i < this.Points.length; i++) {
                point = this.Points[i];
                options.path.push(new google.maps.LatLng(point.Latitude, point.Longitude));
            }
        }

        var polyline = new google.maps.Polyline(options);
        this.get_polyline = function () { return polyline; };
    },

    dispose: function Artem_Google_Polyline$dispose() {
        // first dispose the event listeners
        google.maps.event.clearInstanceListeners(this.get_polyline());

        delete this.get_polyline;
        delete this.get_map;

        delete this.Bounds;
        delete this.Color;
        delete this.EditingFromStart;
        delete this.EditingMaxVertices;
        delete this.EnableDrawing;
        delete this.EnableEditing;
        delete this.IsClickable;
        delete this.IsGeodesic;
        delete this.Length;
        delete this.MouseOutTolerance;
        delete this.Opacity;
        delete this.Points;
        delete this.Weight;
        delete this.ZIndex;
    },

    save: function Artem_Google_Polyline$save() {
        // TODO - this is not yet implemented/available in GoogleMaps API v3
        //        this.Bounds = new Artem.Google.Bounds(this.getBounds());
        //        this.Length = this.getLength();
    },

    //#endregion

    //#> Google Maps API Wrapped -------------------------------------------------------------

    getMap: function () {
        return this.get_polyline().getMap();
    },

    getPath: function () {
        return this.get_polyline().getPath();
    },

    setMap: function (map) {
        this.get_polyline().setMap(map);
    },

    setOptions: function (options) {
        this.get_polyline().setOptions(options);
    },

    setPath: function (path) {
        this.get_polyline().setPath(path);
    }
    //#<
}
//#<

Artem.Google.Polyline.registerClass("Artem.Google.Polyline");