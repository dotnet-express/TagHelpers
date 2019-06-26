using System;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.GridSystem
{
    [HtmlTargetElement("container-fluid")]
    public class ContainerFluid : Bootstrap3TagHelper
    {
        public ContainerFluid() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";    // Replaces <container> with <div> tag
            output.AddCssClass("container-fluid");
        }
    }
}
