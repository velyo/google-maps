using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    public class GoogleDirectionsEvents : GoogleEventList {

        #region Client Events /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// This event is triggered after the polyline and/or textual directions components are added 
        /// to the map and/or DIV elements. Note that the "addoverlay" event is not triggered 
        /// if neither of these elements are attached to a GDirections object. 
        /// This event is fired after the polyline and/or textual directions components are added 
        /// to hte map and/or DIV elements. 
        /// </summary>
        /// <value>The on client add overlay.</value>
        public string OnClientAddOverlay {
            set {
                this.AddClientHandler(GoogleEventList.EventAddOverlay, value);
            }
        }

        /// <summary>
        /// This event is triggered if a directions request results in an error. 
        /// Callers can use GDirections.getStatus() to get more information about the error. 
        /// When an "error" event occurs, no "load" or "addoverlay" events will be triggered. 
        /// </summary>
        /// <value>The on client error.</value>
        public string OnClientError {
            set {
                this.AddClientHandler(GoogleEventList.EventError, value);
            }
        }

        /// <summary>
        /// This event is triggered when the results of a directions query issued via GDirections.load() are available. 
        /// Note that the load() method initiates a new query, which in turn triggers a "load" event once the query has finished loading. 
        /// The "load" event is triggered before any overlay elements are added to the map/panel. 
        /// </summary>
        /// <value>The on client load.</value>
        public string OnClientLoad {
            set {
                this.AddClientHandler(GoogleEventList.EventLoad, value);
            }
        }
        #endregion

        #region Server Events /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Occurs after the polyline and/or textual directions components are added to the map 
        /// and/or DIV elements. Note that the "addoverlay" event is not triggered if neither 
        /// of these elements are attached to a GDirections object. 
        /// This event is fired after the polyline and/or textual directions components are added 
        /// to hte map and/or DIV elements. 
        /// </summary>
        public event EventHandler<GoogleEventArgs> AddOverlay {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventAddOverlay, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventAddOverlay, value);
            }
        }

        /// <summary>
        /// Occurs if a directions request results in an error. Callers can use GDirections.getStatus() 
        /// to get more information about the error. When an "error" event occurs, no "load" or "addoverlay" 
        /// events will be triggered. 
        /// </summary>
        public event EventHandler<GoogleEventArgs> Error {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventError, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventError, value);
            }
        }

        /// <summary>
        /// Occurs when the results of a directions query issued via GDirections.load() are available. 
        /// Note that the load() method initiates a new query, which in turn triggers a "load" event 
        /// once the query has finished loading. The "load" event is triggered before any overlay elements 
        /// are added to the map/panel. 
        /// </summary>
        public event EventHandler<GoogleEventArgs> Load {
            add {
                this.AddServerHandler<GoogleEventArgs>(GoogleEventList.EventLoad, value);
            }
            remove {
                this.RemoveServerHandler<GoogleEventArgs>(GoogleEventList.EventLoad, value);
            }
        }

        #endregion
    }
}
