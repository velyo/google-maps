using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    public class BoundsEventArgs : EventArgs, IScriptDataConverter {

        #region Static Fields

        public static readonly BoundsEventArgs Empty = new BoundsEventArgs();

        #endregion

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static BoundsEventArgs FromScriptData(object value) {
            return new BoundsEventArgs(Bounds.FromScriptData(value));
        }
        #endregion  

        #region Properties

        public Bounds Bounds { get; protected set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundsEventArgs"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public BoundsEventArgs(Bounds bounds) {
            this.Bounds  = bounds;
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
            return this.Bounds.ToScriptData();
        }
        #endregion
    }
}
