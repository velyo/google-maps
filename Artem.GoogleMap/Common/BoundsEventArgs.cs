using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// Class for containing bounds event data.
    /// </summary>
    public class BoundsEventArgs : EventArgs, IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The value.</param>
        /// <returns></returns>
        public static BoundsEventArgs FromScriptData(object scriptObject) {
            return new BoundsEventArgs(Bounds.FromScriptData(scriptObject));
        }
        #endregion

        #region Properties

        /// <summary>
        /// The bounds data.
        /// </summary>
        /// <value>The bounds.</value>
        public Bounds Bounds { get; protected set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundsEventArgs"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public BoundsEventArgs(Bounds bounds) {
            this.Bounds = bounds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundsEventArgs"/> class.
        /// </summary>
        public BoundsEventArgs()
            : this(null) {
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {
            return (this.Bounds != null) ? this.Bounds.ToScriptData() : null;
        }
        #endregion
    }
}
