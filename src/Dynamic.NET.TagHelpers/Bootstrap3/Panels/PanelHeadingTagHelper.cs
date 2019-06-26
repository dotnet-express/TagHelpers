using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Panels
{
    /// <summary>
    /// Panel heading tag helper.
    /// </summary>
    [HtmlTargetElement("panel-heading", ParentTag = "panel")]
    public class PanelHeadingTagHelper : Bootstrap3TagHelper
    {
        public PanelHeadingTagHelper()
        {
        }

        [HtmlAttributeName("title")]
        public string Title { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "panel-heading");

            if (Title.IsNotNullOrEmpty())
            {
                TagBuilder titleTag = new TagBuilder("h3") { TagRenderMode = TagRenderMode.Normal };
                titleTag.AddCssClass("panel-title");
                titleTag.InnerHtml.Append(Title);
                output.Content.AppendHtml(titleTag);
            }
        }
    }
}
