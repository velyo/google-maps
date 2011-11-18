using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace Artem.Google.UI {

    /// <summary>
    /// Defines an image to be used as the icon or shadow for a Marker. 
    /// 'origin' and 'size' are used to select a segment of a sprite image and 'anchor' 
    /// overrides the position of the anchor point from its default bottom middle position. 
    /// The anchor of an image is the pixel to which the system refers in tracking the image's position. 
    /// By default, the anchor is set to the bottom middle of the image (coordinates width/2, height). 
    /// So when a marker is placed at a given LatLng, the pixel defined as the anchor is positioned at the specified LatLng. 
    /// To scale the image, whether sprited or not, set the value of scaledSize to the size of the whole image and set size, 
    /// origin and anchor in scaled values. The MarkerImage cannot be changed once constructed. 
    /// </summary>
    public class MarkerImage : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.UI.MarkerImage"/>.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MarkerImage(string url) {
            return new MarkerImage { Url = url };
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Artem.Google.UI.MarkerImage"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(MarkerImage image) {
            return (image != null) ? image.Url : null;
        }

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static MarkerImage FromScriptData(object scriptObject) {

            var data = scriptObject as IDictionary<string, object>;
            if (data != null) {
                var result = new MarkerImage();
                object value;

                if (data.TryGetValue("anchor", out value))
                    result._anchor = Point.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("origin", out value))
                    result._origin = Point.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("scaledSize", out value))
                    result._scaledSize = Size.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("size", out value))
                    result._size = Size.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("url", out value)) result.Url = (string)value;

                return result;
            }
            return null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the anchor.
        /// </summary>
        /// <value>The anchor.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Point Anchor {
            get { return _anchor ?? (_anchor = new Point()); }
            set { _anchor = value; }
        }
        Point _anchor;

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>The origin.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Point Origin {
            get { return _origin ?? (_origin = new Point()); }
            set { _origin = value; }
        }
        Point _origin;

        /// <summary>
        /// Gets or sets the size of the scaled.
        /// </summary>
        /// <value>The size of the scaled.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Size ScaledSize {
            get { return _scaledSize ?? (_scaledSize = new Size()); }
            set { _scaledSize = value; }
        }
        Size _scaledSize;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Size Size {
            get { return _size ?? (_size = new Size()); }
            set { _size = value; }
        }
        Size _size;

        /// <summary>
        /// The URL of the marker image.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerImage"/> class.
        /// </summary>
        public MarkerImage() {
            //this.Anchor = Point.DefaultMarkerIconAnchor;
            //this.Size = Size.DefaultMarkerIconSize;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData() {

            var result = new Dictionary<string, object>();

            if (_anchor != null) result["anchor"] = _anchor.ToScriptData();
            if (_origin != null) result["origin"] = _origin.ToScriptData();
            if (_scaledSize != null) result["scaledSize"] = _scaledSize.ToScriptData();
            if (_size != null) result["size"] = _size.ToScriptData();
            if (this.Url != null) result["url"] = this.Url;

            return result;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString() {
            return this.Url;
        }
        #endregion
    }
}
