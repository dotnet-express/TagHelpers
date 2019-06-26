using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dynamic.NET.TagHelpers.Internal
{
    internal class CssClassInfoParser
    {
        private Type type;

        internal CssClassInfoParser(Type type)
        {
            this.type = type;
        }

        internal string GetValue(string value)
        {
            if (value.IsNullOrEmpty())
                return value;

            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                string fieldValue = field.GetValue(null) as string;

                if (fieldValue.Equals(value, StringComparison.OrdinalIgnoreCase))
                    return value;

                var attr = field.GetCustomAttribute<CssClassInfoAttribute>();
                if (attr != null)
                {
                    if (attr.Aliases.Any(t => t.Equals(value, StringComparison.OrdinalIgnoreCase)))
                        return fieldValue;
                }
            }

            return value;

        }
    }
}
