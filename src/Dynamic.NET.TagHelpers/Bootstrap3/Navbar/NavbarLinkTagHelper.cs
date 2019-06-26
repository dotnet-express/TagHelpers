using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    [OutputElementHint("a")]
    [HtmlTargetElement("navbar-link", ParentTag = "navbar-items")]
    public class NavbarLinkTagHelper : Bootstrap3TagHelper
    {
        public NavbarLinkTagHelper() : base()
        {
        }

        [HtmlAttributeName("active")]
        public bool IsItemActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsItemDisabled { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");

            if (!context.AllAttributes.ContainsName("href"))
                output.Attributes.SetAttribute("href", "#");

            TagBuilder wrapper = new TagBuilder("li") { TagRenderMode = TagRenderMode.Normal };
            if (IsItemActive) wrapper.AddCssClass("active");
            if (IsItemDisabled) wrapper.AddCssClass("disabled");
            output.WrapOutside(wrapper);
        }
    }
}
