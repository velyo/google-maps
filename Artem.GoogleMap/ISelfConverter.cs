using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artem.Google {

    public interface ISelfConverter {
        IDictionary<string, object> ToDictionary();
    }
}
