///<reference name="MicrosoftAjax.debug.js"/>
//#> Info
// GoogleMap Control v5.0 Commons javascipt library (debug).
// This file contains the common javascript object for GoogleMap Control client code.
//
// Assembly:    Artem.GooleMap
// Version:     5.0.0.0
// Project:     http://googlemap.codeplex.com
// Demo:        http://googlemap.artembg.com
// Author:      Velio Ivanov - velio@artembg.com
//              http://artembg.com
// License:     Microsoft Permissive License (Ms-PL) v1.1
//              http://www.codeplex.com/googlemap/license
// API:         http://code.google.com/apis/maps/
// Outlining:   VisualStudio 2010 JavaScript Outlining
//              http://jsoutlining.codeplex.com/
//#<

Type.registerNamespace("Artem.Google");


//#> Bounds class 

Artem.Google.Bounds = function Artem_Google_Bounds(gbounds) {
    if (gbounds) {
        this.NorthEast = new Artem.Google.Location(gbounds.getNorthEast());
        this.SouthWest = new Artem.Google.Location(gbounds.getSouthWest());
    }
}
Artem.Google.Bounds.prototype = {
    NorthEast: null,
    SouthWest: null
}
Artem.Google.Bounds.registerClass("Artem.Google.Bounds");
//#<


//#> Distance class 

Artem.Google.Distance = function Artem_Google_Distance(gdistance) {
    if (gdistance) {
        this.Html = gdistance.html;
        this.Meters = gdistance.meters;
    }
}
Artem.Google.Distance.prototype = {
    Html: null,
    Meters: null
}
Artem.Google.Distance.registerClass("Artem.Google.Distance");
//#<


//#> Duration class 

Artem.Google.Duration = function Artem_Google_Duration(gduration) {
    if (gduration) {
        this.Html = gduration.html;
        this.Seconds = gduration.seconds;
    }
}
Artem.Google.Duration.prototype = {
    Html: null,
    Seconds: null
}
Artem.Google.Duration.registerClass("Artem.Google.Duration");
//#<


//#> Location class 

Artem.Google.Location = function Artem_Google_Location(gpoint) {
    if (gpoint) {
        this.Latitude = gpoint.lat();
        this.Longitude = gpoint.lng();
    }
}
Artem.Google.Location.prototype = {
    Latitude: null,
    Longitude: null
}
Artem.Google.Location.registerClass("Artem.Google.Location");
//#<


//#> Point class

Artem.Google.Point = function (gpoint) {
    if (gpoint) {
        this.X = gpoint.x;
        this.Y = gpoint.y;
    }
}
Artem.Google.Point.prototype = {
    X: null,
    Y: null
}
Artem.Google.Point.registerClass("Artem.Google.Point");
//#<


//#> Size class

Artem.Google.Size = function (gsize) {
    if (gsize) {
        this.Height = gsize.height;
        this.Width = gsize.width;
    }
}
Artem.Google.Size.prototype = {
    Height: null,
    Width: null
}
Artem.Google.Size.registerClass("Artem.Google.Size");
//#<

//#> Converter

Artem.Google.Converter = {

    controlPosition: function (value) {
        switch (value) {
            case 0:
                return google.maps.ControlPosition.TOP_LEFT;
            case 1:
                return google.maps.ControlPosition.TOP;
            case 2:
                return google.maps.ControlPosition.TOP_RIGHT;
            case 3:
                return google.maps.ControlPosition.RIGHT;
            case 4:
                return google.maps.ControlPosition.BOTTOM_RIGHT;
            case 5:
                return google.maps.ControlPosition.BOTTOM;
            case 6:
                return google.maps.ControlPosition.BOTTOM_LEFT;
            case 7:
                return google.maps.ControlPosition.LEFT;
        }
    },

    latlngArray: function (points) {

        var result = null;

        if (points) {
            result = [];
            for (var i = 0; i < points.length; i++) {
                result.push(new google.maps.LatLng(points[i].lat, points[i].lng));
            }
        }

        return result;
    },

    mapTypeControlOptions: function (value) {
        return {
            mapTypeIds: value.MapTypes,
            position: Artem.Google.Converter.controlPosition(value.Position),
            style: Artem.Google.Converter.mapTypeControlStyle(value.ViewStyle)
        };
    },

    mapTypeControlStyle: function (value) {
        switch (value) {
            case 1:
                return google.maps.MapTypeControlStyle.DROPDOWN_MENU;
            case 2:
                return google.maps.MapTypeControlStyle.HORIZONTAL_BAR;
            default:
                return google.maps.MapTypeControlStyle.DEFAULT;
        }
    },

    mapTypeId: function (value) {
        switch (value) {
            case 1:
                return google.maps.MapTypeId.SATELLITE;
            case 2:
                return google.maps.MapTypeId.HYBRID;
            case 3:
                return google.maps.MapTypeId.TERRAIN;
            default:
                return google.maps.MapTypeId.ROADMAP;
        }
    },

    navigationControlOptions: function (value) {
        return {
            position: Artem.Google.Converter.controlPosition(value.Position),
            style: Artem.Google.Converter.navigationControlStyle(value.ViewStyle)
        };
    },

    navigationControlStyle: function (value) {
        switch (value) {
            case 1:
                return google.maps.NavigationControlStyle.ZOOM_PAN;
            case 2:
                return google.maps.NavigationControlStyle.SMALL;
            case 3:
                return google.maps.NavigationControlStyle.ANDROID;
            default:
                return google.maps.NavigationControlStyle.DEFAULT;
        }
    },

    streetView: function (value, position) {
        var options = {
            addressControl: value.EnableAddressControl,
            enableCloseButton: value.EnableCloseButton,
            linksControl: value.EnableLinksControl,
            navigationControl: value.EnableNavigationControl,
            pano: value.Pano,
            visible: value.Visble
        };
        var node = document.getElementById(value.Pano || "panorama");

        if (value.AddressControlOptions)
            options.addressControlOptions = Artem.Google.Converter.streetViewAddressControlOptions(value.AddressControlOptions);
        if (value.NavigationControlOptions)
            option.navigationControlOptions = Artem.Google.Converter.navigationControlOptions(value.NavigationControlOptions);
        if (value.Pov)
            options.pov = { heading: value.Pov.Heading, pitch: value.Pov.Pitch, zoom: value.Pov.Zoom };

        options.position = (value.Position)
            ? new google.maps.LatLng(value.Position.Latitude, value.Position.Longitude)
            : position;

        return new google.maps.StreetViewPanorama(node, options);
    },

    streetViewAddressControlOptions: function (value) {
        return {
            position: Artem.Google.Converter.controlPosition(value.Position),
            style: value.ViewStyle
        };
    }
}
//#<

