using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    [HtmlTargetElement("navbar-content")]
    public class NavbarContentTagHelper : Bootstrap3TagHelper
    {
        public NavbarContentTagHelper() : base()
        {
        }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public NavbarTagHelper NavbarContext { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");

            if (NavbarContext != null && NavbarContext.IsCollapsible)
            {
                output.MergeAttribute("id", $"{ NavbarContext.ControlId }-content");

                output.AddCssClass("collapse");
                output.AddCssClass("navbar-collapse");
            }
        }
    }
}
