using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [OutputElementHint("input")]
    [HtmlTargetElement("form-radio", TagStructure = TagStructure.WithoutEndTag)]
    public class FormRadioTagHelper : FormControlTagHelper
    {
        public FormRadioTagHelper(IHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {

        }

        [HtmlAttributeName("inline")]
        public bool IsInline { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("input");

            output.TagMode = TagMode.SelfClosing;

            InputType = "radio";
            output.Attributes.SetAttribute("type", InputType);

            // AspFor
            RenderAspFor(context, output);

            // Control Id
            RenderControlId(context, output, "form-radio");

            //Label Text
            RenderRadioLabel(context, output);

            // Disabled & ReadOnly
            RenderVisability(context, output);

            if (this.IsInline)
            {
                TagBuilder wrapper1 = new TagBuilder("label") { TagRenderMode = TagRenderMode.Normal };
                wrapper1.AddCssClass("radio-inline");
                output.WrapOutside(wrapper1);
            }
            else
            {
                TagBuilder wrapper1 = new TagBuilder("label") { TagRenderMode = TagRenderMode.Normal };
                output.WrapOutside(wrapper1);

                TagBuilder wrapper2 = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
                wrapper2.AddCssClass("radio");
                if (IsDisabled) wrapper2.AddCssClass("disabled");
                output.WrapOutside(wrapper2);
            }

            // Help Text
            RenderHelpText(context, output);

            // Validation
            RenderValidation(context, output);

            // Fix checkbox bug
            RenderValidationFix(context, output);

            // Horizontal
            RenderHorizontalForm(context, output, true);
        }

        private void RenderRadioLabel(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(LabelText))
                output.PostElement.AppendHtml(LabelText);
        }

        private void RenderValidationFix(TagHelperContext context, TagHelperOutput output)
        {
            if (output.Attributes.ContainsName("data-val-required"))
            {
                var text = output.Attributes["data-val-required"].Value;
                output.Attributes.RemoveAll("data-val-required");
                output.Attributes.Add("required", null);
                output.Attributes.Add("data-msg-required", text);
            }

        }
    }
}
