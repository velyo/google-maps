using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class GoogleEventList {

        #region Static Fields /////////////////////////////////////////////////////////////////////

        public const string EventAddMapType = "addmaptype";
        public const string EventAddOverlay = "addoverlay";
        public const string EventAddressNotFound = "addressnotfound";
        public const string EventCancelLine = "cancelline";
        public const string EventClearOverlays = "clearoverlays";
        public const string EventClick = "click";
        public const string EventDoubleClick = "dblclick";
        public const string EventDrag = "drag";
        public const string EventDragEnd = "dragend";
        public const string EventDragStart = "dragstart";
        public const string EventEndLine = "endline";
        public const string EventError = "error";
        public const string EventGeoLocationLoaded = "geoload";
        public const string EventHeadingChanged = "headingchanged";
        public const string EventInfoWindowBeforeClose = "infowindowbeforeclose";
        public const string EventInfoWindowClose = "infowindowclose";
        public const string EventInfoWindowOpen = "infowindowopen";
        public const string EventLineUpdated = "lineupdated";
        public const string EventLoad = "load";
        public const string EventLocationLoaded = "locationloaded";
        public const string EventMapTypeChanged = "maptypechanged";
        public const string EventMouseDown = "mousedown";
        public const string EventMouseMove = "mousemove";
        public const string EventMouseOut = "mouseout";
        public const string EventMouseOver = "mouseover";
        public const string EventMouseUp = "mouseup";
        public const string EventMove = "move";
        public const string EventMoveEnd = "moveend";
        public const string EventMoveStart = "movestart";
        public const string EventRemove = "remove";
        public const string EventRemoveMapType = "removemaptype";
        public const string EventRemoveOverlay = "removeoverlay";
        public const string EventRotatabilityChanged = "rotatabilitychanged";
        public const string EventSingleRightClick = "singlerightclick";
        public const string EventTilesLoaded = "tilesloaded";
        public const string EventVisibilityChanged = "visibilitychanged";
        public const string EventZoomEnd = "zoomend";

        static readonly string ServerHandlerName = "Artem.Google.serverHandler";

        #endregion

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        EventHandlerList _events;
        Dictionary<string, IList<string>> _registry;
        JavaScriptSerializer _serializer;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

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

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty {
            get {
                return (_registry == null || _registry.Count == 0);
            }
        }

        /// <summary>
        /// Gets the registry.
        /// </summary>
        /// <value>The registry.</value>
        public IDictionary<string, IList<string>> Registry {
            get {
                return _registry ?? (_registry = new Dictionary<string, IList<string>>());
            }
        }
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Adds the client handler.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="handler">The handler.</param>
        public void AddClientHandler(string name, string handler) {
            this.Register(name, handler);
        }

        /// <summary>
        /// Adds the server handler.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="handler">The handler.</param>
        public void AddServerHandler(string name, EventHandler handler) {
            this.Events.AddHandler(name, handler);
            this.Register(name, ServerHandlerName);
        }

        /// <summary>
        /// Adds the server handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="handler">The handler.</param>
        public void AddServerHandler<T>(string name, EventHandler<T> handler) where T : EventArgs {
            this.Events.AddHandler(name, handler);
            this.Register(name, ServerHandlerName);
        }

        /// <summary>
        /// Removes the server handler.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="handler">The handler.</param>
        public void RemoveServerHandler(string name, EventHandler handler) {
            this.Events.RemoveHandler(name, handler);
            this.UnRegister(name, ServerHandlerName);
        }

        /// <summary>
        /// Removes the server handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="handler">The handler.</param>
        public void RemoveServerHandler<T>(string name, EventHandler<T> handler) where T : EventArgs {
            this.Events.RemoveHandler(name, handler);
            this.UnRegister(name, ServerHandlerName);
        }

        /// <summary>
        /// Registers the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="handler">The handler.</param>
        protected void Register(string name, string handler) {
            if (!this.Registry.ContainsKey(name)) this.Registry[name] = new List<string>();
            if (!this.Registry[name].Contains(handler)) this.Registry[name].Add(handler);
        }

        /// <summary>
        /// Uns the register.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="handler">The handler.</param>
        protected void UnRegister(string name, string handler) {
            if (this.Registry.ContainsKey(name)) 
                if (this.Registry[name].Contains(handler)) this.Registry[name].Remove(handler);
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="key">The key.</param>
        protected internal virtual void RaiseEvent(object sender, string key, string args) {

            Delegate handler = null;
            EventArgs e = GoogleEventArgs.Empty;
            switch (key) {
                case GoogleEventList.EventAddMapType:
                    handler = Events[GoogleEventList.EventAddMapType];
                    break;
                case GoogleEventList.EventAddOverlay:
                    handler = Events[GoogleEventList.EventAddOverlay];
                    break;
                case GoogleEventList.EventAddressNotFound:
                    handler = Events[GoogleEventList.EventAddressNotFound];
                    e = this.Serializer.Deserialize<GoogleAddressEventArgs>(args);
                    break;
                case GoogleEventList.EventCancelLine:
                    handler = Events[GoogleEventList.EventCancelLine];
                    break;
                case GoogleEventList.EventClearOverlays:
                    handler = Events[GoogleEventList.EventClearOverlays];
                    break;
                case GoogleEventList.EventClick:
                    handler = Events[GoogleEventList.EventClick];
                    e = this.Serializer.Deserialize<GoogleLocationEventArgs>(args);
                    break;
                case GoogleEventList.EventDoubleClick:
                    handler = Events[GoogleEventList.EventDoubleClick];
                    e = this.Serializer.Deserialize<GoogleLocationEventArgs>(args);
                    break;
                case GoogleEventList.EventDrag:
                    handler = Events[GoogleEventList.EventDrag];
                    break;
                case GoogleEventList.EventDragEnd:
                    handler = Events[GoogleEventList.EventDragEnd];
                    e = this.Serializer.Deserialize<GoogleBoundsEventArgs>(args);
                    break;
                case GoogleEventList.EventDragStart:
                    handler = Events[GoogleEventList.EventDragStart];
                    e = this.Serializer.Deserialize<GoogleBoundsEventArgs>(args);
                    break;
                case GoogleEventList.EventEndLine:
                    handler = Events[GoogleEventList.EventEndLine];
                    break;
                case GoogleEventList.EventGeoLocationLoaded:
                    handler = Events[GoogleEventList.EventGeoLocationLoaded];
                    e = this.Serializer.Deserialize<GoogleAddressEventArgs>(args);
                    break;
                case GoogleEventList.EventHeadingChanged:
                    handler = Events[GoogleEventList.EventHeadingChanged];
                    break;
                case GoogleEventList.EventInfoWindowBeforeClose:
                    handler = Events[GoogleEventList.EventInfoWindowBeforeClose];
                    break;
                case GoogleEventList.EventInfoWindowClose:
                    handler = Events[GoogleEventList.EventInfoWindowClose];
                    break;
                case GoogleEventList.EventInfoWindowOpen:
                    handler = Events[GoogleEventList.EventInfoWindowOpen];
                    break;
                case GoogleEventList.EventLineUpdated:
                    handler = Events[GoogleEventList.EventLineUpdated];
                    break;
                case GoogleEventList.EventLoad:
                    handler = Events[GoogleEventList.EventLoad];
                    break;
                case GoogleEventList.EventLocationLoaded:
                    handler = Events[GoogleEventList.EventLocationLoaded];
                    e = this.Serializer.Deserialize<GoogleAddressEventArgs>(args);
                    break;
                case GoogleEventList.EventMapTypeChanged:
                    handler = Events[GoogleEventList.EventMapTypeChanged];
                    break;
                case GoogleEventList.EventMouseDown:
                    handler = Events[GoogleEventList.EventMouseDown];
                    e = this.Serializer.Deserialize<GoogleLocationEventArgs>(args);
                    break;
                case GoogleEventList.EventMouseMove:
                    handler = Events[GoogleEventList.EventMouseMove];
                    e = this.Serializer.Deserialize<GoogleLocationEventArgs>(args);
                    break;
                case GoogleEventList.EventMouseOut:
                    handler = Events[GoogleEventList.EventMouseOut];
                    e = this.Serializer.Deserialize<GoogleLocationEventArgs>(args);
                    break;
                case GoogleEventList.EventMouseOver:
                    handler = Events[GoogleEventList.EventMouseOver];
                    e = new GoogleLocationEventArgs(args);
                    break;
                case GoogleEventList.EventMouseUp:
                    handler = Events[GoogleEventList.EventMouseUp];
                    e = new GoogleLocationEventArgs(args);
                    break;
                case GoogleEventList.EventMove:
                    handler = Events[GoogleEventList.EventMove];
                    e = new GoogleEventArgs();
                    break;
                case GoogleEventList.EventMoveEnd:
                    handler = Events[GoogleEventList.EventMoveEnd];
                    e = new GoogleEventArgs();
                    break;
                case GoogleEventList.EventMoveStart:
                    handler = Events[GoogleEventList.EventMoveStart];
                    e = new GoogleEventArgs();
                    break;
                case GoogleEventList.EventRemove:
                    handler = Events[GoogleEventList.EventRemove];
                    break;
                case GoogleEventList.EventRemoveMapType:
                    handler = Events[GoogleEventList.EventRemoveMapType];
                    break;
                case GoogleEventList.EventRemoveOverlay:
                    handler = Events[GoogleEventList.EventRemoveOverlay];
                    break;
                case GoogleEventList.EventRotatabilityChanged:
                    handler = Events[GoogleEventList.EventRotatabilityChanged];
                    break;
                case GoogleEventList.EventSingleRightClick:
                    handler = Events[GoogleEventList.EventSingleRightClick];
                    e = new GoogleLocationEventArgs(args);
                    break;
                case GoogleEventList.EventTilesLoaded:
                    handler = Events[GoogleEventList.EventTilesLoaded];
                    break;
                case GoogleEventList.EventZoomEnd:
                    handler = Events[GoogleEventList.EventZoomEnd];
                    e = new GoogleZoomEventArgs(args);
                    break;
                case GoogleEventList.EventVisibilityChanged:
                    handler = Events[GoogleEventList.EventVisibilityChanged];
                    e = new GoogleVisibilityEventArgs(args);
                    break;
            }

            if (handler != null) handler.DynamicInvoke(sender, e);
        }
        #endregion
    }
}