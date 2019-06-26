using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CssClassInfoAttribute : Attribute
    {
        public string ClassName { get; set; }
        public string[] Aliases { get; set; }

        public CssClassInfoAttribute(string className)
        {
            this.ClassName = className;
        }

        public CssClassInfoAttribute(string className, params string[] aliases)
        {
            this.ClassName = className;
            this.Aliases = aliases;
        }
    }
}
