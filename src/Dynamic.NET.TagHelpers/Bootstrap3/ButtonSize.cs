using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3
{
    public static partial class ButtonSize
    {
        /// <summary>
        /// Bootstrap 3. Standard button size.
        /// </summary>
        public static readonly string Normal = string.Empty;

        /// <summary>
        /// Bootstrap 3. Large button with .btn-lg cglass
        /// </summary>
        [CssClassInfo("btn-lg", "large", "lg")]
        public static readonly string Large = "btn-lg";

        /// <summary>
        /// Bootstrap 3. Small button with .btn-sm cglass
        /// </summary>
        [CssClassInfo("btn-sm", "small", "sm")]
        public static readonly string Small = "btn-sm";

        /// <summary>
        /// Bootstrap 3. Extra Small button with .btn-sm cglass
        /// </summary>
        [CssClassInfo("btn-xs", "extrasmall", "xs")]
        public static readonly string ExtraSmall = "btn-xs";

        public static string Parse(string size)
        {
            var parser = CssClassInfoCache.GetParser(typeof(ButtonSize));
            string className = parser.GetValue(size);
            return className;
        }
    }
}
