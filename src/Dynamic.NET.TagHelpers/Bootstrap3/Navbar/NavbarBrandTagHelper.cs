using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    [OutputElementHint("a")]
    [HtmlTargetElement("navbar-brand", ParentTag = "navbar-header")]
    public class NavbarBrandTagHelper : Bootstrap3TagHelper
    {
        public NavbarBrandTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");
            output.AddCssClass("navbar-brand");
        }
    }
}
