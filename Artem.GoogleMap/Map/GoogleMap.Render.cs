using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using Artem.Google.Resources;
using System.Web.UI.WebControls;
using System.Web;

namespace Artem.Google.UI {

    ///// <summary>
    ///// The values for the GoogleMap RenderMode - Auto, Ajax, Web.
    ///// On Auto render mode the control with switch automatically to Ajax render mode if ScriptManager 
    ///// instance exists on the page, otherwise the old render mode will be used which is now known as Web.
    ///// If the render mode is Ajax, the control will force usage of the ScriptControl on the page,
    ///// otherwise will render error to the page as any ScriptControl.
    ///// If the render mofe is Web, then the old render mode and JS inludes and references will be forced,
    ///// even if the page is MS AJAX enabled (instance of ScriptControl exists, or referenced as script links).
    ///// </summary>
    //public enum MapRenderMode {
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    Auto,
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    Ajax,
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    Web
    //}

    /// <summary>
    /// 
    /// </summary>
    partial class GoogleMap {

        

        #region Properties

        ///// <summary>
        ///// Gets the client script.
        ///// </summary>
        ///// <value>The client script.</value>
        //private ClientScriptManager ClientScript {
        //    get {
        //        if (_clientScript == null) {
        //            Page page = this.Page;
        //            if (page == null)
        //                throw new InvalidOperationException(Errors.PageCannotBeNull);
        //            _clientScript = page.ClientScript;
        //        }
        //        return _clientScript;
        //    }
        //}
        //ClientScriptManager _clientScript;

        ///// <summary>
        ///// Gets the script manager.
        ///// </summary>
        ///// <value>The script manager.</value>
        //private ScriptManager ScriptManager {
        //    get {
        //        if (_scriptManager == null) {
        //            Page page = this.Page;
        //            if (page == null)
        //                throw new InvalidOperationException(Errors.PageCannotBeNull);
        //            _scriptManager = ScriptManager.GetCurrent(page);
        //            if (this.RenderMode == MapRenderMode.Ajax && _scriptManager == null)
        //                throw new InvalidOperationException(string.Format(Errors.RequiresScriptManager, this.ID));
        //        }
        //        return _scriptManager;
        //    }
        //}
        //ScriptManager _scriptManager;

        
        #endregion

        #region Methods

        ///// <summary>
        ///// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        ///// </summary>
        ///// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        //protected override void OnPreRender(EventArgs e) {
        //    base.OnPreRender(e);

        //    if (!this.IsStatic) {
        //        if (!Page.IsPostBack) {
        //            if (this.Width == Unit.Empty) this.Width = new Unit("600px");
        //            if (this.Height == Unit.Empty) this.Height = new Unit("480px");
        //        }
        //        if (!this.DesignMode) {
        //            ScriptManager.RegisterHiddenField(this, this.ClientStateID, this.SaveClientState());
        //            this.Page.RegisterRequiresPostBack(this);
        //            this.RenderGoogleReference();
        //            this.RenderScriptReferences();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Renders the control to the specified HTML writer.
        ///// </summary>
        ///// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the control content.</param>
        //protected override void Render(HtmlTextWriter writer) {
        //    base.Render(writer);
        //    if (!this.DesignMode && !this.IsStatic) this.RenderScriptDescriptors();
        //}

        

        ///// <summary>
        ///// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        ///// </summary>
        ///// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        //protected override void RenderContents(HtmlTextWriter writer) {
        //    // KEEP THIS EMPTY
        //}

        ///// <summary>
        ///// Renders the HTML closing tag of the control into the specified writer. This method is used primarily by control developers.
        ///// </summary>
        ///// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        //public override void RenderEndTag(HtmlTextWriter writer) {
        //    base.RenderEndTag(writer);

        //    if (!this.IsStatic) {
        //        // must be outside the map div otherwise Google API script will remove it
        //        if (_templateContainer != null)
        //            _templateContainer.RenderControl(writer);
        //        // street view pano
        //        //bool flag = this.IsStreetView &&
        //        //            this.StreetViewMode == StreetViewMode.Overlay &&
        //        //            string.IsNullOrEmpty(this.StreetViewPanoID);
        //        //if (flag) {
        //        //    writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID + "_Pano");
        //        //    writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "500px");
        //        //    writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "200px");
        //        //    writer.RenderBeginTag(HtmlTextWriterTag.Div);
        //        //    writer.RenderEndTag();
        //        //}
        //    }
        //}
        #endregion

        #region Render Utility Methods

        ///// <summary>
        ///// Registers the script descriptors.
        ///// </summary>
        //private void RenderScriptDescriptors() {

        //    ScriptManager scriptManager = this.ScriptManager;
        //    if (scriptManager != null) {
        //        scriptManager.RegisterScriptDescriptors(this);
        //    }
        //    else {
        //        var csm = this.ClientScript;
        //        Type type = this.GetType();
        //        string key = "Artem.Google.Map:" + this.ID;
        //        bool appInitialized = Convert.ToBoolean(this.Context.Items["Sys.Application.initialize"]);

        //        string properties = this.Serializer.Serialize(new {
        //            clientMapID = this.ID,
        //            clientStateID = this.ClientStateID,
        //            //mapEvents = this.MapEvents.ServerEvents.ToArray(),
        //            name = this.UniqueID
        //        });

        //        Dictionary<string, string> eventEntries = new Dictionary<string, string>();
        //        // map events
        //        foreach (var name in this.MapEvents.Registry.Keys) {
        //            foreach (var handler in this.MapEvents.Registry[name])
        //                eventEntries.Add(name, handler);
        //        }
        //        // marker events
        //        foreach (var name in this.MarkerEvents.Registry.Keys) {
        //            foreach (var handler in this.MarkerEvents.Registry[name])
        //                eventEntries.Add("marker_" + name, handler);
        //        }
        //        string events = this.Serializer.Serialize(eventEntries);

        //        StringBuilder buffer = new StringBuilder();
        //        if (!appInitialized) {
        //            buffer.AppendLine("Sys.Application.initialize();");
        //            this.Context.Items["Sys.Application.initialize"] = true;
        //        }
        //        buffer
        //            .AppendLine("Sys.Application.add_init(function() {")
        //            .AppendFormat("\t$create(Artem.Google.Map, {0}, {1}, null, $get(\"{2}\"));", properties, events, this.ClientID)
        //            .AppendLine()
        //            .AppendLine("});");
        //        csm.RegisterStartupScript(type, key, buffer.ToString(), true);
        //        //csm.RegisterOnSubmitStatement(type, this.ClientStateID, "Artem.Google.Manager.save();");
        //    }
        //}

        ///// <summary>
        ///// Registers the script references.
        ///// </summary>
        //private void RenderScriptReferences() {

        //    ScriptManager scriptManager = this.ScriptManager;
        //    if (scriptManager != null) {
        //        scriptManager.RegisterScriptControl(this);
        //    }
        //    else {
        //        var clientScript = this.Page.ClientScript;
        //        string name;
        //        Type type = this.GetType();

        //        foreach (var reference in this.GetScriptReferences()) {
        //            name = reference.Name;
        //            if (!clientScript.IsClientScriptIncludeRegistered(name)) {
        //                clientScript.RegisterClientScriptResource(type, name);
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
