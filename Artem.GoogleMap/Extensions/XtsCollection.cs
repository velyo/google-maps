using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Collections {

    /// <summary>
    /// 
    /// </summary>
    internal static class XtsCollection {

        #region Static Methods ////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Determines whether [is null or empty] [the specified collection].
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>
        /// 	<c>true</c> if [is null or empty] [the specified collection]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this ICollection collection) {
            return ((collection == null) || (collection.Count == 0));
        }

        /// <summary>
        /// Determines whether [is not null or empty] [the specified collection].
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>
        /// 	<c>true</c> if [is not null or empty] [the specified collection]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty(this ICollection collection) {
            return !IsNullOrEmpty(collection);
        }
        #endregion
    }
}
