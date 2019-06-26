using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Layout
{
    [HtmlTargetElement("wrapper", ParentTag = "body")]
    public class WrapperTagHelper : AdminLTE2TagHelper
    {
        public WrapperTagHelper() : base()
        {

        }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public BodyTagHelper BodyContext { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("wrapper");

            if (BodyContext != null && BodyContext.IsNeedWrapper)
                BodyContext.IsNeedWrapper = false;
        }
    }
}
