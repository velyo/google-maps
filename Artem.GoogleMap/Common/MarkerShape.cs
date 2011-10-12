using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public enum MarkerShapeType {
        /// <summary>
        Circle = 1,
        /// <summary>
        /// 
        /// </summary>
        Poly,
        /// <summary>
        /// 
        /// </summary>
        Rect
    }

    /// <summary>
    /// This object defines the marker shape to use in determination of a marker's clickable region. 
    /// The shape consists of two properties — type and coord — which define the general type of marker 
    /// and coordinates specific to that type of marker.
    /// </summary>
    public class MarkerShape : ISelfConverter {

        #region Properties

        /// <summary>
        /// The format of this attribute depends on the value of the type and follows the w3 AREA coords 
        /// specification found at http://www.w3.org/TR/REC-html40/struct/objects.html#adef-coords. 
        /// <c>Coords</c> is an array of integers that specify the pixel position of the shape relative 
        /// to the top-left corner of the target image. 
        /// The coordinates depend on the value of type as follows: 
        ///   - circle: coord is [x1,y1,r] where x1,y2 are the coordinates of the center of the circle, and r is the radius of the circle. 
        ///   - poly: coord is [x1,y1,x2,y2...xn,yn] where each x,y pair contains the coordinates of one vertex of the polygon. 
        ///   - rect: coord is [x1,y1,x2,y2] where x1,y1 are the coordinates of the upper-left corner of the rectangle and x2,y2 are the coordinates of the lower-right coordinates of the rectangle.
        /// </summary>
        /// <value>The coords.</value>
        public int[] Coords { get; set; }

        /// <summary>
        /// Describes the shape's type and can be circle, poly or rect.
        /// </summary>
        /// <value>The type.</value>
        public MarkerShapeType Type { get; set; }

        #endregion

        #region Methods

        public IDictionary<string, object> ToDictionary() {
                return new Dictionary<string, object> { { "coords", Coords }, { "type", Type.ToString().ToLower() } };
        }

        #endregion
    }
}
