using System;
using System.Collections.Generic;
using System.Linq;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Buttons
{
    [OutputElementHint("button")]
    [HtmlTargetElement("button")]
    [HtmlTargetElement("btn-default")]
    [HtmlTargetElement("btn-primary")]
    [HtmlTargetElement("btn-success")]
    [HtmlTargetElement("btn-info")]
    [HtmlTargetElement("btn-warning")]
    [HtmlTargetElement("btn-danger")]
    [TagHelperContext]
    public class ButtonTagHelper : Bootstrap3TagHelper
    {
        public ButtonTagHelper() : base()
        {
        }

        [HtmlAttributeName("active")]
        public bool IsActive { get; set; }

        [HtmlAttributeName("block")]
        public bool IsBlock { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsDisabled { get; set; }

        [HtmlAttributeName("type")]
        public string Type { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("button");
            output.AddCssClass("btn");

            if (TagName.Equals("button", StringComparison.OrdinalIgnoreCase))
                output.AddCssClass(ButtonColor.Default);
            else
                output.AddCssClass(context.TagName);

            if (IsBlock)
                output.AddCssClass("btn-block");

            // Type
            RenderType(context, output);

            // Disabled & ReadOnly
            RenderVisability(context, output);
        }

        protected void RenderType(TagHelperContext context, TagHelperOutput output)
        {
            if (Type.IsNullOrEmpty())
                Type = "button";

            output.Attributes.SetAttribute("type", Type);
        }

        protected void RenderVisability(TagHelperContext context, TagHelperOutput output)
        {
            if (IsActive)
                output.AddCssClass("active");

            if (IsDisabled) {
                output.AddCssClass("disabled");
                output.MergeAttribute("disabled", "disabled");
            }
        }

        public override int Order => 0;
    }
}
