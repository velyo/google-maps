using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    partial class GoogleMap {

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        GoogleEventList _mapEvents;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets a list of event handler delegates for the control. This property is read-only.
        /// </summary>
        /// <value></value>
        /// <returns>The list of event handler delegates.</returns>
        protected internal GoogleEventList MapEvents {
            get {
                return _mapEvents ??
                    (_mapEvents = new GoogleEventList());
            }
        }
        #endregion

        #region Client Events /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the on client address not found.
        /// </summary>
        /// <value>The on client address not found.</value>
        [Category("GoogleEvents")]
        public string OnClientAddressNotFound {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventAddressNotFound, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client click.
        /// </summary>
        /// <value>The on client click.</value>
        [Category("GoogleEvents")]
        public string OnClientClick {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventClick, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client double click.
        /// </summary>
        /// <value>The on client double click.</value>
        [Category("GoogleEvents")]
        public string OnClientDoubleClick {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventDoubleClick, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client drag.
        /// </summary>
        /// <value>The on client drag.</value>
        [Category("GoogleEvents")]
        public string OnClientDrag {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventDrag, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client drag end.
        /// </summary>
        /// <value>The on client drag end.</value>
        [Category("GoogleEvents")]
        public string OnClientDragEnd {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventDragEnd, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client drag start.
        /// </summary>
        /// <value>The on client drag start.</value>
        [Category("GoogleEvents")]
        public string OnClientDragStart {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventDragStart, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client geo location loaded.
        /// </summary>
        /// <value>The on client geo location loaded.</value>
        [Category("GoogleEvents")]
        public string OnClientGeoLocationLoaded {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventGeoLocationLoaded, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client heading changed.
        /// </summary>
        /// <value>The on client heading changed.</value>
        [Category("GoogleEvents")]
        public string OnClientHeadingChanged {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventHeadingChanged, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client info window before close.
        /// </summary>
        /// <value>The on client info window before close.</value>
        [Category("GoogleEvents")]
        public string OnClientInfoWindowBeforeClose {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventInfoWindowBeforeClose, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client info window close.
        /// </summary>
        /// <value>The on client info window close.</value>
        [Category("GoogleEvents")]
        public string OnClientInfoWindowClose {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventInfoWindowClose, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client info window open.
        /// </summary>
        /// <value>The on client info window open.</value>
        [Category("GoogleEvents")]
        public string OnClientInfoWindowOpen {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventInfoWindowOpen, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client location loaded.
        /// </summary>
        /// <value>The on client location loaded.</value>
        [Category("GoogleEvents")]
        public string OnClientLocationLoaded {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventLocationLoaded, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client load.
        /// </summary>
        /// <value>The on client load.</value>
        [Category("GoogleEvents")]
        public string OnClientMapLoad {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventLoad, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client map type add.
        /// </summary>
        /// <value>The on client map type add.</value>
        [Category("GoogleEvents")]
        public string OnClientMapTypeAdd {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventAddMapType, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client map type changed.
        /// </summary>
        /// <value>The on client map type changed.</value>
        [Category("GoogleEvents")]
        public string OnClientMapTypeChanged {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventMapTypeChanged, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client map type remove.
        /// </summary>
        /// <value>The on client map type remove.</value>
        [Category("GoogleEvents")]
        public string OnClientMapTypeRemove {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventRemoveMapType, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client mouse move.
        /// </summary>
        /// <value>The on client mouse move.</value>
        [Category("GoogleEvents")]
        public string OnClientMouseMove {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventMouseMove, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client mouse over.
        /// </summary>
        /// <value>The on client mouse over.</value>
        [Category("GoogleEvents")]
        public string OnClientMouseOver {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventMouseOver, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client mouse out.
        /// </summary>
        /// <value>The on client mouse out.</value>
        [Category("GoogleEvents")]
        public string OnClientMouseOut {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventMouseOut, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client move.
        /// </summary>
        /// <value>The on client move.</value>
        [Category("GoogleEvents")]
        public string OnClientMove {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventMove, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client move end.
        /// </summary>
        /// <value>The on client move end.</value>
        [Category("GoogleEvents")]
        public string OnClientMoveEnd {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventMoveEnd, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client move start.
        /// </summary>
        /// <value>The on client move start.</value>
        [Category("GoogleEvents")]
        public string OnClientMoveStart {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventMoveStart, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client overlay add.
        /// </summary>
        /// <value>The on client overlay add.</value>
        [Category("GoogleEvents")]
        public string OnClientOverlayAdd {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventAddOverlay, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client overlay remove.
        /// </summary>
        /// <value>The on client overlay remove.</value>
        [Category("GoogleEvents")]
        public string OnClientOverlayRemove {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventRemoveOverlay, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client overlays clear.
        /// </summary>
        /// <value>The on client overlays clear.</value>
        [Category("GoogleEvents")]
        public string OnClientOverlaysClear {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventClearOverlays, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client rotatability changed.
        /// </summary>
        /// <value>The on client rotatability changed.</value>
        [Category("GoogleEvents")]
        public string OnClientRotatabilityChanged {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventRotatabilityChanged, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client single right click.
        /// </summary>
        /// <value>The on client single right click.</value>
        [Category("GoogleEvents")]
        public string OnClientSingleRightClick {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventSingleRightClick, value);
            }
        }

        /// <summary>
        /// This event is fired when all visible tiles have finished loading.
        /// </summary>
        /// <value>The on client tiles loaded.</value>
        [Category("GoogleEvents")]
        public string OnClientTilesLoaded {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventTilesLoaded, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client zoom end.
        /// </summary>
        /// <value>The on client zoom end.</value>
        [Category("GoogleEvents")]
        public string OnClientZoomEnd {
            set {
                MapEvents.AddClientHandler(GoogleEventList.EventZoomEnd, value);
            }
        }
        #endregion

        #region Events ////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Occurs when [address not found].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleAddressEventArgs> AddressNotFound {
            add {
                MapEvents.AddServerHandler<GoogleAddressEventArgs>(GoogleEventList.EventAddressNotFound, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleAddressEventArgs>(GoogleEventList.EventAddressNotFound, value);
            }
        }

        /// <summary>
        /// Occurs when [click].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleLocationEventArgs> Click {
            add {
                MapEvents.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventClick, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventClick, value);
            }
        }

        /// <summary>
        /// Occurs when [double click].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleLocationEventArgs> DoubleClick {
            add {
                MapEvents.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventDoubleClick, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventDoubleClick, value);
            }
        }

        /// <summary>
        /// Occurs when [drag].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> Drag {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventDrag, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventDrag, value);
            }
        }

        /// <summary>
        /// Occurs when [drag end].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleBoundsEventArgs> DragEnd {
            add {
                MapEvents.AddServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragEnd, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragEnd, value);
            }
        }

        /// <summary>
        /// Occurs when [drag start].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleBoundsEventArgs> DragStart {
            add {
                MapEvents.AddServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragStart, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragStart, value);
            }
        }

        /// <summary>
        /// Occurs when [geo location loaded].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleAddressEventArgs> GeoLocationLoaded {
            add {
                MapEvents.AddServerHandler<GoogleAddressEventArgs>(GoogleEventList.EventGeoLocationLoaded, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleAddressEventArgs>(GoogleEventList.EventGeoLocationLoaded, value);
            }
        }

        /// <summary>
        /// This event is fired when the current GMapType of the map has been changed to one with a different heading.
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> HeadingChanged {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventHeadingChanged, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventHeadingChanged, value);
            }
        }

        /// <summary>
        /// Occurs when [info window before close].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> InfoWindowBeforeClose {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowBeforeClose, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowBeforeClose, value);
            }
        }

        /// <summary>
        /// Occurs when [info window close].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> InfoWindowClose {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowClose, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowClose, value);
            }
        }

        /// <summary>
        /// Occurs when [info window open].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> InfoWindowOpen {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowOpen, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowOpen, value);
            }
        }

        /// <summary>
        /// Occurs when [location loaded].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleAddressEventArgs> LocationLoaded {
            add {
                MapEvents.AddServerHandler<GoogleAddressEventArgs>(GoogleEventList.EventLocationLoaded, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleAddressEventArgs>(GoogleEventList.EventLocationLoaded, value);
            }
        }

        /// <summary>
        /// Occurs when [map load].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> MapLoad {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventLoad, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventLoad, value);
            }
        }

        /// <summary>
        /// This event is fired when a map type is added to the map.
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> MapTypeAdd {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventAddMapType, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventAddMapType, value);
            }
        }

        /// <summary>
        /// Occurs when [map type changed].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> MapTypeChanged {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventMapTypeChanged, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventMapTypeChanged, value);
            }
        }

        /// <summary>
        /// This event is fired when a map type is removed from the map.
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> MapTypeRemove {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventRemoveMapType, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventRemoveMapType, value);
            }
        }

        /// <summary>
        /// Occurs when [mouse move].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleLocationEventArgs> MouseMove {
            add {
                MapEvents.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseMove, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseMove, value);
            }
        }

        /// <summary>
        /// Occurs when [mouse out].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleLocationEventArgs> MouseOut {
            add {
                MapEvents.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOut, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOut, value);
            }
        }

        /// <summary>
        /// Occurs when [mouse over].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleLocationEventArgs> MouseOver {
            add {
                MapEvents.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOver, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOver, value);
            }
        }

        /// <summary>
        /// Occurs when [move].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> Move {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventMove, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventMove, value);
            }
        }

        /// <summary>
        /// Occurs when [move end].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> MoveEnd {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventMoveEnd, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventMoveEnd, value);
            }
        }

        /// <summary>
        /// Occurs when [move start].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> MoveStart {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventMoveStart, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventMoveStart, value);
            }
        }

        /// <summary>
        /// Occurs when [overlay add].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> OverlayAdd {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventAddOverlay, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventAddOverlay, value);
            }
        }

        /// <summary>
        /// Occurs when [overlay remove].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> OverlayRemove {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventRemoveOverlay, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventRemoveOverlay, value);
            }
        }

        /// <summary>
        /// Occurs when [overlays clear].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> OverlaysClear {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventClearOverlays, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventClearOverlays, value);
            }
        }

        /// <summary>
        /// This event is fired when the rotatability of the map has been changed. 
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> RotatabilityChanged {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventRotatabilityChanged, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventRotatabilityChanged, value);
            }
        }

        /// <summary>
        /// Occurs when [single right click].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleLocationEventArgs> SingleRightClick {
            add {
                MapEvents.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventSingleRightClick, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventSingleRightClick, value);
            }
        }

        /// <summary>
        /// This event is fired when all visible tiles have finished loading. 
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleEventArgs> TilesLoaded {
            add {
                MapEvents.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventTilesLoaded, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventTilesLoaded, value);
            }
        }

        /// <summary>
        /// Occurs when [zoom end].
        /// </summary>
        [Category("Google")]
        public event EventHandler<GoogleZoomEventArgs> ZoomEnd {
            add {
                MapEvents.AddServerHandler<GoogleZoomEventArgs>(GoogleEventList.EventZoomEnd, value);
            }
            remove {
                MapEvents.RemoveServerHandler<GoogleZoomEventArgs>(GoogleEventList.EventZoomEnd, value);
            }
        }
        #endregion
    }
}
