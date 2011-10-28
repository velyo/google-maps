///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="..\Map\GoogleMap.js"/>
///<reference path="http://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Artem.Google");

Artem.Google.PolygonBehavior = function (element) {
    Artem.Google.PolygonBehavior.initializeBase(this, [element]);
};

Artem.Google.PolygonBehavior.prototype = {
    initialize: function () {
        Artem.Google.PolygonBehavior.callBaseMethod(this, 'initialize');
        this._attach();
    },
    dispose: function () {
        this._detach();
        Artem.Google.PolygonBehavior.callBaseMethod(this, 'dispose');
    }
};
Artem.Google.PolygonBehavior.registerClass('Artem.Google.PolygonBehavior', Sys.UI.Behavior);

// members
(function (proto) {

    // fieds

    proto.map = null;
    proto.polygon = null;

    // properties

    proto.get_clickable = function () { return this.clickable; };
    proto.set_clickable = function (value) { this.clickable = value; };

    proto.get_fillColor = function () { return this.fillColor; };
    proto.set_fillColor = function (value) { this.fillColor = value; };

    proto.get_fillOpacity = function () { return this.fillOpacity; };
    proto.set_fillOpacity = function (value) { this.fillOpacity = value; };

    proto.get_geodesic = function () { return this.geodesic; };
    proto.set_geodesic = function (value) { this.geodesic = value; };

    proto.get_name = function () { return this.name; };
    proto.set_name = function (value) { this.name = value; };

    proto.get_paths = function () { return this.paths; };
    proto.set_paths = function (value) { this.paths = value; };

    proto.get_strokeColor = function () { return this.strokeColor; };
    proto.set_strokeColor = function (value) { this.strokeColor = value; };

    proto.get_strokeOpacity = function () { return this.strokeOpacity; };
    proto.set_strokeOpacity = function (value) { this.strokeOpacity = value; };

    proto.get_strokeWeight = function () { return this.strokeWeight; };
    proto.set_strokeWeight = function (value) { this.strokeWeight = value; };

    proto.get_zIndex = function () { return this.zIndex; };
    proto.set_zIndex = function (value) { this.zIndex = value; };

    // methods

    proto._attach = function () {
        var control = $find(this.get_element().id);
        if (control)
            control.add_mapLoaded(Function.createDelegate(this, this.create));
    };

    proto._detach = function () {
        if(this.polygon)
            google.maps.event.clearInstanceListeners(this.polygon);
    };

    proto.create = function () {

        var control = $find(this.get_element().id);
        if (control)
            this.map = control.map;

        var points = Artem.Google.Convert.toLatLngArray(this.paths);
        var options = {
            clickable: this.clickable,
            fillColor: this.fillColor,
            fillOpacity: this.fillOpacity,
            geodesic: this.geodesic,
            map: this.map,
            paths: points,
            strokeColor: this.strokeColor,
            strokeOpacity: this.strokeOpacity,
            strokeWeight: this.strokeWeight,
            zIndex: this.zIndex
        };

        this.polygon = new google.maps.Polygon(options);
        this.composeEvents();
    };

    // GoogleMaps API

    proto.getMap = function () {
        ///<summary>Returns the map on which this poly is attached.</summary>
        return this.polygon.getMap();
    };

    proto.getPath = function () {
        ///<summary>Retrieves the first path.</summary>        
        return this.polygon.getPath();
    };

    proto.getPaths = function () {
        ///<summary>Retrieves the paths for this Polygon.</summary>
        return this.polygon.getPaths()
    };

    proto.setMap = function (map) {
        ///<summary>Renders this Polyline or Polygon on the specified map. If map is set to null, the Poly will be removed.</summary>
        this.polygon.setMap(map);
    };

    proto.setOptions = function (options) {
        ///<summary></summary>
        this.polygon.setOptions(options);
    };

    proto.setPath = function (path) {
        ///<summary>Sets the first path. See PolylineOptions for more details.</summary>
        this.polygon.setPath(path);
    };

    proto.setPaths = function (paths) {
        ///<summary>Sets the path for this Polygon.</summary>
        this.polygon.setPaths(paths);
    };

})(Artem.Google.PolygonBehavior.prototype);

