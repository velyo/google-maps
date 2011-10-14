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

    /// <summary>
    /// The values for the GoogleMap RenderMode - Auto, Ajax, Web.
    /// On Auto render mode the control with switch automatically to Ajax render mode if ScriptManager 
    /// instance exists on the page, otherwise the old render mode will be used which is now known as Web.
    /// If the render mode is Ajax, the control will force usage of the ScriptControl on the page,
    /// otherwise will render error to the page as any ScriptControl.
    /// If the render mofe is Web, then the old render mode and JS inludes and references will be forced,
    /// even if the page is MS AJAX enabled (instance of ScriptControl exists, or referenced as script links).
    /// </summary>
    public enum MapRenderMode {
        /// <summary>
        /// 
        /// </summary>
        Auto,
        /// <summary>
        /// 
        /// </summary>
        Ajax,
        /// <summary>
        /// 
        /// </summary>
        Web
    }

    /// <summary>
    /// 
    /// </summary>
    partial class GoogleMap {

        #region Static Fields


        /// <summary>
        /// The GoogleMaps API script URL. 
        /// The property is not longer readonly in order to provide ability for changing it per application.
        /// For example, if it is changed in the future this property could be set in Global.asax per appliation.
        /// The protocol should be omitted from the specified URL in order to allow 
        /// control to automatically switch to HTTPS when requested under SSL.
        /// </summary>
        public static string ApiUrl = "maps.googleapis.com/maps/api/js?";

        /// <summary>
        /// The Static Maps API script URL.
        /// The protocol should be omitted from the specified URL in order to allow 
        /// control to automatically switch to HTTPS when requested under SSL.
        /// </summary>
        public static string StaticApiUrl = "maps.googleapis.com/maps/api/staticmap?";

        #endregion

        #region Properties

        /// <summary>
        /// Gets the client script.
        /// </summary>
        /// <value>The client script.</value>
        private ClientScriptManager ClientScript {
            get {
                if (_clientScript == null) {
                    Page page = this.Page;
                    if (page == null)
                        throw new InvalidOperationException(Errors.PageCannotBeNull);
                    _clientScript = page.ClientScript;
                }
                return _clientScript;
            }
        }
        ClientScriptManager _clientScript;

        /// <summary>
        /// Gets the script manager.
        /// </summary>
        /// <value>The script manager.</value>
        private ScriptManager ScriptManager {
            get {
                if (_scriptManager == null) {
                    Page page = this.Page;
                    if (page == null)
                        throw new InvalidOperationException(Errors.PageCannotBeNull);
                    _scriptManager = ScriptManager.GetCurrent(page);
                    if (this.RenderMode == MapRenderMode.Ajax && _scriptManager == null)
                        throw new InvalidOperationException(string.Format(Errors.RequiresScriptManager, this.ID));
                }
                return _scriptManager;
            }
        }
        ScriptManager _scriptManager;

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey {
            get {
                return !this.IsStatic ? HtmlTextWriterTag.Div : HtmlTextWriterTag.Img;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e) {
            base.OnPreRender(e);

            if (!this.IsStatic) {
                if (!Page.IsPostBack) {
                    if (this.Width == Unit.Empty) this.Width = new Unit("600px");
                    if (this.Height == Unit.Empty) this.Height = new Unit("480px");
                }
                if (!this.DesignMode) {
                    ScriptManager.RegisterHiddenField(this, this.ClientStateID, this.SaveClientState());
                    this.Page.RegisterRequiresPostBack(this);
                    this.RenderGoogleReference();
                    this.RenderScriptReferences();
                }
            }
        }

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the control content.</param>
        protected override void Render(HtmlTextWriter writer) {
            base.Render(writer);
            if (!this.DesignMode && !this.IsStatic) this.RenderScriptDescriptors();
        }

        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer) {

            if (!this.IsStatic) {
                base.RenderBeginTag(writer);
            }
            else {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "map");
                writer.AddAttribute(HtmlTextWriterAttribute.Src, this.GetStaticSource());
                writer.RenderBeginTag(this.TagKey);
            }
        }

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        protected override void RenderContents(HtmlTextWriter writer) {
            // KEEP THIS EMPTY
        }

        /// <summary>
        /// Renders the HTML closing tag of the control into the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        public override void RenderEndTag(HtmlTextWriter writer) {
            base.RenderEndTag(writer);

            if (!this.IsStatic) {
                // must be outside the map div otherwise Google API script will remove it
                if (_templateContainer != null)
                    _templateContainer.RenderControl(writer);
                // street view pano
                //bool flag = this.IsStreetView &&
                //            this.StreetViewMode == StreetViewMode.Overlay &&
                //            string.IsNullOrEmpty(this.StreetViewPanoID);
                //if (flag) {
                //    writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID + "_Pano");
                //    writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "500px");
                //    writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "200px");
                //    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                //    writer.RenderEndTag();
                //}
            }
        }
        #endregion

        #region Render Utility Methods

        /// <summary>
        /// Renders the static reference.
        /// </summary>
        private string GetStaticSource() {

            string proto = this.Page.Request.IsSecureConnection ? "https" : "http";
            string url = string.Format("{0}://{1}", proto, StaticApiUrl);
            StringBuilder buffer = new StringBuilder(url);
            string center = null;
            string format = (this.StaticFormat != StaticImageFormats.JpgBaseline)
                ? this.StaticFormat.ToString().ToLower() : "jpg-baseline";
            
            if(this.Center != null) {
                center = this.Center.ToString();
            }
            else {
                string address = this.Address ?? this.DefaultAddress;
                if(address != null)
                    center = HttpUtility.UrlEncode(address);
            }
            
            buffer.AppendFormat("center={0}", center);
            buffer.AppendFormat("&zoom={0}", this.Zoom.ToString());
            buffer.AppendFormat("&size={0}x{1}", this.Width.Value, this.Height.Value);
            buffer.AppendFormat("&sensor={0}", this.IsSensor.ToString().ToLower());
            buffer.AppendFormat("&maptype={0}", this.MapType.ToString().ToLower());
            buffer.AppendFormat("&format={0}", format);
            if (!string.IsNullOrEmpty(this.Language))
                buffer.AppendFormat("&language={0}", this.Language);
            if (this.StaticScale > 1)
                buffer.AppendFormat("&scale={0}", this.StaticScale.ToString());

            // TODO add markers 
            // TODO add paths -> polylines
            // TODO add styles - features, elements, rules

            return buffer.ToString();
        }

        /// <summary>
        /// Builds the google reference.
        /// </summary>
        /// <returns></returns>
        protected virtual void RenderGoogleReference() {

            var clientScript = this.Page.ClientScript;

            if (!clientScript.IsClientScriptIncludeRegistered("maps.google.com")) {
                string proto = this.Page.Request.IsSecureConnection ? "https" : "http";
                string url = string.Format("{0}://{1}", proto, ApiUrl);
                StringBuilder buffer = new StringBuilder(url);

                if (!string.IsNullOrEmpty(this.ApiVersion))
                    buffer.AppendFormat("v={0}&", this.ApiVersion);
                // sensor
                buffer.AppendFormat("sensor={0}", this.IsSensor.ToString().ToLower());
                // language
                if (!string.IsNullOrEmpty(this.Language))
                    buffer.AppendFormat("&language={0}", this.Language);
                // region
                if (!string.IsNullOrEmpty(this.Region))
                    buffer.AppendFormat("&region={0}", this.Region);

                //if (!string.IsNullOrEmpty(this.EnterpriseKey))
                //    buffer.AppendFormat("&client={0}", this.EnterpriseKey);

                clientScript.RegisterClientScriptInclude("maps.google.com", buffer.ToString());
            }
        }

        /// <summary>
        /// Registers the script descriptors.
        /// </summary>
        private void RenderScriptDescriptors() {

            ScriptManager scriptManager = this.ScriptManager;
            if (scriptManager != null) {
                scriptManager.RegisterScriptDescriptors(this);
            }
            else {
                var csm = this.ClientScript;
                Type type = this.GetType();
                string key = "Artem.Google.Map:" + this.ID;
                bool appInitialized = Convert.ToBoolean(this.Context.Items["Sys.Application.initialize"]);

                string properties = this.Serializer.Serialize(new {
                    clientMapID = this.ID,
                    clientStateID = this.ClientStateID,
                    //mapEvents = this.MapEvents.ServerEvents.ToArray(),
                    name = this.UniqueID
                });

                Dictionary<string, string> eventEntries = new Dictionary<string, string>();
                // map events
                foreach (var name in this.MapEvents.Registry.Keys) {
                    foreach (var handler in this.MapEvents.Registry[name])
                        eventEntries.Add(name, handler);
                }
                // marker events
                foreach (var name in this.MarkerEvents.Registry.Keys) {
                    foreach (var handler in this.MarkerEvents.Registry[name])
                        eventEntries.Add("marker_" + name, handler);
                }
                //// directions events
                //foreach (var name in this.DirectionsEvents.Registry.Keys) {
                //    foreach (var handler in this.DirectionsEvents.Registry[name])
                //        eventEntries.Add("directions_" + name, handler);
                //}
                // polygon events
                //foreach (var name in this.PolygonEvents.Registry.Keys) {
                //    foreach (var handler in this.PolygonEvents.Registry[name])
                //        eventEntries.Add("polygon_" + name, handler);
                //}
                //// polyline events
                //foreach (var name in this.PolylineEvents.Registry.Keys) {
                //    foreach (var handler in this.PolylineEvents.Registry[name])
                //        eventEntries.Add("polyline_" + name, handler);
                //}
                string events = this.Serializer.Serialize(eventEntries);

                StringBuilder buffer = new StringBuilder();
                if (!appInitialized) {
                    buffer.AppendLine("Sys.Application.initialize();");
                    this.Context.Items["Sys.Application.initialize"] = true;
                }
                buffer
                    .AppendLine("Sys.Application.add_init(function() {")
                    .AppendFormat("\t$create(Artem.Google.Map, {0}, {1}, null, $get(\"{2}\"));", properties, events, this.ClientID)
                    .AppendLine()
                    .AppendLine("});");
                csm.RegisterStartupScript(type, key, buffer.ToString(), true);
                //csm.RegisterOnSubmitStatement(type, this.ClientStateID, "Artem.Google.Manager.save();");
            }
        }

        /// <summary>
        /// Registers the script references.
        /// </summary>
        private void RenderScriptReferences() {

            ScriptManager scriptManager = this.ScriptManager;
            if (scriptManager != null) {
                scriptManager.RegisterScriptControl(this);
            }
            else {
                var clientScript = this.Page.ClientScript;
                string name;
                Type type = this.GetType();

                foreach (var reference in this.GetScriptReferences()) {
                    name = reference.Name;
                    if (!clientScript.IsClientScriptIncludeRegistered(name)) {
                        clientScript.RegisterClientScriptResource(type, name);
                    }
                }
            }
        }
        #endregion

        #region IScriptControl Methods

        /// <summary>
        /// Gets the script descriptors.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScriptDescriptor> GetScriptDescriptors() {

            // map descriptor
            var descriptor = new ScriptControlDescriptor("Artem.Google.Map", this.ClientID);

            // properties
            descriptor.AddProperty("clientMapID", this.ID);
            descriptor.AddProperty("clientStateID", this.ClientStateID);
            //descriptor.AddProperty("mapEvents", this.MapEvents.ServerEvents.ToArray());
            descriptor.AddProperty("name", this.UniqueID);

            // map events
            foreach (var name in this.MapEvents.Registry.Keys) {
                foreach (var handler in this.MapEvents.Registry[name])
                    descriptor.AddEvent(name, handler);
            }
            // marker events
            foreach (var name in this.MarkerEvents.Registry.Keys) {
                foreach (var handler in this.MarkerEvents.Registry[name])
                    descriptor.AddEvent("marker_" + name, handler);
            }
            //// directions events
            //foreach (var name in this.DirectionsEvents.Registry.Keys) {
            //    foreach (var handler in this.DirectionsEvents.Registry[name])
            //        descriptor.AddEvent("directions_" + name, handler);
            //}
            // polygon events
            //foreach (var name in this.PolygonEvents.Registry.Keys) {
            //    foreach (var handler in this.PolygonEvents.Registry[name])
            //        descriptor.AddEvent("polygon_" + name, handler);
            //}
            //// polyline events
            //foreach (var name in this.PolylineEvents.Registry.Keys) {
            //    foreach (var handler in this.PolylineEvents.Registry[name])
            //        descriptor.AddEvent("polyline_" + name, handler);
            //}

            yield return descriptor;

        }

        /// <summary>
        /// Gets the script references.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScriptReference> GetScriptReferences() {

            string assembly = this.GetType().Assembly.FullName;
