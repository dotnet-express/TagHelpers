using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Dynamic.NET.TagHelpers.Extensions
{
    public static class MemberInfoExtensions
    {
        public static bool HasCustomAttribute<T>(this MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes(typeof(T), true).Any();
        }

        public static bool HasCustomAttribute(this MemberInfo memberInfo, Type attributeType)
        {
            return memberInfo.GetCustomAttributes(attributeType, true).Any();
        }

        public static string GetHtmlAttributeName(this MemberInfo property)
        {
            var htmlAttributeNameAttribute = property.GetCustomAttribute<HtmlAttributeNameAttribute>();
            if (htmlAttributeNameAttribute != null)
                return htmlAttributeNameAttribute.DictionaryAttributePrefix + htmlAttributeNameAttribute.Name;
            return Regex.Replace(property.Name, "([A-Z])", "-$1").ToLower().Trim('-');
        }
    }
}
