using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Navs
{
    [HtmlTargetElement("nav-header", ParentTag = "nav-tabs")]
    [HtmlTargetElement("nav-header", ParentTag = "nav-pills")]
    public class NavHeaderTagHelper : AdminLTE2TagHelper
    {
        public NavHeaderTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("li");
            output.AddCssClass("header");
        }
    }
}
