using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.ComponentModel;
using Artem.Google.Serialization;
using System.Web.UI;

namespace Artem.Google.UI {

    /// <summary>
    /// 
    /// </summary>
    public class MarkerOptions : IScriptDataConverter {

        #region Static Methods

        /// <summary>
        /// Retrieves an instance from script data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static MarkerOptions FromScriptData(IDictionary<string, object> data) {

            if (data != null) {
                var result = new MarkerOptions();
                object value;

                if (data.TryGetValue("animation", out value)) result.Animation = (MarkerAnimation)(int)value;
                if (data.TryGetValue("clickable", out value)) result.Clickable = (bool)value;
                if (data.TryGetValue("cursor", out value)) result.Cursor = (string)value;
                if (data.TryGetValue("draggable", out value)) result.Draggable = (bool)value;
                if (data.TryGetValue("flat", out value)) result.Flat = (bool)value;
                if (data.TryGetValue("icon", out value))
                    result.Icon = MarkerImage.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("optimized", out value)) result.Optimized = (bool)value;
                if (data.TryGetValue("position", out value))
                    result.Position = LatLng.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("raiseOnDrag", out value)) result.RaiseOnDrag = (bool)value;
                if (data.TryGetValue("shadow", out value))
                    result.Shadow = MarkerImage.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("shape", out value))
                    result.Shape = MarkerShape.FromScriptData((IDictionary<string, object>)value);
                if (data.TryGetValue("title", out value)) result.Title = (string)value;
                if (data.TryGetValue("visible", out value)) result.Visible = (bool)value;
                if (data.TryGetValue("zIndex", out value)) result.ZIndex = (int)value;

                return result;
            }
            return null;
        }
        #endregion

        #region Fields

        MarkerImage _icon;
        LatLng _position;
        MarkerImage _shadow;
        MarkerShape _shape;

        #endregion

        #region Properties

        /// <summary>
        /// Which animation to play when marker is added to a map.
        /// </summary>
        /// <value>The animation.</value>
        public MarkerAnimation? Animation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MarkerOptions"/> is clickable.
        /// If true, the marker receives mouse and touch events. Default value is true.
        /// </summary>
        /// <value><c>true</c> if clickable; otherwise, <c>false</c>.</value>
        public bool? Clickable { get; set; }

        /// <summary>
        /// Mouse cursor to show on hover
        /// </summary>
        /// <value>The cursor.</value>
        public string Cursor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MarkerOptions"/> is draggable.
        /// If true, the marker can be dragged. Default value is false.
        /// </summary>
        /// <value><c>true</c> if draggable; otherwise, <c>false</c>.</value>
        public bool? Draggable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MarkerOptions"/> is flat.
        /// If true, the marker shadow will not be displayed.
        /// </summary>
        /// <value><c>true</c> if flat; otherwise, <c>false</c>.</value>
        public bool? Flat { get; set; }

        /// <summary>
        /// Icon for the foreground.
        /// </summary>
        /// <value>The icon.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public MarkerImage Icon {
            get {
                return _icon ?? (_icon = new MarkerImage());
            }
            set {
                _icon = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MarkerOptions"/> is optimized.
        /// Optimization renders many markers as a single static element. Optimized rendering is enabled by default. 
        /// Disable optimized rendering for animated GIFs or PNGs, or when each marker must be rendered as a separate DOM element (advanced usage only).
        /// </summary>
        /// <value><c>true</c> if optimized; otherwise, <c>false</c>.</value>
        public bool? Optimized { get; set; }

        /// <summary>
        /// Marker position. Required.
        /// </summary>
        /// <value>The position.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public LatLng Position {
            get {
                return _position ?? (_position = new LatLng());
            }
            set {
                _position = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [raise on drag].
        /// If false, disables raising and lowering the marker on drag. This option is true by default.
        /// </summary>
        /// <value><c>true</c> if [raise on drag]; otherwise, <c>false</c>.</value>
        public bool? RaiseOnDrag { get; set; }

        /// <summary>
        /// Gets or sets the shadow image.
        /// </summary>
        /// <value>The shadow.</value>
        public MarkerImage Shadow {
            get {
                return _shadow ?? (_shadow = new MarkerImage());
            }
            set {
                _shadow = value;
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// Image map region definition used for drag/click.
        /// </summary>
        /// <value>The shape.</value>
        public MarkerShape Shape {
            get {
                return _shape ?? (_shape = new MarkerShape());
            }
            set {
                _shape = value;
            }
        }

        /// <summary>
        /// Gets or sets the title. Rollover text.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MarkerOptions"/> is visible.
        /// If true, the marker is visible
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool? Visible { get; set; }

        /// <summary>
        /// All markers are displayed on the map in order of their zIndex, with higher values displaying in front of markers with lower values. By default, markers are displayed according to their vertical position on screen, with lower markers appearing in front of markers further up the screen.
        /// </summary>
        /// <value>The index.</value>
        public int? ZIndex { get; set; }

        #endregion

        #region Ctor

        public MarkerOptions() {
            this.Clickable = true;
            this.Optimized = true;
            this.RaiseOnDrag = true;
            this.Visible = true;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the instance as a script data.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, object> ToScriptData() {

            var result = new Dictionary<string, object>();

            if (Animation.HasValue) result["animation"] = this.Animation.Value;
            if (Clickable.HasValue) result["clickable"] = this.Clickable.Value;
            if (Cursor != null) result["cursor"] = this.Cursor;
            if (Draggable.HasValue) result["draggable"] = this.Draggable.Value;
            if (Flat.HasValue) result["flat"] = this.Flat.Value;
            if (_icon != null) result["icon"] = _icon.ToScriptData();
            if (Optimized.HasValue) result["optimized"] = this.Optimized.Value;
            if (_position != null) result["position"] = _position.ToScriptData();
            if (RaiseOnDrag.HasValue) result["raiseOnDrag"] = this.RaiseOnDrag.Value;
            if (_shadow != null) result["shadow"] = _shadow.ToScriptData();
            if (_shape != null) result["shape"] = _shape.ToScriptData();
            if (Title != null) result["title"] = this.Title;
            if (Visible.HasValue) result["visible"] = this.Visible.Value;
            if (ZIndex.HasValue) result["zIndex"] = this.ZIndex.Value;

            return result;

        }

        #endregion
    }
}
