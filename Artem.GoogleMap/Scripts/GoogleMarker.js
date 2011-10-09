///<reference name="MicrosoftAjax.debug.js"/>

Type.registerNamespace("Artem.Google");

//#> Marker class

Artem.Google.Marker = function Artem_Google_Marker(map, index, state) {
    ///<param name="map" type="Artem.Google.Map"></param>
    ///<param name="state" type="Artem.Google.Marker"></param>

    this.Index = index;

    this.Address = state.Address;
    this.AutoOpenInfo = state.AutoOpenInfo;
    this.Clickable = state.Clickable;
    this.Cursor = state.Cursor;
    this.Draggable = state.Draggable;
    this.Flat = state.Flat;
    this.HasInfoContent = state.HasInfoContent;
    this.Icon = state.Icon;
    this.InfoWindowOptions = state.InfoWindowOptions;
    this.OpenInfoBehaviour = state.OpenInfoBehaviour;
    this.Position = state.Position;
    this.Shadow = state.Shadow;
    this.Shape = state.Shape;
    this.Text = state.Text;
    this.Title = state.Title;
    this.Visible = state.Visible;
    this.ZIndex = state.ZIndex;
    //    this.AutoPan = state.AutoPan
    //    this.Bouncy = state.Bouncy;
    //    this.DragCrossMove = state.DragCrossMove;
    //    this.InfoWindowAnchor = state.InfoWindowAnchor;
    //    this.MaxZoom = state.MaxZoom;
    //    this.MinZoom = state.MinZoom;

    this.get_map = function () { return map; };
    this.initialize();
}
Artem.Google.Marker.prototype = {

    //#region Fields ------------------------------------------------------------------------------

    Address: null,
    AutoOpenInfo: false,
    Clickable: true,
    Cursor: null,
    Draggable: false,
    Flat: false,
    HasInfoContent: false,
    Icon: null,
    Index: null,
    InfoWindowOptions: null,
    OpenInfoBehaviour: null,
    Position: null,
    Shadow: null,
    Shape: null,
    Text: null,
    Title: null,
    Visible: true,
    ZIndex: null,

    //    AutoPan: null,
    //    Bouncy: null,
    //    DragCrossMove: null,
    //    InfoWindowAnchor: null,
    //    MaxZoom: null,
    //    MinZoom: null,

    //#endregion

    //#region Properties --------------------------------------------------------------------------

    get_map: null,
    get_marker: null,
    get_infoWindow: null,

    //#endregion

    //#region Methods -----------------------------------------------------------------------------

    initialize: function Artem_Google_Marker$initialize() {

        if (this.Position) {
            this._create(new google.maps.LatLng(this.Position.Latitude, this.Position.Longitude));
        }
        else {
            var self = this;
            this.get_map().geocodeAddress(this.Address, function (location) { self._create(location); });
        }
    },

    dispose: function Artem_Google_Marker$dispose() {

        // first remove event listeners
        var marker = this.get_marker();
        if (marker)
            google.maps.event.clearInstanceListeners(marker);

        delete this.get_marker;
        delete this.get_map;

        delete this.Address;
        delete this.AutoOpenInfo;
        delete this.Clickable;
        delete this.Cursor;
        delete this.Draggable;
        delete this.Flat;
        delete this.Icon;
        delete this.InfoWindowOptions;
        delete this.OpenInfoBehaviour;
        delete this.Position;
        delete this.Shadow;
        delete this.Shape;
        delete this.Text;
        delete this.Title;
        delete this.Visible;
        delete this.ZIndex;
    },

    save: function Artem_Google_Marker$save() {
        // TODO
        //        this.Text = null;
    },
    //#endregion

    //#region Google Maps API Wrapped -------------------------------------------------------------

    getClickable: function () {
        return this.get_marker().getClickable();
    },
    getCursor: function () {
        return this.get_marker().getClickable();
    },
    getDraggable: function () {
        return this.get_marker().getDraggable();
    },
    getFlat: function () {
        return this.get_marker().getFlat();
    },
    getIcon: function () {
        return this.get_marker().getIcon();
    },
    getMap: function () {
        return this.get_marker().getMap();
    },
    getPosition: function () {
        return this.get_marker().getPosition();
    },
    getShadow: function () {
        return this.get_marker().getShadow();
    },
    getShape: function () {
        return this.get_marker().getShape();
    },
    getTitle: function () {
        return this.get_marker().getTitle();
    },
    getVisible: function () {
        return this.get_marker().getVisible();
    },
    getZIndex: function () {
        return this.get_marker().getZIndex();
    },

    setClickable: function (flag) {
        this.get_marker().setClickable(flag);
    },
    setCursor: function (cursor) {
        this.get_marker().setCursor(cursor);
    },
    setDraggable: function (flag) {
        this.get_marker().setDraggable(flag);
    },
    setFlat: function (flag) {
        this.get_marker().setFlat(flag);
    },
    setIcon: function (icon) {
        this.get_marker().setIcon(icon);
    },
    setMap: function (map) {
        this.get_marker().setMap(map);
    },
    setOptions: function (options) {
        this.get_marker().setOptions(options);
    },
    setPosition: function (latlng) {
        this.get_marker().setPosition(latlng);
    },
    setShadow: function (shadow) {
        this.get_marker().setShadow(shadow);
    },
    setShape: function (shape) {
        this.get_marker().setShape(shape);
    },
    setTitle: function (title) {
        this.get_marker().setTitle(title);
    },
    setVisible: function (visible) {
        this.get_marker().setVisible(visible);
    },
    setZIndex: function (zIndex) {
        this.get_marker().setZIndex(zIndex);
    },
    //#endregion

    //#> Private Methods

    _create: function Artem_Google_Marker$_create(position) {

        var marker;
        var infoWindow;

        if (position) {
            var options = {
                clickable: this.Clickable,
                cursor: this.Cursor,
                draggable: this.Draggable,
                flat: this.Flat,
                icon: this._toImage(this.Icon),
                map: this.get_map().get_map(),
                position: position,
                shadow: this._toImage(this.Shadow),
                shape: this._toShape(this.Shape),
                title: this.Title,
                visible: this.Visible,
                zIndex: this.ZIndex
            };
            var self = this;

            marker = new google.maps.Marker(options);
        }
        this.get_marker = function () { return marker; };

        infoWindow = this._createInfo();
        this.get_infoWindow = function () { return infoWindow; };
    },

    _createInfo: function Artem_Google_Marker$_createInfo() {

        var infoContent;
        var infoWindow;
        var marker = this.get_marker();

        if (marker) {
            var self = this;
            var options = {
                content: null
            };

            if (this.HasInfoContent) {
                options.content = $get(this.get_map().get_id() + "_MarkerInfo" + this.Index);
            }
            else if (this.Text) {
                options.content = this.Text;
            }
            if (this.InfoWindowOptions) {
                options.disableAutoPan = this.InfoWindowOptions.DisableAutoPan;
                if (this.InfoWindowOptions.MaxWidth)
                    options.maxWidth = this.InfoWindowOptions.MaxWidth;
                if (this.InfoWindowOptions.PixelOffset)
                    options.pixelOffset = this.InfoWindowOptions.PixelOffset;
                if (this.InfoWindowOptions.ZIndex)
                    options.zIndex = this.InfoWindowOptions.ZIndex;
            }

            infoWindow = new google.maps.InfoWindow(options);

            var eventName = this._getEventName(this.OpenInfoBehaviour);
            google.maps.event.addListener(marker, eventName, function () {
                infoWindow.open(self.get_map().get_map(), marker);
            });

            if (this.AutoOpenInfo)
                infoWindow.open(this.get_map().get_map(), marker);
        }
        return infoWindow;
    },

    _getEventName: function Artem_Google_Marker$_getEventName(openBehavior) {
        switch (openBehavior) {
            case 1:
                return "click";
            case 2:
                return "dblclick";
            case 3:
                return "mousedown";
            case 4:
                return "mouseout";
            case 5:
                return "mouseover";
            case 6:
                return "mouseup";
        }
    },

    _toImage: function Artem_Google_Marker$_toImage(state) {

        if (state) {
            var anchor;
            var origin;
            var scaledSize;
            var size;

            if (state.Anchor)
                anchor = new google.maps.Point(state.Anchor.X, state.Anchor.Y);
            if (state.Origin)
                origin = new google.maps.Point(state.Origin.X, state.Origin.Y);
            if (scaledSize)
                scaledSize = new google.maps.Size(state.ScaledSize.Width, state.ScaledSize.Height);
            if (size)
                size = new google.maps.Size(state.Size.Width, state.Size.Height);

            return new google.maps.MarkerImage(state.Url, size, origin, anchor, scaledSize);
        }
        else
            return null;
    },

    _toShape: function Artem_Google_Marker$_toShape(state) {

        if (state) {
            var type;

            switch (state.Type) {
                case 1:
                    type = "circle";
                    break;
                case 2:
                    type = "poly";
                    break;
                case 3:
                    type = "rect";
                    break;
            }

            return { coord: state.Coords, type: type };
        }
        else
            return null;
    }
    //#<
}
//#<

Artem.Google.Marker.registerClass("Artem.Google.Marker", null, Sys.IDisposable);