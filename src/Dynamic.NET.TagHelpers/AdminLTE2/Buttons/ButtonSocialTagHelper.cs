using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Buttons
{
    /// <summary>
    /// <see cref="ITagHelper"/> implementation targeting &lt;btn-social&gt; element.
    /// </summary>
    /// <example>
    /// Example: &lt;btn-social icon="facebook"&gt;Sign in with Facebook&lt;/btn-social&gt;
    /// </example>
    [OutputElementHint("button")]
    [HtmlTargetElement("btn-social")]
    public class ButtonSocialTagHelper : AdminLTE2TagHelper
    {
        public ButtonSocialTagHelper() : base()
        {
        }

        [HtmlAttributeName("icon")]
        public string Icon { get; set; }

        [HtmlAttributeName("block")]
        public bool IsBlock { get; set; }

        [HtmlAttributeName("flat")]
        public bool IsFlat { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("button");

            output.TagMode = TagMode.StartTagAndEndTag;

            output.AddCssClass("btn");
            output.AddCssClass($"btn-{Icon.ToLower()}");

            if (IsBlock) output.AddCssClass("btn-block");
            if (IsFlat) output.AddCssClass("btn-flat");

            if (Icon.IsNotNullOrEmpty())
            {
                // Fix: this fix microsoft social button collision.
                if (Icon.Equals("microsoft", StringComparison.OrdinalIgnoreCase)) Icon = "windows";

                TagBuilder builder = new TagBuilder("i") { TagRenderMode = TagRenderMode.Normal };
                builder.AddCssClass($"fa-{Icon.ToLower()}");
                builder.AddCssClass("fa");

                output.PreContent.AppendHtml(builder);
                output.PreContent.AppendHtml(" ");
            }
        }
    }
}
