using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    [HtmlTargetElement("navbar-dropdown", ParentTag = "navbar-items")]
    public class NavbarDropdownTagHelper : Bootstrap3TagHelper
    {
        public NavbarDropdownTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("li");
            output.AddCssClass("dropdown");
        }
    }
}
