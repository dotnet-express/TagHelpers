using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Media
{
    [TagHelperContext]
    [HtmlTargetElement("media-list")]
    public class MediaListTagHelper : Bootstrap3TagHelper
    {
        public MediaListTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("ul");
            output.AddCssClass("media-list");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
