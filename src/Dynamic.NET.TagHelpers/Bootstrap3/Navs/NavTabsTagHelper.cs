using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navs
{
    [HtmlTargetElement("nav-tabs")]
    [HtmlTargetElement("nav-pills")]
    public class NavTabsTagHelper : Bootstrap3TagHelper
    {
        public NavTabsTagHelper() : base()
        {
        }

        [HtmlAttributeName("stacked")]
        public bool IsStacked { get; set; }

        [HtmlAttributeName("justified")]
        public bool IsJustified { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("ul");
            output.AddCssClass("nav");

            output.AddCssClass(context.TagName);

            if (IsStacked) output.AddCssClass("nav-stacked");
            if (IsJustified) output.AddCssClass("nav-justified");

            // ARIA
            output.Attributes.SetAttribute("role", "tablist");
        }
    }
}
