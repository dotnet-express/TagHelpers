using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumInfoAttribute: Attribute
    {
        public string Name { get; set; }

        public EnumInfoAttribute(string name)
        {
            this.Name = name;
        }
    }
}
