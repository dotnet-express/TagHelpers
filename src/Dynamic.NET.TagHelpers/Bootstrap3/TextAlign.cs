using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3
{
    public static class TextAlign
    {
        /// <summary>
        /// Bootstrap 3. Default text alignment.
        /// </summary>
        public static readonly string Default = string.Empty;

        /// <summary>
        /// Bootstrap 3. Left text alignment
        /// </summary>
        [CssClassInfo("text-left", "left")]
        public static readonly string Left = "text-left";

        /// <summary>
        /// Bootstrap 3. Center text alignment
        /// </summary>
        [CssClassInfo("text-center", "center")]
        public static readonly string Center = "text-center";

        /// <summary>
        /// Bootstrap 3. Right text alignment
        /// </summary>
        [CssClassInfo("text-right", "right")]
        public static readonly string Right = "text-right";

        /// <summary>
        /// Bootstrap 3. Justify text alignment
        /// </summary>
        [CssClassInfo("text-justify", "justify")]
        public static readonly string Justify = "text-justify";

        /// <summary>
        /// Bootstrap 3. No wrap text
        /// </summary>
        [CssClassInfo("text-nowrap", "nowrap")]
        public static readonly string NoWrap = "text-nowrap";

        internal static string Parse(string align)
        {
            var parser = CssClassInfoCache.GetParser(typeof(TextAlign));
            string className = parser.GetValue(align);
            return className;
        }
    }
}
