Type.registerNamespace("Artem.Google");

Artem.Google.MarkersBehavior = function (element) {
    Artem.Google.MarkersBehavior.initializeBase(this, [element]);
};

Artem.Google.MarkersBehavior.prototype = {
    initialize: function () {
        Artem.Google.MarkersBehavior.callBaseMethod(this, 'initialize');
        //        alert("MarkersBehavior");
    },
    dispose: function () {
        Artem.Google.MarkersBehavior.callBaseMethod(this, 'dispose');
    }
};

// members
(function (proto) {

    // Google properties

    // properties

    // methods

    proto.create = function(){
    };

    // GoogleMaps API

//    proto.

})(Artem.Google.MarkersBehavior.prototype);

// events
(function (proto) {

}) (Artem.Google.MarkersBehavior.prototype);

// server events - entry points
(function (behavior) {

}) (Artem.Google.MarkersBehavior);

Artem.Google.MarkersBehavior.registerClass('Artem.Google.MarkersBehavior', Sys.UI.Behavior);