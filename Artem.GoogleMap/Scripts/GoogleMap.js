///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="GoogleCommons.js"/>
//#region Info
// ------------------------------------------------------------------------------------------------
// Copyright (C) ArtemBG.
// ------------------------------------------------------------------------------------------------
// GoogleMap4.debug.js
// GoogleMap Control v5.0 javascipt library (debug).
//
// Assembly:    Artem.GooleMap
// Version:     5.0.0.0
// Project:     http://googlemap.codeplex.com
// Demo:        http://googlemap.artembg.com
// Author:      Velio Ivanov - velio@artembg.com
//              http://artembg.com
// License:     Microsoft Permissive License (Ms-PL) v1.1
//              http://www.codeplex.com/googlemap/license
// API:         http://code.google.com/apis/maps/
// Outlining:   VisualStudio 2010 JavaScript Outlining
//              http://jsoutlining.codeplex.com/
//#endregion

Type.registerNamespace("Artem.Google");
Type.registerNamespace("Artem.Google.Events");

//#region Map class ///////////////////////////////////////////////////////////////////////////////

Artem.Google.Map = function Artem_Google_Map(element) {
    /// <summary>This class represents the client GoogleMap control object.</summary>
    /// <field name="get_polygonEvents" type="Sys.EventHandlerList"></field>

    Artem.Google.Map.initializeBase(this, [element]);

    var self = this;

    var clientMapID = null;
    this.get_clientMapID = function () { return clientMapID; };
    this.set_clientMapID = function (value) { clientMapID = value; }

    var directionsEvents = null;
    this.get_directionsEvents = function (read) {
        if (directionsEvents == null && !read)
            directionsEvents = new Sys.EventHandlerList();
        return directionsEvents;
    };

    var loadDelegate = null;
    this.get_loadDelegate = function (getonly) {
        if (!loadDelegate && !getonly)
            loadDelegate = Function.createDelegate(self, self.load)
        return loadDelegate;
    };

    var mapEvents = null;
    this.get_mapEvents = function (read) {
        if (mapEvents == null && !read)
            mapEvents = new Sys.EventHandlerList();
        return mapEvents;
    };

    var mapPano = null;
    this.get_mapPano = function () { return mapPano; }
    this.set_mapPano = function (value) { mapPano = value; };

    var markerEvents = null;
    this.get_markerEvents = function (read) {
        if (markerEvents == null && !read)
            markerEvents = new Sys.EventHandlerList();
        return markerEvents;
    };

    var markerManager = null;
    this.get_markerManager = function () { return markerManager; };
    this.set_markerManager = function (value) { markerManager = value; }

    var name = null;
    this.get_name = function () { return name; };
    this.set_name = function (value) { name = value; };

    var partialUpdateDelegate = null;
    this.get_partialUpdateDelegate = function (getonly) {
        if (!partialUpdateDelegate && !getonly)
            partialUpdateDelegate = Function.createDelegate(self, self._onPartialUpdate)
        return partialUpdateDelegate;
    };

    var polygonEvents = null;
    this.get_polygonEvents = function (read) {
        if (polygonEvents == null && !read)
            polygonEvents = new Sys.EventHandlerList();
        return polygonEvents;
    };

    var polylineEvents = null;
    this.get_polylineEvents = function (read) {
        if (polylineEvents == null && !read)
            polylineEvents = new Sys.EventHandlerList();
        return polylineEvents;
    };

    var raiseServerEventDelegate = null;
    this.get_raiseServerEventDelegate = function (getonly) {
        if (!raiseServerEventDelegate && !getonly)
            raiseServerEventDelegate = Function.createDelegate(self, self._raiseServerEvent);
        return raiseServerEventDelegate;
    };

    var submitDelegate = null;
    this.get_submitDelegate = function (getonly) {
        if (!submitDelegate && !getonly)
            submitDelegate = Function.createDelegate(self, self._onSubmit);
        return submitDelegate;
    };

    // TODO check if this is needed
    //        var renderMarkerManagerDelegate = null;
};

