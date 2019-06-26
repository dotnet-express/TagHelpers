using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Buttons
{
    [OutputElementHint("a")]
    [HtmlTargetElement("btn-link")]
    public class ButtonLinkTagHelper : Bootstrap3TagHelper
    {
        public ButtonLinkTagHelper(): base()
        {
        }

        [HtmlAttributeName("active")]
        public bool IsActive { get; set; }

        [HtmlAttributeName("block")]
        public bool IsBlock { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsDisabled { get; set; }

        [HtmlAttributeName("href")]
        public string Href { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");

            output.AddCssClass("btn");
            output.AddCssClass("btn-link");

            if (IsBlock)
                output.AddCssClass("btn-block");

            RenderHref(context, output);

            RenderVisability(context, output);
        }

        protected void RenderHref(TagHelperContext context, TagHelperOutput output)
        {
            if (Href.IsNullOrEmpty())
                Href = "#";

            output.Attributes.SetAttribute("href", Href);
        }

        protected void RenderVisability(TagHelperContext context, TagHelperOutput output)
        {
            if (IsActive)
                output.AddCssClass("active");

            if (IsDisabled)
            {
                output.AddCssClass("disabled");
                output.MergeAttribute("disabled", "disabled");
            }
        }

        public override int Order => 0;
    }
}
