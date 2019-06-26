using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [OutputElementHint("textarea")]
    [HtmlTargetElement("form-textarea")]
    public class FormTextareaTagHelper : FormControlTagHelper
    {
        public FormTextareaTagHelper(IHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea";
            output.AddCssClass("form-control");

            output.TagMode = TagMode.StartTagAndEndTag;

            if (string.IsNullOrEmpty(InputType))
                InputType = "text";

            output.Attributes.SetAttribute("type", InputType);

            if (!string.IsNullOrEmpty(InputName))
                output.Attributes.SetAttribute("name", InputName);

            // AspFor
            RenderAspFor(context, output);

            // Control Id
            RenderControlId(context, output, "form-textarea");

            // Disabled & ReadOnly
            RenderVisability(context, output);

            // Help
            RenderHelpText(context, output);

            // Validation
            RenderValidation(context, output);

            // Horizontal
            RenderHorizontalForm(context, output);

            // Size
            RenderSize(context, output);

            // Label
            RenderLabel(context, output);
        }
    }
}
