using System;
using System.Collections.Generic;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Script.Serialization;

[assembly: WebResource("Velyo.Google.Maps.Polygon.GoogleGroundBehavior.js", "text/javascript")]
[assembly: WebResource("Velyo.Google.Maps.Polygon.GoogleGroundBehavior.min.js", "text/javascript")]

namespace Velyo.Google.Maps
{
    /// <summary>
    /// A rectangular image overlay on the map.
    /// </summary>
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GoogleGround runat=server></{0}:GoogleGround>")]
    public class GoogleGround : Overlay
    {
        private Bounds _bounds;


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

        /// <summary>
        /// Gets or sets the bounds of this overlay.
        /// </summary>
        /// <value>The bounds.</value>
        [Category("Appearance")]
        [Description("Gets or sets the bounds of this overlay.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Bounds Bounds
        {
            get { return _bounds ?? (_bounds = new Bounds()); }
            set { _bounds = value; }
        }

        /// <summary>
        /// Gets or sets the URL of the image to show on this overlay.
        /// </summary>
        /// <value>The URL.</value>
        [Category("Appearance")]
        [Description("Gets or sets the URL of the image to show on this overlay.")]
        public string Url { get; set; }


        /// <summary>
        /// When overridden in a derived class, registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control to which the extender is associated.</param>
        /// <returns>
        /// An enumeration of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
        {
            var descriptor = new ScriptBehaviorDescriptor("Velyo.Google.Maps.GroundBehavior", targetControl.ClientID);

            // properties
            descriptor.AddProperty("clickable", Clickable);
            descriptor.AddProperty("name", UniqueID);

            if (_bounds != null)
            {
                descriptor.AddProperty("bounds", _bounds.ToScriptData());
            }
            if (Url != null)
            {
                descriptor.AddProperty("url", Url);
            }

            // events
            if (Click != null)
            {
                descriptor.AddEvent("click", "Velyo.Google.Maps.GroundBehavior.raiseServerClick");
            }
            else if (OnClientClick != null)
            {
                descriptor.AddEvent("click", OnClientClick);
            }

            yield return descriptor;
        }

        /// <summary>
        /// When overridden in a derived class, registers the script libraries for the control.
        /// </summary>
        /// <returns>
        /// An object that implements the <see cref="T:System.Collections.IEnumerable"/> interface and that contains ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </returns>
        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            string assembly = GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Velyo.Google.Maps.Polygon.GoogleGroundBehavior.js", assembly);
#else
            yield return new ScriptReference("Velyo.Google.Maps.Polygon.GoogleGroundBehavior.min.js", assembly);
#endif
        }

        #region Event Methods

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(MouseEventArgs e)
        {
            Click?.Invoke(this, e);
        }

        /// <summary>
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        public override void RaisePostBackEvent(string eventArgument)
        {
            var ser = new JavaScriptSerializer();
            dynamic args = ser.DeserializeObject(eventArgument);
            if (args != null)
            {
                string name = args["name"];
                var e = MouseEventArgs.FromScriptData(args);
                switch (name)
                {
                    case "click":
                        this.OnClick(e);
                        break;
                }
            }
        }
        #endregion
    }
}
