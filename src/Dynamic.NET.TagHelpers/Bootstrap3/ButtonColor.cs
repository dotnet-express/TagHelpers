using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Dynamic.NET.TagHelpers.Internal;

namespace Dynamic.NET.TagHelpers.Bootstrap3
{
    public static partial class ButtonColor
    {
        /// <summary>
        /// Bootstrap 3. Standard button with .btn-default class
        /// </summary>
        [CssClassInfo(Default, "default")]
        public const string Default = "btn-default";

        /// <summary>
        /// Bootstrap 3. Primary action button with .btn-primary class
        /// </summary>
        [CssClassInfo(Primary, "primary")]
        public const string Primary = "btn-primary";

        /// <summary>
        /// Bootstrap 3. Successful or positive action button with .btn-success class
        /// </summary>
        [CssClassInfo(Success, "success")]
        public const string Success = "btn-success";

        /// <summary>
        /// Bootstrap 3. Informational alert button with .btn-info class
        /// </summary>
        [CssClassInfo(Info, "info")]
        public const string Info = "btn-info";

        /// <summary>
        /// Bootstrap 3. Warning button with .btn-warning class
        /// </summary>
        [CssClassInfo(Warning, "warning")]
        public const string Warning = "btn-warning";

        /// <summary>
        /// Bootstrap 3. Danger button with .btn-danger class
        /// </summary>
        [CssClassInfo(Danger, "danger")]
        public const string Danger = "btn-danger";

        /// <summary>
        /// Bootstrap 3. Button look like a link with .btn-link class
        /// </summary>
        [CssClassInfo(Link, "link")]
        public const string Link = "btn-link";

        internal static string Parse(string color)
        {
            var parser = CssClassInfoCache.GetParser(typeof(ButtonColor));
            string className = parser.GetValue(color);
            return className;
        }
    }
}
