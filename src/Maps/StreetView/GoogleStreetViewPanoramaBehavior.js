///<reference name="MicrosoftAjax.debug.js"/>
///<reference path=".\GoogleMap.js"/>
///<reference path="https://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Velyo.Google.Maps");

Velyo.Google.Maps.StreetViewPanoramaBehavior = function (element) {
    Velyo.Google.Maps.StreetViewPanoramaBehavior.initializeBase(this, [element]);
}

Velyo.Google.Maps.StreetViewPanoramaBehavior.prototype = {
    initialize: function () {
        Velyo.Google.Maps.StreetViewPanoramaBehavior.callBaseMethod(this, 'initialize');
        alert("Velyo.Google.Maps.StreetViewPanoramaBehavior");
    },
    dispose: function () {
        Velyo.Google.Maps.StreetViewPanoramaBehavior.callBaseMethod(this, 'dispose');
    }
}

Velyo.Google.Maps.StreetViewPanoramaBehavior.registerClass('Velyo.Google.Maps.StreetViewPanoramaBehavior', Sys.UI.Behavior);
