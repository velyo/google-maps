using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artem.GoogleMap.WebSite.Models {

    /// <summary>
    /// Summary description for MarkerRecord
    /// </summary>
    public class MarkerRecord {

        #region Properties

        public string Info { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        #endregion
    }
}