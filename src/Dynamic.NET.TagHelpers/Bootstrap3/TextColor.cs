using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3
{
    public static partial class TextColor
    {
        /// <summary>
        /// Bootstrap 3. Muted text color
        /// </summary>
        [CssClassInfo("text-muted", "muted")]
        public static readonly string Muted = "text-muted";

        /// <summary>
        /// Bootstrap 3. Primary text color
        /// </summary>
        [CssClassInfo("text-primary", "primary")]
        public static readonly string Primary = "text-primary";

        /// <summary>
        /// Bootstrap 3. Success text color
        /// </summary>
        [CssClassInfo("text-success", "success")]
        public static readonly string Success = "text-success";

        /// <summary>
        /// Bootstrap 3. Info text color
        /// </summary>
        [CssClassInfo("text-info", "info")]
        public static readonly string Info = "text-info";

        /// <summary>
        /// Bootstrap 3. Warning text color
        /// </summary>
        [CssClassInfo("text-warning", "warning")]
        public static readonly string Warning = "text-warning";

        /// <summary>
        /// Bootstrap 3. Danger text color
        /// </summary>
        [CssClassInfo("text-danger", "danger")]
        public static readonly string Danger = "text-danger";

        internal static string Parse(string color)
        {
            var parser = CssClassInfoCache.GetParser(typeof(TextColor));
            string className = parser.GetValue(color);
            return className;
        }
    }
}