//
Artem.Google.Map.prototype = {

    //#> Fields 

    Address: null,
    Center: null,
    Language: null,
    Region: null,
    Zoom: null,

    Bounds: null,
    DefaultAddress: null,
    DisableClear: false,
    DisableDefaultUI: false,
    DisableDoubleClickZoom: false,
    DisableKeyboardShortcuts: false,
    Draggable: true,
    DraggableCursor: null,
    DraggingCursor: null,
    EnableReverseGeocoding: false,
    EnableScrollWheelZoom: true,
    MapType: null,
    MapTypeControlOptions: null,
    NavigationControlOptions: null,
    ScaleControlOptions: null,
    ShowMapTypeControl: true,
    ShowNavigationControl: true,
    ShowScaleControl: true,
    ShowStreetViewControl: true,
    StreetView: null,

    Markers: [],
    Polygons: [],
    Polylines: [],







    Height: null,
    IsGeolocation: false,
    IsLoaded: false,
    IsStatic: null,
    MarkerManagerOptions: null,
    ShowTraffic: null,
    Width: null,
    // collections
    Actions: [],
    Directions: [],


    //    // BEGIN OBSOLETE
    //    // events
    //    ClientEvents: null,
    //    ServerEvents: null,
    //    MarkerEvents: null,
    //    PolygonEvents: null,
    //    PolylineEvents: null,

    //    // END OBSOLETE

    //#endregion

    //#> Properties 

    get_clientMapID: null,
    set_clientMapID: null,
    get_directionsEvents: null,
    get_loadDelegate: null,
    get_mapEvents: null,
    get_mapPano: null,
    set_mapPano: null,
    get_markerEvents: null,
    get_markerManager: null,
    set_markerManager: null,
    get_name: null,
    set_name: null,
    get_partialUpdateDelegate: null,
    get_polygonEvents: null,
    get_polylineEvents: null,
    get_raiseServerEventDelegate: null,
    get_submitDelegate: null,

    //#<

    //#> Base 



    

    //#> Private Methods 

    _onPartialUpdate: function Artem_Google_Map$_onPartialUpdate() {
        this.loadState();
        return true;
    },

    _onSubmit: function Artem_Google_Map$_onSubmit() {
        this.saveState();
        return true;
    },

    _raiseServerEvent: function Artem_Google_Map$_raiseServerEvent() {

        if (arguments.length > 0) {
            var index = arguments.length - 1;
            var entry = arguments[index];
            var name = entry.name;
            var type = entry.type;
            var data = type + ":" + name;
            var args;

            switch (name) {
                case "addressnotfound":
                case "geoload":
                case "locationloaded":
                    args = new Artem.Google.Events.AddressEventArgs(arguments[0]);
                    break;
                case "click":
                case "dblclick":
                    if (type == "map")
                    // overlay argument passed is not used so far
                        args = new Artem.Google.Events.LocationEventArgs(arguments[1]);
                    else
                        args = new Artem.Google.Events.LocationEventArgs(arguments[0]);
                    break;
                case "dragend":
                case "dragstart":
                    args = new Artem.Google.Events.BoundsEventArgs(this.getBounds());
                    break;
                case "mousemove":
                case "mouseover":
                case "mouseout":
                case "singlerightclick":
                    args = new Artem.Google.Events.LocationEventArgs(arguments[0]);
                    break;
                case "zoomend":
                    args = Artem.Google.Events.ZoomEventArgs(arguments[0], arguments[1]);
                    break;
                case "addmaptype":
                case "addoverlay":
                case "clearoverlays":
                case "drag":
                case "infowindowbeforeclose":
                case "infowindowclose":
                case "infowindowopen":
                case "load":
                case "maptypechanged":
                case "move":
                case "moveend":
                case "movestart":
                case "removemaptype":
                case "removeoverlay":
                    // overlay argument passed is not used so far
                    break;
            }

            if (args)
                data += "$" + Sys.Serialization.JavaScriptSerializer.serialize(args);
            __doPostBack(this.get_name(), data);
        }
    },

    _validateHandler: function Artem_Google_Map$_validateHandler(type, name, handler) {
        return (handler == Artem.Google.serverHandler)
            ? Function.createCallback(this.get_raiseServerEventDelegate(), { name: name, type: type })
            : handler;
    },

    //#endregion

    //#> Public Methods 

    addDirections: function Artem_Google_Map$addDirections(state) {
        if (!this.Directions) this.Directions = new Array();
        this.Directions.push(new Artem.Google.Directions(this, state));
    },

    addMarker: function Artem_Google_Map$addMarker(state) {
        if (!this.Markers) this.Markers = new Array();
        this.Markers.push(new Artem.Google.Marker(this, state));
    },

    addPolygon: function Artem_Google_Map$addPolygon(state) {
        if (!this.Polygons) this.Polygons = new Array();
        this.Polygons.push(new Artem.Google.Polygon(this, state));
    },

    addPolyline: function Artem_Google_Map$addPolyline(state) {
        if (!this.Polylines) this.Polylines = new Array();
        this.Polylines.push(new Artem.Google.Polyline(this, state));
    },

    clearDirections: function Artem_Google_Map$clearDirections() {

        if (this.Directions) {
            for (var i = 0; i < this.Directions.length; i++) {
                this.Directions[i].dispose();
            }
            this.Directions = new Array();
        }
    },

    clearMarkers: function Artem_Google_Map$clearMarkers() {

        if (this.Markers) {
            for (var i = 0; i < this.Markers.length; i++) {
                this.Markers[i].dispose();
            }
            this.Markers = new Array();
        }
    },

    clearPolygons: function Artem_Google_Map$clearPolygons() {

        if (this.Polygons) {
            for (var i = 0; i < this.Polygons.length; i++) {
                this.Polygons[i].dispose();
            }
            this.Polygons = new Array();
        }
    },

    clearPolylines: function Artem_Google_Map$clearPolylines() {

        if (this.Polylines) {
            for (var i = 0; i < this.Polylines.length; i++) {
                this.Polylines[i].dispose();
            }
            this.Polylines = new Array();
        }
    },

    removeDirections: function Artem_Google_Map$removeDirections(index) {
        var items = this.Directions.splice(index, 1)
        if (items && items.length) items[0].dispose();
    },

    removeMarker: function Artem_Google_Map$removeMarker() {
        var items = this.Markers.splice(index, 1)
        if (items && items.length) items[0].dispose();
    },

    removePolygon: function Artem_Google_Map$removePolygon() {
        var items = this.Polygons.splice(index, 1)
        if (items && items.length) items[0].dispose();
    },

    removePolyline: function Artem_Google_Map$removePolyline() {
        var items = this.Polylines.splice(index, 1)
        if (items && items.length) items[0].dispose();
    },

    setAddress: function Artem_Google_Map$setAddress(addresses) {
        if (addresses.Status.code == 200) {
            try {
                this.Address = addresses.Placemark[0].address;
                this._raiseLocationLoaded(this.Address);
            }
            catch (ex) { }
        }
    },

    setStreetView: function Artem_Google_Map$setStreetView(overlay, latlng) {
        this.get_mapPano().setLocationAndPOV(latlng);
    },
    //#endregion

    //#> Events 

    //#region MapEvents 

    // addmaptype event
    add_addmaptype: function Artem_Google_Map$add_addmaptype(handler) {
        this.get_mapEvents().addHandler("addmaptype", this._validateHandler("map", "addmaptype", handler));
    },
    remove_addmaptype: function Artem_Google_Map$remove_addmaptype(handler) {
        this.get_mapEvents().removeHandler("addmaptype", handler);
    },

    // addoverlay event
    add_addoverlay: function Artem_Google_Map$add_addoverlay(handler) {
        this.get_mapEvents().addHandler("addoverlay", this._validateHandler("map", "addoverlay", handler));
    },
    remove_addoverlay: function Artem_Google_Map$remove_addoverlay(handler) {
        this.get_mapEvents().removeHandler("addoverlay", handler);
    },

    // addressnotfound
    add_addressnotfound: function Artem_Google_Map$add_addressnotfound(handler) {
        this.get_events().addHandler("addressnotfound", this._validateHandler("map", "addressnotfound", handler));
    },
    remove_addressnotfound: function Artem_Google_Map$remove_addressnotfound(handler) {
        this.get_events().removeHandler("addressnotfound", handler);
    },
    _raiseAddressNotFound: function Artem_Google_Map$_raiseAddressNotFound(address) {
        var handler = this.get_events().getHandler('addressnotfound');
        if (handler) handler(address);
    },

    // clearoverlays event
    add_clearoverlays: function Artem_Google_Map$add_clearoverlays(handler) {
        this.get_mapEvents().addHandler("clearoverlays", this._validateHandler("map", "clearoverlays", handler));
    },
    remove_clearoverlays: function Artem_Google_Map$remove_clearoverlays(handler) {
        this.get_mapEvents().removeHandler("clearoverlays", handler);
    },

    // click event
    add_click: function Artem_Google_Map$add_click(handler) {
        this.get_mapEvents().addHandler("click", this._validateHandler("map", "click", handler));
    },
    remove_click: function Artem_Google_Map$remove_click(handler) {
        this.get_mapEvents().removeHandler("click", handler);
    },

    // dblclick event
    add_dblclick: function Artem_Google_Map$add_dblclick(handler) {
        this.get_mapEvents().addHandler("dblclick", this._validateHandler("map", "dblclick", handler));
    },
    remove_dblclick: function Artem_Google_Map$remove_dblclick(handler) {
        this.get_mapEvents().removeHandler("dblclick", handler);
    },

    // drag event
    add_drag: function Artem_Google_Map$add_drag(handler) {
        this.get_mapEvents().addHandler("drag", this._validateHandler("map", "drag", handler));
    },
    remove_drag: function Artem_Google_Map$remove_drag(handler) {
        this.get_mapEvents().removeHandler("drag", handler);
    },

    // dragend event
    add_dragend: function Artem_Google_Map$add_dragend(handler) {
        this.get_mapEvents().addHandler("dragend", this._validateHandler("map", "dragend", handler));
    },
    remove_dragend: function Artem_Google_Map$remove_dragend(handler) {
        this.get_mapEvents().removeHandler("dragend", handler);
    },

    // dragstart event
    add_dragstart: function Artem_Google_Map$add_dragstart(handler) {
        this.get_mapEvents().addHandler("dragstart", this._validateHandler("map", "dragstart", handler));
    },
    remove_dragstart: function Artem_Google_Map$remove_dragstart(handler) {
        this.get_mapEvents().removeHandler("dragstart", handler);
    },

    // geoload event
    add_geoload: function Artem_Google_Map$add_geoload(handler) {
        this.get_events().addHandler("geoload", this._validateHandler("map", "geoload", handler));
    },
    remove_geoload: function Artem_Google_Map$remove_geoload(handler) {
        this.get_events().removeHandler("geoload", handler);
    },
    _raiseGeoLoad: function Artem_Google_Map$_raisegeoload(address) {
        var handler = this.get_events().getHandler('geoload');
        if (handler) handler(address);
    },

    // infowindowbeforeclose event
    add_infowindowbeforeclose: function Artem_Google_Map$add_infowindowbeforeclose(handler) {
        this.get_mapEvents().addHandler("infowindowbeforeclose", this._validateHandler("map", "infowindowbeforeclose", handler));
    },
    remove_infowindowbeforeclose: function Artem_Google_Map$remove_infowindowbeforeclose(handler) {
        this.get_mapEvents().removeHandler("infowindowbeforeclose", handler);
    },

    // infowindowclose event
    add_infowindowclose: function Artem_Google_Map$add_infowindowclose(handler) {
        this.get_mapEvents().addHandler("infowindowclose", this._validateHandler("map", "infowindowclose", handler));
    },
    remove_infowindowclose: function Artem_Google_Map$remove_infowindowclose(handler) {
        this.get_mapEvents().removeHandler("infowindowclose", handler);
    },

    // infowindowopen event
    add_infowindowopen: function Artem_Google_Map$add_infowindowopen(handler) {
        this.get_mapEvents().addHandler("infowindowopen", this._validateHandler("map", "infowindowopen", handler));
    },
    remove_infowindowopen: function Artem_Google_Map$remove_infowindowopen(handler) {
        this.get_mapEvents().removeHandler("infowindowopen", handler);
    },

    // load event
    add_load: function Artem_Google_Map$add_load(handler) {
        this.get_mapEvents().addHandler("load", this._validateHandler("map", "load", handler));
    },
    remove_load: function Artem_Google_Map$remove_load(handler) {
        this.get_mapEvents().removeHandler("load", handler);
    },

    // locationloaded event
    add_locationloaded: function Artem_Google_Map$add_locationloaded(handler) {
        this.get_events().addHandler("locationloaded", this._validateHandler("map", "locationloaded", handler));
    },
    remove_locationloaded: function Artem_Google_Map$remove_locationloaded(handler) {
        this.get_events().removeHandler("locationloaded", handler);
    },
    _raiseLocationLoaded: function Artem_Google_Map$_raiseLocationLoaded(address) {
        var handler = this.get_events().getHandler('locationloaded');
        if (handler) handler(address);
    },

    // maptypechanged event
    add_maptypechanged: function Artem_Google_Map$add_maptypechanged(handler) {
        this.get_mapEvents().addHandler("maptypechanged", this._validateHandler("map", "maptypechanged", handler));
    },
    remove_maptypechanged: function Artem_Google_Map$remove_maptypechanged(handler) {
        this.get_mapEvents().removeHandler("maptypechanged", handler);
    },

    // mousedown event
    add_mousedown: function Artem_Google_Map$add_mousedown(handler) {
        this.get_mapEvents().addHandler("mousedown", this._validateHandler("map", "mousedown", handler));
    },
    remove_mousedown: function Artem_Google_Map$remove_mousedown(handler) {
        this.get_mapEvents().removeHandler("mousedown", handler);
    },

    // mousemove event
    add_mousemove: function Artem_Google_Map$add_mousemove(handler) {
        this.get_mapEvents().addHandler("mousemove", this._validateHandler("map", "mousemove", handler));
    },
    remove_mousemove: function Artem_Google_Map$remove_mousemove(handler) {
        this.get_mapEvents().removeHandler("mousemove", handler);
    },

    // mouseout event
    add_mouseout: function Artem_Google_Map$add_mouseout(handler) {
        this.get_mapEvents().addHandler("mouseout", this._validateHandler("map", "mouseout", handler));
    },
    remove_mouseout: function Artem_Google_Map$remove_mouseout(handler) {
        this.get_mapEvents().removeHandler("mouseout", handler);
    },

    // mouseover event
    add_mouseover: function Artem_Google_Map$add_mouseover(handler) {
        this.get_mapEvents().addHandler("mouseover", this._validateHandler("map", "mouseover", handler));
    },
    remove_mouseover: function Artem_Google_Map$remove_mouseover(handler) {
        this.get_mapEvents().removeHandler("mouseover", handler);
    },

    // mouseup event
    add_mouseup: function Artem_Google_Map$add_mouseup(handler) {
        this.get_mapEvents().addHandler("mouseup", this._validateHandler("map", "mouseup", handler));
    },
    remove_mouseup: function Artem_Google_Map$remove_mouseup(handler) {
        this.get_mapEvents().removeHandler("mouseup", handler);
    },

    // move event
    add_move: function Artem_Google_Map$add_move(handler) {
        this.get_mapEvents().addHandler("move", this._validateHandler("map", "move", handler));
    },
    remove_move: function Artem_Google_Map$remove_move(handler) {
        this.get_mapEvents().removeHandler("move", handler);
    },

    // moveend event
    add_moveend: function Artem_Google_Map$add_moveend(handler) {
        this.get_mapEvents().addHandler("moveend", this._validateHandler("map", "moveend", handler));
    },
    remove_moveend: function Artem_Google_Map$remove_moveend(handler) {
        this.get_mapEvents().removeHandler("moveend", handler);
    },

    // movestart event
    add_movestart: function Artem_Google_Map$add_movestart(handler) {
        this.get_mapEvents().addHandler("movestart", this._validateHandler("map", "movestart", handler));
    },
    remove_movestart: function Artem_Google_Map$remove_movestart(handler) {
        this.get_mapEvents().removeHandler("movestart", handler);
    },

    // removemaptype event
    add_removemaptype: function Artem_Google_Map$add_removemaptype(handler) {
        this.get_mapEvents().addHandler("removemaptype", this._validateHandler("map", "removemaptype", handler));
    },
    remove_removemaptype: function Artem_Google_Map$remove_removemaptype(handler) {
        this.get_mapEvents().removeHandler("removemaptype", handler);
    },

    // removeoverlay event
    add_removeoverlay: function Artem_Google_Map$add_removeoverlay(handler) {
        this.get_mapEvents().addHandler("removeoverlay", this._validateHandler("map", "removeoverlay", handler));
    },
    remove_removeoverlay: function Artem_Google_Map$remove_removeoverlay(handler) {
        this.get_mapEvents().removeHandler("removeoverlay", handler);
    },

    // singlerightclick event
    add_singlerightclick: function Artem_Google_Map$add_singlerightclick(handler) {
        this.get_mapEvents().addHandler("singlerightclick", this._validateHandler("map", "singlerightclick", handler));
    },
    remove_singlerightclick: function Artem_Google_Map$remove_singlerightclick(handler) {
        this.get_mapEvents().removeHandler("singlerightclick", handler);
    },

    // zoomend event
    add_zoomend: function Artem_Google_Map$add_zoomend(handler) {
        this.get_mapEvents().addHandler("zoomend", this._validateHandler("map", "zoomend", handler));
    },
    remove_zoomend: function Artem_Google_Map$remove_zoomend(handler) {
        this.get_mapEvents().removeHandler("zoomend", handler);
    },

    //#endregion

    //#region MarkerEvents

    add_marker_click: function (handler) {
        this.get_markerEvents().addHandler("click", this._validateHandler("marker", "click", handler));
    },
    remove_marker_click: function (handler) {
        this.get_markerEvents().removeHandler("click", handler);
    },

    add_marker_dblclick: function (handler) {
        this.get_markerEvents().addHandler("dblclick", this._validateHandler("marker", "dblclick", handler));
    },
    remove_marker_dblclick: function (handler) {
        this.get_markerEvents().removeHandler("dblclick", handler);
    },

    add_marker_drag: function (handler) {
        this.get_markerEvents().addHandler("drag", this._validateHandler("marker", "drag", handler));
    },
    remove_marker_drag: function (handler) {
        this.get_markerEvents().removeHandler("drag", handler);
    },

    add_marker_dragend: function (handler) {
        this.get_markerEvents().addHandler("dragend", this._validateHandler("marker", "dragend", handler));
    },
    remove_marker_dragend: function (handler) {
        this.get_markerEvents().removeHandler("dragend", handler);
    },

    add_marker_dragstart: function (handler) {
        this.get_markerEvents().addHandler("dragstart", this._validateHandler("marker", "dragstart", handler));
    },
    remove_marker_dragstart: function (handler) {
        this.get_markerEvents().removeHandler("dragstart", handler);
    },

    // TODO geoload

    add_marker_infowindowopen: function (handler) {
        this.get_markerEvents().addHandler("infowindowopen", this._validateHandler("marker", "infowindowopen", handler));
    },
    remove_marker_infowindowopen: function (handler) {
        this.get_markerEvents().removeHandler("infowindowopen", handler);
    },

    add_marker_infowindowbeforeclose: function (handler) {
        this.get_markerEvents().addHandler("infowindowbeforeclose", this._validateHandler("marker", "infowindowbeforeclose", handler));
    },
    remove_marker_infowindowbeforeclose: function (handler) {
        this.get_markerEvents().removeHandler("infowindowbeforeclose", handler);
    },

    add_marker_infowindowclose: function (handler) {
        this.get_markerEvents().addHandler("infowindowclose", this._validateHandler("marker", "infowindowclose", handler));
    },
    remove_marker_infowindowclose: function (handler) {
        this.get_markerEvents().removeHandler("infowindowclose", handler);
    },

    add_marker_mousedown: function (handler) {
        this.get_markerEvents().addHandler("mousedown", this._validateHandler("marker", "mousedown", handler));
    },
    remove_marker_mousedown: function (handler) {
        this.get_markerEvents().removeHandler("mousedown", handler);
    },

    add_marker_mouseout: function (handler) {
        this.get_markerEvents().addHandler("mouseout", this._validateHandler("marker", "mouseout", handler));
    },
    remove_marker_mouseout: function (handler) {
        this.get_markerEvents().removeHandler("mouseout", handler);
    },

    add_marker_mouseover: function (handler) {
        this.get_markerEvents().addHandler("mouseover", this._validateHandler("marker", "mouseover", handler));
    },
    remove_marker_mouseover: function (handler) {
        this.get_markerEvents().removeHandler("mouseover", handler);
    },

    add_marker_mouseup: function (handler) {
        this.get_markerEvents().addHandler("mouseup", this._validateHandler("marker", "mouseup", handler));
    },
    remove_marker_mouseup: function (handler) {
        this.get_markerEvents().removeHandler("mouseup", handler);
    },

    add_marker_remove: function (handler) {
        this.get_markerEvents().addHandler("remove", this._validateHandler("marker", "remove", handler));
    },
    remove_marker_remove: function (handler) {
        this.get_markerEvents().removeHandler("remove", handler);
    },

    add_marker_visibilitychanged: function (handler) {
        this.get_markerEvents().addHandler("visibilitychanged", this._validateHandler("marker", "visibilitychanged", handler));
    },
    remove_marker_visibilitychanged: function (handler) {
        this.get_markerEvents().removeHandler("visibilitychanged", handler);
    },

    //#endregion

    //#region DirectionsEvents

    add_directions_addoverlay: function (handler) {
        this.get_directionsEvents().addHandler("addoverlay", this._validateHandler("directions", "addoverlay", handler));
    },
    remove_directions_addoverlay: function (handler) {
        this.get_directionsEvents().removeHandler("addoverlay", handler);
    },

    add_directions_error: function (handler) {
        this.get_directionsEvents().addHandler("error", this._validateHandler("directions", "error", handler));
    },
    remove_directions_error: function (handler) {
        this.get_directionsEvents().removeHandler("error", handler);
    },

    add_directions_load: function (handler) {
        this.get_directionsEvents().addHandler("load", this._validateHandler("directions", "load", handler));
    },
    remove_directions_load: function (handler) {
        this.get_directionsEvents().removeHandler("load", handler);
    },

    //#endregion

    //#region PolygonEvents

    add_polygon_cancelline: function (handler) {
        this.get_polygonEvents().addHandler("cancelline", this._validateHandler("polygon", "cancelline", handler));
    },
    remove_polygon_cancelline: function (handler) {
        this.get_polygonEvents().removeHandler("cancelline", handler);
    },

    add_polygon_click: function (handler) {
        this.get_polygonEvents().addHandler("click", this._validateHandler("polygon", "click", handler));
    },
    remove_polygon_click: function (handler) {
        this.get_polygonEvents().removeHandler("click", handler);
    },

    add_polygon_endline: function (handler) {
        this.get_polygonEvents().addHandler("endline", this._validateHandler("polygon", "endline", handler));
    },
    remove_polygon_endline: function (handler) {
        this.get_polygonEvents().removeHandler("endline", handler);
    },

    add_polygon_lineupdated: function (handler) {
        this.get_polygonEvents().addHandler("lineupdated", this._validateHandler("polygon", "lineupdated", handler));
    },
    remove_polygon_lineupdated: function (handler) {
        this.get_polygonEvents().removeHandler("lineupdated", handler);
    },

    add_polygon_mouseout: function (handler) {
        this.get_polygonEvents().addHandler("mouseout", this._validateHandler("polygon", "mouseout", handler));
    },
    remove_polygon_mouseout: function (handler) {
        this.get_polygonEvents().removeHandler("mouseout", handler);
    },

    add_polygon_mouseover: function (handler) {
        this.get_polygonEvents().addHandler("mouseover", this._validateHandler("polygon", "mouseover", handler));
    },
    remove_polygon_mouseover: function (handler) {
        this.get_polygonEvents().removeHandler("mouseover", handler);
    },

    add_polygon_remove: function (handler) {
        this.get_polygonEvents().addHandler("remove", this._validateHandler("polygon", "remove", handler));
    },
    remove_polygon_remove: function (handler) {
        this.get_polygonEvents().removeHandler("remove", handler);
    },

    add_polygon_visibilitychanged: function (handler) {
        this.get_polygonEvents().addHandler("visibilitychanged", this._validateHandler("polygon", "visibilitychanged", handler));
    },
    remove_polygon_visibilitychanged: function (handler) {
        this.get_polygonEvents().removeHandler("visibilitychanged", handler);
    },

    //#endregion 

    //#> PolylineEvents

    add_polyline_cancelline: function (handler) {
        this.get_polylineEvents().addHandler("cancelline", this._validateHandler("polyline", "cancelline", handler));
    },
    remove_polyline_cancelline: function (handler) {
        this.get_polylineEvents().removeHandler("cancelline", handler);
    },

    add_polyline_click: function (handler) {
        this.get_polylineEvents().addHandler("click", this._validateHandler("polyline", "click", handler));
    },
    remove_polyline_click: function (handler) {
        this.get_polylineEvents().removeHandler("click", handler);
    },

    add_polyline_endline: function (handler) {
        this.get_polylineEvents().addHandler("endline", this._validateHandler("polyline", "endline", handler));
    },
    remove_polyline_endline: function (handler) {
        this.get_polylineEvents().removeHandler("endline", handler);
    },

    add_polyline_lineupdated: function (handler) {
        this.get_polylineEvents().addHandler("lineupdated", this._validateHandler("polyline", "lineupdated", handler));
    },
    remove_polyline_lineupdated: function (handler) {
        this.get_polylineEvents().removeHandler("lineupdated", handler);
    },

    add_polyline_mouseout: function (handler) {
        this.get_polylineEvents().addHandler("mouseout", this._validateHandler("polyline", "mouseout", handler));
    },
    remove_polyline_mouseout: function (handler) {
        this.get_polylineEvents().removeHandler("mouseout", handler);
    },

    add_polyline_mouseover: function (handler) {
        this.get_polylineEvents().addHandler("mouseover", this._validateHandler("polyline", "mouseover", handler));
    },
    remove_polyline_mouseover: function (handler) {
        this.get_polylineEvents().removeHandler("mouseover", handler);
    },

    add_polyline_remove: function (handler) {
        this.get_polylineEvents().addHandler("remove", this._validateHandler("polyline", "remove", handler));
    },
    remove_polyline_remove: function (handler) {
        this.get_polylineEvents().removeHandler("remove", handler);
    },

    add_polyline_visibilitychanged: function (handler) {
        this.get_polylineEvents().addHandler("visibilitychanged", this._validateHandler("polyline", "visibilitychanged", handler));
    },
    remove_polyline_visibilitychanged: function (handler) {
        this.get_polylineEvents().removeHandler("visibilitychanged", handler);
    },

    //#<
};

