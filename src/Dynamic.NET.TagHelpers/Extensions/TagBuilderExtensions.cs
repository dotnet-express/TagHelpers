using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Extensions
{
    public static class TagBuilderExtensions
    {
        /// <summary>
        ///     Adds an style entry
        /// </summary>
        public static void AddCssStyle(this TagBuilder builder, string name, string value)
        {
            if (builder.Attributes.ContainsKey("style"))
            {
                if (string.IsNullOrEmpty(builder.Attributes["style"].ToString()))
                {
                    builder.Attributes["style"] = name + ": " + value + ";";
                }
                else
                {
                    var styleText = builder.Attributes["style"].ToString();
                    builder.Attributes["style"] = styleText + (styleText.EndsWith(";") ? " " : "; ") + name + ": " + value + ";";
                }
            }
            else
            {
                builder.Attributes.Add("style", name + ": " + value + ";");
            }
        }
    }
}
