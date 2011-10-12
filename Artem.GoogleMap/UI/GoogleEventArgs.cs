using System;
using System.Collections.Generic;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class GoogleEventArgs : EventArgs {

        #region Static Fields /////////////////////////////////////////////////////////////////////

        public static readonly new GoogleEventArgs Empty = new GoogleEventArgs();

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class GoogleAddressEventArgs : GoogleEventArgs {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleAddressEventArgs"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public GoogleAddressEventArgs(string address) {
            this.Address = address;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleAddressEventArgs"/> class.
        /// </summary>
        public GoogleAddressEventArgs() {
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class GoogleBoundsEventArgs : GoogleEventArgs {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public GoogleBounds Bounds { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleBoundsEventArgs"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public GoogleBoundsEventArgs(GoogleBounds bounds) {
            this.Bounds = bounds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleBoundsEventArgs"/> class.
        /// </summary>
        public GoogleBoundsEventArgs() {
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class GoogleLocationEventArgs : GoogleEventArgs {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public Location Location { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleLocationEventArgs"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        public GoogleLocationEventArgs(Location location) {
            this.Location = location;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleLocationEventArgs"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        public GoogleLocationEventArgs(string location)
            : this(Location.Parse(location)) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleLocationEventArgs"/> class.
        /// </summary>
        public GoogleLocationEventArgs() {
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class GoogleVisibilityEventArgs : GoogleEventArgs {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleVisibilityEventArgs"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleVisibilityEventArgs"/> class.
        /// </summary>
        /// <param name="visible">if set to <c>true</c> [visible].</param>
        public GoogleVisibilityEventArgs(bool visible) {
            this.Visible = visible;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleVisibilityEventArgs"/> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public GoogleVisibilityEventArgs(string args) {

            bool flag = false;
            if (bool.TryParse(args, out flag))
                this.Visible = flag;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleVisibilityEventArgs"/> class.
        /// </summary>
        public GoogleVisibilityEventArgs() {
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class GoogleZoomEventArgs : GoogleEventArgs {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets the new level.
        /// </summary>
        /// <value>The new level.</value>
        public double NewLevel { get; set; }

        /// <summary>
        /// Gets or sets the old level.
        /// </summary>
        /// <value>The old level.</value>
        public double OldLevel { get; set; }

        #endregion

        #region Construct /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleZoomEventArgs"/> class.
        /// </summary>
        /// <param name="newLevel">The new level.</param>
        /// <param name="oldLevel">The old level.</param>
        public GoogleZoomEventArgs(double newLevel, double oldLevel) {
            this.NewLevel = newLevel;
            this.OldLevel = oldLevel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleZoomEventArgs"/> class.
        /// </summary>
        /// <param name="args">The args.</param>
        public GoogleZoomEventArgs(string args) {
            // TODO
            throw new NotImplementedException();
            //this.NewLevel = 0D;
            //this.OldLevel = 0D;

            //if (!string.IsNullOrEmpty(args)) {
            //    args = args.Trim('(', ')');
            //    string[] pair = args.Split(',');
            //    if (pair.Length >= 2) {
            //        this.OldLevel = JsUtil.ToDouble(pair[0]);
            //        this.NewLevel = JsUtil.ToDouble(pair[1]);
            //    }
            //}
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleZoomEventArgs"/> class.
        /// </summary>
        public GoogleZoomEventArgs() {
        }
        #endregion
    }
}
