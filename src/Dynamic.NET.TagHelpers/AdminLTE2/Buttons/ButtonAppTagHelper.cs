using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Buttons
{
    [OutputElementHint("a")]
    [HtmlTargetElement("btn-app")]
    public class ButtonAppTagHelper : AdminLTE2TagHelper
    {
        public ButtonAppTagHelper() : base()
        {
        }

        [HtmlAttributeName("icon")]
        public string Icon { get; set; }

        [HtmlAttributeName("flat")]
        public bool IsFlat { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");

            output.AddCssClass("btn");
            output.AddCssClass("btn-app");

            if (IsFlat) output.AddCssClass("btn-flat");

            if (Icon.IsNotNullOrEmpty())
            {
                TagBuilder builder = new TagBuilder("i") { TagRenderMode = TagRenderMode.Normal };
                builder.AddCssClass($"fa-{Icon.ToLower()}");
                builder.AddCssClass("fa");

                output.PreContent.AppendHtml(builder);
                output.PreContent.AppendHtml(" ");
            }
        }
    }
}
