using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GoogleBounds {

        #region Static Methods ////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(GoogleBounds a, GoogleBounds b) {
            return ((a.NorthEast == b.NorthEast) && (a.SouthWest == b.SouthWest));
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(GoogleBounds a, GoogleBounds b) {
            return !(a == b);
        }
        #endregion

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        private LatLng _southWest;
        private LatLng _northEast;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the south west.
        /// </summary>
        /// <value>The south west.</value>
        [DataMember]
        public LatLng SouthWest {
            get { return _southWest; }
            set { _southWest = value; }
        }

        /// <summary>
        /// Gets or sets the north east.
        /// </summary>
        /// <value>The north east.</value>
        [DataMember]
        public LatLng NorthEast {
            get { return _northEast; }
            set { _northEast = value; }
        }
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) {

            if (!(obj is GoogleBounds)) return false;
            GoogleBounds bounds = (GoogleBounds)obj;
            return ((bounds.NorthEast == this.NorthEast) && (bounds.SouthWest == this.SouthWest));
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

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return string.Format("SouthWest: {0}, NorthEast: {1}",
                this.SouthWest.ToString(), this.NorthEast.ToString());
        }
        #endregion
    }
}
