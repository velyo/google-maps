///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="..\Scripts\GoogleMap.js"/>

Type.registerNamespace("Artem.Google");

Artem.Google.DirectionsBehavior = function (element) {
    Artem.Google.DirectionsBehavior.initializeBase(this, [element]);
}

Artem.Google.DirectionsBehavior.prototype = {
    initialize: function () {
        Artem.Google.DirectionsBehavior.callBaseMethod(this, 'initialize');
        Artem.Worker.queue(Function.createDelegate(this, this._attach));
    },
    dispose: function () {
        this._detach();
        Artem.Google.DirectionsBehavior.callBaseMethod(this, 'dispose');
    }
};

// members
(function (proto) {

    // fields
    proto.map = null;
    proto.renderer = null;
    proto.service = null;

    // properties
    proto.get_name = function () { return this.name; };
    proto.set_name = function (value) { this.name = value; };

    // service properties
    proto.get_avoidHighways = function () { return this.avoidHighways ? this.avoidHighways : false; };
    proto.set_avoidHighways = function (value) { this.avoidHighways = value; };

    proto.get_avoidTolls = function () { return this.avoidTolls ? this.avoidTolls : false; };
    proto.set_avoidTolls = function (value) { this.avoidTolls = value; };

    proto.get_destination = function () { return this.destination; };
    proto.set_destination = function (value) { this.destination = value; };

    proto.get_optimizeWaypoints = function () { return this.optimizeWaypoints ? this.optimizeWaypoints : false; };
    proto.set_optimizeWaypoints = function (value) { this.optimizeWaypoints = value; };

    proto.get_origin = function () { return this.origin };
    proto.set_origin = function (value) { this.origin = value; }

    proto.get_provideRouteAlternatives = function () { return this.provideRouteAlternatives ? this.provideRouteAlternatives : false; };
    proto.set_provideRouteAlternatives = function (value) { this.provideRouteAlternatives = value; };

    proto.get_region = function () { return this.region; };
    proto.set_region = function (value) { this.region = value; };

    proto.get_travelMode = function () { return this.travelMode; };
    proto.set_travelMode = function (value) { this.travelMode = value; };

    proto.get_unitSystem = function () { return this.unitSystem; };
    proto.set_unitSystem = function (value) { this.unitSystem = value };

    proto.get_waypoints = function () { return this.waypoints; };
    proto.set_waypoints = function (value) { this.waypoints = value; };

    // renderer properties
    proto.get_draggable = function () { return this.draggable; };
    proto.set_draggable = function (value) { this.draggable = value };

    proto.get_hideRouteList = function () { return this.hideRouteList; };
    proto.set_hideRouteList = function (value) { this.hideRouteList = value };

    proto.get_markerOptions = function () { return this.markerOptions; };
    proto.set_markerOptions = function (value) { this.markerOptions = value; };

    proto.get_panelId = function () { return this.panelId; };
    proto.set_panelId = function (value) { this.panelId = value; };

    proto.get_polylineOptions = function () { return this.polylineOptions; };
    proto.set_polylineOptions = function (value) { this.polylineOptions = value };

    proto.get_preserveViewport = function () { return this.preserveViewport; };
    proto.set_preserveViewport = function (value) { this.preserveViewport = value };

    proto.get_routeIndex = function () { return this.routeIndex; };
    proto.set_routeIndex = function (value) { this.routeIndex = value };

    proto.get_suppressBicyclingLayer = function () { return this.suppressBicyclingLayer; };
    proto.set_suppressBicyclingLayer = function (value) { this.suppressBicyclingLayer = value };

    proto.get_suppressInfoWindows = function () { return this.suppressInfoWindows; };
    proto.set_suppressInfoWindows = function (value) { this.suppressInfoWindows = value };

    proto.get_suppressMarkers = function () { return this.suppressMarkers; };
    proto.set_suppressMarkers = function (value) { this.suppressMarkers = value };

    proto.get_suppressPolylines = function () { return this.suppressPolylines; };
    proto.set_suppressPolylines = function (value) { this.suppressPolylines = value };

    // public method

    proto._attach = function () {

        var control = $find(this.get_element().id);
        if (control)
            control.add_mapLoaded(Function.createDelegate(this, this.create));
    };

    proto._detach = function () {
        if (this.renderer)
            google.maps.event.clearInstanceListeners(this.renderer);
    };

    proto.create = function () {
        ///<summary>Loads the directions and renders them out.</summary>

        if (!this.service)
            this.service = new google.maps.DirectionsService();
        if (!this.map) {
            var control = $find(this.get_element().id);
            if (control) this.map = control.map;
        }

        var request = {
            destination: this.destination,
            origin: this.origin,
            travelMode: (this.travelMode == 0)
                    ? google.maps.TravelMode.DRIVING
                    : ((this.travelMode == 1)
                        ? google.maps.TravelMode.WALKING
                        : google.maps.TravelMode.BICYCLING)
        };

        var d = this.destination;
        request.destination = (d.Latitude && d.Longitude) 
            ? new google.maps.LatLng(d.Latitude, d.Longitude) : d;
        var o = this.origin;
        request.origin = (o.Latitude && o.Longitude)
            ? new google.maps.LatLng(o.Latitude, o.Longitude) : o;
        if (this.avoidHighways)
            request.avoidHighways = this.avoidHighways;
        if (this.avoidTolls)
            request.avoidTolls = this.avoidTolls;
        if (this.optimizeWaypoints)
            request.optimizeWaypoints = this.optimizeWaypoints;
        if (this.provideRouteAlternatives)
            request.provideRouteAlternatives = this.provideRouteAlternatives;
        if (this.region)
            request.region = this.region;
        if (this.unitSystem)
            request.unitSystem = this.unitSystem;
        if (this.waypoints)
            request.waypoints = this.waypoints;

        if (request.origin && request.destination) {
            this.service.route(request, Function.createDelegate(this, handleResponse));
        }
        else {
            if (!this.origin) Artem.Google.Log.warn("GoogleDirections: origin value is missing!");
            if (!this.destination) Artem.Google.Log.warn("GoogleDirections: destination value is missing!");
        }
    };

    // private methods

    function handleError(status) {
        Artem.Google.Log.error("Directions routing failed with status: " + status);
    }

    function handleResponse(result, status) {

        if (status == google.maps.DirectionsStatus.OK) {
            var init = false;
            if (init = !this.renderer) {
                var options = {
                    draggable: this.draggable,
                    hideRouteList: this.hideRouteList,
                    map: this.map,
                    preserveViewport: this.preserveViewport,
                    routeIndex: this.routeIndex
                };
                if (this.markerOptions) options.markerOptions = this.markerOptions;
                if (this.panelId) options.panel = document.getElementById(this.panelId);
                if (this.polylineOptions) options.polylineOptions = this.polylineOptions;
                if (this.suppressBicyclingLayer) options.suppressBicyclingLayer = this.suppressBicyclingLayer;
                if (this.suppressInfoWindows) options.suppressInfoWindows = this.suppressInfoWindows;
                if (this.suppressMarkers) options.suppressMarkers = this.suppressMarkers;
                if (this.suppressPolylines) options.suppressPolylines = this.suppressPolylines;

                this.renderer = new google.maps.DirectionsRenderer(options);
                //                if (map)
                //                    renderer.setMap(map.get_gmap());
            }
            this.renderer.setDirections(result);
            if (init) this.composeEvents(this.renderer, null);
        }
        else {
            handleError(status);
        }
    }

    // methods - GoogleMaps API

    proto.getDirections = function () {
        ///<summary>Returns the renderer's current set of directions.</summary>
        return this.renderer.getDirections();
    };

    proto.getMap = function () {
        ///<summary>Returns the map on which the DirectionsResult is rendered.</summary>
        return this.renderer.getMap();
    };

    proto.getPanel = function () {
        ///<summary>Returns the panel &lt;div&gt; in which the DirectionsResult is rendered.</summary>
        return this.renderer.getPanel();
    };

    proto.getRouteIndex = function () {
        ///<summary>Returns the current (zero-based) route index in use by this DirectionsRenderer object.</summary>
        return this.renderer.getRouteIndex();
    };

    proto.setDirections = function (directions) {
        ///<summary>Set the renderer to use the result from the DirectionsService. Setting a valid set of directions in this manner will display the directions on the renderer's designated map and panel.</summary>
        this.renderer.setDirections(directions);
    };

    proto.setMap = function (map) {
        ///<summary>This method specifies the map on which directions will be rendered. Pass null to remove the directions from the map.</summary>
        this.renderer.setMap(map);
        this.map = map;
    };

    proto.setOptions = function (options) {
        ///<summary>Change the options settings of this DirectionsRenderer after initialization.</summary>
        this.renderer.setOptions(options);
    };

    proto.setPanel = function (panel) {
        ///<summary>This method renders the directions in a &lt;div&gt;. Pass null to remove the content from the panel.</summary>
        this.renderer.setPanel(panel);
    };

    proto.setRouteIndex = function (routeIndex) {
        ///<summary>Set the (zero-based) index of the route in the DirectionsResult object to render. By default, the first route in the array will be rendered.</summary>
        this.renderer.setRouteIndex(routeIndex);
        this.routeIndex = routeIndex;
    };

})(Artem.Google.DirectionsBehavior.prototype);

// events
(function (proto) {

    // methods
    proto.composeEvents = function (renderer, handler) {

        if (!this.listener) {
            renderer = renderer || this.renderer;
            if (renderer) {
                handler = handler || this.get_events().getHandler("changed");
                if (handler) {
                    this.listener = google.maps.event.addListener(
                        renderer, "directions_changed", Function.createDelegate(this, raiseChanged));
                }
            }
        }
    };

    // changed
    proto.add_changed = function (handler) {
        this.get_events().addHandler("changed", handler);
        this.composeEvents(null, handler);
    };

    proto.remove_changed = function (handler) {
        this.get_events().removeHandler("changed", handler);
        if (this.listener) {
            var hnd = this.get_events().getHandler("changed");
            if (!hnd) google.maps.event.removeListener(this.listener);
        }
    };

    function raiseChanged(args) {
        var handler = this.get_events().getHandler("changed");
        if (handler) handler(this, args);
    }

})(Artem.Google.DirectionsBehavior.prototype);

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
