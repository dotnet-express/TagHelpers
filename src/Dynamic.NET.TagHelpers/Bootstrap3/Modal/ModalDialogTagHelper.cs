using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Modal
{
    /// <summary>
    /// Modal dialog tag helper
    /// </summary>
    /// <remarks>
    /// Modals are streamlined, but flexible, dialog prompts with the minimum required functionality and smart defaults.
    /// </remarks>
    [TagHelperContext]
    [HtmlTargetElement("modal-dialog")]
    public class ModalDialogTagHelper : Bootstrap3TagHelper
    {
        public ModalDialogTagHelper()
        {
        }

        [HtmlAttributeName("id")]
        public string ControlId { get; set; }

        protected async override Task RenderAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "modal-dialog");

            output.MergeAttribute("role", "document");

            // Control Id
            if (string.IsNullOrEmpty(ControlId))
                ControlId = $"modal-{Guid.NewGuid().ToString("N")}";

            // Render child content
            await output.GetChildContentAsync();

            // Render modal wrapper
            RenderModalWrapper(context, output);

            // Render content wrapper
            RenderContentWrapper(context, output);
        }

        private void RenderControlId(TagHelperContext context, TagHelperOutput output)
        {
            
        }

        private void RenderModalWrapper(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder modalTag = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };

            modalTag.MergeAttribute("id", ControlId);

            modalTag.AddCssClass("fade");
            modalTag.AddCssClass("modal");

            modalTag.MergeAttribute("role", "dialog");
            modalTag.MergeAttribute("tabindex", "-1");

            modalTag.MergeAttribute("aria-labelledby", $"{ControlId}-title");

            output.WrapOutside(modalTag);
        }

        private void RenderContentWrapper(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder contentTag = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };

            contentTag.AddCssClass("modal-content");

            output.WrapContentOutside(contentTag);
        }
    }
}
