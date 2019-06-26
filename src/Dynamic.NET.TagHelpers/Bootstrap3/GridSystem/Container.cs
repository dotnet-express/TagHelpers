using System;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.GridSystem
{
    [HtmlTargetElement("container")]
    public class Container : Bootstrap3TagHelper
    {
        public Container() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";    // Replaces <container> with <div> tag
            output.AddCssClass("container");
        }
    }
}
    