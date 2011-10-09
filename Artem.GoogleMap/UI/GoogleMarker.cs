using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class GoogleMarker {

        #region Fields  /////////////////////////////////////////////////////////////////

        EventHandlerList _events;
        InfoWindowContent _infoContent;

        #endregion

        #region Properties  /////////////////////////////////////////////////////////////

        #region Appearance

        /// <summary>
        /// Mouse cursor to show on hover.
        /// </summary>
        /// <value>The cursor.</value>
        [Category("Appearance")]
        public string Cursor { get; set; }

        /// <summary>
        /// If <c>true</c>, the marker shadow will not be displayed. 
        /// The default value for this option is <c>false</c>, i.e. 
        /// if the option is not specified, the marker will have a shaddow.
        /// </summary>
        /// <value><c>true</c> if flat; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        public bool Flat { get; set; }

        /// <summary>
        /// Gets or sets the icon for the foreground.
        /// </summary>
        /// <value>The icon.</value>
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerImage Icon { get; set; }

        /// <summary>
        /// Gets or sets the shadow.
        /// </summary>
        /// <value>The shadow.</value>
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerImage Shadow { get; set; }

        /// <summary>
        /// Gets or sets the shape image map region definition used for drag/click.
        /// </summary>
        /// <value>The shape.</value>
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerShape Shape { get; set; }

        /// <summary>
        /// Gets or sets the title of the marker. 
        /// This string will appear as tooltip on the marker, i.e. it will work just 
        /// as the title attribute on HTML elements.
        /// </summary>
        /// <value>The title.</value>
        [Category("Appearance")]
        public string Title { get; set; }

        /// <summary>
        /// If <c>true</c>, the marker is visible. 
        /// The default value for this option is <c>true</c>, i.e.
        /// if the option is not specified the marker will be visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets the z-index of the marker.
        /// All Markers are displayed on the map in order of their zIndex, 
        /// with higher values displaying in front of Markers with lower values. 
        /// By default, Markers are displayed according to their latitude, with Markers 
        /// of lower latitudes appearing in front of Markers at higher latitudes.
        /// </summary>
        /// <value>The index of the Z.</value>
        [Category("Appearance")]
        public int ZIndex { get; set; }

        #endregion

        #region Behavior

        /// <summary>
        /// Gets or sets a value indicating whether marker info window will be opened on initial map load.
        /// The default value for this option is <c>false</c>, i.e. 
        /// if the option is not specified, the marker's infor window will not be initially opened.
        /// </summary>
        /// <value><c>true</c> if [auto open info]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool AutoOpenInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleMarker"/> is clickable.
        /// Toggles whether or not the marker is clickable. 
        /// Markers that are not clickable or draggable are inert, consume less resources 
        /// and do not respond to any events. 
        /// The default value for this option is <c>true</c>, i.e. 
        /// if the option is not specified, the marker will be clickable.
        /// </summary>
        /// <value><c>true</c> if clickable; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool Clickable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleMarker"/> is draggable.
        /// Toggles whether or not the marker will be draggable by users. Markers set up to be 
        /// dragged require more resources to set up than markers that are clickable. Any marker 
        /// that is draggable is also clickable, bouncy and auto-pan enabled by default. 
        /// The default value for this option is <c>false</c>, i.e. 
        /// if the option is not specified, the marker will not be draggable.
        /// </summary>
        /// <value><c>true</c> if draggable; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool Draggable { get; set; }

        /// <summary>
        /// Gets or sets the info window options.
        /// </summary>
        /// <value>The info window options.</value>
        [Category("Behavior")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public InfoWindowOptions InfoWindowOptions {
            get {
                return _infoWindowOptions ?? (_infoWindowOptions = new InfoWindowOptions());
            }
            set {
                _infoWindowOptions = value;
            }
        }
        InfoWindowOptions _infoWindowOptions;

        /// <summary>
        /// Gets or sets the behaviour for opening the info window of the marker - 
        /// on which mouse event the info window of the marker to be opened.
        /// Available values are: Click, DoubleClick, MouseDown, MouseOut, MouseOver, MouseUp.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [show info on mouse over]; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        public OpenInfoBehaviour OpenInfoBehaviour { get; set; }

        #endregion

        #region Data

        /// <summary>
        /// Gets or sets the address of the marker.
        /// </summary>
        /// <value>The address.</value>
        [Category("Data")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the marker.
        /// </summary>
        /// <value>The latitude.</value>
        [Browsable(false)]
        [ScriptIgnore]
        public double Latitude {
            get {
                return (this.Position != null) ? this.Position.Latitude : 0D;
            }
            set {
                (this.Position ?? (this.Position = new LatLng())).Latitude = value;
            }
        }

        /// <summary>
        /// Gets or sets the longitude of the marker.
        /// </summary>
        /// <value>The longitude.</value>
        [Browsable(false)]
        [ScriptIgnore]
        public double Longitude {
            get {
                return (this.Position != null) ? this.Position.Longitude : 0D;
            }
            set {
                (this.Position ?? (this.Position = new LatLng())).Longitude = value;
            }
        }

        /// <summary>
        /// Marker position.
        /// </summary>
        /// <value>The position.</value>
        [Category("Data")]
        public LatLng Position { get; set; }

        /// <summary>
        /// The marker info window text.
        /// </summary>
        /// <value>The text.</value>
        [Category("Data")]
        public string Text { get; set; }

        #endregion

        #region Layout

        /// <summary>
        /// Gets a value indicating whether this instance has info window.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has info window; otherwise, <c>false</c>.
        /// </value>
        [Browsable(false)]
        public bool HasInfoContent {
            get {
                return ((this.InfoContent.Controls.Count > 0) || (this.InfoWindowTemplate != null));
            }
        }

        /// <summary>
        /// Gets the content of the info.
        /// </summary>
        /// <value>The content of the info.</value>
        [ScriptIgnore]
        public InfoWindowContent InfoContent {
            get {
                return _infoContent ??
                    (_infoContent = new InfoWindowContent());
            }
            set {
                _infoContent = value;
            }
        }

        /// <summary>
        /// Gets or sets the controls' template content of the info window.
        /// </summary>
        /// <value>The content of the info window.</value>
        [Browsable(false)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        [TemplateContainer(typeof(GoogleMap))]
        [ScriptIgnore]
        public ITemplate InfoWindowTemplate { get; set; }

        #endregion

        #region Protected

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>The events.</value>
        protected internal EventHandlerList Events {
            get {
                if (_events == null)
                    _events = new EventHandlerList();
                return _events;
            }
        }
        #endregion

        #region Not Yet Supported in GoogleMaps API v3

        /// <summary>
        /// Gets or sets a value indicating whether to 'Auto-pan' the map 
        /// as you drag the marker near the edge.
        /// </summary>
        /// <value><c>true</c> if [auto pan]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        [ScriptIgnore]
        public bool AutoPan { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleMarker"/> is bouncy.
        /// Toggles whether or not the marker should bounce up and down after it finishes dragging.
        /// </summary>
        /// <value><c>true</c> if bouncy; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        [ScriptIgnore]
        public bool Bouncy { get; set; }

        /// <summary>
        /// When dragging markers normally, the marker floats up and away from the cursor. 
        /// Setting this value to true keeps the marker underneath the cursor, 
        /// and moves the cross downwards instead. The default value for this option is false.
        /// </summary>
        /// <value><c>true</c> if [drag cross move]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        [ScriptIgnore]
        public bool DragCrossMove { get; set; }

        ///// <summary>
        ///// Gets or sets the geo status.
        ///// </summary>
        ///// <value>The geo status.</value>
        //[Obsolete("Not yet available in GoogleMaps API v3")]
        //public GeoStatusCode GeoStatus { get; set; }

        /// <summary>
        /// Gets or sets the info window anchor.
        /// The pixel coordinate relative to the top left corner of the icon image at 
        /// which this icon is anchored to the map.
        /// </summary>
        /// <value>The info window anchor.</value>
        [Browsable(false)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        [ScriptIgnore]
        public GooglePoint InfoWindowAnchor { get; set; }

        /// <summary>
        /// Gets or sets the max zoom.
        /// </summary>
        /// <value>The max zoom.</value>
        [Browsable(false)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        [ScriptIgnore]
        public double? MaxZoom { get; set; }

        /// <summary>
        /// Gets or sets the min zoom.
        /// </summary>
        /// <value>The min zoom.</value>
        [Browsable(false)]
        [Obsolete("Not yet available in GoogleMaps API v3")]
        [ScriptIgnore]
        public double? MinZoom { get; set; }

        #endregion
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMarker"/> class.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="text">The text.</param>
        public GoogleMarker(double latitude, double longitude)
            : this() {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMarker"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="text">The text.</param>
        public GoogleMarker(string address)
            : this() {
            this.Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleMarker"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public GoogleMarker() {

            //this.AutoPan = true;
            this.Clickable = true;
            this.Visible = true;
            this.OpenInfoBehaviour = UI.OpenInfoBehaviour.Click;
        }
        #endregion

        #region Methods /////////////////////////////////////////////////////////////////
        #endregion
    }
}