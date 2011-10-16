///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="http://maps.googleapis.com/maps/api/js?sensor=false"/>

// ------------------------------------------------------------------------------------------------
// Copyright (C) ArtemBG.
// ------------------------------------------------------------------------------------------------
// GoogleMap4.debug.js
// GoogleMap Control v5.0 javascipt library (debug).
//
// Assembly:    Artem.GooleMap
// Version:     5.5.0.0
// Project:     http://googlemap.codeplex.com
// Demo:        http://googlemap.artembg.com
// Author:      Velio Ivanov - velio@artembg.com
//              http://artembg.com
// License:     Microsoft Permissive License (Ms-PL) v1.1
//              http://www.codeplex.com/googlemap/license
// API:         http://code.google.com/apis/maps/

Type.registerNamespace("Artem.Google");

// Map class
Artem.Google.Map = function (element) {
    /// <summary>This class represents the client GoogleMap control object.</summary>
    Artem.Google.Map.initializeBase(this, [element]);
};

Artem.Google.Map.prototype = {

    initialize: function () {
        Artem.Google.Map.callBaseMethod(this, 'initialize');
        this.create();
    },

    dispose: function () {
        //        detachEvents(this);
        Artem.Google.Map.callBaseMethod(this, 'dispose');
    }
};

// members
(function (proto) {

    // google properties

    var map;
    proto.get_map = function() { return map; };
//    proto.set_map = function(value) { map = value; };

    // properties

    var address;
    proto.get_address = function () { return address; };
    proto.set_address = function (value) { address = value; };

    var backgroundColor;
    proto.get_backgroundColor = function () { return backgroundColor; };
    proto.set_backgroundColor = function (value) { backgroundColor = value; };

    var center;
    proto.get_center = function () { return center; };
    proto.set_center = function (value) { center = value; };

    var defaultAddress;
    proto.get_defaultAddress = function () { return defaultAddress; };
    proto.set_defaultAddress = function (value) { defaultAddress = value; };

    var enableReverseGeocoding;
    proto.get_enableReverseGeocoding = function() { return enableReverseGeocoding; };
    proto.set_enableReverseGeocoding = function(value) { enableReverseGeocoding = value; };

    var language;
    proto.get_language = function () { return language; };
    proto.set_language = function (value) { language = value; };

    var region;
    proto.get_region = function () { return region; };
    proto.set_region = function (value) { region = value; };

    var zoom;
    proto.get_zoom = function () { return zoom; };
    proto.set_zoom = function (value) { zoom = value; };

    // private methods

    // methods

    proto.create = function (location) {
        /// <summary>Creates the map.</summary>

        if (!location) {
            if (center)
                location = Artem.Google.Convert.toLatLng(center);
        }
        else {
            center = location;
        }

        // create map
        if (location) {
            var options = {
                center: location,
                mapTypeId: google.maps.MapTypeId.HYBRID,//Artem.Google.Converter.mapTypeId(state.MapType),
                zoom: zoom
//                disableDefaultUI: state.DisableDefaultUI,
//                disableDoubleClickZoom: state.DisableDoubleClickZoom,
//                draggable: state.Draggable,
//                draggableCursor: state.DraggableCursor,
//                draggingCursor: state.DraggingCursor,
//                keyboardShortcuts: !state.DisableKeyboardShortcuts,
//                mapTypeControl: state.ShowMapTypeControl,
//                navigationControl: state.ShowNavigationControl,
//                noClear: state.DisableClear,
//                scaleControl: state.ShowScaleControl,
//                scaleControlOptions: state.ScaleControlOptions,
//                scrollwheel: state.EnableScrollWheelZoom,
//                streetViewControl: state.ShowStreetViewControl
            };  

//            if (state.MapTypeControlOptions)
//                options.mapTypeControlOptions = Artem.Google.Converter.mapTypeControlOptions(state.MapTypeControlOptions);
//            if (state.NavigationControlOptions)
//                options.navigationControlOptions = Artem.Google.Converter.navigationControlOptions(state.NavigationControlOptions);
//            if (state.StreetView)
//                options.streetView = Artem.Google.Converter.streetView(state.StreetView, location);

            map = new google.maps.Map(this.get_element(), options);

            //        attachEvents(map);
            //        render(map);

            // if reverse geocoding is enabled then try resolve the address
            if (enableReverseGeocoding) {
                var options = {
                    latlng: location,
                    language: language,
                    region: region
                };
                Artem.Google.Geocoding.getAddress(options, function (address) { address = address; });
            }
        }
        else {
            var options = {
                address: address,
                defaultAddress: defaultAddress,
                language: language,
                region: region
            }
            Artem.Google.Geocoding.getLocation(options, Function.createDelegate(this, this.create));
            //            function (location) { create(self, location); });
        }
    };

})(Artem.Google.Map.prototype);

