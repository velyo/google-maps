Type.registerNamespace("Artem.Google");

Artem.Google.PolygonBehavior = function (element) {
    Artem.Google.PolygonBehavior.initializeBase(this, [element]);
};

Artem.Google.PolygonBehavior.prototype = {
    initialize: function () {
        Artem.Google.PolygonBehavior.callBaseMethod(this, 'initialize');
        this.test();
    },
    dispose: function () {
        Artem.Google.PolygonBehavior.callBaseMethod(this, 'dispose');
    }
};

(function (proto, undefined) {

    proto.test = function(){
        alert("Test!");
    };

})(Artem.Google.PolygonBehavior.prototype);

Artem.Google.PolygonBehavior.registerClass('Artem.Google.PolygonBehavior', Sys.UI.Behavior);