Artem.Google.Map.registerClass("Artem.Google.Map", Sys.UI.Control);
//#endregion

// Properties
(function (proto) {

} (Artem.Google.Map.prototype));

// Common
(function (proto) {

    // properties
    var geocoder;
    proto.get_geocoder = function () {
        return geocoder || (geocoder = new google.maps.Geocoder());
    };

    //#> private methods - create & render
    function create(map, location) {
        /// <summary>Creates the map.</summary>

        if (location)
            map.Center = new Artem.Google.Location(location);
        else
            location = new google.maps.LatLng(map.Center.Latitude, map.Center.Longitude);

        var options = {
            center: null,
            mapTypeId: Artem.Google.Converter.mapTypeId(map.MapType),
            zoom: map.Zoom,
            disableDefaultUI: map.DisableDefaultUI,
            disableDoubleClickZoom: map.DisableDoubleClickZoom,
            draggable: map.Draggable,
            draggableCursor: map.DraggableCursor,
            draggingCursor: map.DraggingCursor,
            keyboardShortcuts: !map.DisableKeyboardShortcuts,
            mapTypeControl: map.ShowMapTypeControl,
            navigationControl: map.ShowNavigationControl,
            noClear: map.DisableClear,
            scaleControl: map.ShowScaleControl,
            scaleControlOptions: map.ScaleControlOptions,
            scrollwheel: map.EnableScrollWheelZoom,
            streetViewControl: map.ShowStreetViewControl
        };

        if (location)
            map.Center = new Artem.Google.Location(location);
        else
            location = new google.maps.LatLng(map.Center.Latitude, map.Center.Longitude);

        options.center = location;

        if (map.MapTypeControlOptions)
            options.mapTypeControlOptions = Artem.Google.Converter.mapTypeControlOptions(map.MapTypeControlOptions);
        if (map.NavigationControlOptions)
            options.navigationControlOptions = Artem.Google.Converter.navigationControlOptions(map.NavigationControlOptions);
        if (map.StreetView)
            options.streetView = Artem.Google.Converter.streetView(map.StreetView, location);

        var gmap = new google.maps.Map(map.get_element(), options);
        map.set_map(gmap);

        attachEvents(map);
        render(map);
    }

    function render(map) {
        /// <summary>Renders the map overlays.</summary>

        var i, name, handler;
        // markers
        if (map.Markers) {
            for (i = 0; i < map.Markers.length; i++) {
                map.Markers[i] = new Artem.Google.Marker(map, i, map.Markers[i]);
                // attach events
                for (name in map.get_markerEvents()._list) {
                    handler = map.get_markerEvents().getHandler(name);
                    google.maps.event.addListener(map.Markers[i].get_marker(), name, handler);
                }
            }
        }
        // directions
        if (map.Directions) {
            for (i = 0; i < map.Directions.length; i++) {
                map.Directions[i] = new Artem.Google.Directions(map, map.Directions[i]);
                // attach events
                for (name in map.get_directionsEvents()._list) {
                    handler = map.get_directionsEvents().getHandler(name);
                    google.maps.event.addListener(map.Directions[i].get_directions(), name, handler);
                }
            }
        }
        // polygons
        if (map.Polygons) {
            for (i = 0; i < map.Polygons.length; i++) {
                map.Polygons[i] = new Artem.Google.Polygon(map, map.Polygons[i]);
                // attach events
                for (name in map.get_polygonEvents()._list) {
                    handler = map.get_polygonEvents().getHandler(name);
                    google.maps.event.addListener(map.Polygons[i].get_polygon(), name, handler);
                }
            }
        }
        // polylines
        if (map.Polylines) {
            for (i = 0; i < map.Polylines.length; i++) {
                map.Polylines[i] = new Artem.Google.Polyline(map, map.Polylines[i]);
                // attach events
                for (name in map.get_polylineEvents()._list) {
                    handler = map.get_polylineEvents().getHandler(name);
                    google.maps.event.addListener(map.Polylines[i].get_polyline(), name, handler);
                }
            }
        }
        //        // fire actions
        //        if (map.Actions) {
        //            for (var i = 0; i < map.Actions.length; i++) {
        //                Function.Delegate.callFromString(map, map.Actions[i]);
        //            }
        //        }

        // traffic overlay
        if(map.ShowTraffic) {
            var traffic = new google.maps.TrafficLayer();
            traffic.setMap(map.get_map());
        }
    }
    //#<

    //#> private methods - events attach/detach
    function attachEvents (map) {

        if (typeof (Sys.WebForms) !== "undefined" && typeof (Sys.WebForms.PageRequestManager) !== "undefined") {
            var requestManager = Sys.WebForms.PageRequestManager.getInstance();
            if (requestManager) {
                Array.add(requestManager._onSubmitStatements, map.get_submitDelegate());
                requestManager.add_endRequest(map.get_partialUpdateDelegate());
            }
        }
        else {
            $addHandler(document.forms[0], "submit", map.get_submitDelegate());
        }

        // map events
        var name, handler;
        var events = map.get_mapEvents();
        var gmap = map.get_map();
        for (name in events._list) {
            handler = events.getHandler(name);
            google.maps.event.addListener(gmap, name, handler);
        }
    }

    function detachEvents (map) {

        var delegate;
        if (typeof (Sys.WebForms) !== "undefined" && typeof (Sys.WebForms.PageRequestManager) !== "undefined") {
            var requestManager = Sys.WebForms.PageRequestManager.getInstance();
            if (requestManager) {
                delegate = map.get_partialUpdateDelegate(true);
                if (delegate) {
                    requestManager.remove_endRequest(delegate);
                }
                delegate = map.get_submitDelegate(true);
                if (delegate) {
                    Array.remove(requestManager._onSubmitStatements, delegate);
                }
            }
        }
        else {
            delegate = map.get_submitDelegate(true);
            if (delegate) {
                $removeHandler(document.forms[0], "submit", delegate);
            }
        }

        // remove map event handlers
        var gmap = map.get_map();
        if (gmap) google.maps.event.clearInstanceListeners(gmap);
    }
    //#<

    //#> private nmethods - handle geocoding errors
    function handleAddressError(map, status) {

        if (!map.Center && map.DefaultAddress) {
            if (console && console.warn)
                console.warn(status + " ... applying default address.");

            var geocoder = map.get_geocoder();
            var request = { 'address': map.DefaultAddress };

            if (map.Language)
                request.language = map.Language;
            if (map.Region)
                request.region = map.Region;

            geocoder.geocode(request, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    create(map, results[0].geometry.location);
                }
                else {
                    if (console && console.error)
                        console.error("DefaultAddress geocoding failed with status: " + status);
                }
            });
        }
        else {
            if (console && console.error)
                console.error("Address geocoding failed with status: " + status + "\nDefaultAddress is not set and map was left empty!");
        }
    }

    function handleLocationError(map, status) {

        if (!map.Center) {
            if (console && console.error)
                console.error("Reverse location geocoding failed with status: " + status);
        }
        else {
            if (console && console.error)
                console.error("The map center is not set (latitude/longitude)!");
        }
    }
    //#<

    //#> public methods - control base
    proto.initialize = function () {
        Artem.Google.Map.callBaseMethod(this, 'initialize');
        var self = this;

        eval("window." + this.get_clientMapID() + " = this;");
        this.loadState();

        // create map
        if (this.Center) {
            create(this);
            // if reverse geocoding is enabled then try resolve the address
            if (this.EnableReverseGeocoding) {
                var location = new google.maps.LatLng(this.Center.Latitude, this.Center.Longitude);
                this.geocodeLocation(location, function (address) { self.Address = address; });
            }
        }
        else {
            this.geocodeAddress(this.Address, function (location) { create(self, location); });
        }
    };

    proto.dispose = function () {

        // first remove event handlers
        detachEvents(this);

        // clear 
        this.clearMarkers();
        this.clearDirections();
        this.clearPolygons();
        this.clearPolylines()

        delete this.get_clientMapID;
        delete this.get_loadDelegate;
        delete this.get_mapEvents;
        delete this.get_mapPano;
        delete this.get_markerManager;
        delete this.get_name;
        delete this.get_partialUpdateDelegate;
        delete this.get_polygonEvents;
        delete this.get_polylineEvents;
        delete this.get_raiseServerEventDelegate;
        delete this.get_submitDelegate;

        Artem.Google.Map.callBaseMethod(this, 'dispose');
    };
    //#<

    //#> public methods - geocoding
    proto.getGeocodeRequest = function (latlng, address) {

        return {
            latLng: latlng,
            address: address,
            language: this.Language,
            region: this.Region
        };
    };

    proto.geocodeAddress = function (address, callback) {

        var self = this;
        var geocoder = this.get_geocoder();
        var request = this.getGeocodeRequest(null, address);

        geocoder.geocode(request, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                try {
                    var location;
                    if (results && results.length)
                        location = results[0].geometry.location;
                    callback(location);
                }
                catch (ex) {
                    // TODO
                }
            }
            else {
                handleAddressError(self, status);
            }
        });
    };

    proto.geocodeLocation = function (latlng, callback) {

        var self = this;
        var geocoder = this.get_geocoder();
        var request = this.getGeocodeRequest(latlng, null);

        geocoder.geocode(request, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                try {
                    var address;
                    if (results && results.length)
                        address = results[0].formatted_address;
                    callback(address);
                }
                catch (ex) {
                    // TODO
                }
            }
            else {
                handleLocationError(self, status);
            }
        });
    };
    //#<
} (Artem.Google.Map.prototype));

