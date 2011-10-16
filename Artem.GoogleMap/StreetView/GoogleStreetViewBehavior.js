Type.registerNamespace("Artem.Google");

Artem.Google.StreetViewBehavior = function (element) {
    Artem.Google.StreetViewBehavior.initializeBase(this, [element]);
}

Artem.Google.StreetViewBehavior.prototype = {
    initialize: function () {
        Artem.Google.StreetViewBehavior.callBaseMethod(this, 'initialize');
        alert("Artem.Google.StreetViewBehavior");
    },
    dispose: function () {
        Artem.Google.StreetViewBehavior.callBaseMethod(this, 'dispose');
    }
}

Artem.Google.StreetViewBehavior.registerClass('Artem.Google.StreetViewBehavior', Sys.UI.Behavior);
