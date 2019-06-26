using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Media
{
    [HtmlTargetElement("media")]
    public class MediaTagHelper : Bootstrap3TagHelper
    {
        public MediaTagHelper() : base()
        {
        }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public MediaListTagHelper MediaListContext { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("media");

            if (MediaListContext != null)
            {
                output.SetTagName("li");
            }
        }
    }
}
