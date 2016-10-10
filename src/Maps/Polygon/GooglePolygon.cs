using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;

[assembly: WebResource("Velyo.Google.Maps.Polygon.GooglePolygonBehavior.js", "text/javascript")]
[assembly: WebResource("Velyo.Google.Maps.Polygon.GooglePolygonBehavior.min.js", "text/javascript")]

namespace Velyo.Google.Maps
{
    /// <summary>
    /// Polygon (like a polyline) defines a series of connected coordinates in an ordered sequence; 
    /// additionally, polygons form a closed loop and define a filled region.
    /// </summary>
    [ParseChildren(true, "Paths")]
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GooglePolygon runat=server></{0}:GooglePolygon>")]
    public class GooglePolygon : Overlay
    {
        private List<LatLng> _paths;

        
        /// <summary>
        /// This event is fired when the DOM click event is fired on the Polygon.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM click event is fired on the Polygon.")]
        public event EventHandler<MouseEventArgs> Click;

        /// <summary>
        /// This event is fired when the DOM dblclick event is fired on the Polygon.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM dblclick event is fired on the Polygon.")]
        public event EventHandler<MouseEventArgs> DoubleClick;

        /// <summary>
        /// This event is fired when the DOM mousedown event is fired on the Polygon.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM mousedown event is fired on the Polygon.")]
        public event EventHandler<MouseEventArgs> MouseDown;

        /// <summary>
        /// This event is fired when the DOM mousemove event is fired on the Polygon.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM mousemove event is fired on the Polygon.")]
        public event EventHandler<MouseEventArgs> MouseMove;

        /// <summary>
        /// This event is fired on Polygon mouseout.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired on Polygon mouseout.")]
        public event EventHandler<MouseEventArgs> MouseOut;

        /// <summary>
        /// This event is fired on Polygon mouseover.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired on Polygon mouseover.")]
        public event EventHandler<MouseEventArgs> MouseOver;

        /// <summary>
        /// This event is fired when the DOM mouseup event is fired on the Polygon.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the DOM mouseup event is fired on the Polygon.")]
        public event EventHandler<MouseEventArgs> MouseUp;

        /// <summary>
        /// This event is fired when the Polygon is right-clicked on.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the Polygon is right-clicked on.")]
        public event EventHandler<MouseEventArgs> RightClick;


        /// <summary>
        /// Gets or sets the on client click handler.
        /// </summary>
        /// <value>The on client click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side click handler.")]
        public string OnClientClick { get; set; }

        /// <summary>
        /// Gets or sets the on client double click handler.
        /// </summary>
        /// <value>The on client double click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side double click handler.")]
        public string OnClientDoubleClick { get; set; }

        /// <summary>
        /// Gets or sets the on client mouse down handler.
        /// </summary>
        /// <value>The on client mouse down.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side mouse down handler.")]
        public string OnClientMouseDown { get; set; }

        /// <summary>
        /// Gets or sets the on client mouse move handler.
        /// </summary>
        /// <value>The on client mouse move.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side mouse move handler.")]
        public string OnClientMouseMove { get; set; }

        /// <summary>
        /// Gets or sets the on client mouse out handler.
        /// </summary>
        /// <value>The on client mouse out.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side mouse out handler.")]
        public string OnClientMouseOut { get; set; }

        /// <summary>
        /// Gets or sets the on client mouse over handler.
        /// </summary>
        /// <value>The on client mouse over.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side mouse over handler.")]
        public string OnClientMouseOver { get; set; }

        /// <summary>
        /// Gets or sets the on client mouse up handler.
        /// </summary>
        /// <value>The on client mouse up.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side mouse up handler.")]
        public string OnClientMouseUp { get; set; }

        /// <summary>
        /// Gets or sets the on client right click handler.
        /// </summary>
        /// <value>The on client right click.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side right click handler.")]
        public string OnClientRightClick { get; set; }

        /// <summary>
        /// The fill color. All CSS3 colors are supported except for extended named colors.
        /// </summary>
        /// <value>The color of the fill.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The fill color. All CSS3 colors are supported except for extended named colors.")]
        public Color FillColor { get; set; } = Color.Red;

        /// <summary>
        /// The fill opacity between 0.0 and 1.0
        /// </summary>
        /// <value>The fill opacity.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0.5F)]
        [Description("The fill opacity between 0.0 and 1.0")]
        public float FillOpacity { get; set; } = 0.5F;

