using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.GridSystem
{
    [HtmlTargetElement("row")]
    public class RowTagHelper : Bootstrap3TagHelper
    {
        public RowTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";    // Replaces <container> with <div> tag
            output.AddCssClass("row");
        }
    }
}
