﻿using System;
using System.Collections.Generic;
using System.Web.UI;

[assembly: WebResource("Velyo.Google.Maps.StreetView.GoogleStreetViewPanoramaBehavior.js", "text/javascript")]
[assembly: WebResource("Velyo.Google.Maps.StreetView.GoogleStreetViewPanoramaBehavior.min.js", "text/javascript")]

namespace Velyo.Google.Maps
{
    /// <summary>
    /// Extender control which targets GoogleMap controls and displays the panorama for a given LatLng or panorama ID. 
    /// A StreetViewPanorama object provides a Street View "viewer" which can be stand-alone within a separate &lt;div&gt; or bound to a Map.
    /// </summary>
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GoogleStreetView runat=server></{0}:GoogleStreetView>")]
    public class GoogleStreetViewPanorama : ExtenderControl, IPostBackEventHandler
    {
        /// <summary>
        /// When overridden in a derived class, registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control to which the extender is associated.</param>
        /// <returns>
        /// An enumeration of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
        {
            yield return new ScriptBehaviorDescriptor("Velyo.Google.Maps.StreetViewPanoramaBehavior", targetControl.ClientID);
        }

        /// <summary>
        /// When overridden in a derived class, registers the script libraries for the control.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="T:System.Collections.IEnumerable"/> interface and that contains ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {

            string assembly = this.GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Velyo.Google.Maps.StreetView.GoogleStreetViewPanoramaBehavior.js", assembly);
#else
            yield return new ScriptReference("Velyo.Google.Maps.StreetView.GoogleStreetViewPanoramaBehavior.min.js", assembly);
#endif
        }

        /// <summary>
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            throw new NotImplementedException();
        }
    }
}
