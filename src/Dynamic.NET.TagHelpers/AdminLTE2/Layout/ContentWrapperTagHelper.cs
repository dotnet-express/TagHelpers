using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Layout
{
    [HtmlTargetElement("content-wrapper", ParentTag = "wrapper")]
    public class ContentWrapperTagHelper : AdminLTE2TagHelper
    {
        public ContentWrapperTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("content-wrapper");
        }
    }
}