// events
(function (proto) {

})(Artem.Google.Map.prototype);

// server events - entry points
(function (proto) {

})(Artem.Google.Map.prototype);

// utilities //////////////////////////////////////////////////////////////////

// convert
Artem.Google.Convert = (function () {

    function latlng(point) {
        return (point) ? new google.maps.LatLng(point.lat, point.lng) : null;
    }

    function latlngArray(points) {

        var result = null;

        if (points) {
            result = [];
            for (var i = 0; i < points.length; i++) {
                result.push(new google.maps.LatLng(points[i].lat, points[i].lng));
            }
        }

        return result;
    }

    function latlngBounds(bounds) {
        return (bounds)
            ? new google.maps.LatLngBounds(latlng(bounds.sw), latlng(bounds.ne))
            : null;
    }

    return {
        toLatLng: latlng,
        toLatLngArray: latlngArray,
        toLatLngBounds: latlngBounds
    };
})();

// geocoding
Artem.Google.Geocoding = (function () {

    var geocoder;

    function getAddress(options, callback) {

        var request = {
            lanlng: options.lanlng,
            language: options.language,
            region: options.region
        };

        geocoder = geocoder || new google.maps.Geocoder();
        geocoder.geocode(request, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                try {
                    var address;
                    if (results && results.length)
                        address = results[0].formatted_address;
                    callback(address);
                }
                catch (ex) {
                    Artem.Google.Log.error(ex);
                }
            }
            else {
                Artem.Google.Log.error("Reverse location geocoding failed with status: " + status);
            }
        });
    }

    function getLocation(options, callback) {

        var request = {
            address: options.address,
            language: options.language,
            region: options.region
        };

        geocoder = geocoder || new google.maps.Geocoder();
        geocoder.geocode(request, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                try {
                    var location;
                    if (results && results.length)
                        location = results[0].geometry.location;
                    callback(location);
                }
                catch (ex) {
                    Artem.Google.Log.error(ex);
                }
            }
            else {
                handleAddressError(status, options, callback);
            }
        });
    }

    function handleAddressError(status, options, callback) {

        if (options.defaultAddress) {
            Artem.Google.Log.warn(status + " ... applying default address.");

            var request = {
                address: options.defaultAddress,
                language: options.language,
                region: options.region
            };

            geocoder = geocoder || new google.maps.Geocoder();
            geocoder.geocode(request, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    var location;
                    if (results && results.length)
                        location = results[0].geometry.location;
                    callback(location);
                }
                else {
                    if (console && console.error)
                        console.error("DefaultAddress geocoding failed with status: " + status);
                }
            });
        }
        else {
            Artem.Google.Log.error("Address geocoding failed with status: " + status + "\nDefaultAddress is not set and map was left empty!");
        }
    }
})();

// log
Artem.Google.Log = (function () {

    // methods

    function dir(obj) {
        if (console && console.dir) console.dir(obj);
    }

    function error(message) {
        if (console && console.error)
            console.error(message);
        else
            throw (message);
    }

    function info(message) {
        if (console && console.info) console.info(message);
    }

    function warn(message) {
        if (console && console.warn) console.warn(message);
    }

    return {
        dir: dir,
        error: error,
        info: info,
        warn: warn
    };
})();

//Artem.Google.Map = function (element) {
//    var self = this;

//    var clientMapID = null;
//    this.get_clientMapID = function () { return clientMapID; };
//    this.set_clientMapID = function (value) { clientMapID = value; }

//    var directionsEvents = null;
//    this.get_directionsEvents = function (read) {
//        if (directionsEvents == null && !read)
//            directionsEvents = new Sys.EventHandlerList();
//        return directionsEvents;
//    };

//    var mapEvents = null;
//    this.get_mapEvents = function (read) {
//        if (mapEvents == null && !read)
//            mapEvents = new Sys.EventHandlerList();
//        return mapEvents;
//    };

//    var mapPano = null;
//    this.get_mapPano = function () { return mapPano; }
//    this.set_mapPano = function (value) { mapPano = value; };

