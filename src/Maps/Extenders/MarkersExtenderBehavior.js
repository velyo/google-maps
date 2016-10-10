/// <reference name="MicrosoftAjax.js"/>
///<reference path="..\Map\GoogleMap.js"/>
///<reference path="https://maps.googleapis.com/maps/api/js?sensor=false"/>

Type.registerNamespace("Velyo.Google.Maps");

// constructor
Velyo.Google.Maps.MarkersExtenderBehavior = function Artem_Google_MarkersExtenderBehavior(element) {
    Velyo.Google.Maps.MarkersExtenderBehavior.initializeBase(this, [element]);
}

// instance members
Velyo.Google.Maps.MarkersExtenderBehavior.prototype = {

    // Base ---------------------------------------------------------------------------------------

    initialize: function Artem_Google_MarkersExtenderBehavior$initialize() {
        Velyo.Google.Maps.MarkersExtenderBehavior.callBaseMethod(this, 'initialize');
    },
    
    dispose: function Artem_Google_MarkersExtenderBehavior$dispose() {
        //Add custom dispose actions here
        Velyo.Google.Maps.MarkersExtenderBehavior.callBaseMethod(this, 'dispose');
    }
}

// Register ///////////////////////////////////////////////////////////////////////////////////////

Velyo.Google.Maps.MarkersExtenderBehavior.registerClass('Velyo.Google.Maps.MarkersExtenderBehavior', Sys.UI.Behavior);
