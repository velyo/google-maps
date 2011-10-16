using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

[assembly: WebResource("Artem.Google.Markers.GoogleMarkersBehavior.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Markers.GoogleMarkersBehavior.min.js", "text/javascript")]

namespace Artem.Google.UI {

    //[ParseChildren(true, "Paths")]
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GoogleMarkers runat=server></{0}:GoogleMarkers>")]
    public class GoogleMarkers : ExtenderControl, IPostBackEventHandler {

        #region Methods

        /// <summary>
        /// When overridden in a derived class, registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control to which the extender is associated.</param>
        /// <returns>
        /// An enumeration of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl) {

            var descriptor = new ScriptBehaviorDescriptor("Artem.Google.MarkersBehavior", targetControl.ClientID);
            yield return descriptor;
        }

        /// <summary>
        /// When overridden in a derived class, registers the script libraries for the control.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="T:System.Collections.IEnumerable"/> interface and that contains ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences() {

            string assembly = this.GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Artem.Google.Markers.GoogleMarkersBehavior.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Markers.GoogleMarkersBehavior.min.js", assembly);
#endif
        }
            
        public void RaisePostBackEvent(string eventArgument) {
            throw new NotImplementedException();
        }
        #endregion
    }
}
