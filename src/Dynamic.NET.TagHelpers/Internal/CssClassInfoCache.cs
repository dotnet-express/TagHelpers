using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic.NET.TagHelpers.Internal
{
    internal static class CssClassInfoCache
    {
        static IDictionary<Type, CssClassInfoParser> parsers = new Dictionary<Type, CssClassInfoParser>();

        internal static CssClassInfoParser GetParser(Type type)
        {
            if (parsers.ContainsKey(type))
                return parsers[type];

            CssClassInfoParser parser = new CssClassInfoParser(type);
            parsers.Add(type, parser);

            return parser;
        }
    }
}
