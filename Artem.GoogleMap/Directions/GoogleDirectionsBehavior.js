///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="..\Scripts\GoogleCommons.js"/>
///<reference path="..\Scripts\GoogleMap.js"/>

Type.registerNamespace("Artem.Google");

Artem.Google.DirectionsBehavior = function (element) {
    Artem.Google.DirectionsBehavior.initializeBase(this, [element]);
}

Artem.Google.DirectionsBehavior.prototype = {
    initialize: function () {
        Artem.Google.DirectionsBehavior.callBaseMethod(this, 'initialize');
        this.load();
    },
    dispose: function () {
        this.unload();
        Artem.Google.DirectionsBehavior.callBaseMethod(this, 'dispose');
    }
};

// members
(function (proto) {

    // properties
    var map;
    proto.get_map = function () { return map; };

    var name;
    proto.get_name = function () { return name; };
    proto.set_name = function (value) { name = value; };

    var renderer;
    proto.get_renderer = function () { return renderer; };

    var service;
    proto.get_servise = function () { return service; };

    // service properties
    var avoidHighways = false;
    proto.get_avoidHighways = function () { return avoidHighways; };
    proto.set_avoidHighways = function (value) { avoidHighways = value; };

    var avoidTolls = false;
    proto.get_avoidTolls = function () { return avoidTolls; };
    proto.set_avoidTolls = function (value) { avoidTolls = value; };

    var destination;
    proto.get_destination = function () { return destination; };
    proto.set_destination = function (value) { destination = value; };

    var optimizeWaypoints = false;
    proto.get_optimizeWaypoints = function () { return optimizeWaypoints; };
    proto.set_optimizeWaypoints = function (value) { optimizeWaypoints = value; };

    var origin;
    proto.get_origin = function () { return origin };
    proto.set_origin = function (value) { origin = value; }

    var provideRouteAlternatives = false;
    proto.get_provideRouteAlternatives = function () { return provideRouteAlternatives; };
    proto.set_provideRouteAlternatives = function (value) { provideRouteAlternatives = value; };

    var region;
    proto.get_region = function () { return region; };
    proto.set_region = function (value) { region = value; };

    var travelMode;
    proto.get_travelMode = function () { return travelMode; };
    proto.set_travelMode = function (value) { travelMode = value; };

    var unitSystem;
    proto.get_unitSystem = function () { return unitSystem; };
    proto.set_unitSystem = function (value) { unitSystem = value };

    var waypoints;
    proto.get_waypoints = function () { return waypoints; };
    proto.set_waypoints = function (value) { waypoints = value; };

    // renderer properties
    var draggable;
    proto.get_draggable = function () { return draggable; };
    proto.set_draggable = function (value) { draggable = value };

    var hideRouteList;
    proto.get_hideRouteList = function () { return hideRouteList; };
    proto.set_hideRouteList = function (value) { hideRouteList = value };

    var markerOptions;
    proto.get_markerOptions = function () { return markerOptions; };
    proto.set_markerOptions = function (value) { markerOptions = value; };

    var panelId;
    proto.get_panelId = function () { return panelId; };
    proto.set_panelId = function (value) { panelId = value; };

    var polylineOptions;
    proto.get_polylineOptions = function () { return polylineOptions; };
    proto.set_polylineOptions = function (value) { polylineOptions = value };

    var preserveViewport;
    proto.get_preserveViewport = function () { return preserveViewport; };
    proto.set_preserveViewport = function (value) { preserveViewport = value };

    var routeIndex;
    proto.get_routeIndex = function () { return routeIndex; };
    proto.set_routeIndex = function (value) { routeIndex = value };

    var suppressBicyclingLayer;
    proto.get_suppressBicyclingLayer = function () { return suppressBicyclingLayer; };
    proto.set_suppressBicyclingLayer = function (value) { suppressBicyclingLayer = value };

    var suppressInfoWindows;
    proto.get_suppressInfoWindows = function () { return suppressInfoWindows; };
    proto.set_suppressInfoWindows = function (value) { suppressInfoWindows = value };

    var suppressMarkers;
    proto.get_suppressMarkers = function () { return suppressMarkers; };
    proto.set_suppressMarkers = function (value) { suppressMarkers = value };

    var suppressPolylines;
    proto.get_suppressPolylines = function () { return suppressPolylines; };
    proto.set_suppressPolylines = function (value) { suppressPolylines = value };

    // private methods

    function handleError(status) {
        Artem.Google.Log.error("Directions routing failed with status: " + status);
    }

    function handleResponse(result, status) {

        if (status == google.maps.DirectionsStatus.OK) {
            var init = false;
            if (init = !renderer) {
                var options = {
                    draggable: draggable,
                    hideRouteList: hideRouteList,
                    map: map.get_gmap(),
                    preserveViewport: preserveViewport,
                    routeIndex: routeIndex
                };
                if (markerOptions) options.markerOptions = markerOptions;
                if (panelId) options.panel = document.getElementById(panelId);
                if (polylineOptions) options.polylineOptions = polylineOptions;
                if (suppressBicyclingLayer) options.suppressBicyclingLayer = suppressBicyclingLayer;
                if (suppressInfoWindows) options.suppressInfoWindows = suppressInfoWindows;
                if (suppressMarkers) options.suppressMarkers = suppressMarkers;
                if (suppressPolylines) options.suppressPolylines = suppressPolylines;

                renderer = new google.maps.DirectionsRenderer(options);
                //                if (map)
                //                    renderer.setMap(map.get_gmap());
            }
            renderer.setDirections(result);
            if (init) this.registerEvents(renderer, null);
        }
        else {
            handleError(status);
        }
    }

    // public method

    proto.load = function (request) {
        ///<summary>Loads the directions and renders them out.</summary>

        if (!map)
            map = $find(this.get_element().id);

        if (!service)
            service = new google.maps.DirectionsService();

        if (!request) {
            request = {
                destination: destination,
                origin: origin,
                travelMode: (travelMode == 0) ? google.maps.TravelMode.DRIVING : ((travelMode == 1) ? google.maps.TravelMode.WALKING : google.maps.TravelMode.BICYCLING)
            };
            if (avoidHighways)
                request.avoidHighways = avoidHighways;
            if (avoidTolls)
                request.avoidTolls = avoidTolls;
            if (optimizeWaypoints)
                request.optimizeWaypoints = optimizeWaypoints;
            if (provideRouteAlternatives)
                request.provideRouteAlternatives = provideRouteAlternatives;
            if (region)
                request.region = region;
            if (unitSystem)
                request.unitSystem = unitSystem;
            if (waypoints)
                request.waypoints = waypoints;
        }

        if (request.origin && request.destination) {
            service.route(request, Function.createDelegate(this, handleResponse));
        }
        else {
            if (!origin) Artem.Google.Log.warn("GoogleDirections: origin value is missing!");
            if (!destination) Artem.Google.Log.warn("GoogleDirections: destination value is missing!");
        }
    };

    proto.unload = function () {
        if (renderer)
            google.maps.event.clearInstanceListeners(renderer);
    };

    // methods - GoogleMaps API

    proto.getDirections = function () {
        ///<summary>Returns the renderer's current set of directions.</summary>
        return renderer.getDirections();
    };

    proto.getMap = function () {
        ///<summary>Returns the map on which the DirectionsResult is rendered.</summary>
        return renderer.getMap();
    };

    proto.getPanel = function () {
        ///<summary>Returns the panel &lt;div&gt; in which the DirectionsResult is rendered.</summary>
        return renderer.getPanel();
    };

    proto.getRouteIndex = function () {
        ///<summary>Returns the current (zero-based) route index in use by this DirectionsRenderer object.</summary>
        return renderer.getRouteIndex();
    };

    proto.setDirections = function (directions) {
        ///<summary>Set the renderer to use the result from the DirectionsService. Setting a valid set of directions in this manner will display the directions on the renderer's designated map and panel.</summary>
        renderer.setDirections(directions);
    };

    proto.setMap = function (map) {
        ///<summary>This method specifies the map on which directions will be rendered. Pass null to remove the directions from the map.</summary>
        renderer.setMap(map);
    };

    proto.setOptions = function (options) {
        ///<summary>Change the options settings of this DirectionsRenderer after initialization.</summary>
        renderer.setOptions(map);
    };

    proto.setPanel = function (panel) {
        ///<summary>This method renders the directions in a &lt;div&gt;. Pass null to remove the content from the panel.</summary>
        renderer.setPanel(map);
    };

    proto.setRouteIndex = function (routeIndex) {
        ///<summary>Set the (zero-based) index of the route in the DirectionsResult object to render. By default, the first route in the array will be rendered.</summary>
        renderer.setRouteIndex(routeIndex);
    };

}) (Artem.Google.DirectionsBehavior.prototype);

