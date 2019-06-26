using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Media
{
    [HtmlTargetElement("media-body", ParentTag = "media")]
    public class MediaBodyTagHelper : Bootstrap3TagHelper
    {
        public MediaBodyTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("media-body");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
