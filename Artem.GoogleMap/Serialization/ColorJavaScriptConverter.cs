using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Drawing;

namespace Artem.Google.Serialization {

    /// <summary>
    /// 
    /// </summary>
    class ColorJavaScriptConverter : JavaScriptConverter {

        #region Static Fields /////////////////////////////////////////////////////////////////////

        static readonly Type[] Types = { typeof(Color) };

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// When overridden in a derived class, gets a collection of the supported types.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An object that implements <see cref="T:System.Collections.Generic.IEnumerable`1"/> that represents the types supported by the converter.
        /// </returns>
        public override IEnumerable<Type> SupportedTypes {
            get {
                return ColorJavaScriptConverter.Types;
            }
        }

        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// When overridden in a derived class, converts the provided dictionary into an object of the specified type.
        /// </summary>
        /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2"/> instance of property data stored as name/value pairs.</param>
        /// <param name="type">The type of the resulting object.</param>
        /// <param name="serializer">The <see cref="T:System.Web.Script.Serialization.JavaScriptSerializer"/> instance.</param>
        /// <returns>The deserialized object.</returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer) {

            Color result = Color.Black;
            object value = null;

            if (dictionary.TryGetValue("HtmlValue", out value)) {
                result = ColorTranslator.FromHtml(value as string);
            }

            return result;
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

            Dictionary<string, object> result = new Dictionary<string, object>();

            if (obj is Color) {
                Color color = (Color)obj;
                result["HtmlValue"] = ColorTranslator.ToHtml(color);// JsUtil.Encode(color);
            }

            return result;
        }
        #endregion
    }
}
