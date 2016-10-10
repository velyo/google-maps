///<reference name="MicrosoftAjax.debug.js"/>
///<reference path=".\GoogleMap.js"/>
///<reference path="https://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Velyo.Google.Maps");

Velyo.Google.Maps.GroundBehavior = function (element) {
    Velyo.Google.Maps.GroundBehavior.initializeBase(this, [element]);
};

Velyo.Google.Maps.GroundBehavior.prototype = {
    initialize: function () {
        Velyo.Google.Maps.GroundBehavior.callBaseMethod(this, 'initialize');
        Velyo.Google.Maps.Worker.queue(Function.createDelegate(this, this._attach));
    },
    dispose: function () {
        this._detach();
        Velyo.Google.Maps.GroundBehavior.callBaseMethod(this, 'dispose');
    }
};

Velyo.Google.Maps.GroundBehavior.registerClass('Velyo.Google.Maps.GroundBehavior', Sys.UI.Behavior);

// members
(function (proto) {

    // fields

    proto.map = null;
    proto.ground = null;

    // properties

    var name;
    proto.get_name = function () { return name; };
    proto.set_name = function (value) { name = value; };

    var bounds;
    proto.get_bounds = function () { return bounds; };
    proto.set_bounds = function (value) { bounds = value; };

    var clickable;
    proto.get_clickable = function () { return clickable; };
    proto.set_clickable = function (value) { clickable = value; };

    var url;
    proto.get_url = function () { return url; };
    proto.set_url = function (value) { url = value; };

    // methods

    proto._attach = function () {
        var control = $find(this.get_element().id);
        if (control)
            control.add_mapLoaded(Function.createDelegate(this, this.create));
    };

    proto._detach = function () {
        if (this.ground)
            google.maps.event.clearInstanceListeners(this.ground);
    };

    proto.create = function () {

        var control = $find(this.get_element().id);
        if (control)
            this.map = control.map;
        this.ground = new google.maps.GroundOverlay(
            url,
            Velyo.Google.Maps.Convert.toLatLngBounds(bounds),
            { clickable: clickable, map: this.map });
        this.composeEvents();
    };

    // GoogleMaps API

    proto.getBounds = function () {
        ///<summary>Gets the LatLngBounds of this overlay.</summary>
        return this.ground.getBounds();
    };

    proto.getMap = function () {
        ///<summary>Returns the map on which this ground overlay is displayed.</summary>
        return this.ground.getMap();
    };

    proto.getUrl = function () {
        ///<summary>Gets the url of the projected image.</summary>
        return this.ground.getUrl();
    };

    proto.getMap = function (map) {
        ///<summary>Renders the ground overlay on the specified map. If map is set to null, the overlay is removed.</summary>
        return this.ground.setMap(map);
    };

})(Velyo.Google.Maps.GroundBehavior.prototype);

// events
(function (proto) {

    // fields
    var handlers = {
        "click": raiseClick
    };
    proto.delegates = {
        "click": null
    };
    proto.listeners = {
        "click": null
    };

    // utility

    proto.composeEvents = function () {

        if (this.ground) {
            var handler;
            for (var name in handlers) {
                handler = this.get_events().getHandler(name);
                if (handler) {
                    if (!this.listeners[name]) {
                        if (!this.delegates[name]) this.delegates[name] = Function.createDelegate(this, handlers[name]);
                        this.listeners[name] = google.maps.event.addListener(this.ground, name, this.delegates[name]);
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

})(Velyo.Google.Maps.GroundBehavior.prototype);

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

})(Velyo.Google.Maps.GroundBehavior);