using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace Dynamic.NET.TagHelpers.Extensions
{
    public static class EnumExtensions
    {
        public static EnumInfoAttribute GetEnumInfo(this Enum e)
        {
            MemberInfo memberInfo = e.GetType().GetMember(e.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                return memberInfo.GetCustomAttribute<EnumInfoAttribute>();
            }

            throw new InvalidOperationException("It is not possible to read EnumInfoAttribute from enumeration.");
        }
    }
}