// State
(function (proto) {

    
    
    // properties
    var clientStateID = null;
    proto.get_clientStateID = function () { return clientStateID; };
    proto.set_clientStateID = function (value) { clientStateID = value; };

    proto.viewState = {
        
    };

    // public method
    proto.loadState = function () {

        if (clientStateID) {
            var stateField = $get(clientStateID);
            if (stateField) {
                var stateContent = stateField.value;
                if (stateContent == 'undefined' || stateContent == '') return;
                var state = Sys.Serialization.JavaScriptSerializer.deserialize(stateContent, true);

                this.Address = state.Address;
                this.Center = state.Center;
                this.Language = state.Language;
                this.Region = state.Region;
                this.Zoom = state.Zoom;

                this.Bounds = state.Bounds;
                this.DefaultAddress = state.DefaultAddress;
                this.DisableClear = state.DisableClear;
                this.DisableDefaultUI = state.DisableDefaultUI;
                this.DisableDoubleClickZoom = state.DisableDoubleClickZoom;
                this.DisableKeyboardShortcuts = state.DisableKeyboardShortcuts;
                this.Draggable = state.Draggable;
                this.DraggableCursor = state.DraggableCursor;
                this.DraggingCursor = state.DraggingCursor;
                this.EnableReverseGeocoding = state.EnableReverseGeocoding;
                this.EnableScrollWheelZoom = state.EnableScrollWheelZoom;
                this.MapType = state.MapType;
                this.MapTypeControlOptions = state.MapTypeControlOptions;
                this.NavigationControlOptions = state.NavigationControlOptions;
                this.ScaleControlOptions = state.ScaleControlOptions;
                this.ShowMapTypeControl = state.ShowMapTypeControl;
                this.ShowNavigationControl = state.ShowNavigationControl;
                this.ShowScaleControl = state.ShowScaleControl;
                this.ShowStreetViewControl = state.ShowStreetViewControl;
                this.ShowTraffic = state.ShowTraffic;
                this.StreetView = state.StreetView;

                this.Markers = state.Markers;
                this.Polygons = state.Polygons;
                this.Polylines = state.Polylines;







                this.Directions = state.Directions;
                this.Height = state.Height;
                this.IsStatic = state.IsStatic;
                this.Width = state.Width;

                //        // events
                //        if (config.MapEvents) {
                //            this.ClientEvents = config.MapEvents.ClientEvents;
                //            this.ServerEvents = config.MapEvents.ServerEvents;
                //        }
                //        this.MarkerEvents = config.MarkerEvents;
                //        this.PolygonEvents = config.PolygonEvents;
                //        this.PolylineEvents = config.PolylineEvents;
            }
        }
    };

    proto.saveState = function () {

        if (clientStateID) {
            var stateField = $get(clientStateID);
            if (stateField) {
                var i;
                var center = this.getCenter();

                this.Bounds = new Artem.Google.Bounds(this.getBounds());
                this.Center = {
                    Latitude: (center !== null) ? center.lat() : 0,
                    Longitude: (center !== null) ? center.lng() : 0
                };
                this.Zoom = this.getZoom() || 0;

                if (this.Markers) {
                    for (i = 0; i < this.Markers.length; i++) {
                        this.Markers[i].save();
                    }
                }
                if (this.Directions) {
                    for (i = 0; i < this.Directions.length; i++) {
                        this.Directions[i].save();
                    }
                }
                if (this.Polygons) {
                    for (i = 0; i < this.Polygons.length; i++) {
                        this.Polygons[i].save();
                    }
                }
                if (this.Polylines) {
                    for (i = 0; i < this.Polylines.length; i++) {
                        this.Polylines[i].save();
                    }
                }

                var state = new Artem.Google.State(this);
                stateField.value = Sys.Serialization.JavaScriptSerializer.serialize(state);
            }
        }
    };
} (Artem.Google.Map.prototype));

