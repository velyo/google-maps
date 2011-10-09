using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public partial class GoogleMarkerEvents : GoogleEventList {

        #region Client Events /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the on client click.
        /// </summary>
        /// <value>The on client click.</value>
        public string OnClientClick {
            set {
                this.AddClientHandler(GoogleEventList.EventClick, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client double click.
        /// </summary>
        /// <value>The on client double click.</value>
        public string OnClientDoubleClick {
            set {
                this.AddClientHandler(GoogleEventList.EventDoubleClick, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client drag.
        /// </summary>
        /// <value>The on client drag.</value>
        public string OnClientDrag {
            set {
                this.AddClientHandler(GoogleEventList.EventDrag, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client drag end.
        /// </summary>
        /// <value>The on client drag end.</value>
        public string OnClientDragEnd {
            set {
                this.AddClientHandler(GoogleEventList.EventDragEnd, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client drag start.
        /// </summary>
        /// <value>The on client drag start.</value>
        public string OnClientDragStart {
            set {
                this.AddClientHandler(GoogleEventList.EventDragStart, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client geo location loaded.
        /// </summary>
        /// <value>The on client geo location loaded.</value>
        public string OnClientGeoLocationLoaded {
            set {
                this.AddClientHandler(GoogleEventList.EventGeoLocationLoaded, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client info window open.
        /// </summary>
        /// <value>The on client info window open.</value>
        public string OnClientInfoWindowOpen {
            set {
                this.AddClientHandler(GoogleEventList.EventInfoWindowOpen, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client info window before close.
        /// </summary>
        /// <value>The on client info window before close.</value>
        public string OnClientInfoWindowBeforeClose {
            set {
                this.AddClientHandler(GoogleEventList.EventInfoWindowBeforeClose, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client info window close.
        /// </summary>
        /// <value>The on client info window close.</value>
        public string OnClientInfoWindowClose {
            set {
                this.AddClientHandler(GoogleEventList.EventInfoWindowClose, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client mouse down.
        /// </summary>
        /// <value>The on client mouse down.</value>
        public string OnClientMouseDown {
            set {
                this.AddClientHandler(GoogleEventList.EventMouseDown, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client mouse out.
        /// </summary>
        /// <value>The on client mouse out.</value>
        public string OnClientMouseOut {
            set {
                this.AddClientHandler(GoogleEventList.EventMouseOut, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client mouse over.
        /// </summary>
        /// <value>The on client mouse over.</value>
        public string OnClientMouseOver {
            set {
                this.AddClientHandler(GoogleEventList.EventMouseOver, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client mouse up.
        /// </summary>
        /// <value>The on client mouse up.</value>
        public string OnClientMouseUp {
            set {
                this.AddClientHandler(GoogleEventList.EventMouseUp, value);
            }
        }


        /// <summary>
        /// Gets or sets the on client remove.
        /// </summary>
        /// <value>The on client remove.</value>
        public string OnClientRemove {
            set {
                this.AddClientHandler(GoogleEventList.EventRemove, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client visibility changed.
        /// </summary>
        /// <value>The on client visibility changed.</value>
        public string OnClientVisibilityChanged {
            set {
                this.AddClientHandler(GoogleEventList.EventVisibilityChanged, value);
            }
        }
        #endregion

        #region Server Events /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Occurs when [click].
        /// </summary>
        public event EventHandler<GoogleLocationEventArgs> Click {
            add {
                this.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventClick, value);
            }
            remove {
                this.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventClick, value);
            }
        }

        /// <summary>
        /// Occurs when [double click].
        /// </summary>
        public event EventHandler<GoogleLocationEventArgs> DoubleClick {
            add {
                this.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventDoubleClick, value);
            }
            remove {
                this.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventDoubleClick, value);
            }
        }

        /// <summary>
        /// Occurs when [drag].
        /// </summary>
        public event EventHandler<GoogleBoundsEventArgs> Drag {
            add {
                this.AddServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDrag, value);
            }
            remove {
                this.RemoveServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDrag, value);
            }
        }

        /// <summary>
        /// Occurs when [drag end].
        /// </summary>
        public event EventHandler<GoogleBoundsEventArgs> DragEnd {
            add {
                this.AddServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragEnd, value);
            }
            remove {
                this.RemoveServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragEnd, value);
            }
        }

        /// <summary>
        /// Occurs when [drag start].
        /// </summary>
        public event EventHandler<GoogleBoundsEventArgs> DragStart {
            add {
                this.AddServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragStart, value);
            }
            remove {
                this.RemoveServerHandler<GoogleBoundsEventArgs>(GoogleEventList.EventDragStart, value);
            }
        }

        /// <summary>
        /// Occurs when [geo location loaded].
        /// </summary>
        public event EventHandler<GoogleEventArgs> GeoLocationLoaded {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventGeoLocationLoaded, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventGeoLocationLoaded, value);
            }
        }

        /// <summary>
        /// Occurs when [info window before close].
        /// </summary>
        public event EventHandler<GoogleEventArgs> InfoWindowBeforeClose {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowBeforeClose, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowBeforeClose, value);
            }
        }

        /// <summary>
        /// Occurs when [info window close].
        /// </summary>
        public event EventHandler<GoogleEventArgs> InfoWindowClose {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowClose, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowClose, value);
            }
        }

        /// <summary>
        /// Occurs when [info window open].
        /// </summary>
        public event EventHandler<GoogleEventArgs> InfoWindowOpen {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowOpen, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventInfoWindowOpen, value);
            }
        }

        /// <summary>
        /// Occurs when [mouse down].
        /// </summary>
        public event EventHandler<GoogleLocationEventArgs> MouseDown {
            add {
                this.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseDown, value);
            }
            remove {
                this.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseDown, value);
            }
        }

        /// <summary>
        /// Occurs when [mouse out].
        /// </summary>
        public event EventHandler<GoogleLocationEventArgs> MouseOut {
            add {
                this.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOut, value);
            }
            remove {
                this.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOut, value);
            }
        }

        /// <summary>
        /// Occurs when [mouse over].
        /// </summary>
        public event EventHandler<GoogleLocationEventArgs> MouseOver {
            add {
                this.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOver, value);
            }
            remove {
                this.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseOver, value);
            }
        }

        /// <summary>
        /// Occurs when [mouse up].
        /// </summary>
        public event EventHandler<GoogleLocationEventArgs> MouseUp {
            add {
                this.AddServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseUp, value);
            }
            remove {
                this.RemoveServerHandler<GoogleLocationEventArgs>(GoogleEventList.EventMouseUp, value);
            }
        }

        /// <summary>
        /// Occurs when [remove].
        /// </summary>
        public event EventHandler<GoogleEventArgs> Remove {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventRemove, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventRemove, value);
            }
        }

        /// <summary>
        /// Occurs when [visibility changed].
        /// </summary>
        public event EventHandler<GoogleVisibilityEventArgs> VisibilityChanged {
            add {
                this.AddServerHandler<GoogleVisibilityEventArgs>(GoogleEventList.EventVisibilityChanged, value);
            }
            remove {
                this.RemoveServerHandler<GoogleVisibilityEventArgs>(GoogleEventList.EventVisibilityChanged, value);
            }
        }
        #endregion
    }
}
