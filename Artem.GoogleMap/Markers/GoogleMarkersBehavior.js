///<reference name="MicrosoftAjax.debug.js"/>
///<reference path="..\Map\GoogleMap.js"/>
///<reference path="http://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Artem.Google");

Artem.Google.MarkersBehavior = function (element) {
    Artem.Google.MarkersBehavior.initializeBase(this, [element]);
};

Artem.Google.MarkersBehavior.prototype = {
    initialize: function () {
        Artem.Google.MarkersBehavior.callBaseMethod(this, 'initialize');
        Artem.Worker.queue(Function.createDelegate(this, this._attach));
    },
    dispose: function () {
        this._detach();
        Artem.Google.MarkersBehavior.callBaseMethod(this, 'dispose');
    }
};

// members
(function (proto) {

    // fields

    proto.counter = 0;
    proto.map = null;
    proto.markers = [];

    // properties

    proto.get_groupOptions = function () { return this.groupOptions; };
    proto.set_groupOptions = function (value) { this.groupOptions = value; };

    proto.get_infoOptions = function () { return this.infoOptions; };
    proto.set_infoOptions = function (value) { this.infoOptions = value; };

    proto.get_markerOptions = function () { return this.markerOptions; };
    proto.set_markerOptions = function (value) { this.markerOptions = value; };

    proto.get_name = function () { return this.name; };
    proto.set_name = function (value) { this.name = value; };

    // methods

    proto._attach = function () {
        var control = $find(this.get_element().id);
        if (control)
            control.add_mapLoaded(Function.createDelegate(this, this.create));
    };

    proto._detach = function () {
        if (this.markers) {
            for (var i = 0; i < this.markers.length; i++)
                google.maps.event.clearInstanceListeners(this.markers[i]);
        }
    };

    proto.create = function () {

        if (this.markerOptions) {
            var control;
            var gmarker;
            var ginfo;

            if (!this.map) {
                control = $find(this.get_element().id);
                if (control)
                    this.map = control.map;
            }

            for (var i = 0; i < this.markerOptions.length; i++) {
                var marker = Artem.Google.merge(this.groupOptions, this.markerOptions[i]);
                marker.map = this.map;
                marker.index = i;

                if (marker.position) {
                    marker.position = new google.maps.LatLng(marker.position.lat, marker.position.lng);
                    Function.createDelegate(this, setMarker)(null, marker);
                }
                else if (marker.address) {
                    var delegate = Function.createDelegate(this, Function.createCallback(setMarker, marker));
                    var options = { address: marker.address };
                    if (control) {
                        options.language = control.get_language();
                        options.region = control.get_region();
                    }
                    Artem.Google.Geocoding.getLocation(options, delegate);
                }
            }
        }
    };

    // private methods

    function setMarker(position, marker) {

        if (marker) {
            if (position) marker.position = position;

            gmarker = new google.maps.Marker(marker);
            if (marker.info) {
                ginfo = new google.maps.InfoWindow(Artem.Google.merge({ content: marker.info }, this.infoOptions));
                marker.info = ginfo;
                google.maps.event.addListener(gmarker, 'click',
                        Function.createDelegate(this,
                            Function.createCallback(
                                function (e, ctx) { ctx.i.open(this.map, ctx.m); }, { m: gmarker, i: ginfo })));
            }
            this.markers.push(gmarker);
        }
        this.counter++;
        if (this.counter == this.markerOptions.length) this.composeEvents();
    }

    // TODO GoogleMaps API


})(Artem.Google.MarkersBehavior.prototype);

