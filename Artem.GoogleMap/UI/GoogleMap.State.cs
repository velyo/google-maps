using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    partial class GoogleMap : IPostBackDataHandler {

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        JavaScriptSerializer _serializer;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the client state ID.
        /// </summary>
        /// <value>The client state ID.</value>
        protected internal string ClientStateID {
            get {
                return this.ClientID + "_ClientState";
            }
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <value>The serializer.</value>
        protected internal JavaScriptSerializer Serializer {
            get {
                if (_serializer == null) {
                    _serializer = JsUtil.CreateSerializer();
                }
                return _serializer;
            }
        }
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Loads the state of the google map.
        /// </summary>
        /// <param name="state">The state.</param>
        protected virtual void LoadClientState(string viewState) {

            _loading = true;
            try {
                //dynamic state = this.Serializer.DeserializeObject(viewState);

                //this._address = state.Address;
                //this._center = state.Center;
                //this.Language = state.Language;
                //this.Region = state.Region;
                //this.Zoom = state.Zoom;
                //this.Bounds = state.Bounds;
                //this.DefaultAddress = state.DefaultAddress;
                //this.DisableClear = state.DisableClear;
                //this.DisableDefaultUI = state.DisableDefaultUI;
                //this.DisableDoubleClickZoom = state.DisableDoubleClickZoom;
                //this.DisableKeyboardShortcuts = state.DisableKeyboardShortcuts;
                //this.Draggable = state.Draggable;
                //this.DraggableCursor = state.DraggableCursor;
                //this.DraggingCursor = state.DraggingCursor;
                //this.EnableReverseGeocoding = state.EnableReverseGeocoding;
                //this.EnableScrollWheelZoom = state.EnableScrollWheelZoom;
                //this.MapType = state.MapType;
                //this.MapTypeControlOptions = state.MapTypeControlOptions;
                //this.NavigationControlOptions = state.NavigationControlOptions;
                //this.ScaleControlOptions = state.ScaleControlOptions;
                //this.ShowMapTypeControl = state.ShowMapTypeControl;
                //this.ShowNavigationControl = state.ShowNavigationControl;
                //this.ShowScaleControl = state.ShowScaleControl;
                //this.ShowStreetViewControl = state.ShowStreetViewControl;
                //this.ShowTraffic = state.ShowTraffic;
                //this.StreetView = state.StreetView;
                //this.Markers = state.Markers;
                //this.Polygons = state.Polygons;
                //this.Polylines = state.Polylines;

                //this.Directions = state.Directions;
                
                ////this.PolygonEvents = state.PolygonEvents;
                ////this.PolylineEvents = state.PolylineEvents;
                //this.Height = state.Height;
                //this.Width = state.Width;

                var state = this.Serializer.Deserialize<ClientState>(viewState);
                state.CopyTo(this);
            }
            finally {
                _loading = false;
            }

            //List<GoogleDirection> dirs = new List<GoogleDirection>();
            //dirs.Add(new GoogleDirection { Locale = "Test", Bounds = new GoogleBounds { NorthEast = new GoogleLocation { Latitude = 1, Longitude = 2 } } });
            //string buffer = this.Serializer.Serialize(dirs);

            //List<GoogleDirection> result = this.Serializer.Deserialize<List<GoogleDirection>>(buffer);
        }

        /// <summary>
        /// Saves the state of the client.
        /// </summary>
        protected virtual string SaveClientState() {

            //ClientState state = new ClientState(this);
            return this.Serializer.Serialize(new {
                Address = this._address,
                Center = this._center,
                Language = this.Language,
                Region = this.Region,
                Zoom = this.Zoom,
                Bounds = this.Bounds,
                DefaultAddress = this.DefaultAddress,
                DisableClear = this.DisableClear,
                DisableDefaultUI = this.DisableDefaultUI,
                DisableDoubleClickZoom = this.DisableDoubleClickZoom,
                DisableKeyboardShortcuts = this.DisableKeyboardShortcuts,
                Draggable = this.Draggable,
                DraggableCursor = this.DraggableCursor,
                DraggingCursor = this.DraggingCursor,
                EnableReverseGeocoding = this.EnableReverseGeocoding,
                EnableScrollWheelZoom = this.EnableScrollWheelZoom,
                MapType = this.MapType,
                MapTypeControlOptions = this.MapTypeControlOptions,
                NavigationControlOptions = this.NavigationControlOptions,
                ScaleControlOptions = this.ScaleControlOptions,
                ShowMapTypeControl = this.ShowMapTypeControl,
                ShowNavigationControl = this.ShowNavigationControl,
                ShowScaleControl = this.ShowScaleControl,
                ShowStreetViewControl = this.ShowStreetViewControl,
                ShowTraffic = this.ShowTraffic,
                StreetView = this.StreetView,
                Markers = this.Markers,
                Polygons = this.Polygons,
                Polylines = this.Polylines,

                Directions = this.Directions,
                //PolygonEvents = this.PolygonEvents,
                //PolylineEvents = this.PolylineEvents,
                Height = this.Height.Value,
                Width = this.Width.Value
            });
        }

        #region IPostBackDataHandler Members

        /// <summary>
        /// When implemented by a class, processes postback data for an ASP.NET server control.
        /// </summary>
        /// <param name="postDataKey">The key identifier for the control.</param>
        /// <param name="postCollection">The collection of all incoming name values.</param>
        /// <returns>
        /// true if the server control's state changes as a result of the postback; otherwise, false.
        /// </returns>
        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection) {

            string state = postCollection[this.ClientStateID];
            if (!string.IsNullOrEmpty(state)) {
                this.LoadClientState(state);
            }
            return false;
        }

        /// <summary>
        /// When implemented by a class, signals the server control to notify the ASP.NET application that the state of the control has changed.
        /// </summary>
        void IPostBackDataHandler.RaisePostDataChangedEvent() {
        }
        #endregion
        #endregion

        #region Nested Types

        /// <summary>
        /// 
        /// </summary>
        [DataContract]
        public class ClientState {

            #region Properties  ///////////////////////////////////////////////////////////////////////

            public string Address { get; set; }
            public LatLng Center { get; set; }
            public string Language { get; set; }
            public string Region { get; set; }
            public int Zoom { get; set; }

            public GoogleBounds Bounds { get; set; }
            public string DefaultAddress { get; set; }
            public bool DisableClear { get; set; }
            public bool DisableDefaultUI { get; set; }
            public bool DisableDoubleClickZoom { get; set; }
            public bool DisableKeyboardShortcuts { get; set; }
            public bool Draggable { get; set; }
            public string DraggableCursor { get; set; }
            public string DraggingCursor { get; set; }
            public bool EnableReverseGeocoding { get; set; }
            public bool EnableScrollWheelZoom { get; set; }
            public MapType MapType { get; set; }
            public MapTypeControlOptions MapTypeControlOptions { get; set; }
            public NavigationControlOptions NavigationControlOptions { get; set; }
            public ScaleControlOptions ScaleControlOptions { get; set; }
            public bool ShowMapTypeControl { get; set; }
            public bool ShowNavigationControl { get; set; }
            public bool ShowScaleControl { get; set; }
            public bool ShowStreetViewControl { get; set; }
            public bool ShowTraffic { get; set; }
            public StreetViewPanorama StreetView { get; set; }

            public List<GoogleMarker> Markers { get; set; }
            public List<GooglePolygon> Polygons { get; set; }
            public List<GooglePolyline> Polylines { get; set; }





            public List<GoogleDirections> Directions { get; set; }
            public bool EnableMarkerManager { get; set; }
            
            public double Height { get; set; }
            public bool IsStatic { get; set; }
            public MarkerManagerOptions MarkerManagerOptions { get; set; }
            //public GooglePolygonEvents PolygonEvents { get; set; }
            //public GooglePolylineEvents PolylineEvents { get; set; }
            
            public double Width { get; set; }

            #endregion

            #region Construct /////////////////////////////////////////////////////////////////////////

            /// <summary>
            /// Initializes a new instance of the <see cref="ClientState"/> class.
            /// </summary>
            /// <param name="map">The map.</param>
            public ClientState(GoogleMap map) {
                this.Load(map);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ClientState"/> class.
            /// </summary>
            /// <param name="map">The map.</param>
            public ClientState() {
            }
            #endregion

            #region Methods ///////////////////////////////////////////////////////////////////////////

            public void Load(GoogleMap map) {

                this.Address = map._address;
                this.Center = map._center;
                this.Language = map.Language;
                this.Region = map.Region;
                this.Zoom = map.Zoom;

                this.Bounds = map.Bounds;
                this.DefaultAddress = map.DefaultAddress;
                this.DisableClear = map.DisableClear;
                this.DisableDefaultUI = map.DisableDefaultUI;
                this.DisableDoubleClickZoom = map.DisableDoubleClickZoom;
                this.DisableKeyboardShortcuts = map.DisableKeyboardShortcuts;
                this.Draggable = map.Draggable;
                this.DraggableCursor = map.DraggableCursor;
                this.DraggingCursor = map.DraggingCursor;
                this.EnableReverseGeocoding = map.EnableReverseGeocoding;
                this.EnableScrollWheelZoom = map.EnableScrollWheelZoom;
                this.MapType = map.MapType;
                this.MapTypeControlOptions = map.MapTypeControlOptions;
                this.NavigationControlOptions = map.NavigationControlOptions;
                this.ScaleControlOptions = map.ScaleControlOptions;
                this.ShowMapTypeControl = map.ShowMapTypeControl;
                this.ShowNavigationControl = map.ShowNavigationControl;
                this.ShowScaleControl = map.ShowScaleControl;
                this.ShowStreetViewControl = map.ShowStreetViewControl;
                this.ShowTraffic = map.ShowTraffic;
                this.StreetView = map.StreetView;

                this.Markers = map.Markers;
                this.Polygons = map.Polygons;
                this.Polylines = map.Polylines;
                
                
                
                this.Directions = map.Directions;
                this.Height = map.Height.Value;
                //this.PolygonEvents = map.PolygonEvents;
                //this.PolylineEvents = map.PolylineEvents;
                this.Width = map.Width.Value;
            }

            public void CopyTo(GoogleMap map) {

                map.Address = this.Address;
                map.Center = this.Center;
                map.Language = this.Language;
                map.Region = this.Region;
                map.Zoom = this.Zoom;

                map.Bounds = this.Bounds;
                map.DefaultAddress = this.DefaultAddress;
                map.DisableClear = this.DisableClear;
                map.DisableDefaultUI = this.DisableDefaultUI;
                map.DisableDoubleClickZoom = this.DisableDoubleClickZoom;
                map.DisableKeyboardShortcuts = this.DisableKeyboardShortcuts;
                map.Draggable = this.Draggable;
                map.DraggableCursor = this.DraggableCursor;
                map.DraggingCursor = this.DraggingCursor;
                map.EnableReverseGeocoding = this.EnableReverseGeocoding;
                map.EnableScrollWheelZoom = this.EnableScrollWheelZoom;
                map.MapType = this.MapType;
                map.MapTypeControlOptions = this.MapTypeControlOptions;
                map.NavigationControlOptions = this.NavigationControlOptions;
                map.ScaleControlOptions = this.ScaleControlOptions;
                map.ShowMapTypeControl = this.ShowMapTypeControl;
                map.ShowNavigationControl = this.ShowNavigationControl;
                map.ShowScaleControl = this.ShowScaleControl;
                map.ShowStreetViewControl = this.ShowStreetViewControl;
                map.ShowTraffic = this.ShowTraffic;
                map.StreetView = this.StreetView;

                map.Markers = this.Markers;
                map.Polygons = this.Polygons;
                map.Polylines = this.Polylines;
                
                
                
                map.Directions = this.Directions;
                map.Height = new Unit(this.Height, UnitType.Pixel);
                //map.PolygonEvents = this.PolygonEvents;
                //map.PolylineEvents = this.PolylineEvents;
                map.ShowScaleControl = this.ShowScaleControl;
                map.Width = new Unit(this.Width, UnitType.Pixel);
            }
            #endregion
        }
        #endregion
    }
}
