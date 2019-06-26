using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [HtmlTargetElement("help-block")]
    public class HelpBlockTagHelper : Bootstrap3TagHelper
    {
        public HelpBlockTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.AddCssClass("help-block");
        }
    }
}
