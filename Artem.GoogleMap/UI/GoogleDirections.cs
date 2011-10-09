using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace Artem.Google.UI {

    public enum TravelMode {
        Driving,
        Walking
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GoogleDirections {

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        IList<string> _actions;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the actions of the polygon.
        /// </summary>
        /// <value>The actions.</value>
        protected internal IList<string> Actions {
            get {
                if (_actions == null)
                    _actions = new List<string>();
                return _actions;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [avoid highways].
        /// If <code>true</code> directions will attempt to exclude highways when computing directions. 
        /// Note that directions may still include highways if there are no viable alternatives.
        /// </summary>
        /// <value><c>true</c> if [avoid highways]; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool AvoidHighways { get; set; }

        /// <summary>
        /// Gets or sets the bounds of this <see cref="GoogleDirections"/>.
        /// It is used to get the bounding box for the result of this directions query.
        /// Have in mind it requires an additional post back after driving location are loaded.
        /// </summary>
        /// <value>The bounds.</value>
        [DataMember]
        public GoogleBounds Bounds { get; set; }

        /// <summary>
        /// Gets or sets the distance of this <see cref="GoogleDirections"/>.
        /// </summary>
        /// <value>The distance.</value>
        [DataMember]
        public GoogleDistance Distance { get; set; }

        /// <summary>
        /// Gets or sets the duration of this <see cref="GoogleDirections"/>.
        /// </summary>
        /// <value>The duration.</value>
        [DataMember]
        public GoogleDuration Duration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [get polyline].
        /// By default, the GDirections.load*() methods fetch polyline data only if a map is attached to the GDirections object. 
        /// This field can be used to override this behavior and retrieve polyline data 
        /// even when a map is not attached to the Directions object.
        /// </summary>
        /// <value><c>true</c> if [get polyline]; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool? GetPolyline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [get steps].
        /// By default, the GDirections.load*() methods fetch steps data only if a panel is attached to the GDirections object. 
        /// This field can be used to override this behavior and retrieve steps data 
        /// even when a panel is not attached to the Directions object.
        /// </summary>
        /// <value><c>true</c> if [get steps]; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool? GetSteps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleDirections"/> is localized.
        /// The locale to use for the directions result. For example, "en_US", "fr", "fr_CA", etc.
        /// </summary>
        /// <value><c>true</c> if localized; otherwise, <c>false</c>.</value>
        [DataMember]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the query of <see cref="GoogleDirections"/>.
        /// The query parameter is a string containing any valid directions query, e.g. 
        /// "from: Seattle to: San Francisco" or "from: Toronto to: Ottawa to: New York". 
        /// </summary>
        /// <value>The query.</value>
        [DataMember]
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleDirections"/> should alter the viewport.
        /// When this option is set to true, the viewport is left alone for this request.
        /// </summary>
        /// <value><c>true</c> to preserve; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool PreserveViewport { get; set; }

        /// <summary>
        /// Gets or sets the route panel id.
        /// </summary>
        /// <value>The route panel id.</value>
        [DataMember]
        public string RoutePanelId { get; set; }

        /// <summary>
        /// Gets or sets the travel mode.
        /// The mode of travel, such as driving (default) or walking. 
        /// Note that if you specify walking directions, 
        /// you will need to specify a <div> panel to hold a warning notice to users.
        /// </summary>
        /// <value>The travel mode.</value>
        [DataMember]
        public TravelMode TravelMode { get; set; }

        #endregion

        #region Construct  //////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="routePanelId">The route panel id.</param>
        /// <param name="locale">The locale.</param>
        /// <param name="preserveViewport">if set to <c>true</c> [preserve viewport].</param>
        public GoogleDirections(string query, string routePanelId, string locale, bool preserveViewport) {
            this.Query = query;
            this.RoutePanelId = routePanelId;
            this.Locale = (locale != null) ? locale : "en_US";
            this.PreserveViewport = preserveViewport;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="routePanelId">The route panel id.</param>
        /// <param name="locale">The locale.</param>
        public GoogleDirections(string query, string routePanelId, string locale)
            : this(query, routePanelId, locale, false) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="routePanelId">The route panel id.</param>
        public GoogleDirections(string query, string routePanelId)
            : this(query, routePanelId, null, false) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public GoogleDirections(string query)
            : this(query, null, null, false) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleDirections"/> class.
        /// </summary>
        public GoogleDirections()
            : this(null, null, null, false) {
        }
        #endregion

        #region Methods /////////////////////////////////////////////////////////////////
        #endregion
    }
}
