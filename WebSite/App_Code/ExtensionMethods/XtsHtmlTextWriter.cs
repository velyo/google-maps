using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.UI {

    /// <summary>
    /// 
    /// </summary>
    public static class XtsHtmlTextWriter {

        #region Static Methods ////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Begins the tag.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public static HtmlTag BeginTag(this HtmlTextWriter writer, HtmlTextWriterTag tag) {
            return new HtmlTag(writer, tag);
        }

        /// <summary>
        /// Begins the tag.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public static HtmlTag BeginTag(this HtmlTextWriter writer, string tag) {
            return new HtmlTag(writer, tag);
        }

        /// <summary>
        /// Renders the tag.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="tag">The tag.</param>
        public static void RenderTag(this HtmlTextWriter writer, HtmlTextWriterTag tag) {
            writer.RenderBeginTag(tag);
            writer.RenderEndTag();
        }

        /// <summary>
        /// Renders the tag.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="tag">The tag.</param>
        public static void RenderTag(this HtmlTextWriter writer, string tag) {
            writer.RenderBeginTag(tag);
            writer.RenderEndTag();
        }

        /// <summary>
        /// Renders the tag.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="content">The content.</param>
        public static void RenderTag(this HtmlTextWriter writer, HtmlTextWriterTag tag, string content) {

            writer.RenderBeginTag(tag);
            writer.Write(content);
            writer.RenderEndTag();
        }

        /// <summary>
        /// Renders the tag.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="content">The content.</param>
        public static void RenderTag(this HtmlTextWriter writer, string tag, string content) {

            writer.RenderBeginTag(tag);
            writer.Write(content);
            writer.RenderEndTag();
        }
        #endregion

        #region Nested Types

        public class HtmlTag : IDisposable {

            #region Fields

            HtmlTextWriter _writer;

            #endregion

            #region Ctor/ Dtor

            /// <summary>
            /// Initializes a new instance of the <see cref="HtmlTag"/> class.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <param name="tag">The tag.</param>
            public HtmlTag(HtmlTextWriter writer, HtmlTextWriterTag tag) {
                _writer = writer;
                _writer.RenderBeginTag(tag);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="HtmlTag"/> class.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <param name="tag">The tag.</param>
            public HtmlTag(HtmlTextWriter writer, string tag) {
                _writer = writer;
                _writer.RenderBeginTag(tag);
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose() {
                _writer.RenderEndTag();
            }
            #endregion
        }
        #endregion
    }
}