// Markers
(function (proto) {

} (Artem.Google.Map.prototype));

// Polylines
(function (proto) {

} (Artem.Google.Map.prototype));

// Polygons
(function (proto) {

} (Artem.Google.Map.prototype));

// Directions
(function (proto) {

} (Artem.Google.Map.prototype));

// Events
(function () {
    // AddressEventArgs
    Artem.Google.Events.AddressEventArgs = function Artem_Google_Events_AddressEventArgs(address) {
        Artem.Google.Events.AddressEventArgs.initializeBase(this);
        this.Address = address;
    }
    Artem.Google.Events.AddressEventArgs.prototype = {
        Address: null
    }
    Artem.Google.Events.AddressEventArgs.registerClass("Artem.Google.Events.AddressEventArgs", Sys.EventArgs);

    // BoundsEventArgs
    Artem.Google.Events.BoundsEventArgs = function Artem_Google_Events_BoundsEventArgs(gbouns) {
        Artem.Google.Events.BoundsEventArgs.initializeBase(this);
        this.Bounds = new Artem.Google.Bounds(gbouns);
    }
    Artem.Google.Events.BoundsEventArgs.prototype = {
        Bounds: null
    }
    Artem.Google.Events.BoundsEventArgs.registerClass("Artem.Google.Events.BoundsEventArgs", Sys.EventArgs);

    // LocationEventArgs
    Artem.Google.Events.LocationEventArgs = function Artem_Google_Events_LocationEventArgs(glocation) {
        Artem.Google.Events.LocationEventArgs.initializeBase(this);
        this.Location = new Artem.Google.Location(glocation);
    }
    Artem.Google.Events.LocationEventArgs.prototype = {
        Location: null
    }
    Artem.Google.Events.LocationEventArgs.registerClass("Artem.Google.Events.LocationEventArgs", Sys.EventArgs);

    // VisibilityEventArgs
    Artem.Google.Events.VisibilityEventArgs = function Artem_Google_Events_VisibilityEventArgs(visible) {
        Artem.Google.Events.VisibilityEventArgs.initializeBase(this);
        this.Visible = visible;
    }
    Artem.Google.Events.VisibilityEventArgs.prototype = {
        Visible: false
    }
    Artem.Google.Events.VisibilityEventArgs.registerClass("Artem.Google.Events.VisibilityEventArgs", Sys.EventArgs);

    // ZoomEventArgs
    Artem.Google.Events.ZoomEventArgs = function Artem_Google_Events_ZoomEventArgs(oldlevel, newlevel) {
        Artem.Google.Events.ZoomEventArgs.initializeBase(this);
        this.NewLevel = newlevel;
        this.OldLevel = oldlevel;
    }
    Artem.Google.Events.ZoomEventArgs.prototype = {
        NewLevel: null,
        OldLevel: null
    }
    Artem.Google.Events.ZoomEventArgs.registerClass("Artem.Google.Events.ZoomEventArgs", Sys.EventArgs);

} ());

