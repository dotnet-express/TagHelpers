using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Layout
{
    [HtmlTargetElement("content-header")]
    public class ContentHeaderTagHelper : AdminLTE2TagHelper
    {
        public ContentHeaderTagHelper() : base()
        {
        }

        [HtmlAttributeName("title")]
        public string Title { get; set; }

        [HtmlAttributeName("sub-title")]
        public string SubTitle { get; set; }


        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("section");
            output.AddCssClass("content-header");

            output.TagMode = TagMode.StartTagAndEndTag;

            // Title & SubTitle
            RenderTitle(context, output);
        }

        private void RenderTitle(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                TagBuilder builderTitle = new TagBuilder("h1") { TagRenderMode = TagRenderMode.Normal };
                builderTitle.InnerHtml.Append(Title);

                if (!string.IsNullOrEmpty(SubTitle))
                {
                    TagBuilder builderSubTitle = new TagBuilder("small") { TagRenderMode = TagRenderMode.Normal };
                    builderSubTitle.InnerHtml.Append(SubTitle);

                    builderTitle.InnerHtml.AppendHtml(builderSubTitle);
                }

                output.PreContent.AppendHtml(builderTitle);
            }
        }
    }
}
