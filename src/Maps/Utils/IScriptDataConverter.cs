using System.Collections.Generic;

namespace Velyo.Google
{
    /// <summary>
    /// Defines methods to convert object data to script data.
    /// </summary>
    public interface IScriptDataConverter
    {
        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> ToScriptData();
    }
}
