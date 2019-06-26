using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navs
{
    [HtmlTargetElement("nav-dropdown", ParentTag = "nav-tabs")]
    [HtmlTargetElement("nav-dropdown", ParentTag = "nav-pills")]
    public class NavDropdownTagHelper : Bootstrap3TagHelper
    {
        public NavDropdownTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("li");
            output.AddCssClass("dropdown");
        }
    }
}
