using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Navs
{
    [HtmlTargetElement("nav-tabs-custom")]
    public class NavTabsCustomTagHelper : AdminLTE2TagHelper
    {
        public NavTabsCustomTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("nav-tabs-custom");
        }
    }
}
