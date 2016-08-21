using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

#region Resources
[assembly: WebResource("Artem.Google.UI.GoogleMarkersBehavior.js", "text/javascript")]
#endregion
namespace Velyo.Google.Map.UI
{
    /// <summary>
    /// Summary description for GoogleMarkersExtender
    /// </summary>
    [TargetControlType(typeof(GoogleMap))]
    public class GoogleMarkersExtender : ExtenderControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMarkersExtender"/> class.
        /// </summary>
        public GoogleMarkersExtender() { }


        [DefaultValue("")]
        public string ServiceMethod { get; set; }

        [UrlProperty]
        public string ServicePath { get; set; }


        /// <summary>
        /// When overridden in a derived class, registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control to which the extender is associated.</param>
        /// <returns>
        /// An enumeration of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(System.Web.UI.Control targetControl)
        {
            ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor("Artem.Google.GoogleMarkersBehavior", targetControl.ClientID);
            yield return descriptor;
        }

        // Generate the script reference
        /// <summary>
        /// When overridden in a derived class, registers the script libraries for the control.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="T:System.Collections.IEnumerable"/> interface and that contains ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            yield return new ScriptReference("Artem.Google.UI.GoogleMarkersBehavior.js", this.GetType().Assembly.FullName);
        }
    }
}