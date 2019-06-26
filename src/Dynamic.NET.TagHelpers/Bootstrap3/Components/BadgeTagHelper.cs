using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [HtmlTargetElement("badge")]
    public class BadgeTagHelper : Bootstrap3TagHelper
    {
        public BadgeTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("span");
            output.AddCssClass("badge");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
