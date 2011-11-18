using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Collections;

[assembly: WebResource("Artem.Google.Markers.GoogleMarkersBehavior.js", "text/javascript")]
[assembly: WebResource("Artem.Google.Markers.GoogleMarkersBehavior.min.js", "text/javascript")]

namespace Artem.Google.UI {

    /// <summary>
    /// Extender control which targets GoogleMap contol and adds the markers overlays to the google map.
    /// </summary>
    [PersistChildren(false)]
    [TargetControlType(typeof(GoogleMap))]
    [ToolboxData("<{0}:GoogleMarkers runat=server></{0}:GoogleMarkers>")]
    public class GoogleMarkers : DataBoundControl, IExtenderControl, IPostBackEventHandler {

        #region Static Methods

        /// <summary>
        /// Finds the update panel.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns></returns>
        static UpdatePanel FindUpdatePanel(Control control) {

            Control parent = control.Parent;
            do {
                if (parent is UpdatePanel) return (parent as UpdatePanel);
            }
            while ((parent = parent.Parent) != null);
            return null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the data address field.
        /// </summary>
        /// <value>The data address field.</value>
        [Category("Data")]
        public string DataAddressField { get; set; }

        /// <summary>
        /// Gets or sets the data icon field.
        /// </summary>
        /// <value>The data icon field.</value>
        [Category("Data")]
        public string DataIconField { get; set; }

        /// <summary>
        /// Gets or sets the data info field.
        /// </summary>
        /// <value>The data info field.</value>
        [Category("Data")]
        public string DataInfoField { get; set; }

        /// <summary>
        /// Gets or sets the data latitude field.
        /// </summary>
        /// <value>The data latitude field.</value>
        [Category("Data")]
        public string DataLatitudeField { get; set; }

        /// <summary>
        /// Gets or sets the data longitude field.
        /// </summary>
        /// <value>The data longitude field.</value>
        [Category("Data")]
        public string DataLongitudeField { get; set; }

        /// <summary>
        /// Options for the markers' info wondows. All markers' info windows will use these options.
        /// </summary>
        /// <value>The info window options.</value>
        [Category("Appearance")]
        [Description("Options for the markers' info wondows. All markers' info windows will use these options.")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public InfoWindowOptions InfoWindowOptions {
            get {
                return _infoWindowOptions ?? (_infoWindowOptions = new InfoWindowOptions());
            }
            set { _infoWindowOptions = value; }
        }
        InfoWindowOptions _infoWindowOptions;

        /// <summary>
        /// Options for the markers. All markers rendered will use these options.
        /// </summary>
        /// <value>The marker options.</value>
        [Category("Appearance")]
        [Description("Options for the markers. All markers rendered will use these options.")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerOptions MarkerOptions {
            get { return _options ?? (_options = new MarkerOptions()); }
            set { _options = value; }
        }
        MarkerOptions _options;

        /// <summary>
        /// Markers to be rendered to target map control.
        /// </summary>
        /// <value>The markers.</value>
        [Category("Appearance")]
        [Description("Markers to be rendered to target map control.")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Marker> Markers {
            get {
                return _markers ?? (_markers = new List<Marker>());
            }
            set {
                _markers = value;
            }
        }
        List<Marker> _markers;

        /// <summary>
        /// Gets the script manager.
        /// </summary>
        /// <value>The script manager.</value>
        private ScriptManager ScriptManager {
            get {
                if (_scriptManager == null) {
                    var page = this.Page;
                    if (page != null) {
                        _scriptManager = System.Web.UI.ScriptManager.GetCurrent(this.Page);
                        if (_scriptManager == null)
                            throw new InvalidOperationException(string.Format(
                                "The control with ID '{0}' requires a ScriptManager on the page. The ScriptManager must appear before any controls that need it.", this.ID));
                    }
                    else
                        throw new InvalidOperationException("Page cannot be null.");
                }
                return _scriptManager;
            }
        }
        ScriptManager _scriptManager;

        /// <summary>
        /// Gets or sets the target control ID.
        /// </summary>
        /// <value>The target control ID.</value>
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Identifies the control to extend.")]
        [IDReferenceProperty]
        public string TargetControlID {
            get { return _targetControlID ?? string.Empty; }
            set { _targetControlID = value; }
        }
        string _targetControlID;

        /// <summary>
        /// Gets or sets a value that indicates whether a server control is rendered as UI on the page.
        /// </summary>
        /// <value></value>
        /// <returns>true if the control is visible on the page; otherwise false.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Visible {
            get { return base.Visible; }
            set { throw new NotSupportedException(); }
        }
        #endregion

        #region Events

        /// <summary>
        /// This event is fired when the marker icon was clicked.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's animation property changes.")]
        public event EventHandler<MarkerEventArgs> AnimationChanged;
        /// <summary>
        /// Gets or sets the client animation changed handler.
        /// </summary>
        /// <value>The client animation changed handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client animation changed handler.")]
        public string OnClientAnimationChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker icon was clicked.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker icon was clicked.")]
        public event EventHandler<MarkerEventArgs> Click;
        /// <summary>
        /// Gets or sets the client click handler.
        /// </summary>
        /// <value>The client click handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client click handler.")]
        public string OnClientClick { get; set; }

        /// <summary>
        /// This event is fired when the marker clickable property was changed.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker clickable property was changed.")]
        public event EventHandler<MarkerEventArgs> ClickableChanged;
        /// <summary>
        /// Gets or sets the client clickable property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client clickable property changed handler.")]
        public string OnClientClickableChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker's cursor property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's cursor property changes.")]
        public event EventHandler<MarkerEventArgs> CursorChanged;
        /// <summary>
        /// Gets or sets the client cursor property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client cursor property changed handler.")]
        public string OnClientCursorChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker icon was double clicked.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker icon was double clicked.")]
        public event EventHandler<MarkerEventArgs> DoubleClick;
        /// <summary>
        /// Gets or sets the client double click handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client double click handler.")]
        public string OnClientDoubleClick { get; set; }

        /// <summary>
        /// This event is repeatedly fired while the user drags the marker.
        /// </summary>
        [Category("Google")]
        [Description("This event is repeatedly fired while the user drags the marker.")]
        public event EventHandler<MarkerEventArgs> Drag;
        /// <summary>
        /// Gets or sets the client drag handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag handler.")]
        public string OnClientDrag { get; set; }

        /// <summary>
        /// This event is fired when the marker's draggable property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's draggable property changes.")]
        public event EventHandler<MarkerEventArgs> DraggableChanged;
        /// <summary>
        /// Gets or sets the client draggable property changed handler.
        /// </summary>
        /// <value>The client hanlder.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client draggable property changed handler.")]
        public string OnClientDraggableChanged { get; set; }

        /// <summary>
        /// This event is fired when the user stops dragging the marker.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user stops dragging the marker.")]
        public event EventHandler<MarkerEventArgs> DragEnd;
        /// <summary>
        /// Gets or sets the client drag end handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag end handler.")]
        public string OnClientDragEnd { get; set; }

        /// <summary>
        /// This event is fired when the user starts dragging the marker.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the user starts dragging the marker.")]
        public event EventHandler<MarkerEventArgs> DragStart;
        /// <summary>
        /// Gets or sets the client drag start handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client drag start handler.")]
        public string OnClientDragStart { get; set; }

        /// <summary>
        /// This event is fired when the marker's flat property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's flat property changes.")]
        public event EventHandler<MarkerEventArgs> FlatChanged;
        /// <summary>
        /// Gets or sets the client flat property changed handler.
        /// </summary>
        /// <value>The on client flat property changed handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client flat property changed handler.")]
        public string OnClientFlatChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker icon property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker icon property changes.")]
        public event EventHandler<MarkerEventArgs> IconChanged;
        /// <summary>
        /// Gets or sets the client icon property changed handler.
        /// </summary>
        /// <value>The client icon property changed handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client icon property changed handler.")]
        public string OnClientIconChanged { get; set; }

        /// <summary>
        /// This event is fired for a mousedown on the marker.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired for a mousedown on the marker.")]
        public event EventHandler<MarkerEventArgs> MouseDown;
        /// <summary>
        /// Gets or sets the client mouse down handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client-side mouse down handler.")]
        public string OnClientMouseDown { get; set; }

        /// <summary>
        /// This event is fired when the mouse leaves the area of the marker icon.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the mouse leaves the area of the marker icon.")]
        public event EventHandler<MarkerEventArgs> MouseOut;
        /// <summary>
        /// Gets or sets the client mouse out handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse out handler.")]
        public string OnClientMouseOut { get; set; }

        /// <summary>
        /// This event is fired when the mouse enters the area of the marker icon.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the mouse enters the area of the marker icon.")]
        public event EventHandler<MarkerEventArgs> MouseOver;
        /// <summary>
        /// Gets or sets the client mouse over handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse over handler.")]
        public string OnClientMouseOver { get; set; }

        /// <summary>
        /// This event is fired for a mouseup on the marker.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired for a mouseup on the marker.")]
        public event EventHandler<MarkerEventArgs> MouseUp;
        /// <summary>
        /// Gets or sets the client mouse up handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client mouse up handler.")]
        public string OnClientMouseUp { get; set; }

        /// <summary>
        /// This event is fired when the marker position property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker position property changes.")]
        public event EventHandler<MarkerEventArgs> PositionChanged;
        /// <summary>
        /// Gets or sets the client marker position property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client marker position property changed handler.")]
        public string OnClientPositionChanged { get; set; }

        /// <summary>
        /// This event is fired for a rightclick on the marker.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired for a rightclick on the marker.")]
        public event EventHandler<MarkerEventArgs> RightClick;
        /// <summary>
        /// Gets or sets the client right click handler.
        /// </summary>
        /// <value>The client right click handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client right click handler.")]
        public string OnClientRightClick { get; set; }

        /// <summary>
        /// This event is fired when the marker's shadow property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's shadow property changes.")]
        public event EventHandler<MarkerEventArgs> ShadowChanged;
        /// <summary>
        /// Gets or sets the client marker's shadow property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client marker's shadow property changed handler.")]
        public string OnClientShadowChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker's shape property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's shape property changes.")]
        public event EventHandler<MarkerEventArgs> ShapeChanged;
        /// <summary>
        /// Gets or sets the client marker's shape property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client marker's shape property changed handler.")]
        public string OnClientShapeChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker title property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker title property changes.")]
        public event EventHandler<MarkerEventArgs> TitleChanged;
        /// <summary>
        /// Gets or sets the client marker's title property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client marker's title property changed handler.")]
        public string OnClientTitleChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker's visible property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's visible property changes.")]
        public event EventHandler<MarkerEventArgs> VisibleChanged;
        /// <summary>
        /// Gets or sets the client marker's visible property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client marker's visible property changed handler.")]
        public string OnClientVisibleChanged { get; set; }

        /// <summary>
        /// This event is fired when the marker's zIndex property changes.
        /// </summary>
        [Category("Google")]
        [Description("This event is fired when the marker's zIndex property changes.")]
        public event EventHandler<MarkerEventArgs> ZIndexChanged;
        /// <summary>
        /// Gets or sets the client marker's zIndex property changed handler.
        /// </summary>
        /// <value>The client handler.</value>
        [Category("Client Event")]
        [Description("Gets or sets the client marker's zIndex property changed handler.")]
        public string OnClientZIndexChanged { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);
            this.RegisterWithScriptManager();
        }

        /// <summary>
        /// Registers the with script manager.
        /// </summary>
        private void RegisterWithScriptManager() {

            if (!string.IsNullOrEmpty(this.TargetControlID)) {
                var target = this.FindControl(this.TargetControlID);
                if (target != null) {
                    if (FindUpdatePanel(this) == FindUpdatePanel(target))
                        this.ScriptManager.RegisterExtenderControl<GoogleMarkers>(this, target);
                    else
                        throw new InvalidOperationException(
                            "An extender can't be in a different UpdatePanel than the control it extends.");
                }
                else
                    throw new InvalidOperationException(string.Format(
                        "The TargetControlID of '{0}' is not valid. A control with ID '{1}' could not be found.", this.ID, this.TargetControlID));
            }
            else
                throw new InvalidOperationException(string.Format(
                    "The TargetControlID of '{0}' is not valid. The value cannot be null or empty.", this.ID));
        }

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the control content.</param>
        protected override void Render(HtmlTextWriter writer) {
            base.Render(writer);
            if (!this.DesignMode)
                this.ScriptManager.RegisterScriptDescriptors(this);
        }

        #region IExtenderControl Members

        /// <summary>
        /// Registers the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control and returns an object that contains the <see cref="T:System.Web.UI.ScriptDescriptor"/> objects for the control.
        /// </summary>
        /// <param name="targetControl">The server control that the extender is associated with.</param>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable"/> collection that contains <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
        /// </returns>
        IEnumerable<ScriptDescriptor> IExtenderControl.GetScriptDescriptors(Control targetControl) {

            var descriptor = new ScriptBehaviorDescriptor("Artem.Google.MarkersBehavior", targetControl.ClientID);

            if (_options != null)
                descriptor.AddProperty("groupOptions", _options.ToScriptData());
            if (_markers != null)
                descriptor.AddProperty("markerOptions", _markers.Select(m => m.ToScriptData()).ToArray());
            if (_infoWindowOptions != null)
                descriptor.AddProperty("infoOptions", _infoWindowOptions.ToScriptData());
            descriptor.AddProperty("name", this.UniqueID);

            #region events

            if (this.AnimationChanged != null)
                descriptor.AddEvent("animationChanged", "Artem.Google.MarkersBehavior.raiseServerAnimationChanged");
            else if (this.OnClientAnimationChanged != null)
                descriptor.AddEvent("animationChanged", this.OnClientAnimationChanged);

            if (this.Click != null)
                descriptor.AddEvent("click", "Artem.Google.MarkersBehavior.raiseServerClick");
            else if (this.OnClientClick != null)
                descriptor.AddEvent("click", this.OnClientClick);

            if (this.ClickableChanged != null)
                descriptor.AddEvent("clickableChanged", "Artem.Google.MarkersBehavior.raiseServerClickableChanged");
            else if (this.OnClientClickableChanged != null)
                descriptor.AddEvent("clickableChanged", this.OnClientClickableChanged);

            if (this.CursorChanged != null)
                descriptor.AddEvent("cursorChanged", "Artem.Google.MarkersBehavior.raiseServerCursorChanged");
            else if (this.OnClientCursorChanged != null)
                descriptor.AddEvent("cursorChanged", this.OnClientCursorChanged);

            if (this.DoubleClick != null)
                descriptor.AddEvent("doubleClick", "Artem.Google.MarkersBehavior.raiseServerDoubleClick");
            else if (this.OnClientDoubleClick != null)
                descriptor.AddEvent("doubleClick", this.OnClientDoubleClick);

            if (this.Drag != null)
                descriptor.AddEvent("drag", "Artem.Google.MarkersBehavior.raiseServerDrag");
            else if (this.OnClientDrag != null)
                descriptor.AddEvent("drag", this.OnClientDrag);

            if (this.DraggableChanged != null)
                descriptor.AddEvent("draggableChanged", "Artem.Google.MarkersBehavior.raiseServerDraggableChanged");
            else if (this.OnClientDraggableChanged != null)
                descriptor.AddEvent("draggableChanged", this.OnClientDraggableChanged);

            if (this.DragEnd != null)
                descriptor.AddEvent("dragEnd", "Artem.Google.MarkersBehavior.raiseServerDragEnd");
            else if (this.OnClientDragEnd != null)
                descriptor.AddEvent("dragEnd", this.OnClientDragEnd);

            if (this.DragStart != null)
                descriptor.AddEvent("dragStart", "Artem.Google.MarkersBehavior.raiseServerDragStart");
            else if (this.OnClientDragStart != null)
                descriptor.AddEvent("dragStart", this.OnClientDragStart);

            if (this.FlatChanged != null)
                descriptor.AddEvent("flatChanged", "Artem.Google.MarkersBehavior.raiseServerFlatChanged");
            else if (this.OnClientFlatChanged != null)
                descriptor.AddEvent("flatChanged", this.OnClientFlatChanged);

            if (this.IconChanged != null)
                descriptor.AddEvent("iconChanged", "Artem.Google.MarkersBehavior.raiseServerIconChanged");
            else if (this.OnClientIconChanged != null)
                descriptor.AddEvent("iconChanged", this.OnClientIconChanged);

            if (this.MouseDown != null)
                descriptor.AddEvent("mouseDown", "Artem.Google.MarkersBehavior.raiseServerMouseDown");
            else if (this.OnClientMouseDown != null)
                descriptor.AddEvent("mouseDown", this.OnClientMouseDown);

            if (this.MouseOut != null)
                descriptor.AddEvent("mouseOut", "Artem.Google.MarkersBehavior.raiseServerMouseOut");
            else if (this.OnClientMouseOut != null)
                descriptor.AddEvent("mouseOut", this.OnClientMouseOut);

            if (this.MouseOver != null)
                descriptor.AddEvent("mouseOver", "Artem.Google.MarkersBehavior.raiseServerMouseOver");
            else if (this.OnClientMouseOver != null)
                descriptor.AddEvent("mouseOver", this.OnClientMouseOver);

            if (this.MouseUp != null)
                descriptor.AddEvent("mouseUp", "Artem.Google.MarkersBehavior.raiseServerMouseUp");
            else if (this.OnClientMouseUp != null)
                descriptor.AddEvent("mouseUp", this.OnClientMouseUp);

            if (this.PositionChanged != null)
                descriptor.AddEvent("positionChanged", "Artem.Google.MarkersBehavior.raiseServerPositionChanged");
            else if (this.OnClientPositionChanged != null)
                descriptor.AddEvent("positionChanged", this.OnClientPositionChanged);

            if (this.RightClick != null)
                descriptor.AddEvent("rightClick", "Artem.Google.MarkersBehavior.raiseServerRightClick");
            else if (this.OnClientRightClick != null)
                descriptor.AddEvent("rightClick", this.OnClientRightClick);

            if (this.ShadowChanged != null)
                descriptor.AddEvent("shadowChanged", "Artem.Google.MarkersBehavior.raiseServerShadowChanged");
            else if (this.OnClientShadowChanged != null)
                descriptor.AddEvent("shadowChanged", this.OnClientShadowChanged);

            if (this.ShapeChanged != null)
                descriptor.AddEvent("shapeChanged", "Artem.Google.MarkersBehavior.raiseServerShapeChanged");
            else if (this.OnClientShapeChanged != null)
                descriptor.AddEvent("shapeChanged", this.OnClientShapeChanged);

            if (this.TitleChanged != null)
                descriptor.AddEvent("titleChanged", "Artem.Google.MarkersBehavior.raiseServerTitleChanged");
            else if (this.OnClientTitleChanged != null)
                descriptor.AddEvent("titleChanged", this.OnClientTitleChanged);

            if (this.VisibleChanged != null)
                descriptor.AddEvent("visibleChanged", "Artem.Google.MarkersBehavior.raiseServerVisibleChanged");
            else if (this.OnClientVisibleChanged != null)
                descriptor.AddEvent("visibleChanged", this.OnClientVisibleChanged);

            if (this.ZIndexChanged != null)
                descriptor.AddEvent("zindexChanged", "Artem.Google.MarkersBehavior.raiseServerZIndexChanged");
            else if (this.OnClientZIndexChanged != null)
                descriptor.AddEvent("zindexChanged", this.OnClientZIndexChanged);

            #endregion

            yield return descriptor;
        }

        /// <summary>
        /// Registers the script libraries for the control and returns an enumeration of ECMAScript (JavaScript) files that have been registered as embedded resources.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable"/> collection that contains JavaScript files that have been registered as embedded resources.
        /// </returns>
        IEnumerable<ScriptReference> IExtenderControl.GetScriptReferences() {

            string assembly = this.GetType().Assembly.FullName;
#if DEBUG
            yield return new ScriptReference("Artem.Google.Markers.GoogleMarkersBehavior.js", assembly);
#else
            yield return new ScriptReference("Artem.Google.Markers.GoogleMarkersBehavior.min.js", assembly);
#endif
        }
        #endregion

        #region Event Methods

        /// <summary>
        /// Raises the <see cref="E:AnimationChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnAnimationChanged(MarkerEventArgs e) {
            if (this.AnimationChanged != null) this.AnimationChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnClick(MarkerEventArgs e) {
            if (this.Click != null) this.Click(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:ClickableChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnClickableChanged(MarkerEventArgs e) {
            if (this.ClickableChanged != null) this.ClickableChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:CursorChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCursorChanged(MarkerEventArgs e) {
            if (this.CursorChanged != null) this.CursorChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DoubleClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDoubleClick(MarkerEventArgs e) {
            if (this.DoubleClick != null) this.DoubleClick(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:Drag"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDrag(MarkerEventArgs e) {
            if (this.Drag != null) this.Drag(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DraggableChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDraggableChanged(MarkerEventArgs e) {
            if (this.DraggableChanged != null) this.DraggableChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DragEnd"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDragEnd(MarkerEventArgs e) {
            if (this.DragEnd != null) this.DragEnd(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:DragStart"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDragStart(MarkerEventArgs e) {
            if (this.DragStart != null) this.DragStart(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:FlatChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnFlatChanged(MarkerEventArgs e) {
            if (this.FlatChanged != null) this.FlatChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:IconChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnIconChanged(MarkerEventArgs e) {
            if (this.IconChanged != null) this.IconChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseDown(MarkerEventArgs e) {
            if (this.MouseDown != null) this.MouseDown(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseOut"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseOut(MarkerEventArgs e) {
            if (this.MouseOut != null) this.MouseOut(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseOver"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseOver(MarkerEventArgs e) {
            if (this.MouseOver != null) this.MouseOver(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:MouseUp"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMouseUp(MarkerEventArgs e) {
            if (this.MouseUp != null) this.MouseUp(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:PositionChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPositionChanged(MarkerEventArgs e) {
            if (this.PositionChanged != null) this.PositionChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:RightClick"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MouseEventArgs"/> instance containing the event data.</param>
        protected virtual void OnRightClick(MarkerEventArgs e) {
            if (this.RightClick != null) this.RightClick(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:ShadowChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnShadowChanged(MarkerEventArgs e) {
            if (this.ShadowChanged != null) this.ShadowChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:ShapeChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnShapeChanged(MarkerEventArgs e) {
            if (this.ShapeChanged != null) this.ShapeChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:TitleChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTitleChanged(MarkerEventArgs e) {
            if (this.TitleChanged != null) this.TitleChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:VisibleChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnVisibleChanged(MarkerEventArgs e) {
            if (this.VisibleChanged != null) this.VisibleChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:ZIndexChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Artem.Google.UI.MarkerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnZIndexChanged(MarkerEventArgs e) {
            if (this.ZIndexChanged != null) this.ZIndexChanged(this, e);
        }

        /// <summary>
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {

            var ser = new JavaScriptSerializer();
            dynamic args = ser.DeserializeObject(eventArgument);
            if (args != null) {
                string name = args["name"];
                var e = MarkerEventArgs.FromScriptData(args);
                switch (name) {
                    case "animationChanged":
                        this.OnAnimationChanged(e);
                        break;
                    case "click":
                        this.OnClick(e);
                        break;
                    case "clickableChanged":
                        this.OnClickableChanged(e);
                        break;
                    case "cursorChanged":
                        this.OnCursorChanged(e);
                        break;
                    case "doubleClick":
                        this.OnDoubleClick(e);
                        break;
                    case "drag":
                        this.OnDrag(e);
                        break;
                    case "draggableChanged":
                        this.OnDraggableChanged(e);
                        break;
                    case "dragEnd":
                        this.OnDragEnd(e);
                        break;
                    case "dragStart":
                        this.OnDragStart(e);
                        break;
                    case "flatChanged":
                        this.OnFlatChanged(e);
                        break;
                    case "iconChanged":
                        this.OnIconChanged(e);
                        break;
                    case "mouseDown":
                        this.OnMouseDown(e);
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
                    case "positionChanged":
                        this.OnPositionChanged(e);
                        break;
                    case "rightClick":
                        this.OnRightClick(e);
                        break;
                    case "shadowChanged":
                        this.OnShadowChanged(e);
                        break;
                    case "shapeChanged":
                        this.OnShapeChanged(e);
                        break;
                    case "titleChanged":
                        this.OnTitleChanged(e);
                        break;
                    case "visibleChanged":
                        this.OnVisibleChanged(e);
                        break;
                    case "zindexChanged":
                        this.OnZIndexChanged(e);
                        break;
                }
            }
        }
        #endregion

        #region DataBound Methods

        /// <summary>
        /// When overridden in a derived class, binds data from the data source to the control.
        /// </summary>
        /// <param name="data">The <see cref="T:System.Collections.IEnumerable"/> list of data returned from a <see cref="M:System.Web.UI.WebControls.DataBoundControl.PerformSelect"/> method call.</param>
        protected override void PerformDataBinding(IEnumerable data) {
            base.PerformDataBinding(data);

            if (data != null) {
                bool hasAddressDataField = !string.IsNullOrEmpty(DataAddressField);
                bool hasIconDataField = !string.IsNullOrEmpty(DataIconField);
                bool hasInfoDataField = !string.IsNullOrEmpty(DataInfoField);
                bool hasLatitudeDataField = !string.IsNullOrEmpty(DataLatitudeField);
                bool hasLongitudeDataField = !string.IsNullOrEmpty(DataLongitudeField);

                Marker marker;
                foreach (object dataItem in data) {
                    marker = new Marker();

                    //if (hasAddressDataField)
                    //    marker.Address = DataBinder.Eval(dataItem, DataAddressField, "");
                    if (hasIconDataField)
                        marker.Icon = DataBinder.Eval(dataItem, DataIconField, null);
                    if (hasInfoDataField)
                        marker.Info = DataBinder.Eval(dataItem, DataInfoField, null);
                    if (hasLatitudeDataField)
                        marker.Position.Latitude = (double)DataBinder.Eval(dataItem, DataLatitudeField);
                    if (hasLongitudeDataField)
                        marker.Position.Longitude = (double)DataBinder.Eval(dataItem, DataLongitudeField);

                    this.Markers.Add(marker);
                }
            }
        }

        /// <summary>
        /// Retrieves data from the associated data source.
        /// </summary>
        protected override void PerformSelect() {

            // Call OnDataBinding here if bound to a data source using the
            // DataSource property (instead of a DataSourceID), because the
            // databinding statement is evaluated before the call to GetData.       
            if (!IsBoundUsingDataSourceID) OnDataBinding(EventArgs.Empty);

            // The GetData method retrieves the DataSourceView object from  
            // the IDataSource associated with the data-bound control.            
            GetData().Select(
                CreateDataSourceSelectArguments(),
                (data) => {
                    // Call OnDataBinding only if it has not already been 
                    // called in the PerformSelect method.
                    if (IsBoundUsingDataSourceID) OnDataBinding(EventArgs.Empty);
                    // The PerformDataBinding method binds the data in the  
                    // retrievedData collection to elements of the data-bound control.
                    PerformDataBinding(data);
                });

            // The PerformDataBinding method has completed.
            RequiresDataBinding = false;
            MarkAsDataBound();

            // Raise the DataBound event.
            OnDataBound(EventArgs.Empty);
        }
        #endregion
        #endregion
    }
}
