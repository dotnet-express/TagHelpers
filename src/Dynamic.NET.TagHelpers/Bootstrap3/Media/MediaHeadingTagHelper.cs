using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Media
{
    [HtmlTargetElement("media-heading", ParentTag = "media-body")]
    public class MediaHeadingTagHelper : Bootstrap3TagHelper
    {
        public MediaHeadingTagHelper() : base()
        {
        }

        [HtmlAttributeName("level")]
        public int Level { get; set; } = 4;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("h" + Level);
            output.AddCssClass("media-heading");
        }
    }
}
