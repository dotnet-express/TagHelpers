using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Helpers
{
    [HtmlTargetElement("sr-only")]
    public class SrOnlyTagHelper : Bootstrap3TagHelper
    {
        public SrOnlyTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("span");
            output.TagMode = TagMode.StartTagAndEndTag;

            output.AddCssClass("sr-only");
        }
    }
}
