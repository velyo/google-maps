    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Artem.Google.UI;

namespace Artem.Google.Serialization {

    class PolylineOptionsConverter : JavaScriptConverter {

        #region Properties

        /// <summary>
        /// When overridden in a derived class, gets a collection of the supported types.
        /// </summary>
        /// <value></value>
        /// <returns>An object that implements <see cref="T:System.Collections.Generic.IEnumerable`1"/> that represents the types supported by the converter.</returns>
        public override IEnumerable<Type> SupportedTypes {
            get {
                yield return typeof(PolylineOptions);
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// When overridden in a derived class, converts the provided dictionary into an object of the specified type.
        /// </summary>
        /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2"/> instance of property data stored as name/value pairs.</param>
        /// <param name="type">The type of the resulting object.</param>
        /// <param name="serializer">The <see cref="T:System.Web.Script.Serialization.JavaScriptSerializer"/> instance.</param>
        /// <returns>The deserialized object.</returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer) {

            PolylineOptions options = null;
            object value;

            if (dictionary.TryGetValue("polylineOptions", out value)) {
                // TODO proper implementation, the value will be dictionary probably
                if (value is PolylineOptions)
                    options = (PolylineOptions)value;
            }

            return options;
        }

        /// <summary>
        /// When overridden in a derived class, builds a dictionary of name/value pairs.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="serializer">The object that is responsible for the serialization.</param>
        /// <returns>
        /// An object that contains key/value pairs that represent the object’s data.
        /// </returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer) {

                var result = new Dictionary<string, object>();

                if (obj is PolylineOptions) {
                    var options = obj as PolylineOptions;
                    if (options != null) {
                        result["clickable"] = options.Clickable;
                        result["geodesic"] = options.Geodesic;
                        //if (options.Path != null)
                        //    result["path"] = options.Path;
                        if (options.StrokeColor != null)
                            result["strokeColor"] = options.StrokeColor;
                        if (options.StrokeOpacity >= 0 && options.StrokeOpacity <= 1)
                            result["strokeOpacity"] = options.StrokeOpacity;
                        result["strokeWeight"] = options.StrokeWeight;
                        result["zIndex"] = options.ZIndex;
                    }
                }

                return result;
        }
        #endregion
    }
}
