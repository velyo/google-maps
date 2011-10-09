using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class GoogleDuration {

        #region Static Methods //////////////////////////////////////////////////////////

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(GoogleDuration a, GoogleDuration b) {
            return ((a.Seconds == b.Seconds) && (a.Html == b.Html));
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(GoogleDuration a, GoogleDuration b) {
            return !(a == b);
        }
        #endregion

        #region Fields  /////////////////////////////////////////////////////////////////

        public double Seconds;
        public string Html;

        #endregion

        #region Methods /////////////////////////////////////////////////////////////////

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) {

            if (!(obj is GoogleDuration)) return false;
            GoogleDuration dur = (GoogleDuration)obj;
            return ((dur.Seconds == this.Seconds) && (dur.Html == this.Html));
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        #endregion
    }
}