// Google Maps API Wrapped
(function (proto) {

    // properties
    var map = null;
    proto.get_map = function () { return map; };
    proto.set_map = function (value) { map = value; };

    // public methods
    proto.fitBounds = function (bounds) {
        return map.fitBounds(bounds);
    };

    proto.getBounds = function () {
        return map.getBounds();
    };

    proto.getCenter = function () {
        return map.getCenter();
    };

    proto.getDiv = function () {
        return map.getDiv();
    };

    proto.getMapTypeId = function () {
        return map.getMapTypeId();
    };

    proto.getProjection = function () {
        return map.getProjection();
    };

    proto.getStreetView = function () {
        return map.getStreetView();
    }

    proto.getZoom = function () {
        return map.getZoom();
    };

    proto.panBy = function (x, y) {
        map.panBy(x, y);
    };

    proto.panTo = function (latlng) {
        map.panTo(latlng);
    };

    proto.panToBounds = function (bounds) {
        map.panToBounds(bounds);
    };

    proto.setCenter = function (latlng) {
        map.setCenter(latlng);
    };

    proto.setMapTypeId = function (mapTypeId) {
        map.setMapTypeId(mapTypeId);
    };

    proto.setOptions = function (options) {
        map.setOptions(panorama);
    };

    proto.setStreetView = function (panorama) {
        map.setStreetView(panorama);
    };

    proto.setZoom = function (zoom) {
        map.setZoom(zoom);
    };
} (Artem.Google.Map.prototype));

