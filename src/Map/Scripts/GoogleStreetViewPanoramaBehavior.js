Type.registerNamespace("Velyo.Google");

Velyo.Google.StreetViewPanoramaBehavior = function (element) {
    Velyo.Google.StreetViewPanoramaBehavior.initializeBase(this, [element]);
}

Velyo.Google.StreetViewPanoramaBehavior.prototype = {
    initialize: function () {
        Velyo.Google.StreetViewPanoramaBehavior.callBaseMethod(this, 'initialize');
        alert("Velyo.Google.StreetViewPanoramaBehavior");
    },
    dispose: function () {
        Velyo.Google.StreetViewPanoramaBehavior.callBaseMethod(this, 'dispose');
    }
}

Velyo.Google.StreetViewPanoramaBehavior.registerClass('Velyo.Google.StreetViewPanoramaBehavior', Sys.UI.Behavior);
