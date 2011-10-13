using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("Artem.Google.Polyline.GooglePolylineBehavior.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Polyline.GooglePolylineBehavior.min.js", "text/javascript")]

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true, "Path")]
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GooglePolyline runat=server></{0}:GooglePolyline>")]
    public class GooglePolyline : ExtenderControl, IPostBackEventHandler {

        #region Fields

        //IDictionary<string, object> _options = new Dictionary<string, object>();
        List<LatLng> _path;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this polyline is clickable.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is clickable; otherwise, <c>false</c>.
        /// </value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Indicates whether this Polyline handles click events. Defaults to true.")]
        public bool Clickable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GooglePolyline"/> is geodesic.
        /// Render each edge as a geodesic (a segment of a "great circle"). 
        /// A geodesic is the shortest path between two points along the surface of the Earth.
        /// </summary>
        /// <value><c>true</c> if geodesic; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Render each edge as a geodesic (a segment of a 'great circle'). A geodesic is the shortest path between two points along the surface of the Earth.")]
        public bool Geodesic { get; set; }

        /// <summary>
        /// The ordered sequence of coordinates of the Polyline. 
        /// This path is specified using an array of LatLngs.
        /// </summary>
        /// <value>The path.</value>
        [Browsable(true)]
        [Category("Data")]
        [Description("The ordered sequence of coordinates of the Polyline. This path is specified using an array of LatLngs.")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public List<LatLng> Path {
            get {
                return _path ?? (_path = new List<LatLng>());
            }
            set {
                _path = value;
            }
        }

        /// <summary>
        /// Gets or sets a value for stroke color of the polyline. 
        /// </summary>
        /// <value>The color.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Render each edge as a geodesic (a segment of a 'great circle'). A geodesic is the shortest path between two points along the surface of the Earth.")]
        public Color StrokeColor { get; set; }

        /// <summary>
        /// Gets or sets the opacity of polyline.
        /// The opacity is given as a number between 0 and 1. The line will be antialiased and semitransparent.
        /// </summary>
        /// <value>The opacity.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0.5F)]
        [Description("The opacity is given as a number between 0 and 1. The line will be antialiased and semitransparent.")]
        public float StrokeOpacity { get; set; }

        /// <summary>
        /// Gets or sets the weight of polyline.
        /// The weight is the width of the line in pixels.
        /// </summary>
        /// <value>The weight.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The weight is the width of the line in pixels.")]
        public int StrokeWeight { get; set; }

        /// <summary>
        /// The zIndex compared to other polys.
        /// </summary>
        /// <value>The index.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The zIndex compared to other polys.")]
        public int ZIndex { get; set; }

        #endregion

        #region Events


        /// <summary>
        /// This event is fired when the DOM click event is fired on the Polyline.
        /// </summary>
        public event EventHandler Click;
        /// <summary>
        /// Gets or sets the on client click handler.
        /// </summary>
        /// <value>The on client click.</value>
        public string OnClientClick { get; set; }

        /// <summary>
        /// This event is fired when the DOM dblclick event is fired on the Polyline.
        /// </summary>
        public event EventHandler DoubleClick;
        /// <summary>
        /// Gets or sets the on client double click handler.
        /// </summary>
        /// <value>The on client double click.</value>
        public string OnClientDoubleClick { get; set; }

        /// <summary>
        /// This event is fired when the DOM mousedown event is fired on the Polyline.
        /// </summary>
        public event EventHandler MouseDown;
        /// <summary>
        /// Gets or sets the on client mouse down handler.
        /// </summary>
        /// <value>The on client mouse down.</value>
        public string OnClientMouseDown { get; set; }

        /// <summary>
        /// This event is fired when the DOM mousemove event is fired on the Polyline.
        /// </summary>
        public event EventHandler MouseMove;
        /// <summary>
        /// Gets or sets the on client mouse move handler.
        /// </summary>
        /// <value>The on client mouse move.</value>
        public string OnClientMouseMove { get; set; }

        /// <summary>
        /// This event is fired on Polyline mouseout.
        /// </summary>
        public event EventHandler MouseOut;
        /// <summary>
        /// Gets or sets the on client mouse out handler.
        /// </summary>
        /// <value>The on client mouse out.</value>
        public string OnClientMouseOut { get; set; }

        /// <summary>
        /// This event is fired on Polyline mouseover.
        /// </summary>
        public event EventHandler MouseOver;
        /// <summary>
        /// Gets or sets the on client mouse over handler.
        /// </summary>
        /// <value>The on client mouse over.</value>
        public string OnClientMouseOver { get; set; }

        /// <summary>
        /// This event is fired when the DOM mouseup event is fired on the Polyline.
        /// </summary>
        public event EventHandler MouseUp;
        /// <summary>
        /// Gets or sets the on client mouse up handler.
        /// </summary>
        /// <value>The on client mouse up.</value>
        public string OnClientMouseUp { get; set; }

        /// <summary>
        /// This event is fired when the Polyline is right-clicked on.
        /// </summary>
        public event EventHandler RightClick;
        /// <summary>
        /// Gets or sets the on client right click handler.
        /// </summary>
        /// <value>The on client right click.</value>
        public string OnClientRightClick { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="GooglePolyline"/> class.
        /// </summary>
        public GooglePolyline() {
            this.Clickable = true;
            this.StrokeColor = Color.Blue;
            this.StrokeOpacity = .5F;
            this.StrokeWeight = 1;
            this.ZIndex = 1;
        }
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

            var descriptor = new ScriptBehaviorDescriptor("Artem.Google.PolylineBehavior", targetControl.ClientID);

            // properties
            descriptor.AddProperty("clickable", this.Clickable);
            descriptor.AddProperty("geodesic", this.Geodesic);
            descriptor.AddProperty("path",
                (_path != null) ? _path.Select(p => new { lat = p.Latitude, lng = p.Longitude }).ToArray() : null);
            descriptor.AddProperty("strokeColor", ColorTranslator.ToHtml(this.StrokeColor));
            descriptor.AddProperty("strokeOpacity", this.StrokeOpacity);
            descriptor.AddProperty("strokeWeight", this.StrokeWeight);
            descriptor.AddProperty("zIndex", this.ZIndex);

            // events
            if (this.Click != null)
                descriptor.AddEvent("click", "Artem.Google.PolylineBehavior.raiseServerClick");
            else if (this.OnClientClick != null)
                descriptor.AddEvent("click", this.OnClientClick);

            if (this.DoubleClick != null)
                descriptor.AddEvent("doubleClick", "Artem.Google.PolylineBehavior.raiseServerDoubleClick");
            else if (this.OnClientDoubleClick != null)
                descriptor.AddEvent("doubleClick", this.OnClientDoubleClick);

            if (this.MouseDown != null)
                descriptor.AddEvent("mouseDown", "Artem.Google.PolylineBehavior.raiseServerMouseDown");
            else if (this.OnClientMouseDown != null)
                descriptor.AddEvent("mouseDown", this.OnClientMouseDown);

            if (this.MouseMove != null)
                descriptor.AddEvent("mouseMove", "Artem.Google.PolylineBehavior.raiseServerMouseMove");
            else if (this.OnClientMouseMove != null)
                descriptor.AddEvent("mouseMove", this.OnClientMouseMove);

            if (this.MouseOut != null)
                descriptor.AddEvent("mouseOut", "Artem.Google.PolylineBehavior.raiseServerMouseOut");
            else if (this.OnClientMouseMove != null)
                descriptor.AddEvent("mouseOut", this.OnClientMouseOut);

            if (this.MouseOver != null)
                descriptor.AddEvent("mouseOver", "Artem.Google.PolylineBehavior.raiseServerMouseOver");
            else if (this.OnClientMouseOver != null)
                descriptor.AddEvent("mouseOver", this.OnClientMouseOver);

            if (this.MouseUp != null)
                descriptor.AddEvent("mouseUp", "Artem.Google.PolylineBehavior.raiseServerMouseUp");
            else if (this.OnClientMouseUp != null)
                descriptor.AddEvent("mouseUp", this.OnClientMouseUp);

            if (this.RightClick != null)
                descriptor.AddEvent("rightClick", "Artem.Google.PolylineBehavior.raiseServerRightClick");
            else if (this.OnClientRightClick != null)
                descriptor.AddEvent("rightClick", this.OnClientRightClick);

            yield return descriptor;
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences() {
            string assembly = this.GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Artem.Google.Polyline.GooglePolylineBehavior.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Polyline.GooglePolylineBehavior.min.js", assembly);
#endif
        }

        public void RaisePostBackEvent(string eventArgument) {
            throw new NotImplementedException();
        }
        #endregion
    }
}
