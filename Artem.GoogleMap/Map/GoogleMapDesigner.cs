using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;
using System.ComponentModel;
using System.IO;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class GoogleMapDesigner : ControlDesigner {

        #region Fields  ///////////////////////////////////////////////////////////////////////////

        GoogleMap _map;

        #endregion

        #region Properties  ///////////////////////////////////////////////////////////////////////

        ///// <summary>
        ///// 
        ///// </summary>
        //public override TemplateGroupCollection TemplateGroups {
        //    get {
        //        TemplateGroupCollection collection = new TemplateGroupCollection();
        //        TemplateGroup group;
        //        TemplateDefinition template;
        //        GoogleMap control;

        //        control = (GoogleMap)Component;
        //        group = new TemplateGroup("Item");
        //        template = new TemplateDefinition(this, "Template", control, "Template", true);
        //        group.AddTemplateDefinition(template);
        //        collection.Add(group);
        //        return collection;
        //    }
        //}
        #endregion

        #region Methods ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml() {

            StringBuilder html = new StringBuilder();
            html.Append(base.GetDesignTimeHtml());
            html.AppendFormat("<span style='background-color: Gray; border-width: 1px;'>GoogleMap - {0}</span>", _map.ID);

            return html.ToString();
            //if (_map != null) {
            //    StringBuilder sb = new StringBuilder();
            //    using (StringWriter sw = new StringWriter(sb)) {
            //        using (HtmlTextWriter tw = new HtmlTextWriter(sw)) {
            //            _map.RenderControl(tw);
            //        }
            //    }
            //    return sb.ToString();
            //}
            //else {
                //return string.Format("<span>GoogleMap - {0}</span>", _map.ID);
            //}
            //GoogleMap map = this.Component as GoogleMap;
            //if (map != null)
            //    return string.Format("<span>Google Map points to {0}:{1} (latitude:longitude)</span>", map.Latitude, map.Longitude);
            //else
            //    return "<span>Google Map</span>";
        }

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
        public override void Initialize(IComponent component) {

            _map = component as GoogleMap;
            if (_map == null)
                throw new ArgumentException("Component must be a GoogleMap control", "component");
            base.Initialize(component);
            //SetViewFlags(ViewFlags.TemplateEditing, true);
        }
        #endregion
    }
}
