using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [HtmlTargetElement("caption", ParentTag = "thumbnail")]
    public class ThumbnailCaptionTagHelper : Bootstrap3TagHelper
    {
        public ThumbnailCaptionTagHelper() : base()
        {
        }

        [HtmlAttributeName("title")]
        public string Title { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("caption");

            if (Title.IsNotNullOrEmpty())
            {
                TagBuilder title = new TagBuilder("h3") { TagRenderMode = TagRenderMode.Normal };
                title.InnerHtml.Append(Title);
                output.PreContent.AppendHtml(title);
            }
        }
    }
}
