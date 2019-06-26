using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    [HtmlTargetElement("navbar-text", ParentTag = "navbar-content")]
    public class NavbarTextTagHelper : Bootstrap3TagHelper
    {
        public NavbarTextTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("p");
            output.AddCssClass("navbar-text");
        }
    }
}
