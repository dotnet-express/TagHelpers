using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Layout
{
    [HtmlTargetElement("content")]
    public class ContentTagHelper : AdminLTE2TagHelper
    {
        public ContentTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("section");
            output.AddCssClass("content");
            output.AddCssClass("container-fluid");
        }
    }
}
