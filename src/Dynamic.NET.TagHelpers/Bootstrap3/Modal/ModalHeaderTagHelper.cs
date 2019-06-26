using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Modal
{
    /// <summary>
    /// Modal header tag helper.
    /// </summary>
    [HtmlTargetElement("modal-header", ParentTag = "modal-dialog")]
    public class ModalHeaderTagHelper : Bootstrap3TagHelper
    {
        public ModalHeaderTagHelper()
        {
        }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public ModalDialogTagHelper ModalDialogContext { get; set; }

        [HtmlAttributeName("title")]
        public string Title { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "modal-header");

            // Close buttom
            RenderCloseButton(context, output);

            // Title
            RenderTitle(context, output);
        }

        private void RenderControlId(TagHelperContext context, TagHelperOutput output)
        {
            
        }

        private void RenderCloseButton(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder buttonTag = new TagBuilder("button") { TagRenderMode = TagRenderMode.Normal };

            buttonTag.MergeAttribute("type", "button");

            buttonTag.AddCssClass("close");

            buttonTag.MergeAttribute("data-dismiss", "modal");
            buttonTag.MergeAttribute("aria-label", "Close");

            buttonTag.InnerHtml.AppendHtml(@"<span aria-hidden=""true"">&times;</span>");

            output.PreContent.AppendHtml(buttonTag);
        }

        private void RenderTitle(TagHelperContext context, TagHelperOutput output)
        {
            if (Title.IsNotNullOrEmpty())
            {
                TagBuilder titleTag = new TagBuilder("h4") { TagRenderMode = TagRenderMode.Normal };
                titleTag.AddCssClass("modal-title");
                titleTag.InnerHtml.Append(Title);

                if (ModalDialogContext != null)
                {
                    var titleTagId = $"{ModalDialogContext.ControlId}-title";
                    titleTag.MergeAttribute("id", titleTagId);
                }

                output.PreContent.AppendHtml(titleTag);
            }
        }
    }
}
