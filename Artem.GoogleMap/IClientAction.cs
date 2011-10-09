using System;
using System.Collections.Generic;
using System.Text;

namespace Artem.Google {

    /// <summary>
    /// 
    /// </summary>
    public interface IClientAction {

        #region Properties  /////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the actions.
        /// </summary>
        /// <value>The actions.</value>
        List<string> Actions {
            get;
        }
        #endregion
    }
}