        /// <summary>
        /// Render each edge as a geodesic (a segment of a "great circle"). 
        /// A geodesic is the shortest path between two points along the surface of the Earth.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is geodesic; otherwise, <c>false</c>.
        /// </value>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Render each edge as a geodesic (a segment of a great circle''). A geodesic is the shortest path between two points along the surface of the Earth.")]
        public bool Geodesic { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>The points.</value>
        [Browsable(true)]
        [Category("Data")]
        [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<LatLng> Paths
        {
            get { return _paths ?? (_paths = new List<LatLng>()); }
            set { _paths = value; }
        }

        /// <summary>
        /// The stroke color. All CSS3 colors are supported except for extended named colors.
        /// </summary>
        /// <value>The color of the stroke.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The stroke color. All CSS3 colors are supported except for extended named colors.")]
        public Color StrokeColor { get; set; } = Color.Blue;

        /// <summary>
        /// The stroke opacity between 0.0 and 1.0
        /// </summary>
        /// <value>The stroke opacity.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(0.5F)]
        [Description("The stroke opacity between 0.0 and 1.0")]
        public float StrokeOpacity { get; set; } = 0.5F;

        /// <summary>
        /// The stroke width in pixels.
        /// </summary>
        /// <value>The stroke weight.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(5)]
        [Description("The stroke width in pixels.")]
        public int StrokeWeight { get; set; } = 5;

        /// <summary>
        /// The zIndex compared to other polys.
        /// </summary>
        /// <value>The index of the Z.</value>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The zIndex compared to other polys.")]
        public int ZIndex { get; set; } = 1;


        /// <summary>
        /// When overridden in a derived class, registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control to which the extender is associated.</param>
        /// <returns>
        /// An enumeration of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
        {
            var descriptor = new ScriptBehaviorDescriptor("Velyo.Google.Maps.PolygonBehavior", targetControl.ClientID);

            // properties
            descriptor.AddProperty("clickable", Clickable);
            descriptor.AddProperty("fillColor", ColorTranslator.ToHtml(FillColor));
            descriptor.AddProperty("fillOpacity", FillOpacity);
            descriptor.AddProperty("geodesic", Geodesic);
            descriptor.AddProperty("name", UniqueID);
            descriptor.AddProperty("paths",
                (_paths != null) ? _paths.Select(p => new { lat = p.Latitude, lng = p.Longitude }).ToArray() : null);
            descriptor.AddProperty("strokeColor", ColorTranslator.ToHtml(StrokeColor));
            descriptor.AddProperty("strokeOpacity", StrokeOpacity);
            descriptor.AddProperty("strokeWeight", StrokeWeight);
            descriptor.AddProperty("zIndex", ZIndex);

            // events
            if (Click != null)
            {
                descriptor.AddEvent("click", "Velyo.Google.Maps.PolygonBehavior.raiseServerClick");
            }
            else if (OnClientClick != null)
            {
                descriptor.AddEvent("click", OnClientClick);
            }

            if (DoubleClick != null)
            {
                descriptor.AddEvent("doubleClick", "Velyo.Google.Maps.PolygonBehavior.raiseServerDoubleClick");
            }
            else if (OnClientDoubleClick != null)
            {
                descriptor.AddEvent("doubleClick", OnClientDoubleClick);
            }

            if (MouseDown != null)
            {
                descriptor.AddEvent("mouseDown", "Velyo.Google.Maps.PolygonBehavior.raiseServerMouseDown");
            }
            else if (OnClientMouseDown != null)
            {
                descriptor.AddEvent("mouseDown", OnClientMouseDown);
            }

            if (MouseMove != null)
            {
                descriptor.AddEvent("mouseMove", "Velyo.Google.Maps.PolygonBehavior.raiseServerMouseMove");
            }
            else if (OnClientMouseMove != null)
            {
                descriptor.AddEvent("mouseMove", OnClientMouseMove);
            }

            if (MouseOut != null)
            {
                descriptor.AddEvent("mouseOut", "Velyo.Google.Maps.PolygonBehavior.raiseServerMouseOut");
            }
            else if (OnClientMouseOut != null)
            {
                descriptor.AddEvent("mouseOut", OnClientMouseOut);
            }

            if (MouseOver != null)
            {
                descriptor.AddEvent("mouseOver", "Velyo.Google.Maps.PolygonBehavior.raiseServerMouseOver");
            }
            else if (OnClientMouseOver != null)
            {
                descriptor.AddEvent("mouseOver", OnClientMouseOver);
            }

            if (MouseUp != null)
            {
                descriptor.AddEvent("mouseUp", "Velyo.Google.Maps.PolygonBehavior.raiseServerMouseUp");
            }
            else if (OnClientMouseUp != null)
            {
                descriptor.AddEvent("mouseUp", OnClientMouseUp);
            }

            if (RightClick != null)
            {
                descriptor.AddEvent("rightClick", "Velyo.Google.Maps.PolygonBehavior.raiseServerRightClick");
            }
            else if (OnClientRightClick != null)
            {
                descriptor.AddEvent("rightClick", OnClientRightClick);
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
            yield return new ScriptReference("Velyo.Google.Maps.Polygon.GooglePolygonBehavior.js", assembly);
#else
            yield return new ScriptReference("Velyo.Google.Maps.Polygon.GooglePolygonBehavior.min.js", assembly);
#endif
        }

        #region Events

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(MouseEventArgs e)
        {
            Click?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DoubleClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDoubleClick(MouseEventArgs e)
        {
            DoubleClick?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            MouseDown?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseMove"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseMove(MouseEventArgs e)
        {
            MouseMove?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseOut"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseOut(MouseEventArgs e)
        {
            MouseOut?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseOver"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseOver(MouseEventArgs e)
        {
            MouseOver?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseUp"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            MouseUp?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:RightClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnRightClick(MouseEventArgs e)
        {
            RightClick?.Invoke(this, e);
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
                    case "doubleClick":
                        this.OnDoubleClick(e);
                        break;
                    case "mouseDown":
                        this.OnMouseDown(e);
                        break;
                    case "mouseMove":
                        this.OnMouseMove(e);
                        break;
                    case "mouseOut":
                        this.OnMouseOut(e);
                        break;
                    case "mouseOver":
                        this.OnMouseOver(e);
                        break;
                    case "mouseUp":
                        this.OnMouseUp(e);
                        break;
                    case "rightClick":
                        this.OnRightClick(e);
                        break;
                }
            }
        }
        #endregion
    }
}