///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="..\Scripts\GoogleCommons.js"/>
///<reference path="..\Scripts\GoogleMap.js"/>
///<reference path="http://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Artem.Google");

Artem.Google.PolylineBehavior = function (element) {
    Artem.Google.PolylineBehavior.initializeBase(this, [element]);
}

Artem.Google.PolylineBehavior.prototype = {
    initialize: function () {
        Artem.Google.PolylineBehavior.callBaseMethod(this, 'initialize');
        this.create();
    },
    dispose: function () {
        this.detachEvents();
        Artem.Google.PolylineBehavior.callBaseMethod(this, 'dispose');
    }
};

(function (proto) {

    // properties
    var map;
    proto.get_map = function () { return map; };

    var polyline;
    proto.get_polyline = function () { return polyline; };

    var clickable;
    proto.get_clickable = function () { return clickable; };
    proto.set_clickable = function (value) { clickable = value; };

    var geodesic;
    proto.get_geodesic = function () { return geodesic; };
    proto.set_geodesic = function (value) { geodesic = value; };

    var path;
    proto.get_path = function () { return path; };
    proto.set_path = function (value) { path = value; };

    var strokeColor;
    proto.get_strokeColor = function () { return strokeColor; };
    proto.set_strokeColor = function (value) { strokeColor = value; };

    var strokeOpacity;
    proto.get_strokeOpacity = function () { return strokeOpacity; };
    proto.set_strokeOpacity = function (value) { strokeOpacity = value; };

    var strokeWeight;
    proto.get_strokeWeight = function () { return strokeWeight; };
    proto.set_strokeWeight = function (value) { strokeWeight = value; };

    var zIndex;
    proto.get_zIndex = function () { return zIndex; };
    proto.set_zIndex = function (value) { zIndex = value; };

    // methods

    proto.create = function () {
        map = $find(this.get_element().id);

        var points = Artem.Google.Converter.latlngArray(path);
        var options = {
            clickable: clickable,
            geodesic: geodesic,
            map: map.get_map(),
            path: points,
            strokeColor: strokeColor,
            strokeOpacity: strokeOpacity,
            strokeWeight: strokeWeight,
            zIndex: zIndex
        };

        polyline = new google.maps.Polyline(options);
        this.composeEvents();
    };

    // GoogleMaps API

    proto.getMap = function () {
        ///<summary>Returns the map on which this poly is attached.</summary>
        return polyline.getMap();
    };

    proto.getPath = function () {
        ///<summary>Retrieves the first path.</summary>
        return polyline.getPath();
    };

    proto.setMap = function (map) {
        ///<summary>Renders this Polyline or Polygon on the specified map. If map is set to null, the Poly will be removed.</summary>
        polyline.setMap(map);
    };

    proto.setOptions = function (options) {
        ///<summary>Renders this Polyline or Polygon on the specified map. If map is set to null, the Poly will be removed.</summary>
        polyline.setOptions(options);
    };

    proto.setPath = function (path) {
        ///<summary>Sets the first path. See PolylineOptions for more details.</summary>
        polyline.setPath(path);
    };

} (Artem.Google.PolylineBehavior.prototype));

(function (proto) {

    // fields
    var delegates = {
        "click": null,
        "dblclick": null,
        "mousedown": null,
        "mousemove": null,
        "mouseout": null,
        "mouseover": null,
        "mouseup": null,
        "rightclick": null
    };
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
    var listeners = {
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

        var polyline = this.get_polyline();
        if (polyline) {
            var handler;
            for (var name in handlers) {
                handler = this.get_events().getHandler(name);
                if (handler) {
                    if (!listeners[name]) {
                        if (!delegates[name]) delegates[name] = Function.createDelegate(this, handlers[name]);
                        listeners[name] = google.maps.event.addListener(polyline, name, delegates[name]);
                    }
                }
                else if (listeners[name]) {
                    google.maps.event.removeListener(listeners[name]);
                }
            }
        }
    };

    proto.detachEvents = function () {
        google.maps.event.clearInstanceListeners(this.get_polyline());
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

    // mouse up
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

} (Artem.Google.PolylineBehavior.prototype));

/* 
Static server event handler entry points
*/
Artem.Google.PolylineBehavior.raiseServerClick = function (sender, e) {
    ///<summary>An entry point handler to fire server click event post back.</summary>
};

Artem.Google.PolylineBehavior.raiseServerDoubleClick = function (e) {
    ///<summary>An entry point handler to fire server double click event post back.</summary>
};

Artem.Google.PolylineBehavior.raiseServerMouseDown = function (e) {
    ///<summary>An entry point handler to fire server mouse down event post back.</summary>
};

Artem.Google.PolylineBehavior.raiseServerMouseMove = function (e) {
    ///<summary>An entry point handler to fire server mouse move event post back.</summary>
};

Artem.Google.PolylineBehavior.raiseServerMouseOut = function (e) {
    ///<summary>An entry point handler to fire server mouse out event post back.</summary>
};

Artem.Google.PolylineBehavior.raiseServerMouseOver = function (e) {
    ///<summary>An entry point handler to fire server mouse over event post back.</summary>
};

Artem.Google.PolylineBehavior.raiseServerMouseUp = function (e) {
    ///<summary>An entry point handler to fire server mouse up event post back.</summary>
};

Artem.Google.PolylineBehavior.raiseServerRightClick = function (e) {
    ///<summary>An entry point handler to fire server right click event post back.</summary>
};

Artem.Google.PolylineBehavior.registerClass('Artem.Google.PolylineBehavior', Sys.UI.Behavior);