#if DEBUG
            if (this.ScriptManager == null)
                yield return new ScriptReference("Artem.Google.Scripts.MicrosoftAjax.debug.js", assembly);

            yield return new ScriptReference("Artem.Google.Scripts.GoogleCommons.js", assembly);
            yield return new ScriptReference("Artem.Google.Scripts.GoogleMap.js", assembly);

            if (_markers.IsNotNullOrEmpty())
                yield return new ScriptReference("Artem.Google.Scripts.GoogleMarker.js", assembly);

            if (_polygons.IsNotNullOrEmpty())
                yield return new ScriptReference("Artem.Google.Scripts.GooglePolygon.js", assembly);

            if (_polylines.IsNotNullOrEmpty())
                yield return new ScriptReference("Artem.Google.Scripts.GooglePolyline.js", assembly);

            if (_directions.IsNotNullOrEmpty())
                yield return new ScriptReference("Artem.Google.Scripts.GoogleDirections.js", assembly);
#else
            if (this.ScriptManager == null)
                yield return new ScriptReference("Artem.Google.Scripts.MicrosoftAjax.js", assembly);

            yield return new ScriptReference("Artem.Google.Scripts.GoogleCommons.min.js", assembly);
            yield return new ScriptReference("Artem.Google.Scripts.GoogleMap.min.js", assembly);

            if (_markers.IsNotNullOrEmpty()) 
                yield return new ScriptReference("Artem.Google.Scripts.GoogleMarker.min.js", assembly);

            if (_polygons.IsNotNullOrEmpty()) 
                yield return new ScriptReference("Artem.Google.Scripts.GooglePolygon.min.js", assembly);

            if (_polylines.IsNotNullOrEmpty()) 
                yield return new ScriptReference("Artem.Google.Scripts.GooglePolyline.min.js", assembly);

            if (_directions.IsNotNullOrEmpty()) 
                yield return new ScriptReference("Artem.Google.Scripts.GoogleDirections.min.js", assembly);
#endif
        }
        #endregion
    }
}