// Obsolete
(function (proto) {

    //    load: function Artem_Google_Map$load(point) {
    //        if (point) {
    //            if (!this.IsStatic && !(this.IsStreetView && this.StreetViewMode == 0)) {
    //                this.Latitude = point.lat();
    //                this.Longitude = point.lng();
    //                this.setCenter(point, this.Zoom);
    //                if (this.IsGeolocation) {
    //                    this.IsGeolocation = false;
    //                    this._raiseGeoLoad(this.Address);
    //                }
    //                if (this.EnableReverseGeocoding && !this.Address) {
    //                    var delegate = Function.Delegate.create(this, this.setAddress);
    //                    this.get_geocoder().getLocations(point, delegate);
    //                }
    //                this.preRender();
    //                this.render();
    //                //                this.checkResize();
    //            }
    //            else if (this.IsStreetView) {
    //                this.loadStreetView(point);
    //            }
    //            else {
    //                this.loadStatic();
    //            }
    //            this.IsLoaded = true;
    //        }
    //        else {
    //            if ((this.Latitude !== 0) && (this.Longitude !== 0))
    //                this.load(new google.maps.LatLng(this.Latitude, this.Longitude));
    //            else {
    //                if (!this.IsGeolocation) {
    //                    this.IsGeolocation = true;
    //                    this.get_geocoder().getLatLng(this.Address, this.get_loadDelegate());
    //                }
    //            }
    //        }
    //    },

    //    loadAddress: function Artem_Google_Map$loadAddress(address) {
    //        this.Address = address;
    //        this.IsGeolocation = true;
    //        this.get_geocoder().getLatLng(this.Address, this.get_loadDelegate());
    //    },

    //    loadStatic: function Artem_Google_Map$loadStatic() {
    //        var el = this.get_element();
    //        //
    //        var width = 512;
    //        if (this.Didth && this.Width < 512) width = this.Width;
    //        var height = 512;
    //        if (this.Height && this.Height < 512) height = this.Height;
    //        //
    //        var src = "http:\/\/maps.google.com\/staticmap?";
    //        src += "center=" + this.Latitude + "," + this.Longitude + "&";
    //        src += "zoom=" + this.Zoom + "&";
    //        src += "size=" + width + "x" + height + "&";
    //        if (this.EnterpriseKey)
    //            src += "enterpriseKey=" + this.EnterpriseKey + "&";
    //        src += "key=" + this.Key;
    //        // markers
    //        if (this.Markers) {
    //            var i;
    //            src += "&markers=";
    //            for (i = 0; i < this.Markers.length; i++)
    //                src += this.Markers[i].Latitude + "," + this.Markers[i].Longitude + "|";
    //        }
    //        // 
    //        var img = document.createElement("img");
    //        img.src = src;
    //        el.appendChild(img);
    //    },

    //    loadStreetView: function Artem_Google_Map$loadStreetView(point) {
    //        var map = new GStreetviewPanorama(this.get_element(), { latlng: point });
    //        map.checkResize();
    //        this.set_map(map);
    //        //        google.maps.event.addListener(this.GMapPano, "error", function() {
    //        //            if (errorCode == 603) {
    //        //                alert("Error: Flash doesn't appear to be supported by your browser");
    //        //                return;
    //        //            }
    //        //        });
    //    },
} (Artem.Google.Map.prototype));