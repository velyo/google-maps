using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public abstract class Overlay : ExtenderControl, IPostBackEventHandler {

        #region Properties

        /// <summary>
        /// Indicates whether this Overlay handles click events. Defaults to true.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is clickable; otherwise, <c>false</c>.
        /// </value>
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Indicates whether this Overlay handles click events. Defaults to true.")]
        public bool Clickable { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// When implemented by a class, enables a server control to process an event raised when a form is posted to the server.
        /// </summary>
        /// <param name="eventArgument">A <see cref="T:System.String"/> that represents an optional event argument to be passed to the event handler.</param>
        public abstract void RaisePostBackEvent(string eventArgument);

        #endregion
    }
}
