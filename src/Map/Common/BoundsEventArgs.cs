using System;
using System.Collections.Generic;

namespace Velyo.Google.Map.UI
{
    /// <summary>
    /// Class for containing bounds event data.
    /// </summary>
    public class BoundsEventArgs : EventArgs, IScriptDataConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoundsEventArgs"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public BoundsEventArgs(Bounds bounds)
        {
            Bounds = bounds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundsEventArgs"/> class.
        /// </summary>
        public BoundsEventArgs() : this(null) { }


        /// <summary>
        /// The bounds data.
        /// </summary>
        /// <value>The bounds.</value>
        public Bounds Bounds { get; protected set; }


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The value.</param>
        /// <returns></returns>
        public static BoundsEventArgs FromScriptData(object scriptObject)
        {
            return new BoundsEventArgs(Bounds.FromScriptData(scriptObject));
        }

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            return (Bounds != null) ? Bounds.ToScriptData() : null;
        }
    }
}