//#> State class

Artem.Google.State = function Artem_Google_State(gmap) {
    ///<param name="gmap" type="Artem.Google.Map"></param>
    if (gmap) {
        this.Address = gmap.Address;
        this.Center = gmap.Center;
        this.Language = gmap.Language;
        this.Region = gmap.Region;
        this.Zoom = gmap.Zoom;

        this.Bounds = gmap.Bounds;
        this.DefaultAddress = gmap.DefaultAddress;
        this.DisableClear = gmap.DisableClear;
        this.DisableDefaultUI = gmap.DisableDefaultUI;
        this.DisableDoubleClickZoom = gmap.DisableDoubleClickZoom;
        this.DisableKeyboardShortcuts = gmap.DisableKeyboardShortcuts;
        this.Draggable = gmap.Draggable;
        this.DraggableCursor = gmap.DraggableCursor;
        this.DraggingCursor = gmap.DraggingCursor;
        this.EnableReverseGeocoding = gmap.EnableReverseGeocoding;
        this.EnableScrollWheelZoom = gmap.EnableScrollWheelZoom;
        this.MapType = gmap.MapType;
        this.MapTypeControlOptions = gmap.MapTypeControlOptions;
        this.NavigationControlOptions = gmap.NavigationControlOptions;
        this.ScaleControlOptions = gmap.ScaleControlOptions;
        this.ShowMapTypeControl = gmap.ShowMapTypeControl;
        this.ShowNavigationControl = gmap.ShowNavigationControl;
        this.ShowScaleControl = gmap.ShowScaleControl;
        this.ShowStreetViewControl = gmap.ShowStreetViewControl;
        this.StreetView = gmap.StreetView;

        this.Polygons = gmap.Polygons;







        this.Directions = gmap.Directions;
        this.EnableContinuousZoom = gmap.EnableContinuousZoom;
        this.EnableDoubleClickZoom = gmap.EnableDoubleClickZoom;
        this.EnableMarkerManager = gmap.EnableMarkerManager;
        this.Height = gmap.Height;
        this.IsStatic = gmap.IsStatic;
        this.Markers = gmap.Markers;
        this.Polylines = gmap.Polylines;
        this.ShowTraffic = gmap.ShowTraffic;
        this.Width = gmap.Width;
    }
}
Artem.Google.State.prototype = {
    Address: null,
    Center: null,
    EnableReverseGeocoding: null,
    Language: null,
    Region: null,
    Zoom: null,

    Bounds: null,
    DefaultAddress: null,
    DisableDefaultUI: false,
    DisableDoubleClickZoom: false,
    DisableKeyboardShortcuts: false,
    Draggable: true,
    DraggableCursor: null,
    DraggingCursor: null,
    EnableReverseGeocoding: false,
    EnableScrollWheelZoom: true,
    MapType: null,
    MapTypeControlOptions: null,
    NavigationControlOptions: null,
    ScaleControlOptions: null,
    ShowMapTypeControl: true,
    ShowNavigationControl: true,
    ShowScaleControl: true,
    ShowStreetViewControl: true,
    StreetView: null,

    Polygons: null,





    Directions: null,
    EnableContinuousZoom: null,
    EnableMarkerManager: null,
    Height: null,
    IsStatic: null,
    Markers: null,
    Polylines: null,
    ShowTraffic: null,
    Width: null
}
Artem.Google.State.registerClass("Artem.Google.State");
//#<


//#region Utils ///////////////////////////////////////////////////////////////////////////////////

//#region _Manager class 

Artem.Google._Manager = function Artem_Google__Manager() {
    if (arguments.length !== 0) throw Error.parameterCount();
    if (Sys.Application) Sys.Application.registerDisposableObject(this);
}

Artem.Google._Manager.prototype = {

    dispose: function Artem_Google__Manager$dispose() {
        //        GUnload();
    }
}

Artem.Google._Manager.registerClass("Artem.Google._Manager", null, Sys.IDisposable);

var GoogleManager = new Artem.Google._Manager();
//#endregion

Artem.Google.serverHandler = function Artem_Google$serverHandler() { };

//#endregion

(function (log) {

    // methods

    log.dir = function (obj) {
        if (console && console.dir) console.dir(obj);
    };

    log.error = function (message) {
        if (console && console.error)
            console.error(message);
        else
            throw (message);
    };

    log.info = function (message) {
        if (console && console.info) console.info(message);
    };

    log.warn = function (message) {
        if (console && console.warn) console.warn(message);
    };

} (Artem.Google.Log = Artem.Google.Log || {}));