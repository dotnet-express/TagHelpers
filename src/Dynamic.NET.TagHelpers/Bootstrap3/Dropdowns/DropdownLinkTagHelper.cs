using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Dropdowns
{
    [HtmlTargetElement("dropdown-link", ParentTag = "nav-dropdown")]
    [HtmlTargetElement("dropdown-link", ParentTag = "navbar-dropdown")]
    public class DropdownLinkTagHelper : Bootstrap3TagHelper
    {
        public DropdownLinkTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");
            output.AddCssClass("dropdown-toggle");

            if (!context.AllAttributes.ContainsName("href"))
                output.Attributes.SetAttribute("href", "#");

            output.Attributes.SetAttribute("role", "button");
            output.Attributes.SetAttribute("data-toggle", "dropdown");

            //ARIA
            output.Attributes.SetAttribute("aria-haspopup", "true");
            output.Attributes.SetAttribute("aria-expanded", "false");

            if (!context.AllAttributes.ContainsName("nocaret"))
            {
                output.PostContent.AppendHtml("&nbsp;");

                TagBuilder caret = new TagBuilder("span") { TagRenderMode = TagRenderMode.Normal };
                caret.AddCssClass("caret");
                output.PostContent.AppendHtml(caret);
            }
        }
    }
}
