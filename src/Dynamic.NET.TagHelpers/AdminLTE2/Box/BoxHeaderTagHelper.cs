using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Box
{
    [OutputElementHint("div")]
    [HtmlTargetElement("box-header")]
    public class BoxHeaderTagHelper : AdminLTE2TagHelper
    {
        public BoxHeaderTagHelper() : base()
        {
        }

        [HtmlAttributeName("with-border")]
        public bool IsWithBorder { get; set; } = true;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("box-header");

            RenderBorder(context, output);
        }

        private void RenderBorder(TagHelperContext context, TagHelperOutput output)
        {
            if (IsWithBorder)
                output.AddCssClass("with-border");
        }
    }
}