// events
(function (proto) {

    // fields
    var handlers = {
        "animation_changed": raiseAnimationChanged,
        "click": raiseClick,
        "clickable_changed": raiseClickableChanged,
        "cursor_changed": raiseCursorChanged,
        "dblclick": raiseDoubleClick,
        "drag": raiseDrag,
        "dragend": raiseDragEnd,
        "draggable_changed": raiseDraggableChanged,
        "dragstart": raiseDragStart,
        "flat_changed": raiseFlatChanged,
        "icon_changed": raiseIconChanged,
        "mousedown": raiseMouseDown,
        "mouseout": raiseMouseOut,
        "mouseover": raiseMouseOver,
        "mouseup": raiseMouseUp,
        "position_changed": raisePositionChanged,
        "rightclick": raiseRightClick,
        "shadow_changed": raiseShadowChanged,
        "title_changed": raiseTitleChanged,
        "visible_changed": raiseVisibleChanged,
        "zindex_changed": raiseZIndexChanged
    };
    proto.delegates = {
        "animation_changed": null,
        "click": null,
        "clickable_changed": null,
        "cursor_changed": null,
        "dblclick": null,
        "drag": null,
        "dragend": null,
        "draggable_changed": null,
        "dragstart": null,
        "flat_changed": null,
        "icon_changed": null,
        "mousedown": null,
        "mouseout": null,
        "mouseover": null,
        "mouseup": null,
        "position_changed": null,
        "rightclick": null,
        "shadow_changed": null,
        "title_changed": null,
        "visible_changed": null,
        "zindex_changed": null
    };

    proto.listeners = {
        "animation_changed": [],
        "click": [],
        "clickable_changed": [],
        "cursor_changed": [],
        "dblclick": [],
        "drag": [],
        "dragend": [],
        "draggable_changed": [],
        "dragstart": [],
        "flat_changed": [],
        "icon_changed": [],
        "mousedown": [],
        "mouseout": [],
        "mouseover": [],
        "mouseup": [],
        "position_changed": [],
        "rightclick": [],
        "shadow_changed": [],
        "title_changed": [],
        "visible_changed": [],
        "zindex_changed": []
    };

    // utility

    proto.composeEvents = function () {

        if (this.markers) {
            var handler;
            var listener;

            for (var i = 0; i < this.markers.length; i++) {
                for (var name in handlers) {
                    handler = this.get_events().getHandler(name);
                    listener = this.listeners[name][i];
                    if (handler) {
                        if (!listener) {
                            var delegate = Function.createDelegate(
                                this, Function.createCallback(handlers[name], this.markers[i].index));
                            this.listeners[name][i] = google.maps.event.addListener(this.markers[i], name, delegate);//this.delegates[name]);
                        }
                    }
                    else if (listener) {
                        google.maps.event.removeListener(listener);
                    }
                }
            }
        }
    };

    // animation changed
    proto.add_animationChanged = function (handler) {
        this.get_events().addHandler("animation_changed", handler);
        this.composeEvents();
    };
    proto.remove_animationChanged = function (handler) {
        this.get_events().removeHandler("animation_changed", handler);
        this.composeEvents();
    };
    function raiseAnimationChanged(index) {
        var handler = this.get_events().getHandler("animation_changed");
        if (handler) handler(this, { index: index });
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
    function raiseClick(e, index) {
        var handler = this.get_events().getHandler("click");
        e.index = index;
        if (handler) handler(this, e);
    }

    // clickable changed
    proto.add_clickableChanged = function (handler) {
        this.get_events().addHandler("clickable_changed", handler);
        this.composeEvents();
    };
    proto.remove_clickableChanged = function (handler) {
        this.get_events().removeHandler("clickable_changed", handler);
        this.composeEvents();
    };
    function raiseClickableChanged(index) {
        var handler = this.get_events().getHandler("clickable_changed");
        if (handler) handler(this, { index: index });
    }

    // cursor changed
    proto.add_cursorChanged = function (handler) {
        this.get_events().addHandler("cursor_changed", handler);
        this.composeEvents();
    };
    proto.remove_cursorChanged = function (handler) {
        this.get_events().removeHandler("cursor_changed", handler);
        this.composeEvents();
    };
    function raiseCursorChanged(index) {
        var handler = this.get_events().getHandler("cursor_changed");
        if (handler) handler(this, { index: index });
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
    function raiseDoubleClick(e, index) {
        var handler = this.get_events().getHandler("dblclick");
        e.index = index;
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
    function raiseDrag(e, index) {
        var handler = this.get_events().getHandler("drag");
        e.index = index;
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
    function raiseDragEnd(e, index) {
        var handler = this.get_events().getHandler("dragend");
        e.index = index;
        if (handler) handler(this, e);
    }

    // draggable changed
    proto.add_draggableChanged = function (handler) {
        this.get_events().addHandler("draggable_changed", handler);
        this.composeEvents();
    };
    proto.remove_draggableChanged = function (handler) {
        this.get_events().removeHandler("draggable_changed", handler);
        this.composeEvents();
    };
    function raiseDraggableChanged(index) {
        var handler = this.get_events().getHandler("draggable_changed");
        if (handler) handler(this, { index: index });
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
    function raiseDragStart(e, index) {
        var handler = this.get_events().getHandler("dragstart");
        e.index = index;
        if (handler) handler(this, e);
    }

    // flat changed
    proto.add_flatChanged = function (handler) {
        this.get_events().addHandler("flat_changed", handler);
        this.composeEvents();
    };
    proto.remove_flatChanged = function (handler) {
        this.get_events().removeHandler("flat_changed", handler);
        this.composeEvents();
    };
    function raiseFlatChanged(index) {
        var handler = this.get_events().getHandler("flat_changed");
        if (handler) handler(this, { index: index });
    }

    // icon changed
    proto.add_iconChanged = function (handler) {
        this.get_events().addHandler("icon_changed", handler);
        this.composeEvents();
    };
    proto.remove_iconChanged = function (handler) {
        this.get_events().removeHandler("icon_changed", handler);
        this.composeEvents();
    };
    function raiseIconChanged(index) {
        var handler = this.get_events().getHandler("icon_changed");
        if (handler) handler(this, { index: index });
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
    function raiseMouseDown(e, index) {
        var handler = this.get_events().getHandler("mousedown");
        e.index = index;
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
    function raiseMouseOut(e, index) {
        var handler = this.get_events().getHandler("mouseout");
        e.index = index;
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
    function raiseMouseOver(e, index) {
        var handler = this.get_events().getHandler("mouseover");
        e.index = index;
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
    function raiseMouseUp(e, index) {
        var handler = this.get_events().getHandler("mouseup");
        e.index = index;
        if (handler) handler(this, e);
    }

    // position changed
    proto.add_positionChanged = function (handler) {
        this.get_events().addHandler("position_changed", handler);
        this.composeEvents();
    };
    proto.remove_positionChanged = function (handler) {
        this.get_events().removeHandler("position_changed", handler);
        this.composeEvents();
    };
    function raisePositionChanged(index) {
        var handler = this.get_events().getHandler("position_changed");
        if (handler) handler(this, { index: index });
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
    function raiseRightClick(e, index) {
        var handler = this.get_events().getHandler("rightclick");
        e.index = index;
        if (handler) handler(this, e);
    }

    // shadow changed
    proto.add_shadowChanged = function (handler) {
        this.get_events().addHandler("shadow_changed", handler);
        this.composeEvents();
    };
    proto.remove_shadowChanged = function (handler) {
        this.get_events().removeHandler("shadow_changed", handler);
        this.composeEvents();
    };
    function raiseShadowChanged(index) {
        var handler = this.get_events().getHandler("shadow_changed");
        if (handler) handler(this, { index: index });
    }

    // shape changed
    proto.add_shapeChanged = function (handler) {
        this.get_events().addHandler("shape_changed", handler);
        this.composeEvents();
    };
    proto.remove_shapeChanged = function (handler) {
        this.get_events().removeHandler("shape_changed", handler);
        this.composeEvents();
    };
    function raiseShapeChanged(index) {
        var handler = this.get_events().getHandler("shape_changed");
        if (handler) handler(this, { index: index });
    }

    // title changed
    proto.add_titleChanged = function (handler) {
        this.get_events().addHandler("title_changed", handler);
        this.composeEvents();
    };
    proto.remove_titleChanged = function (handler) {
        this.get_events().removeHandler("title_changed", handler);
        this.composeEvents();
    };
    function raiseTitleChanged(index) {
        var handler = this.get_events().getHandler("title_changed");
        if (handler) handler(this, { index: index });
    }

    // visible changed
    proto.add_visibleChanged = function (handler) {
        this.get_events().addHandler("visible_changed", handler);
        this.composeEvents();
    };
    proto.remove_visibleChanged = function (handler) {
        this.get_events().removeHandler("visible_changed", handler);
        this.composeEvents();
    };
    function raiseVisibleChanged(index) {
        var handler = this.get_events().getHandler("visible_changed");
        if (handler) handler(this, { index: index });
    }

    // zindex changed
    proto.add_zindexChanged = function (handler) {
        this.get_events().addHandler("zindex_changed", handler);
        this.composeEvents();
    };
    proto.remove_zindexChanged = function (handler) {
        this.get_events().removeHandler("zindex_changed", handler);
        this.composeEvents();
    };
    function raiseZIndexChanged(index) {
        var handler = this.get_events().getHandler("zindex_changed");
        if (handler) handler(this, { index: index });
    }

})(Artem.Google.MarkersBehavior.prototype);

// server events - entry points
(function (behavior) {

    function raiseServerEvent(name, sender, e) {

        var position = e.latLng || sender.markers[e.index].getPosition();
        var target = sender.name;
        var args = {
            index: e.index,
            name: name,
            position: { lat: position.lat(), lng: position.lng() }
        };
        __doPostBack(target, Sys.Serialization.JavaScriptSerializer.serialize(args));
    }

    behavior.raiseServerAnimationChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server animation changed event post back.</summary>
        raiseServerEvent("animationChanged", sender, e);
    };

    behavior.raiseServerClick = function (sender, e) {
        ///<summary>An entry point handler to fire server click event post back.</summary>
        raiseServerEvent("click", sender, e);
    };

    behavior.raiseServerClickableChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server clickable changed event post back.</summary>
        raiseServerEvent("clickableChanged", sender, e);
    };

    behavior.raiseServerCursorChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server cursor changed event post back.</summary>
        raiseServerEvent("cursorChanged", sender, e);
    };

    behavior.raiseServerDoubleClick = function (sender, e) {
        ///<summary>An entry point handler to fire server double click event post back.</summary>
        raiseServerEvent("doubleClick", sender, e);
    };

    behavior.raiseServerDrag = function (sender, e) {
        ///<summary>An entry point handler to fire server drag event post back.</summary>
        raiseServerEvent("drag", sender, e);
    };

    behavior.raiseServerDragEnd = function (sender, e) {
        ///<summary>An entry point handler to fire server drag end event post back.</summary>
        raiseServerEvent("dragEnd", sender, e);
    };

    behavior.raiseServerDragStart = function (sender, e) {
        ///<summary>An entry point handler to fire server drag start event post back.</summary>
        raiseServerEvent("dragStart", sender, e);
    };

    behavior.raiseServerFlatChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server flat changed event post back.</summary>
        raiseServerEvent("flatChanged", sender, e);
    };

    behavior.raiseServerIconChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server icon changed event post back.</summary>
        raiseServerEvent("iconChanged", sender, e);
    };

    behavior.raiseServerMouseDown = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse down event post back.</summary>
        raiseServerEvent("mouseDown", sender, e);
    };

    behavior.raiseServerMouseOut = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse out event post back.</summary>
        raiseServerEvent("mouseOut", sender, e);
    };

    behavior.raiseServerMouseOver = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse over event post back.</summary>
        raiseServerEvent("mouseOver", sender, e);
    };

    behavior.raiseServerMouseUp = function (sender, e) {
        ///<summary>An entry point handler to fire server mouse up event post back.</summary>
        raiseServerEvent("mouseUp", sender, e);
    };

    behavior.raiseServerPositionChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server position changed event post back.</summary>
        raiseServerEvent("positionChanged", sender, e);
    };

    behavior.raiseServerRightClick = function (sender, e) {
        ///<summary>An entry point handler to fire server right click event post back.</summary>
        raiseServerEvent("rightClick", sender, e);
    };

    behavior.raiseServerShadowChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server shadow changed event post back.</summary>
        raiseServerEvent("shadowChanged", sender, e);
    };

    behavior.raiseServerShapeChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server shadow changed event post back.</summary>
        raiseServerEvent("shapeChanged", sender, e);
    };

    behavior.raiseServerTitleChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server title changed event post back.</summary>
        raiseServerEvent("titleChanged", sender, e);
    };

    behavior.raiseServerVisibleChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server visible changed event post back.</summary>
        raiseServerEvent("visibleChanged", sender, e);
    };

    behavior.raiseServerZIndexChanged = function (sender, e) {
        ///<summary>An entry point handler to fire server zindex changed event post back.</summary>
        raiseServerEvent("zindexChanged", sender, e);
    };

})(Artem.Google.MarkersBehavior);

Artem.Google.MarkersBehavior.registerClass('Artem.Google.MarkersBehavior', Sys.UI.Behavior);