using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navs
{
    [HtmlTargetElement("tab-pane", ParentTag = "tab-content")]
    public class TabPaneTagHelper : Bootstrap3TagHelper
    {
        public TabPaneTagHelper() : base()
        {
        }

        [HtmlAttributeName("active")]
        public bool IsItemActive { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("tab-pane");

            if (IsItemActive) output.AddCssClass("active");

            // ARIA
            output.Attributes.SetAttribute("role", "tabpanel");
        }
    }
}