// events
(function (proto) {

    // fields
    var handlers = {
        "click": raiseClick,
        "dblclick": raiseDoubleClick,
        "mousedown": raiseMouseDown,
        "mousemove": raiseMouseMove,
        "mouseout": raiseMouseOut,
        "mouseover": raiseMouseOver,
        "mouseup": raiseMouseUp,
        "rightclick": raiseRightClick
    };
    proto.delegates = {
        "click": null,
        "dblclick": null,
        "mousedown": null,
        "mousemove": null,
        "mouseout": null,
        "mouseover": null,
        "mouseup": null,
        "rightclick": null
    };
    proto.listeners = {
        "click": null,
        "dblclick": null,
        "mousedown": null,
        "mousemove": null,
        "mouseout": null,
        "mouseover": null,
        "mouseup": null,
        "rightclick": null
    };

    // utility

    proto.composeEvents = function () {

        if (this.polygon) {
            var handler;
            for (var name in handlers) {
                handler = this.get_events().getHandler(name);
                if (handler) {
                    if (!this.listeners[name]) {
                        if (!this.delegates[name]) this.delegates[name] = Function.createDelegate(this, handlers[name]);
                        this.listeners[name] = google.maps.event.addListener(this.polygon, name, this.delegates[name]);
                    }
                }
                else if (this.listeners[name]) {
                    google.maps.event.removeListener(this.listeners[name]);
                }
            }
        }
    };

    // click
    proto.add_click = function (handler) {
        this.get_events().addHandler("click", handler);
        this.composeEvents();
    };
    proto.remove_click = function (handler) {
        this.get_events().removeHandler("click", handler);
        this.composeEvents();
    };
    function raiseClick(e) {
        var handler = this.get_events().getHandler("click");
        if (handler) handler(this, e);
    }

    // double click
    proto.add_doubleClick = function (handler) {
        this.get_events().addHandler("dblclick", handler);
        this.composeEvents();
    };
    proto.remove_doubleClick = function (handler) {
        this.get_events().removeHandler("dblclick", handler);
        this.composeEvents();
    };
    function raiseDoubleClick(e) {
        var handler = this.get_events().getHandler("dblclick");
        if (handler) handler(this, e);
    }

    // mouse down
    proto.add_mouseDown = function (handler) {
        this.get_events().addHandler("mousedown", handler);
        this.composeEvents();
    };
    proto.remove_mouseDown = function (handler) {
        this.get_events().removeHandler("mousedown", handler);
        this.composeEvents();
    };
    function raiseMouseDown(e) {
        var handler = this.get_events().getHandler("mousedown");
        if (handler) handler(this, e);
    }

    // mouse move
    proto.add_mouseMove = function (handler) {
        this.get_events().addHandler("mousemove", handler);
        this.composeEvents();
    };
    proto.remove_mouseMove = function (handler) {
        this.get_events().removeHandler("mousemove", handler);
        this.composeEvents();
    };
    function raiseMouseMove(e) {
        var handler = this.get_events().getHandler("mousemove");
        if (handler) handler(this, e);
    }

    // mouse out
    proto.add_mouseOut = function (handler) {
        this.get_events().addHandler("mouseout", handler);
        this.composeEvents();
    };
    proto.remove_mouseOut = function (handler) {
        this.get_events().removeHandler("mouseout", handler);
        this.composeEvents();
    };
    function raiseMouseOut(e) {
        var handler = this.get_events().getHandler("mouseout");
        if (handler) handler(this, e);
    }

    // mouse over
    proto.add_mouseOver = function (handler) {
        this.get_events().addHandler("mouseover", handler);
        this.composeEvents();
    };
    proto.remove_mouseOver = function (handler) {
        this.get_events().removeHandler("mouseover", handler);
        this.composeEvents();
    };
    function raiseMouseOver(e) {
        var handler = this.get_events().getHandler("mouseover");
        if (handler) handler(this, e);
    }

    // mouse up
    proto.add_mouseUp = function (handler) {
        this.get_events().addHandler("mouseup", handler);
        this.composeEvents();
    };
    proto.remove_mouseUp = function (handler) {
        this.get_events().removeHandler("mouseup", handler);
        this.composeEvents();
    };
    function raiseMouseUp(e) {
        var handler = this.get_events().getHandler("mouseup");
        if (handler) handler(this, e);
    }

    // mouse right
    proto.add_rightClick = function (handler) {
        this.get_events().addHandler("rightclick", handler);
        this.composeEvents();
    };
    proto.remove_rightClick = function (handler) {
        this.get_events().removeHandler("rightclick", handler);
        this.composeEvents();
    };
    function raiseRightClick(e) {
        var handler = this.get_events().getHandler("rightclick");
        if (handler) handler(this, e);
    }

})(Artem.Google.PolygonBehavior.prototype);

// server events - entry points
(function (behavior) {

    function raiseServerEvent(target, args) {
        __doPostBack(target, Sys.Serialization.JavaScriptSerializer.serialize(args));
    }

    behavior.raiseServerClick = function (sender, e) {
        ///<summary>An entry point handler to fire server click event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "click" });
    };

    behavior.raiseServerDoubleClick = function (sender, e) {
        ///<summary>An entry point handler to fire server double click event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "doubleClick" });
    };

    behavior.raiseServerMouseDown = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse down event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseDown" });
    };

    behavior.raiseServerMouseMove = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse move event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseMove" });
    };

    behavior.raiseServerMouseOut = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse out event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseOut" });
    };

    behavior.raiseServerMouseOver = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse over event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseOver" });
    };

    behavior.raiseServerMouseUp = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse up event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseUp" });
    };

    behavior.raiseServerRightClick = function (sender, e) {
        ///<summary>An entry point handler to fire server right click event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "rightClick" });
    };

})(Artem.Google.PolygonBehavior);