//    var markerEvents = null;
//    this.get_markerEvents = function (read) {
//        if (markerEvents == null && !read)
//            markerEvents = new Sys.EventHandlerList();
//        return markerEvents;
//    };

//    var markerManager = null;
//    this.get_markerManager = function () { return markerManager; };
//    this.set_markerManager = function (value) { markerManager = value; }

//    var name = null;
//    this.get_name = function () { return name; };
//    this.set_name = function (value) { name = value; };

//    //    var partialUpdateDelegate = null;
//    //    this.get_partialUpdateDelegate = function (getonly) {
//    //        if (!partialUpdateDelegate && !getonly)
//    //            partialUpdateDelegate = Function.createDelegate(self, self._onPartialUpdate)
//    //        return partialUpdateDelegate;
//    //    };

//    var polygonEvents = null;
//    this.get_polygonEvents = function (read) {
//        if (polygonEvents == null && !read)
//            polygonEvents = new Sys.EventHandlerList();
//        return polygonEvents;
//    };

//    var polylineEvents = null;
//    this.get_polylineEvents = function (read) {
//        if (polylineEvents == null && !read)
//            polylineEvents = new Sys.EventHandlerList();
//        return polylineEvents;
//    };

//    var raiseServerEventDelegate = null;
//    this.get_raiseServerEventDelegate = function (getonly) {
//        if (!raiseServerEventDelegate && !getonly)
//            raiseServerEventDelegate = Function.createDelegate(self, self._raiseServerEvent);
//        return raiseServerEventDelegate;
//    };

//    //    var submitDelegate = null;
//    //    this.get_submitDelegate = function (getonly) {
//    //        if (!submitDelegate && !getonly)
//    //            submitDelegate = Function.createDelegate(self, self._onSubmit);
//    //        return submitDelegate;
//    //    };
//};

//Artem.Google.Map.prototype = {

//    get_clientMapID: null,
//    set_clientMapID: null,
//    get_directionsEvents: null,
//    get_mapEvents: null,
//    get_mapPano: null,
//    set_mapPano: null,
//    get_markerEvents: null,
//    get_markerManager: null,
//    set_markerManager: null,
//    get_name: null,
//    set_name: null,
//    //    get_partialUpdateDelegate: null,
//    get_polygonEvents: null,
//    get_polylineEvents: null,
//    get_raiseServerEventDelegate: null,
//    //    get_submitDelegate: null,


//    //#> Private Methods 

//    //    _onPartialUpdate: function Artem_Google_Map$_onPartialUpdate() {
//    //        this.loadState();
//    //        return true;
//    //    },

//    //    _onSubmit: function Artem_Google_Map$_onSubmit() {
//    //        this.saveState();
//    //        return true;
//    //    },

//    _raiseServerEvent: function Artem_Google_Map$_raiseServerEvent() {

//        if (arguments.length > 0) {
//            var index = arguments.length - 1;
//            var entry = arguments[index];
//            var name = entry.name;
//            var type = entry.type;
//            var data = type + ":" + name;
//            var args;

//            switch (name) {
//                case "addressnotfound":
//                case "geoload":
//                case "locationloaded":
//                    args = new Artem.Google.Events.AddressEventArgs(arguments[0]);
//                    break;
//                case "click":
//                case "dblclick":
//                    if (type == "map")
//                    // overlay argument passed is not used so far
//                        args = new Artem.Google.Events.LocationEventArgs(arguments[1]);
//                    else
//                        args = new Artem.Google.Events.LocationEventArgs(arguments[0]);
//                    break;
//                case "dragend":
//                case "dragstart":
//                    args = new Artem.Google.Events.BoundsEventArgs(this.getBounds());
//                    break;
//                case "mousemove":
//                case "mouseover":
//                case "mouseout":
//                case "singlerightclick":
//                    args = new Artem.Google.Events.LocationEventArgs(arguments[0]);
//                    break;
//                case "zoomend":
//                    args = Artem.Google.Events.ZoomEventArgs(arguments[0], arguments[1]);
//                    break;
//                case "addmaptype":
//                case "addoverlay":
//                case "clearoverlays":
//                case "drag":
//                case "infowindowbeforeclose":
//                case "infowindowclose":
//                case "infowindowopen":
//                case "load":
//                case "maptypechanged":
//                case "move":
//                case "moveend":
//                case "movestart":
//                case "removemaptype":
//                case "removeoverlay":
//                    // overlay argument passed is not used so far
//                    break;
//            }

