using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Attributes
{
    /// <summary>
    /// Marks a property as a bindable for context.
    /// in other tag helpers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class BindTagHelperContextAttribute : Attribute
    {
        /// <summary>
        /// If true, context items which type inherits from the actual property type will be used if no context item with
        /// matching type is found
        /// </summary>
        public bool UseInherited { get; set; } = true;

        /// <summary>
        /// If true, context item will be removed once after it is assigned to the decorated property
        /// </summary>
        public bool RemoveContext { get; set; }

        /// <summary>
        /// Loads context using this key instead of default one
        /// </summary>
        public string Key { get; set; }

        public BindTagHelperContextAttribute()
        {
        }

        public BindTagHelperContextAttribute(string key)
        {
            this.Key = key;
        }
    }
}
