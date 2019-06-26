using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Attributes
{
    /// <summary>
    /// Marks a tag helper as a context class. This means that the tag helper can included as a context (parent)
    /// in other tag helpers.
    /// </summary>
    public class TagHelperContextAttribute : Attribute
    {
        public TagHelperContextAttribute(Type type)
        {
            this.Type = type;
        }

        public TagHelperContextAttribute()
        {
        }

        public TagHelperContextAttribute(string key)
        {
            this.Key = key;
        }

        /// <summary>
        ///     Custom key which will be used to store the context in context items. If set the context will not be accessible
        ///     without the key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Type which will be used as key in context items
        /// </summary>
        public Type Type { get; set; }
    }
}
