using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class GooglePolygonEvents : GoogleEventList {

        #region Client Events /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the on client cancel line.
        /// </summary>
        /// <value>The on client cancel line.</value>
        public string OnClientCancelLine {
            set {
                this.AddClientHandler(GoogleEventList.EventCancelLine, value);
            }
        }

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
        /// Gets or sets the on client end line.
        /// </summary>
        /// <value>The on client end line.</value>
        public string OnClientEndLine {
            set {
                this.AddClientHandler(GoogleEventList.EventEndLine, value);
            }
        }

        /// <summary>
        /// Gets or sets the on client line updated.
        /// </summary>
        /// <value>The on client line updated.</value>
        public string OnClientLineUpdated {
            set {
                this.AddClientHandler(GoogleEventList.EventLineUpdated, value);
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
        /// Occurs when [cancel line].
        /// </summary>
        public event EventHandler<GoogleEventArgs> CancelLine {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventCancelLine, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventCancelLine, value);
            }
        }

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
        /// Occurs when [end line].
        /// </summary>
        public event EventHandler<GoogleEventArgs> EndLine {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventEndLine, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventEndLine, value);
            }
        }

        /// <summary>
        /// Occurs when [line updated].
        /// </summary>
        public event EventHandler<GoogleEventArgs> LineUpdated {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventLineUpdated, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventLineUpdated, value);
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