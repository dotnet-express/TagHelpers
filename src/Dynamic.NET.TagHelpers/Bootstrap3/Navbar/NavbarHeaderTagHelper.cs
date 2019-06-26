using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    [HtmlTargetElement("navbar-header")]
    public class NavbarHeaderTagHelper : Bootstrap3TagHelper
    {
        public NavbarHeaderTagHelper() : base()
        {
        }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public NavbarTagHelper NavbarContext { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("navbar-header");

            RenderCollapseButton(context, output);
        }

        //protected override async Task RenderAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    await output.GetChildContentAsync();
        //}

        private void RenderCollapseButton(TagHelperContext context, TagHelperOutput output)
        {
            if (NavbarContext != null && NavbarContext.IsCollapsible)
            {
                TagBuilder button = new TagBuilder("button") { TagRenderMode = TagRenderMode.Normal };
                button.Attributes.Add("type", "button");
                button.AddCssClass("navbar-toggle");
                button.AddCssClass("collapsed");
                button.Attributes.Add("data-toggle", "collapse");
                button.Attributes.Add("data-target", $"#{ NavbarContext.ControlId }-content");

                // ARIA
                button.Attributes.Add("aria-expanded", "false");

                button.InnerHtml.AppendHtml(string.Format("{0}{0}{0}","<span class=\"icon-bar\"></span>"));

                output.PreContent.AppendHtml(button);
            }
        }
    }
}
