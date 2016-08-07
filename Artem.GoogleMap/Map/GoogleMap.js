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

    // fields
    proto.map = null;
    proto.get_bounds = function () { return this.bounds; };
    proto.set_bounds = function (value) { this.bounds = value;};

    // properties

    proto.get_address = function () { return this.address; };
    proto.set_address = function (value) { this.address = value; };

    proto.get_backgroundColor = function () { return this.backgroundColor; };
    proto.set_backgroundColor = function (value) { this.backgroundColor = value; };

    proto.get_center = function () { return this.center; };
    proto.set_center = function (value) { this.center = value; };

    proto.get_defaultAddress = function () { return this.defaultAddress; };
    proto.set_defaultAddress = function (value) { this.defaultAddress = value; };

    proto.get_disableDefaultUI = function () { return this.disableDefaultUI; };
    proto.set_disableDefaultUI = function (value) { this.disableDefaultUI = value; };

    proto.get_disableDoubleClickZoom = function () { return this.disableDoubleClickZoom; };
    proto.set_disableDoubleClickZoom = function (value) { this.disableDoubleClickZoom = value; };

    proto.get_draggable = function () { return this.draggable; };
    proto.set_draggable = function (value) { this.draggable = value; };

    proto.get_draggableCursor = function () { return this.draggableCursor; };
    proto.set_draggableCursor = function (value) { this.draggableCursor = value; };

    proto.get_draggingCursor = function () { return this.draggingCursor; };
    proto.set_draggingCursor = function (value) { this.draggingCursor = value; };

    proto.get_enableReverseGeocoding = function () { return this.enableReverseGeocoding; };
    proto.set_enableReverseGeocoding = function (value) { this.enableReverseGeocoding = value; };

    proto.get_heading = function () { return this.heading; };
    proto.set_heading = function (value) { this.heading = value; };

    proto.get_keyboardShortcuts = function () { return this.keyboardShortcuts; };
    proto.set_keyboardShortcuts = function (value) { this.keyboardShortcuts = value; };

    proto.get_language = function () { return this.language; };
    proto.set_language = function (value) { this.language = value; };

    proto.get_mapType = function () { return this.mapType; };
    proto.set_mapType = function (value) { this.mapType = value; };

    proto.get_mapTypeControl = function () { return this.mapTypeControl; };
    proto.set_mapTypeControl = function (value) { this.mapTypeControl = value; };

    proto.get_mapTypeControlOptions = function () { return this.mapTypeControlOptions; };
    proto.set_mapTypeControlOptions = function (value) { this.mapTypeControlOptions = value; };

    proto.get_maxZoom = function () { return this.maxZoom; };
    proto.set_maxZoom = function (value) { this.maxZoom = value; };

    proto.get_minZoom = function () { return this.minZoom; };
    proto.set_minZoom = function (value) { this.minZoom = value; };

    proto.get_name = function () { return this.name; };
    proto.set_name = function (value) { this.name = value; };

    proto.get_noClear = function () { return this.noClear; };
    proto.set_noClear = function (value) { this.noClear = value; };

    proto.get_overviewMapControl = function () { return this.overviewMapControl; };
    proto.set_overviewMapControl = function (value) { this.overviewMapControl = value; };

    proto.get_overviewMapControlOptions = function () { return this.overviewMapControlOptions; };
    proto.set_overviewMapControlOptions = function (value) { this.overviewMapControlOptions = value; };

    proto.get_panControl = function () { return this.panControl; };
    proto.set_panControl = function (value) { this.panControl = value; };

    proto.get_panControlOptions = function () { return this.panControlOptions; };
    proto.set_panControlOptions = function (value) { this.panControlOptions = value; };

    proto.get_region = function () { return this.region; };
    proto.set_region = function (value) { this.region = value; };

    proto.get_rotateControl = function () { return this.rotateControl; };
    proto.set_rotateControl = function (value) { this.rotateControl = value; };

    proto.get_rotateControlOptions = function () { return this.rotateControlOptions; };
    proto.set_rotateControlOptions = function (value) { this.rotateControlOptions = value; };

    proto.get_scaleControl = function () { return this.scaleControl; };
    proto.set_scaleControl = function (value) { this.scaleControl = value; };

    proto.get_scaleControlOptions = function () { return this.scaleControlOptions; };
    proto.set_scaleControlOptions = function (value) { this.scaleControlOptions = value; };

    proto.get_scrollwheel = function () { return this.scrollwheel; };
    proto.set_scrollwheel = function (value) { this.scrollwheel = value; };

    proto.get_shortID = function () { return this.shortID; };
    proto.set_shortID = function (value) { this.shortID = value; };

    proto.get_showTraffic = function () { return this.showTraffic; };
    proto.set_showTraffic = function (value) { this.showTraffic = value; };

    proto.get_streetViewControl = function () { return this.streetViewControl; };
    proto.set_streetViewControl = function (value) { this.streetViewControl = value; };

    proto.get_tilt = function () { return this.tilt; };
    proto.set_tilt = function (value) { this.tilt = value; };

    proto.get_zoom = function () { return this.zoom; };
    proto.set_zoom = function (value) { this.zoom = value; };

    proto.get_zoomControl = function () { return this.zoomControl; };
    proto.set_zoomControl = function (value) { this.zoomControl = value; };

    proto.get_zoomControlOptions = function () { return this.zoomControlOptions; };
    proto.set_zoomControlOptions = function (value) { this.zoomControlOptions = value; };
    
    proto.get_searchBoxControl = function () { return this.searchBoxControl; };
    proto.set_searchBoxControl = function (value) { this.searchBoxControl = value; };
    
    proto.get_searchBoxControlOptions = function () { return this.searchBoxControlOptions; };
    proto.set_searchBoxControlOptions = function (value) { this.searchBoxControlOptions = value; };

    // private methods

    // methods

    proto.create = function (location) {
        /// <summary>Creates the map.</summary>

        if (!location) {
            if (this.center)
                location = Artem.Google.Convert.toLatLng(this.center);
        }
        else {
            this.center = location;
        }

        // create map
        if (location || this.bounds) {
            var options = {
                center: location,
                mapTypeId: Artem.Google.Convert.toMapTypeId(this.mapType),
                zoom: this.zoom,
                backgroundColor: this.backgroundColor,
                disableDefaultUI: this.disableDefaultUI,
                disableDoubleClickZoom: this.disableDoubleClickZoom,
                draggable: this.draggable,
                keyboardShortcuts: this.keyboardShortcuts,
                mapTypeControl: this.mapTypeControl,
                noClear: this.noClear,
                overviewMapControl: this.overviewMapControl,
                panControl: this.panControl, 
                rotateControl: this.rotateControl,
                scaleControl: this.scaleControl,
                scrollwheel: this.scrollwheel,
                streetViewControl: this.streetViewControl,
                tilt: this.tilt,
                zoomControl: this.zoomControl
            };
            
            if (this.draggableCursor) options.draggableCursor = this.draggableCursor;
            if (this.draggingCursor) options.draggingCursor = this.draggingCursor;
            if (this.heading) options.heading = this.heading;
            if (this.mapTypeControlOptions) options.mapTypeControlOptions = this.mapTypeControlOptions;
            if (this.maxZoom) options.maxZoom = this.maxZoom;
            if (this.minZoom) options.minZoom = this.minZoom;
            if (this.overviewMapControlOptions) options.overviewMapControlOptions = this.overviewMapControlOptions;
            if (this.panControlOptions) options.panControlOptions = this.panControlOptions;
            if (this.rotateControlOptions) options.rotateControlOptions = this.rotateControlOptions;
            if (this.scaleControlOptions) options.scaleControlOptions = this.scaleControlOptions;
            if (this.zoomControlOptions) options.zoomControlOptions = this.zoomControlOptions;
            if (this.disableMultipleInfoWindows) options.disableMultipleInfoWindows = this.disableMultipleInfoWindows;

            this.map = new google.maps.Map(this.get_element(), options);
            this.composeEvents();

            this.mapLoaded = true;
            this.raiseMapLoaded();

            // fit to bounds, if provided
            if (this.bounds)
                this.fitBounds(new google.maps.LatLngBounds(
                    new google.maps.LatLng(this.bounds.sw.lat, this.bounds.sw.lng), 
                    new google.maps.LatLng(this.bounds.ne.lat, this.bounds.ne.lng)));

            // layers
            if (this.showTraffic) { 
                var traffic = new google.maps.TrafficLayer();
                traffic.setMap(this.map);
            }
            
            // searchbox
            if (this.searchBoxControl) {
                var self = this;
                // Create the search box and link it to the UI element.
                var input = document.getElementById(this.get_element() + "_SearchBox");
                
                if (!input) {
                    input = document.createElement("input");
                    input.type = "text";
                    input.setAttribute("style", self.searchBoxControlOptions.style);
                    input.setAttribute("placeHolder", self.searchBoxControlOptions.text);
                    this.get_element().appendChild(input);
                }
                
                input.onkeypress = function (e) {
                    if (e.keyCode == 13) { // Detect Enter
                        var options = { address: this.value, language: self.language, region: self.region };
                        Artem.Google.Geocoding.getResults(options, function (results) {
                            if (results && results.length)
                                self.map.fitBounds(results[0].geometry.bounds);
                        });
                        return false;
                    }
                };

                this.map.controls[self.searchBoxControlOptions.position].push(input);
            }

            // if reverse geocoding is enabled then try resolve the address
            if (this.enableReverseGeocoding) {
                var options = {
                    latlng: location,
                    language: this.language,
                    region: this.region
                };
                Artem.Google.Geocoding.getAddress(options,
                    Function.createDelegate(this, function (address) { this.address = address; }));
            }

            try {
                if (!window.maps) window.maps = {};
                eval("window.maps." + this.get_shortID() + " = this;");
            }
            catch (ex) { }
        }
        else {
            var options = {
                address: this.address,
                defaultAddress: this.defaultAddress,
                language: this.language,
                region: this.region
            };
            Artem.Google.Geocoding.getLocation(options, Function.createDelegate(this, this.create));
        }
    };

    // GoogleMaps API

    proto.fitBounds = function (bounds) {
        ///<summary>Sets the viewport to contain the given bounds.</summary>
        this.map.fitBounds(bounds);
    };

    proto.getBounds = function () {
        ///<summary>Returns the lat/lng bounds of the current viewport. If the map is not yet initialized (i.e. the mapType is still null), or center and zoom have not been set then the result is null or undefined.</summary>
        return this.map.getBounds();
    };

    proto.getCenter = function () {
        return this.map.getCenter();
    };

    proto.getDiv = function () {
        return this.map.getDiv();
    };

    proto.getHeading = function () {
        ///<summary>Returns the compass heading of aerial imagery. The heading value is measured in degrees (clockwise) from cardinal direction North.</summary>
        return this.map.getHeading();
    };

    proto.getMapTypeId = function () {
        return this.map.getMapTypeId();
    };

    proto.getProjection = function () {
        ///<summary>Returns the current Projection. If the map is not yet initialized (i.e. the mapType is still null) then the result is null. Listen to projection_changed and check its value to ensure it is not null.</summary>
        return this.map.getProjection();
    };

    proto.getStreetView = function () {
        ///<summary>Returns the default StreetViewPanorama bound to the map, which may be a default panorama embedded within the map, or the panorama set using setStreetView(). Changes to the map's streetViewControl will be reflected in the display of such a bound panorama.</summary>
        return this.map.getStreetView();
    };

    proto.getTilt = function () {
        ///<summary>Returns the angle of incidence for aerial imagery (available for SATELLITE and HYBRID map types) measured in degrees from the viewport plane to the map plane. A value of 0 indicates no angle of incidence (no tilt) while 45° imagery will return a value of 45.</summary>
        return this.map.getTilt();
    };

    proto.getZoom = function () {
        return this.map.getZoom();
    };

    proto.panBy = function (x, y) {
        ///<summary>Changes the center of the map by the given distance in pixels. If the distance is less than both the width and height of the map, the transition will be smoothly animated. Note that the map coordinate system increases from west to east (for x values) and north to south (for y values).</summary>
        this.map.panBy(x, y);
    };

    proto.panTo = function (latLng) {
        ///<summary>Changes the center of the map to the given LatLng. If the change is less than both the width and height of the map, the transition will be smoothly animated.</summary>
        this.map.panTo(latLng);
    };

    proto.panToBounds = function (latLngBounds) {
        ///<summary>Pans the map by the minimum amount necessary to contain the given LatLngBounds. It makes no guarantee where on the map the bounds will be, except that as much of the bounds as possible will be visible. The bounds will be positioned inside the area bounded by the map type and navigation (pan, zoom, and Street View) controls, if they are present on the map. If the bounds is larger than the map, the map will be shifted to include the northwest corner of the bounds. If the change in the map's position is less than both the width and height of the map, the transition will be smoothly animated.</summary>
        this.map.panToBounds(latLngBounds);
    };

    proto.setCenter = function (latlng) {
        this.map.setCenter(latlng);
    };

    proto.setHeading = function (heading) {
        ///<summary>Sets the compass heading for aerial imagery measured in degrees from cardinal direction North.</summary>
        this.map.setHeading(heading);
    };

    proto.setMapTypeId = function (mapTypeId) {
        this.map.setMapTypeId(mapTypeId);
    };

    proto.setOptions = function (options) {
        this.map.setOptions(options);
    };

    proto.setStreetView = function (panorama) {
        ///<summary>Binds a StreetViewPanorama to the map. This panorama overrides the default StreetViewPanorama, allowing the map to bind to an external panorama outside of the map. Setting the panorama to null binds the default embedded panorama back to the map.</summary>
        this.map.setStreetView(panorama);
    };

    proto.setTilt = function (tilt) {
        ///<summary>Sets the angle of incidence for aerial imagery (available for SATELLITE and HYBRID map types) measured in degrees from the viewport plane to the map plane. The only supported values are 0, indicating no angle of incidence (no tilt), and 45 indicating a tilt of 45deg;.</summary>
        this.map.setTilt(tilt);
    };

    proto.setZoom = function (zoom) {
        this.map.setZoom(zoom);
    };

})(Artem.Google.Map.prototype);