// events
(function (proto) {

    // fields
    var listener;

    // methods
    proto.registerEvents = function (renderer, handler) {

        if (!listener) {
            renderer = renderer || this.get_renderer();
            if (renderer) {
                handler = handler || this.get_events().getHandler("changed");
                if (handler) {
                    listener = google.maps.event.addListener(
                        renderer, "directions_changed", Function.createDelegate(this, raiseChanged));
                }
            }
        }
    };

    // changed
    proto.add_changed = function (handler) {
        this.get_events().addHandler("changed", handler);
        this.registerEvents(null, handler);
    };

    proto.remove_changed = function (handler) {
        this.get_events().removeHandler("changed", handler);
        if (listener) {
            var hnd = this.get_events().getHandler("changed");
            if (!hnd) google.maps.event.removeListener(listener);
        }
    };

    function raiseChanged(args) {
        var handler = this.get_events().getHandler("changed");
        if (handler) handler(this, args);
    }

}) (Artem.Google.DirectionsBehavior.prototype);

Artem.Google.DirectionsBehavior.raiseServerChanged = function (sender) {

    var routes = sender.getDirections().routes;
    var args = { name: "change" };

    if (routes && routes.length > 0) {
        var legs = routes[0].legs;
        if (legs && legs.length) {
            var route = legs[0];
            delete route.via_waypoint;
            delete route.via_waypoints;

            route.end_location = {
                Latitude: route.end_location.Ma,
                Longitude: route.end_location.Na
            };
            route.start_location = {
                Latitude: route.start_location.Ma,
                Longitude: route.start_location.Na
            };
            for (var i = 0; i < route.steps.length; i++) {
                delete route.steps[i].encoded_lat_lngs;
                delete route.steps[i].end_point;
                delete route.steps[i].lat_lngs;
                delete route.steps[i].path;
                delete route.steps[i].polyline;
                delete route.steps[i].start_point;
                delete route.steps[i].travel_mode;

                route.steps[i].end_location = {
                    Latitude: route.steps[i].end_location.Ma,
                    Longitude: route.steps[i].end_location.Na
                };
                route.steps[i].start_location = {
                    Latitude: route.steps[i].start_location.Ma,
                    Longitude: route.steps[i].start_location.Na
                };
            }
            args.route = route;
        }
    }

    __doPostBack(sender.get_name(), Sys.Serialization.JavaScriptSerializer.serialize(args));
};

Artem.Google.DirectionsBehavior.registerClass('Artem.Google.DirectionsBehavior', Sys.UI.Behavior);
