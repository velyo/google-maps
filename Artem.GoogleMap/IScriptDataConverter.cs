using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google {

    public interface IScriptDataConverter {
        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> ToScriptData();
    }
}
