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
    public class MarkerImage : ISelfConverter {

        #region Static Methods

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Artem.Google.UI.MarkerImage"/>.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MarkerImage(string url) {
            return new MarkerImage { Url = url };
        }

        public static implicit operator string(MarkerImage image) {
            return (image != null) ? image.Url : null;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the anchor.
        /// </summary>
        /// <value>The anchor.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Point Anchor { get; set; }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>The origin.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Point Origin { get; set; }

        /// <summary>
        /// Gets or sets the size of the scaled.
        /// </summary>
        /// <value>The size of the scaled.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Size ScaledSize { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public Size Size { get; set; }

        /// <summary>
        /// The URL of the marker image.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        #endregion

        #region Ctor

        public MarkerImage() {
            this.Anchor = Point.DefaultMarkerIconAnchor;
            this.Size = Size.DefaultMarkerIconSize;
        }
        #endregion

        #region Methods

        public IDictionary<string, object> ToDictionary() {

            var result = new Dictionary<string, object>();

            if (this.Anchor != null)
                result["anchor"] = this.Anchor.ToDictionary();
            if(this.Origin != null)
                result["origin"] = this.Origin.ToDictionary();
            if(this.ScaledSize != null)
                result["scaledSize"] = this.ScaledSize.ToDictionary();
            if(this.Size != null)
                result["size"] = this.Size.ToDictionary();
            if (this.Url != null)
                result["url"] = this.Url;

            return result;
        }
        #endregion
    }
}
