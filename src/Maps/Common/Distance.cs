using System.Collections.Generic;

namespace Velyo.Google.Maps
{
    /// <summary>
    /// A representation of distance as a numeric value and a display string.
    /// </summary>
    public class Distance : IScriptDataConverter
    {
        /// <summary>
        /// A string representation of the distance value, using the UnitSystem specified in the request.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The distance in meters.
        /// </summary>
        public int Value { get; set; }


        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="scriptObject">The script object.</param>
        /// <returns></returns>
        public static Distance FromScriptData(object scriptObject)
        {
            var data = scriptObject as IDictionary<string, object>;
            if (data != null)
            {
                var distance = new Distance();
                object value;

                if (data.TryGetValue("text", out value)) distance.Text = (string)value;
                if (data.TryGetValue("value", out value)) distance.Value = (int)value;

                return distance;
            }
            return null;
        }

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToScriptData()
        {
            return new Dictionary<string, object> { { "text", Text }, { "value", Value } };
        }
    }
}