// events
(function (proto) {

    // fields
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
    proto.delegates = {
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
    proto.listeners = {
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

        if (this.map) {
            var handler;
            for (var name in handlers) {
                handler = this.get_events().getHandler(name);
                if (handler) {
                    if (!this.listeners[name]) {
                        if (!this.delegates[name]) this.delegates[name] = Function.createDelegate(this, handlers[name]);
                        this.listeners[name] = google.maps.event.addListener(this.map, name, this.delegates[name]);
                    }
                }
                else if (this.listeners[name]) {
                    google.maps.event.removeListener(this.listeners[name]);
                }
            }
        }
    };

    proto.detachEvents = function () {
        if (this.map)
            google.maps.event.clearInstanceListeners(this.map);
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

    // map loaded
    proto.add_mapLoaded = function (handler) {
        if (!this.mapLoaded)
            this.get_events().addHandler("mapLoaded", handler);
        else
            handler(this);
    };
    proto.remove_mapLoaded = function (handler) {
        this.get_events().removeHandler("mapLoaded", handler);
    };
    proto.raiseMapLoaded = function () {
        var handler = this.get_events().getHandler("mapLoaded");
        if (handler) handler(this);
    };

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

        var map = sender.map;
        var bounds = map.getBounds();
        var center = map.getCenter();
        var sw = bounds.getSouthWest();
        var ne = bounds.getNorthEast();
        return {
            name: name,
            bounds: { sw: { lat: sw.lat(), lng: sw.lng() }, ne: { lat: ne.lat(), lng: ne.lng() } },
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

    function getResults(options, callback) {
         var request = {
            address: options.address,
            language: options.language,
            region: options.region
        };

        geocoder = geocoder || new google.maps.Geocoder();
        geocoder.geocode(request, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                try {
                    callback(results);
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

    return { getAddress: getAddress, getLocation: getLocation, getResults: getResults };
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

// worker - queue taks in sequence one by one to give ability other js operations to queued meanwhile
Artem.Worker = (function () {
    var tasks = [];
    var timer = null;

    function clear(delegate) {
        tasks = [];
    }

    function queue(task) {
        tasks.push(task);
        if (!timer) setTimeout(work, 1);
    }

    function stop() {
        if (timer) {
            clearTimeout(timer);
            timer = null;
        }
        clear();
    }

    function work() {
        var task = tasks.pop();
        if (task) {
            task.call();
            setTimeout(work, 1);
        }
        else {
            timer = null;
        }
    }

    return { clear: clear, queue: queue, stop: stop };
})();

// utility functions
// object merging
Artem.Google.merge = function (obj1, obj2) {
    var result = {};
    if (obj1)
        for (var name in obj1) result[name] = obj1[name];
    if (obj2)
        for (var name in obj2) result[name] = obj2[name];
    return result;
};