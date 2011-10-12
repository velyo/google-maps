using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Artem.Google.Serialization;

namespace Artem.Google.UI {

    public class PolylineOptions : ISelfConverter {

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PolylineOptions"/> is clickable.
        /// Indicates whether this Polyline handles click events. Defaults to true.
        /// </summary>
        /// <value><c>true</c> if clickable; otherwise, <c>false</c>.</value>
        public bool Clickable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PolylineOptions"/> is geodesic.
        /// Render each edge as a geodesic (a segment of a "great circle"). A geodesic is the shortest path between two points along the surface of the Earth.
        /// </summary>
        /// <value><c>true</c> if geodesic; otherwise, <c>false</c>.</value>
        public bool Geodesic { get; set; }

        // TODO
        ///// <summary>
        ///// The ordered sequence of coordinates of the Polyline. 
        ///// This path may be specified using either a simple array of LatLngs. 
        ///// </summary>
        ///// <value>The path.</value>
        //public LatLng[] Path { get; set; }

        /// <summary>
        /// The stroke color. All CSS3 colors are supported except for extended named colors.
        /// </summary>
        /// <value>The color of the stroke.</value>
        public string StrokeColor { get; set; }

        /// <summary>
        /// The stroke opacity between 0.0 and 1.0
        /// </summary>
        /// <value>The stroke opacity.</value>
        public float StrokeOpacity { get; set; }

        /// <summary>
        /// The stroke width in pixels.
        /// </summary>
        /// <value>The stroke weight.</value>
        public int StrokeWeight { get; set; }

        /// <summary>
        /// The zIndex compared to other polys
        /// </summary>
        /// <value>The index.</value>
        public int ZIndex { get; set; }

        #endregion

        #region Ctor

        public PolylineOptions() {
            this.Clickable = true;
            this.StrokeOpacity = 1;
            this.StrokeWeight = 1;
            this.ZIndex = 1;
        }
        #endregion

        #region Methods

        public IDictionary<string, object> ToDictionary() {

            var result = new Dictionary<string, object>();

            result["clickable"] = Clickable;
            result["geodesic"] = Geodesic;
            if (StrokeColor != null)
                result["strokeColor"] = StrokeColor;
            if (StrokeOpacity >= 0 && StrokeOpacity <= 1)
                result["strokeOpacity"] = StrokeOpacity;
            result["strokeWeight"] = StrokeWeight;
            result["zIndex"] = ZIndex;

            return result;
        }
        #endregion
    }
}
