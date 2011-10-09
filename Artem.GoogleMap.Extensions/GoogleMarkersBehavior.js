/// <reference name="MicrosoftAjax.js"/>

Type.registerNamespace("Artem.Google");

// GoogleMarkersBehavior class ////////////////////////////////////////////////////////////////////

// constructor
Artem.Google.GoogleMarkersBehavior = function Artem_Google_GoogleMarkersBehavior(element) {
    Artem.Google.GoogleMarkersBehavior.initializeBase(this, [element]);
}

// instance members
Artem.Google.GoogleMarkersBehavior.prototype = {

    // Base ---------------------------------------------------------------------------------------

    initialize: function Artem_Google_GoogleMarkersBehavior$initialize() {
        Artem.Google.GoogleMarkersBehavior.callBaseMethod(this, 'initialize');
    },
    
    dispose: function Artem_Google_GoogleMarkersBehavior$dispose() {
        //Add custom dispose actions here
        Artem.Google.GoogleMarkersBehavior.callBaseMethod(this, 'dispose');
    }
}

// Register ///////////////////////////////////////////////////////////////////////////////////////

Artem.Google.GoogleMarkersBehavior.registerClass('Artem.Google.GoogleMarkersBehavior', Sys.UI.Behavior);
