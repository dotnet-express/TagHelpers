using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Dropdowns
{
    [HtmlTargetElement("dropdown-btn")]
    [HtmlTargetElement("dropdown-btn-flat")]
    public class DropdownButtonTagHelper : Bootstrap3TagHelper
    {
        public DropdownButtonTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("button");
            output.TagMode = TagMode.StartTagAndEndTag;

            output.AddCssClass("btn");
            output.AddCssClass("btn-default");
            output.AddCssClass("dropdown-toggle");

            if (context.TagName.Equals("dropdown-btn-flat"))
                output.AddCssClass("btn-flat");

            output.Attributes.SetAttribute("type", "button");
            output.Attributes.SetAttribute("data-toggle", "dropdown");

            //ARIA
            output.Attributes.SetAttribute("aria-haspopup", "true");
            output.Attributes.SetAttribute("aria-expanded", "false");

            if (!context.AllAttributes.ContainsName("nocaret"))
            {
                output.PostContent.AppendHtml(" ");

                TagBuilder caret = new TagBuilder("span") { TagRenderMode = TagRenderMode.Normal };
                caret.AddCssClass("caret");
                output.PostContent.AppendHtml(caret);
            }
            
        }
    }
}
