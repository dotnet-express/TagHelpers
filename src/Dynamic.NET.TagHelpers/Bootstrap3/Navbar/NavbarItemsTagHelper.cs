using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    /// <summary>
    /// Navbar items tag helper.
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    [HtmlTargetElement("navbar-items", ParentTag = "navbar-content")]
    public class NavbarItemsTagHelper : Bootstrap3TagHelper
    {
        public NavbarItemsTagHelper() : base()
        {
        }

        
        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("ul");

            output.AddCssClass("nav");
            output.AddCssClass("navbar-nav");
        }
    }
}