//            if (args)
//                data += "$" + Sys.Serialization.JavaScriptSerializer.serialize(args);
//            __doPostBack(this.get_name(), data);
//        }
//    },

//    _validateHandler: function Artem_Google_Map$_validateHandler(type, name, handler) {
//        return (handler == Artem.Google.serverHandler)
//            ? Function.createCallback(this.get_raiseServerEventDelegate(), { name: name, type: type })
//            : handler;
//    }

//    //#endregion
//};

// Common
//(function (proto) {

//    //#> fields

//    var markers = [];
//    var directions = [];
//    var polygons = [];
//    var polylines = [];

//    //#<

//    //#> properties

//    var clientStateID = null;
//    proto.get_clientStateID = function () { return clientStateID; };
//    proto.set_clientStateID = function (value) { clientStateID = value; };

//    var geocoder;
//    proto.get_geocoder = function () { return geocoder || (geocoder = new google.maps.Geocoder()); };

//    var state;
//    proto.get_state = function () { return state; };

//    //#<

//    //#> private methods - create & render

//    function render(map) {
//        /// <summary>Renders the map overlays.</summary>

//        var i, name, handler;
//        // markers
//        if (state.Markers) {
//            for (i = 0; i < state.Markers.length; i++) {
//                markers.push(new Artem.Google.Marker(map, i, state.Markers[i]));
//                // attach events
//                for (name in map.get_markerEvents()._list) {
//                    handler = map.get_markerEvents().getHandler(name);
//                    google.maps.event.addListener(markers[i].get_marker(), name, handler);
//                }
//            }
//        }
//        // directions
//        if (state.Directions) {
//            for (i = 0; i < state.Directions.length; i++) {
//                directions.push(new Artem.Google.Directions(map, state.Directions[i]));
//                // attach events
//                for (name in map.get_directionsEvents()._list) {
//                    handler = map.get_directionsEvents().getHandler(name);
//                    google.maps.event.addListener(directions[i].get_directions(), name, handler);
//                }
//            }
//        }
//        // polygons
//        if (state.Polygons) {
//            for (i = 0; i < state.Polygons.length; i++) {
//                polygons.push(new Artem.Google.Polygon(map, state.Polygons[i]));
//                // attach events
//                for (name in map.get_polygonEvents()._list) {
//                    handler = map.get_polygonEvents().getHandler(name);
//                    google.maps.event.addListener(polygons[i].get_polygon(), name, handler);
//                }
//            }
//        }
//        // polylines
//        if (state.Polylines) {
//            for (i = 0; i < state.Polylines.length; i++) {
//                polylines.push(new Artem.Google.Polyline(map, state.Polylines[i]));
//                // attach events
//                for (name in map.get_polylineEvents()._list) {
//                    handler = map.get_polylineEvents().getHandler(name);
//                    google.maps.event.addListener(polylines[i].get_polyline(), name, handler);
//                }
//            }
//        }

//        // traffic overlay
//        if (state.ShowTraffic) {
//            var traffic = new google.maps.TrafficLayer();
//            traffic.setMap(map.get_map());
//        }
//    }
//    //#<

//    //#> private methods - events attach/detach

//    function attachEvents(map) {

////        //        if (typeof (Sys.WebForms) !== "undefined" && typeof (Sys.WebForms.PageRequestManager) !== "undefined") {
////        //            var requestManager = Sys.WebForms.PageRequestManager.getInstance();
////        //            if (requestManager) {
////        //                Array.add(requestManager._onSubmitStatements, map.get_submitDelegate());
////        //                requestManager.add_endRequest(map.get_partialUpdateDelegate());
////        //            }
////        //        }
////        //        else {
////        //            $addHandler(document.forms[0], "submit", map.get_submitDelegate());
////        //        }

////        // map events
////        var name, handler;
////        var events = map.get_mapEvents();
////        var gmap = map.get_map();
////        for (name in events._list) {
////            handler = events.getHandler(name);
////            google.maps.event.addListener(gmap, name, handler);
////        }
//    }

//    function detachEvents(map) {

