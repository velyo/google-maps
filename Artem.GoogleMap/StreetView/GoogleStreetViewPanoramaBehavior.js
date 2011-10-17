Type.registerNamespace("Artem.Google");

Artem.Google.StreetViewPanoramaBehavior = function (element) {
    Artem.Google.StreetViewPanoramaBehavior.initializeBase(this, [element]);
}

Artem.Google.StreetViewPanoramaBehavior.prototype = {
    initialize: function () {
        Artem.Google.StreetViewPanoramaBehavior.callBaseMethod(this, 'initialize');
        alert("Artem.Google.StreetViewPanoramaBehavior");
    },
    dispose: function () {
        Artem.Google.StreetViewPanoramaBehavior.callBaseMethod(this, 'dispose');
    }
}

Artem.Google.StreetViewPanoramaBehavior.registerClass('Artem.Google.StreetViewPanoramaBehavior', Sys.UI.Behavior);
