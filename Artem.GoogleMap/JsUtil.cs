using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Artem.Google.Serialization;

namespace Artem.Google {

    /// <summary>
    /// 
    /// </summary>
    public static class JsUtil {

        #region Static Fields

        static NumberFormatInfo _NumberFormat;
        static readonly RegexOptions DefaultRegexOptions =
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace;

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets the number format.
        /// </summary>
        /// <value>The number format.</value>
        public static NumberFormatInfo NumberFormat {
            get {
                return _NumberFormat ??
                    (_NumberFormat = CultureInfo.GetCultureInfo("en-US").NumberFormat);
            }
        }
        #endregion

        #region Static Methods

        /// <summary>
        /// Creates the serializer.
        /// </summary>
        /// <returns></returns>
        public static JavaScriptSerializer CreateSerializer() {

            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(JsUtil.GetConverters());
            return serializer;
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns></returns>
        public static string Encode(bool value) {
            return value.ToString().ToLower();
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Encode(float value) {
            return System.Convert.ToString(value, NumberFormat);
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Encode(double value) {
            return System.Convert.ToString(value, NumberFormat);
        }

        /// <summary>
        /// Encodes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Encode(string value) {

            if (value != null) {
                StringBuilder sb = new StringBuilder();
                sb.Append("\"");
                foreach (char c in value) {
                    switch (c) {
                        case '\"':
                            sb.Append("\\\"");
                            break;
                        case '\\':
                            sb.Append("\\\\");
                            break;
                        case '\b':
                            sb.Append("\\b");
                            break;
                        case '\f':
                            sb.Append("\\f");
                            break;
                        case '\n':
                            sb.Append("\\n");
                            break;
                        case '\r':
                            sb.Append("\\r");
                            break;
                        case '\t':
                            sb.Append("\\t");
                            break;
                        default:
                            int i = (int)c;
                            if (i < 32 || i > 127) {
                                sb.AppendFormat("\\u{0:X04}", i);
                            }
                            else {
                                sb.Append(c);
                            }
                            break;
                    }
                }
                sb.Append("\"");
                //
                return sb.ToString();
            }
            else
                return "\"\"";
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Encode(Color value) {
            int rgb = value.ToArgb() & 0x00FFFFFF;
            return string.Format("\"#{0}\"", rgb.ToString("X6"));
        }

        /// <summary>
        /// Encodes the js function.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeJsFunction(string value) {
            return Encode(Regex.Replace(value, @"(\(.*)", "", DefaultRegexOptions));
        }

        /// <summary>
        /// Gets the converters.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<JavaScriptConverter> GetConverters() {
            yield return new ColorJavaScriptConverter();
            yield return new PolylineOptionsConverter();
        }

        /// <summary>
        /// Determines whether the specified value is undefined.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is undefined; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUndefined(string value) {
            return (value.Equals("undefined", StringComparison.InvariantCultureIgnoreCase) ||
                    value.Equals("NaN", StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Toes the boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool ToBoolean(string value) {
            if (IsUndefined(value)) return false;
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Toes the byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte ToByte(string value) {
            if (IsUndefined(value)) return 0;
            return Convert.ToByte(value, NumberFormat);
        }

        /// <summary>
        /// Toes the color.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Color ToColor(string value) {
            if (IsUndefined(value)) return Color.Black; 
            return ColorTranslator.FromHtml(value);
        }

        /// <summary>
        /// Toes the decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static decimal ToDecimal(string value) {
            if (IsUndefined(value)) return 0;
            return Convert.ToDecimal(value, NumberFormat);
        }

        /// <summary>
        /// Decodes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ToDouble(string value) {
            if (IsUndefined(value)) return 0D;
            return Convert.ToDouble(value, NumberFormat);
        }

        /// <summary>
        /// Toes the int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int ToInt(string value) {
            if (IsUndefined(value)) return 0;
            return Convert.ToInt32(value, NumberFormat);
        }

        /// <summary>
        /// Toes the long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static long ToLong(string value) {
            if (IsUndefined(value)) return 0L;
            return Convert.ToInt64(value, NumberFormat);
        }

        /// <summary>
        /// Toes the single.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static float ToSingle(string value) {
            if (IsUndefined(value)) return 0F;
            return Convert.ToSingle(value, NumberFormat);
        }

        /// <summary>
        /// Toes the short.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static short ToShort(string value) {
            if (IsUndefined(value)) return 0;
            return Convert.ToInt16(value, NumberFormat);
        }

        /// <summary>
        /// Tries the parse point.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="lng">The LNG.</param>
        /// <returns></returns>
        public static bool TryParsePoint(string value, out double lat, out double lng) {

            string[] pair = value.Split(new char[] { ';' });
            if (pair != null && pair.Length == 2) {
                lat = System.Convert.ToDouble(pair[0], NumberFormat);
                lng = System.Convert.ToDouble(pair[1], NumberFormat);
                return true;
            }
            lat = lng = 0;
            return false;
        }
        #endregion
    }
}