////        //        var delegate;
////        //        if (typeof (Sys.WebForms) !== "undefined" && typeof (Sys.WebForms.PageRequestManager) !== "undefined") {
////        //            var requestManager = Sys.WebForms.PageRequestManager.getInstance();
////        //            if (requestManager) {
////        //                delegate = map.get_partialUpdateDelegate(true);
////        //                if (delegate) {
////        //                    requestManager.remove_endRequest(delegate);
////        //                }
////        //                delegate = map.get_submitDelegate(true);
////        //                if (delegate) {
////        //                    Array.remove(requestManager._onSubmitStatements, delegate);
////        //                }
////        //            }
////        //        }
////        //        else {
////        //            delegate = map.get_submitDelegate(true);
////        //            if (delegate) {
////        //                $removeHandler(document.forms[0], "submit", delegate);
////        //            }
////        //        }

////        // remove map event handlers
////        var gmap = map.get_map();
////        if (gmap) google.maps.event.clearInstanceListeners(gmap);
//    }
//    //#<

//    //#> private methods - handle geocoding errors

//    
//    //#<

//    //#> private method - state

//    function loadState() {

//        if (clientStateID) {
//            var stateField = $get(clientStateID);
//            if (stateField) {
//                var stateContent = stateField.value;
//                if (stateContent == 'undefined' || stateContent == '') return;
//                state = Sys.Serialization.JavaScriptSerializer.deserialize(stateContent, true);
//            }
//        }
//    };

//    function saveState() {

//        if (clientStateID) {
//            var stateField = $get(clientStateID);
//            if (stateField) {
//                //                var i;
//                //                var center = this.getCenter();

//                //                this.Bounds = new Artem.Google.Bounds(this.getBounds());
//                //                this.Center = {
//                //                    Latitude: (center !== null) ? center.lat() : 0,
//                //                    Longitude: (center !== null) ? center.lng() : 0
//                //                };
//                //                this.Zoom = this.getZoom() || 0;

//                //                if (this.Markers) {
//                //                    for (i = 0; i < this.Markers.length; i++) {
//                //                        this.Markers[i].save();
//                //                    }
//                //                }
//                //                if (this.Directions) {
//                //                    for (i = 0; i < this.Directions.length; i++) {
//                //                        this.Directions[i].save();
//                //                    }
//                //                }
//                //                if (this.Polygons) {
//                //                    for (i = 0; i < this.Polygons.length; i++) {
//                //                        this.Polygons[i].save();
//                //                    }
//                //                }
//                //                if (this.Polylines) {
//                //                    for (i = 0; i < this.Polylines.length; i++) {
//                //                        this.Polylines[i].save();
//                //                    }
//                //                }

//                //                var state = new Artem.Google.State(this);
//                stateField.value = Sys.Serialization.JavaScriptSerializer.serialize(state);
//            }
//        }
//    };
//    //#<

//    //#> public methods - control

//    
//    //#<

//} (Artem.Google.Map.prototype));



// Google Maps API Wrapped
//(function (proto) {

//    // properties
//    var map = null;
//    proto.get_map = function () { return map; };
//    proto.set_map = function (value) { map = value; };

//    proto.get_gmap = function () { return map; };

//    // public methods
//    proto.fitBounds = function (bounds) {
//        return map.fitBounds(bounds);
//    };

//    proto.getBounds = function () {
//        return map.getBounds();
//    };

//    proto.getCenter = function () {
//        return map.getCenter();
//    };

//    proto.getDiv = function () {
//        return map.getDiv();
//    };

//    proto.getMapTypeId = function () {
//        return map.getMapTypeId();
//    };

//    proto.getProjection = function () {
//        return map.getProjection();
//    };

//    proto.getStreetView = function () {
//        return map.getStreetView();
//    }

//    proto.getZoom = function () {
//        return map.getZoom();
//    };

//    proto.panBy = function (x, y) {
//        map.panBy(x, y);
//    };

//    proto.panTo = function (latlng) {
//        map.panTo(latlng);
//    };

//    proto.panToBounds = function (bounds) {
//        map.panToBounds(bounds);
//    };

//    proto.setCenter = function (latlng) {
//        map.setCenter(latlng);
//    };

//    proto.setMapTypeId = function (mapTypeId) {
//        map.setMapTypeId(mapTypeId);
//    };

//    proto.setOptions = function (options) {
//        map.setOptions(panorama);
//    };

//    proto.setStreetView = function (panorama) {
//        map.setStreetView(panorama);
//    };

//    proto.setZoom = function (zoom) {
//        map.setZoom(zoom);
//    };
//} (Artem.Google.Map.prototype));

Artem.Google.Map.registerClass("Artem.Google.Map", Sys.UI.Control);