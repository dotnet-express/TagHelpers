using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    [HtmlTargetElement("navbar-form", ParentTag = "navbar-content")]
    [HtmlTargetElement("form", ParentTag = "navbar-content")]
    public class NavbarFormTagHelper : Bootstrap3TagHelper
    {
        public NavbarFormTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("form");
            output.AddCssClass("navbar-form");
        }
    }
}
