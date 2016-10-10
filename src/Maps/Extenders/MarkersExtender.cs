using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

[assembly: WebResource("Velyo.Google.Maps.Extenders.MarkersExtenderBehavior.js", "text/javascript")]

namespace Velyo.Google.Maps
{
    /// <summary>
    /// Summary description for GoogleMarkersExtender
    /// </summary>
    [TargetControlType(typeof(GoogleMap))]
    public class MarkersExtender : ExtenderControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkersExtender"/> class.
        /// </summary>
        public MarkersExtender() { }


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
            ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor("Velyo.Google.Maps.MarkersExtenderBehavior", targetControl.ClientID);
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
            yield return new ScriptReference("Velyo.Google.Maps.Extenders.MarkersExtenderBehavior.js", this.GetType().Assembly.FullName);
        }
    }
}