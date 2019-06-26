using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [TagHelperContext]
    [HtmlTargetElement("progress-stack")]
    public class ProgressStackTagHelper : Bootstrap3TagHelper
    {
        public ProgressStackTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("progress");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
