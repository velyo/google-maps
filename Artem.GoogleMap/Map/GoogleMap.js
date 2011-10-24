///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="http://maps.googleapis.com/maps/api/js?sensor=false"/>

// ------------------------------------------------------------------------------------------------
// Copyright (C) ArtemBG.
// ------------------------------------------------------------------------------------------------
// GoogleMap4.debug.js
// GoogleMap Control v5.5 javascipt library (debug).
//
// Assembly:    Artem.GooleMap
// Version:     6.0.0.0
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
        this.detachEvents();
        Artem.Google.Map.callBaseMethod(this, 'dispose');
    }
};
Artem.Google.Map.registerClass("Artem.Google.Map", Sys.UI.Control);

// members
(function (proto) {

    // google properties

    var map;
    proto.get_map = function () { return map; };

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

    var disableDefaultUI;
    proto.get_disableDefaultUI = function () { return disableDefaultUI; };
    proto.set_disableDefaultUI = function (value) { disableDefaultUI = value; };

    var disableDoubleClickZoom;
    proto.get_disableDoubleClickZoom = function () { return disableDoubleClickZoom; };
    proto.set_disableDoubleClickZoom = function (value) { disableDoubleClickZoom = value; };

    var draggable;
    proto.get_draggable = function () { return draggable; };
    proto.set_draggable = function (value) { draggable = value; };

    var draggableCursor;
    proto.get_draggableCursor = function () { return draggableCursor; };
    proto.set_draggableCursor = function (value) { draggableCursor = value; };

    var draggingCursor;
    proto.get_draggingCursor = function () { return draggingCursor; };
    proto.set_draggingCursor = function (value) { draggingCursor = value; };

    var enableReverseGeocoding;
    proto.get_enableReverseGeocoding = function () { return enableReverseGeocoding; };
    proto.set_enableReverseGeocoding = function (value) { enableReverseGeocoding = value; };

    var heading;
    proto.get_heading = function () { return heading; };
    proto.set_heading = function (value) { heading = value; };

    var keyboardShortcuts;
    proto.get_keyboardShortcuts = function () { return keyboardShortcuts; };
    proto.set_keyboardShortcuts = function (value) { keyboardShortcuts = value; };

    var language;
    proto.get_language = function () { return language; };
    proto.set_language = function (value) { language = value; };

    var mapType;
    proto.get_mapType = function () { return mapType; };
    proto.set_mapType = function (value) { mapType = value; };

    var mapTypeControl;
    proto.get_mapTypeControl = function () { return mapTypeControl; };
    proto.set_mapTypeControl = function (value) { mapTypeControl = value; };

    var mapTypeControlOptions;
    proto.get_mapTypeControlOptions = function () { return mapTypeControlOptions; };
    proto.set_mapTypeControlOptions = function (value) { mapTypeControlOptions = value; };

    var maxZoom;
    proto.get_maxZoom = function () { return maxZoom; };
    proto.set_maxZoom = function (value) { maxZoom = value; };

    var minZoom;
    proto.get_minZoom = function () { return minZoom; };
    proto.set_minZoom = function (value) { minZoom = value; };

    var name;
    proto.get_name = function () { return name; };
    proto.set_name = function (value) { name = value; };

    var noClear;
    proto.get_noClear = function () { return noClear; };
    proto.set_noClear = function (value) { noClear = value; };

    var overviewMapControl;
    proto.get_overviewMapControl = function () { return overviewMapControl; };
    proto.set_overviewMapControl = function (value) { overviewMapControl = value; };

    var overviewMapControlOptions;
    proto.get_overviewMapControlOptions = function () { return overviewMapControlOptions; };
    proto.set_overviewMapControlOptions = function (value) { overviewMapControlOptions = value; };

    var panControl;
    proto.get_panControl = function () { return panControl; };
    proto.set_panControl = function (value) { panControl = value; };

    var panControlOptions;
    proto.get_panControlOptions = function () { return panControlOptions; };
    proto.set_panControlOptions = function (value) { panControlOptions = value; };

    var region;
    proto.get_region = function () { return region; };
    proto.set_region = function (value) { region = value; };

    var rotateControl;
    proto.get_rotateControl = function () { return rotateControl; };
    proto.set_rotateControl = function (value) { rotateControl = value; };

    var rotateControlOptions;
    proto.get_rotateControlOptions = function () { return rotateControlOptions; };
    proto.set_rotateControlOptions = function (value) { rotateControlOptions = value; };

    var scaleControl;
    proto.get_scaleControl = function () { return scaleControl; };
    proto.set_scaleControl = function (value) { scaleControl = value; };

    var scaleControlOptions;
    proto.get_scaleControlOptions = function () { return scaleControlOptions; };
    proto.set_scaleControlOptions = function (value) { scaleControlOptions = value; };

    var scrollwheel;
    proto.get_scrollwheel = function () { return scrollwheel; };
    proto.set_scrollwheel = function (value) { scrollwheel = value; };

    var showTraffic;
    proto.get_showTraffic = function () { return showTraffic; };
    proto.set_showTraffic = function (value) { showTraffic = value; };

    var streetViewControl;
    proto.get_streetViewControl = function () { return streetViewControl; };
    proto.set_streetViewControl = function (value) { streetViewControl = value; };

    var tilt;
    proto.get_tilt = function () { return tilt; };
    proto.set_tilt = function (value) { tilt = value; };

    var zoom;
    proto.get_zoom = function () { return zoom; };
    proto.set_zoom = function (value) { zoom = value; };

    var zoomControl;
    proto.get_zoomControl = function () { return zoomControl; };
    proto.set_zoomControl = function (value) { zoomControl = value; };

    var zoomControlOptions;
    proto.get_zoomControlOptions = function () { return zoomControlOptions; };
    proto.set_zoomControlOptions = function (value) { zoomControlOptions = value; };

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
                mapTypeId: Artem.Google.Convert.toMapTypeId(mapType),
                zoom: zoom,
                backgroundColor: backgroundColor,
                disableDefaultUI: disableDefaultUI,
                disableDoubleClickZoom: disableDoubleClickZoom,
                draggable: draggable,
                draggableCursor: draggableCursor,
                draggingCursor: draggingCursor,
                keyboardShortcuts: keyboardShortcuts,
                mapTypeControl: mapTypeControl,
                noClear: noClear,
                overviewMapControl: overviewMapControl,
                panControl: panControl,
                rotateControl: rotateControl,
                scaleControl: scaleControl,
                scrollwheel: scrollwheel,
                streetViewControl: streetViewControl,
                tilt: tilt,
                zoomControl: zoomControl
            };
            if (draggableCursor) options.draggableCursor = draggableCursor;
            if (draggingCursor) options.draggingCursor = draggingCursor;
            if (heading) options.heading = heading;
            if (mapTypeControlOptions) options.mapTypeControlOptions = mapTypeControlOptions;
            if (maxZoom) options.maxZoom = maxZoom;
            if (minZoom) options.minZoom = minZoom;
            if (overviewMapControlOptions) options.overviewMapControlOptions = overviewMapControlOptions;
            if (panControlOptions) options.panControlOptions = panControlOptions;
            if (rotateControlOptions) options.rotateControlOptions = rotateControlOptions;
            if (scaleControlOptions) options.scaleControlOptions = scaleControlOptions;
            if (zoomControlOptions) options.zoomControlOptions = zoomControlOptions;

            map = new google.maps.Map(this.get_element(), options);
            this.composeEvents();

            // layers
            if (showTraffic) {
                var traffic = new google.maps.TrafficLayer();
                traffic.setMap(map);
            }

            // if reverse geocoding is enabled then try resolve the address
            if (enableReverseGeocoding) {
                var options = {
                    latlng: location,
                    language: language,
                    region: region
                };
                Artem.Google.Geocoding.getAddress(options, function (address) { address = address; });
            }

            try {
                if (!window.maps) window.maps = {};
                eval("window.maps." + this.get_id() + " = this;");
            }
            catch (ex) { }
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

    // GoogleMaps API

    proto.fitBounds = function (bounds) {
        ///<summary>Sets the viewport to contain the given bounds.</summary>
        map.fitBounds(bounds);
    };

    proto.getBounds = function () {
        ///<summary>Returns the lat/lng bounds of the current viewport. If the map is not yet initialized (i.e. the mapType is still null), or center and zoom have not been set then the result is null or undefined.</summary>
        return map.getBounds();
    };

    proto.getCenter = function () {
        return map.getCenter();
    };

    proto.getDiv = function () {
        return map.getDiv();
    };

    proto.getHeading = function () {
        ///<summary>Returns the compass heading of aerial imagery. The heading value is measured in degrees (clockwise) from cardinal direction North.</summary>
        return map.getHeading();
    };

    proto.getMapTypeId = function () {
        return map.getMapTypeId();
    };

    proto.getProjection = function () {
        ///<summary>Returns the current Projection. If the map is not yet initialized (i.e. the mapType is still null) then the result is null. Listen to projection_changed and check its value to ensure it is not null.</summary>
        return map.getProjection();
    };

    proto.getStreetView = function () {
        ///<summary>Returns the default StreetViewPanorama bound to the map, which may be a default panorama embedded within the map, or the panorama set using setStreetView(). Changes to the map's streetViewControl will be reflected in the display of such a bound panorama.</summary>
        return map.getStreetView();
    };

    proto.getTilt = function () {
        ///<summary>Returns the angle of incidence for aerial imagery (available for SATELLITE and HYBRID map types) measured in degrees from the viewport plane to the map plane. A value of 0 indicates no angle of incidence (no tilt) while 45° imagery will return a value of 45.</summary>
        return map.getTilt();
    };

    proto.getZoom = function () {
        return map.getZoom();
    };

    proto.panBy = function (x, y) {
        ///<summary>Changes the center of the map by the given distance in pixels. If the distance is less than both the width and height of the map, the transition will be smoothly animated. Note that the map coordinate system increases from west to east (for x values) and north to south (for y values).</summary>
        map.panBy(x, y);
    };

    proto.panTo = function (latLng) {
        ///<summary>Changes the center of the map to the given LatLng. If the change is less than both the width and height of the map, the transition will be smoothly animated.</summary>
        map.panTo(latLng);
    };

    proto.panToBounds = function (latLngBounds) {
        ///<summary>Pans the map by the minimum amount necessary to contain the given LatLngBounds. It makes no guarantee where on the map the bounds will be, except that as much of the bounds as possible will be visible. The bounds will be positioned inside the area bounded by the map type and navigation (pan, zoom, and Street View) controls, if they are present on the map. If the bounds is larger than the map, the map will be shifted to include the northwest corner of the bounds. If the change in the map's position is less than both the width and height of the map, the transition will be smoothly animated.</summary>
        map.panToBounds(latLngBounds);
    };

    proto.setCenter = function (latlng) {
        map.setCenter(latlng);
    };

    proto.setHeading = function (heading) {
        ///<summary>Sets the compass heading for aerial imagery measured in degrees from cardinal direction North.</summary>
        map.setHeading(heading);
    };

    proto.setMapTypeId = function (mapTypeId) {
        map.setMapTypeId(mapTypeId);
    };

    proto.setOptions = function (options) {
        map.setOptions(options);
    };

    proto.setStreetView = function (panorama) {
        ///<summary>Binds a StreetViewPanorama to the map. This panorama overrides the default StreetViewPanorama, allowing the map to bind to an external panorama outside of the map. Setting the panorama to null binds the default embedded panorama back to the map.</summary>
        map.setStreetView(panorama);
    };

    proto.setTilt = function (tilt) {
        ///<summary>Sets the angle of incidence for aerial imagery (available for SATELLITE and HYBRID map types) measured in degrees from the viewport plane to the map plane. The only supported values are 0, indicating no angle of incidence (no tilt), and 45 indicating a tilt of 45deg;.</summary>
        map.setTilt(tilt);
    };

    proto.setZoom = function (zoom) {
        map.setZoom(zoom);
    };

})(Artem.Google.Map.prototype);

