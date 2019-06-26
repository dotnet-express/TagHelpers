using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3
{
    public static partial class BackgroundColor
    {
        /// <summary>
        /// Bootstrap 3. Without background
        /// </summary>
        public static readonly string None = string.Empty;

        /// <summary>
        /// Bootstrap 3. Primary background
        /// </summary>
        [CssClassInfo("bg-primary", "primary")]
        public static readonly string Primary = "bg-primary";

        /// <summary>
        /// Bootstrap 3. Success background
        /// </summary>
        [CssClassInfo("bg-success", "success")]
        public static readonly string Success = "bg-success";

        /// <summary>
        /// Bootstrap 3. Info background
        /// </summary>
        [CssClassInfo("bg-info", "info")]
        public static readonly string Info = "bg-info";

        /// <summary>
        /// Bootstrap 3. Warning background
        /// </summary>
        [CssClassInfo("bg-warning", "warning")]
        public static readonly string Warning = "bg-warning";

        /// <summary>
        /// Bootstrap 3. Danger background
        /// </summary>
        [CssClassInfo("bg-danger", "danger")]
        public static readonly string Danger = "bg-danger";

        internal static string Parse(string color)
        {
            var parser = CssClassInfoCache.GetParser(typeof(BackgroundColor));
            string className = parser.GetValue(color);
            return className;
        }
    }
}
