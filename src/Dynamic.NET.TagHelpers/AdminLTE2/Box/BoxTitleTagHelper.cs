using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Box
{
    [OutputElementHint("div")]
    [HtmlTargetElement("box-title")]
    public class BoxTitleTagHelper : AdminLTE2TagHelper
    {
        public BoxTitleTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("h2");
            output.AddCssClass("box-title");
        }
    }
}