// events
(function (proto) {

    // fields
    var delegates = {
        "bounds_changed": null,
        "center_changed": null,
        "click": null,
        "dblclick": null,
        "drag": null,
        "dragend": null,
        "dragstart": null,
        "heading_changed": null,
        "idle": null,
        "maptypeid_changed": null,
        "mousemove": null,
        "mouseout": null,
        "mouseover": null,
        "projection_changed": null,
        "resize": null,
        "rightclick": null,
        "tilesloaded": null,
        "tilt_changed": null,
        "zoom_changed": null
    };
    var handlers = {
        "bounds_changed": raiseBoundsChanged,
        "center_changed": raiseCenterChanged,
        "click": raiseClick,
        "dblclick": raiseDoubleClick,
        "drag": raiseDrag,
        "dragend": raiseDragEnd,
        "dragstart": raiseDragStart,
        "heading_changed": raiseHeadingChanged,
        "idle": raiseIdle,
        "maptypeid_changed": raiseMapTypeChanged,
        "mousemove": raiseMouseMove,
        "mouseout": raiseMouseOut,
        "mouseover": raiseMouseOver,
        "projection_changed": raiseProjectionChanged,
        "resize": raiseResize,
        "rightclick": raiseRightClick,
        "tilesloaded": raiseTilesLoaded,
        "tilt_changed": raiseTiltChanged,
        "zoom_changed": raiseZoomChanged
    };
    var listeners = {
        "bounds_changed": null,
        "center_changed": null,
        "click": null,
        "dblclick": null,
        "drag": null,
        "dragend": null,
        "dragstart": null,
        "heading_changed": null,
        "idle": null,
        "maptypeid_changed": null,
        "mousemove": null,
        "mouseout": null,
        "mouseover": null,
        "projection_changed": null,
        "resize": null,
        "rightclick": null,
        "tilesloaded": null,
        "tilt_changed": null,
        "zoom_changed": null
    };

    // utility

    proto.composeEvents = function () {

        var map = this.get_map();
        if (map) {
            var handler;
            for (var name in handlers) {
                handler = this.get_events().getHandler(name);
                if (handler) {
                    if (!listeners[name]) {
                        if (!delegates[name]) delegates[name] = Function.createDelegate(this, handlers[name]);
                        listeners[name] = google.maps.event.addListener(map, name, delegates[name]);
                    }
                }
                else if (listeners[name]) {
                    google.maps.event.removeListener(listeners[name]);
                }
            }
        }
    };

    proto.detachEvents = function () {
        google.maps.event.clearInstanceListeners(this.get_map());
    };

    // bounds changed
    proto.add_boundsChanged = function (handler) {
        this.get_events().addHandler("bounds_changed", handler);
        this.composeEvents();
    };
    proto.remove_boundsChanged = function (handler) {
        this.get_events().removeHandler("bounds_changed", handler);
        this.composeEvents();
    };
    function raiseBoundsChanged(e) {
        var handler = this.get_events().getHandler("bounds_changed");
        if (handler) handler(this, e);
    }

    // center changed
    proto.add_centerChanged = function (handler) {
        this.get_events().addHandler("center_changed", handler);
        this.composeEvents();
    };
    proto.remove_centerChanged = function (handler) {
        this.get_events().removeHandler("center_changed", handler);
        this.composeEvents();
    };
    function raiseCenterChanged(e) {
        var handler = this.get_events().getHandler("center_changed");
        if (handler) handler(this, e);
    }

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

    // drag
    proto.add_drag = function (handler) {
        this.get_events().addHandler("drag", handler);
        this.composeEvents();
    };
    proto.remove_drag = function (handler) {
        this.get_events().removeHandler("drag", handler);
        this.composeEvents();
    };
    function raiseDrag(e) {
        var handler = this.get_events().getHandler("drag");
        if (handler) handler(this, e);
    }

    // drag end
    proto.add_dragEnd = function (handler) {
        this.get_events().addHandler("dragend", handler);
        this.composeEvents();
    };
    proto.remove_dragEnd = function (handler) {
        this.get_events().removeHandler("dragend", handler);
        this.composeEvents();
    };
    function raiseDragEnd(e) {
        var handler = this.get_events().getHandler("dragend");
        if (handler) handler(this, e);
    }

    // drag start
    proto.add_dragStart = function (handler) {
        this.get_events().addHandler("dragstart", handler);
        this.composeEvents();
    };
    proto.remove_dragStart = function (handler) {
        this.get_events().removeHandler("dragstart", handler);
        this.composeEvents();
    };
    function raiseDragStart(e) {
        var handler = this.get_events().getHandler("dragstart");
        if (handler) handler(this, e);
    }

    // heading changed
    proto.add_headingChanged = function (handler) {
        this.get_events().addHandler("heading_changed", handler);
        this.composeEvents();
    };
    proto.remove_headingChanged = function (handler) {
        this.get_events().removeHandler("heading_changed", handler);
        this.composeEvents();
    };
    function raiseHeadingChanged(e) {
        var handler = this.get_events().getHandler("heading_changed");
        if (handler) handler(this, e);
    }

    // idle
    proto.add_idle = function (handler) {
        this.get_events().addHandler("idle", handler);
        this.composeEvents();
    };
    proto.remove_idle = function (handler) {
        this.get_events().removeHandler("idle", handler);
        this.composeEvents();
    };
    function raiseIdle(e) {
        var handler = this.get_events().getHandler("idle");
        if (handler) handler(this, e);
    }

    // map type changed
    proto.add_mapTypeChanged = function (handler) {
        this.get_events().addHandler("maptypeid_changed", handler);
        this.composeEvents();
    };
    proto.remove_mapTypeChanged = function (handler) {
        this.get_events().removeHandler("maptypeid_changed", handler);
        this.composeEvents();
    };
    function raiseMapTypeChanged(e) {
        var handler = this.get_events().getHandler("maptypeid_changed");
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

    // projection changed
    proto.add_projectionChanged = function (handler) {
        this.get_events().addHandler("projection_changed", handler);
        this.composeEvents();
    };
    proto.remove_projectionChanged = function (handler) {
        this.get_events().removeHandler("projection_changed", handler);
        this.composeEvents();
    };
    function raiseProjectionChanged(e) {
        var handler = this.get_events().getHandler("projection_changed");
        if (handler) handler(this, e);
    }

    // resize
    proto.add_resize = function (handler) {
        this.get_events().addHandler("resize", handler);
        this.composeEvents();
    };
    proto.remove_resize = function (handler) {
        this.get_events().removeHandler("resize", handler);
        this.composeEvents();
    };
    function raiseResize(e) {
        var handler = this.get_events().getHandler("resize");
        if (handler) handler(this, e);
    }

    // right click
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

    // tiles loaded
    proto.add_tilesLoaded = function (handler) {
        this.get_events().addHandler("tilesloaded", handler);
        this.composeEvents();
    };
    proto.remove_tilesLoaded = function (handler) {
        this.get_events().removeHandler("tilesloaded", handler);
        this.composeEvents();
    };
    function raiseTilesLoaded(e) {
        var handler = this.get_events().getHandler("tilesloaded");
        if (handler) handler(this, e);
    }

    // tilt changed
    proto.add_tiltChanged = function (handler) {
        this.get_events().addHandler("tilt_changed", handler);
        this.composeEvents();
    };
    proto.remove_tiltChanged = function (handler) {
        this.get_events().removeHandler("tilt_changed", handler);
        this.composeEvents();
    };
    function raiseTiltChanged(e) {
        var handler = this.get_events().getHandler("tilt_changed");
        if (handler) handler(this, e);
    }

    // zoom changed
    proto.add_zoomChanged = function (handler) {
        this.get_events().addHandler("zoom_changed", handler);
        this.composeEvents();
    };
    proto.remove_zoomChanged = function (handler) {
        this.get_events().removeHandler("zoom_changed", handler);
        this.composeEvents();
    };
    function raiseZoomChanged(e) {
        var handler = this.get_events().getHandler("zoom_changed");
        if (handler) handler(this, e);
    }

})(Artem.Google.Map.prototype);

// server events - entry points
(function (control) {

    function getMapEventArgs(sender, name) {

        var map = sender.get_map();
        var bounds = map.getBounds();
        var center = map.getCenter();
        return {
            name: name,
            bounds: { sw: bounds.getSouthWest(), ne: bounds.getNorthEast() },
            center: { lat: center.lat(), lng: center.lng() },
            mapType: map.getMapTypeId(),
            zoom: map.getZoom()
        };
    }

    function raiseServerEvent(target, args) {
        __doPostBack(target, Sys.Serialization.JavaScriptSerializer.serialize(args));
    }

    control.raiseServerBoundsChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server bounds changed event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "boundsChanged"));
    };

    control.raiseServerCenterChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server center changed event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "centerChanged"));
    };

    control.raiseServerClick = function (sender, e) {
        ///<summary>An entry point handler to fire server click event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "click" });
    };

    control.raiseServerDoubleClick = function (sender, e) {
        ///<summary>An entry point handler to fire server double click event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "doubleClick" });
    };

    control.raiseServerDrag = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "drag"));
    };

    control.raiseServerDragEnd = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "dragEnd"));
    };

    control.raiseServerDragStart = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "dragStart"));
    };

    control.raiseServerHeadingChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), { name: "headingChanged" });
    };

    control.raiseServerIdle = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), { name: "idle" });
    };

    control.raiseServerMapTypeChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "mapTypeChanged"));
    };

    control.raiseServerMouseMove = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse move event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseMove" });
    };

    control.raiseServerMouseOut = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse out event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseOut" });
    };

    control.raiseServerMouseOver = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse over event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "mouseOver" });
    };

    control.raiseServerProjectionChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), { name: "projectionChanged" });
    };

    control.raiseServerResize = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "resize"));
    };

    control.raiseServerRightClick = function (sender, e) {
        ///<summary>An entry point handler to fire server right click event post back.</summary>
        raiseServerEvent(
            sender.get_name(),
            { lat: e.latLng.lat(), lng: e.latLng.lng(), name: "rightClick" });
    };

    control.raiseServerTilesLoaded = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), { name: "tilesLoaded" });
    };

    control.raiseServerTiltChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), { name: "tiltChanged" });
    };

    control.raiseServerZoomChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent(sender.get_name(), getMapEventArgs(sender, "zoomChanged"));
    };

})(Artem.Google.Map);

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

    function mapTypeId(value) {
        switch (value) {
            case 0:
                return google.maps.MapTypeId.HYBRID;
            case 1:
                return google.maps.MapTypeId.ROADMAP;
            case 2:
                return google.maps.MapTypeId.SATELLITE;
            case 3:
                return google.maps.MapTypeId.TERRAIN;
            default:
                return google.maps.MapTypeId.HYBRID;
        }
    }

    return {
        toLatLng: latlng,
        toLatLngArray: latlngArray,
        toLatLngBounds: latlngBounds,
        toMapTypeId: mapTypeId
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

    return { getAddress: getAddress, getLocation: getLocation };
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

// object merging
Artem.Google.merge = function (obj1, obj2) {
    var result = {};
    for (var name in obj1) result[name] = obj1[name];
    for (var name in obj2) result[name] = obj2[name];
    return result;
};