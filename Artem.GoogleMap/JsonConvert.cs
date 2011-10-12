using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Artem.Google {

    internal static class JsonConvert {

        #region Static Properties

        public static JavaScriptSerializer Serializer {
            get {
                if (_Serializer == null)
                    _Serializer = new WeakReference(new JavaScriptSerializer());
                return (JavaScriptSerializer)
                    (_Serializer.Target ?? (_Serializer.Target = new JavaScriptSerializer()));
            }
        }
        static WeakReference _Serializer;

        public static IEnumerable<JavaScriptConverter> Converters {
            get {
                if (_Converters == null)
                    _Converters = new WeakReference(JsUtil.GetConverters());
                return (IEnumerable<JavaScriptConverter>)
                    (_Converters.Target ?? (_Converters.Target = JsUtil.GetConverters()));
            }
        }
        static WeakReference _Converters;

        #endregion

        #region Static Methods

        public static IDictionary<string, object> Convert(object value) {

            if (value != null) {
                var converter = GetConverter(value.GetType());
                if (converter != null) {
                    return converter.Serialize(value, Serializer);
                }
            }
            return null;
        }

        private static JavaScriptConverter GetConverter(Type type) {
            return Converters.Where(c => c.SupportedTypes.Contains(type)).FirstOrDefault();
        }

        public static object Parse(Dictionary<string, object> dictionary, Type type) {

            if ((dictionary != null) && (type != null)) {
                var converter = GetConverter(type);
                if (converter != null) {
                    return converter.Deserialize(dictionary, type, Serializer);
                }
            }
            return null;
        }

        public static object Parse<T>(Dictionary<string, object> dictionary) {
            return Parse(dictionary, typeof(T));
        }

        //public static IDictionary<string, object> ToDictionary(this object value) {
        //    return Convert(value);
        //}
        #endregion
    }
}
