using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class GoogleMarkerStyle {

        #region Properties  ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleMarkerStyle"/> is clickable.
        /// </summary>
        /// <value><c>true</c> if clickable; otherwise, <c>false</c>.</value>
        public bool Clickable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleMarkerStyle"/> is draggable.
        /// </summary>
        /// <value><c>true</c> if draggable; otherwise, <c>false</c>.</value>
        public bool Draggable { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerImage Icon { get; set; }

        /// <summary>
        /// Gets or sets the shadow.
        /// </summary>
        /// <value>The shadow.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerImage Shadow { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Applies the on marker.
        /// </summary>
        /// <param name="marker">The marker.</param>
        public virtual void ApplyOnMarker(GoogleMarker marker) {

            marker.Clickable = this.Clickable;
            marker.Draggable = this.Draggable;
            marker.Icon = this.Icon;
            marker.Shadow = this.Shadow;
            marker.Text = this.Text;
            marker.Title = this.Title;
        }
        #endregion
    }
}
