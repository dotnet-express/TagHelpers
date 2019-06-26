using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [HtmlTargetElement("page-header")]
    public class PageHeaderTagHelper : Bootstrap3TagHelper
    {
        public PageHeaderTagHelper() : base()
        {
        }

        [HtmlAttributeName("level")]
        public int Level { get; set; } = 1;

        [HtmlAttributeName("title")]
        public string Title { get; set; }

        [HtmlAttributeName("sub-title")]
        public string SubTitle { get; set; }


        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("page-header");

            output.TagMode = TagMode.StartTagAndEndTag;

            // Title & SubTitle
            RenderTitle(context, output);
        }

        private void RenderTitle(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                if (Level < 1) Level = 1;
                if (Level > 6) Level = 6;

                TagBuilder builderTitle = new TagBuilder("h"+Level) { TagRenderMode = TagRenderMode.Normal };
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
