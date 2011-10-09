using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Artem.Google.UI;

namespace Artem.Google.Web.Demo.Maps {

    public partial class ZoomPanTypePage : Page {

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Handles the zoom pan type changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HandleZoomPanTypeChanged(object sender, EventArgs e) {

            //DropDownList list = sender as DropDownList;
            //if (list != null) {
            //    ZoomPanType type = (ZoomPanType)Enum.Parse(typeof(ZoomPanType), list.SelectedValue);
            //    GoogleMap1.ZoomPanType = type;
            //}
        }
        #endregion
    }
}