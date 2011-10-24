///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="..\Map\GoogleMap.js"/>
///<reference path="http://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Artem.Google");

Artem.Google.GroundBehavior = function (element) {
    Artem.Google.GroundBehavior.initializeBase(this, [element]);
};

Artem.Google.GroundBehavior.prototype = {
    initialize: function () {
        Artem.Google.GroundBehavior.callBaseMethod(this, 'initialize');
        this.create();
    },
    dispose: function () {
        this.detachEvents();
        Artem.Google.GroundBehavior.callBaseMethod(this, 'dispose');
    }
};

Artem.Google.GroundBehavior.registerClass('Artem.Google.GroundBehavior', Sys.UI.Behavior);

// members
(function (proto) {

    // google

    var map;
    proto.get_map = function () { return map; };

    var ground;
    proto.get_ground = function () { return ground; };

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

    proto.create = function () {

        map = $find(this.get_element().id);
        ground = new google.maps.GroundOverlay(
            url,
            Artem.Google.Convert.toLatLngBounds(bounds),
            { clickable: clickable, map: map.get_map() });
        this.composeEvents();
    };

    // GoogleMaps API

    proto.getBounds = function () {
        ///<summary>Gets the LatLngBounds of this overlay.</summary>
        return map.getBounds();
    };

    proto.getMap = function () {
        ///<summary>Returns the map on which this ground overlay is displayed.</summary>
        return map.getMap();
    };

    proto.getUrl = function () {
        ///<summary>Gets the url of the projected image.</summary>
        return map.getUrl();
    };

    proto.getMap = function (map) {
        ///<summary>Renders the ground overlay on the specified map. If map is set to null, the overlay is removed.</summary>
        return map.setMap(map);
    };

})(Artem.Google.GroundBehavior.prototype);

// events
(function (proto) {

    // fields
    var delegates = {
        "click": null
    };
    var handlers = {
        "click": raiseClick
    };
    var listeners = {
        "click": null
    };

    // utility

    proto.composeEvents = function () {

        var ground = this.get_ground();
        if (ground) {
            var handler;
            for (var name in handlers) {
                handler = this.get_events().getHandler(name);
                if (handler) {
                    if (!listeners[name]) {
                        if (!delegates[name]) delegates[name] = Function.createDelegate(this, handlers[name]);
                        listeners[name] = google.maps.event.addListener(ground, name, delegates[name]);
                    }
                }
                else if (listeners[name]) {
                    google.maps.event.removeListener(listeners[name]);
                }
            }
        }
    };

    proto.detachEvents = function () {
        google.maps.event.clearInstanceListeners(this.get_ground());
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

})(Artem.Google.GroundBehavior.prototype);

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

})(Artem.Google.GroundBehavior);