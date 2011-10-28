using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Script.Serialization;

[assembly: WebResource("Artem.Google.Polygon.GoogleGroundBehavior.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Polygon.GoogleGroundBehavior.min.js", "text/javascript")]

namespace Artem.Google.UI {

    /// <summary>
    /// A rectangular image overlay on the map.
    /// </summary>
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GoogleGround runat=server></{0}:GoogleGround>")]
    public class GoogleGround : ExtenderControl, IPostBackEventHandler {

        #region Properties

        /// <summary>
        /// Gets or sets the bounds of this overlay.
        /// </summary>
        /// <value>The bounds.</value>
        [Category("Appearance")]
        [Description("Gets or sets the bounds of this overlay.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Bounds Bounds {
            get { return _bounds ?? (_bounds = new Bounds()); }
            set { _bounds = value; }
        }
        Bounds _bounds;

        /// <summary>
        /// If true, the ground overlay can receive click events. Defaults to true.
        /// </summary>
        /// <value><c>true</c> if clickable; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("If true, the ground overlay can receive click events. Defaults to true.")]
        public bool Clickable { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image to show on this overlay.
        /// </summary>
        /// <value>The URL.</value>
        [Category("Appearance")]
        [Description("Gets or sets the URL of the image to show on this overlay.")]
        public string Url { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// This event is fired when the DOM click event is fired on the GroundOverlay.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM click event is fired on the GroundOverlay.")]
        public event EventHandler<MouseEventArgs> Click;
        /// <summary>
        /// Gets or sets the client click handler.
        /// </summary>
        /// <value>The client click handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client click handler.")]
        public string OnClientClick { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// When overridden in a derived class, registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control to which the extender is associated.</param>
        /// <returns>
        /// An enumeration of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl) {

            var descriptor = new ScriptBehaviorDescriptor("Artem.Google.GroundBehavior", targetControl.ClientID);

            if (_bounds != null)
                descriptor.AddProperty("bounds", _bounds.ToScriptData());
            descriptor.AddProperty("clickable", this.Clickable);
            descriptor.AddProperty("name", this.UniqueID);
            if (this.Url != null)
                descriptor.AddProperty("url", this.Url);

            if (this.Click != null)
                descriptor.AddEvent("click", "Artem.Google.GroundBehavior.raiseServerClick");
            else if (this.OnClientClick != null)
                descriptor.AddEvent("click", this.OnClientClick);

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
            yield return new ScriptReference("Artem.Google.Polygon.GoogleGroundBehavior.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Polyline.GoogleGroundBehavior.min.js", assembly);
#endif
        }

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(MouseEventArgs e) {
            if (this.Click != null) this.Click(this, e);
        }

        /// <summary>
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        public void RaisePostBackEvent(string eventArgument) {

            var ser = new JavaScriptSerializer();
            dynamic args = ser.DeserializeObject(eventArgument);
            if (args != null) {
                string name = args["name"];
                var e = MouseEventArgs.FromScriptData(args);
                switch (name) {
                    case "click":
                        this.OnClick(e);
                        break;
                }
            }
        }
        #endregion
    }
}
