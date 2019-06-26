using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [HtmlTargetElement("input-group-btn", ParentTag = "input-group")]
    public class InputGroupButtonTagHelper : Bootstrap3TagHelper
    {
        public InputGroupButtonTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("input-group-btn");
        }
    }
}
