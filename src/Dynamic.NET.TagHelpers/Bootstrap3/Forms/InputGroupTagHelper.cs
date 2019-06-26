using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [TagHelperContext]
    [HtmlTargetElement("input-group")]
    public class InputGroupTagHelper : FormControlTagHelper
    {
        public InputGroupTagHelper(IHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }
        protected override async Task RenderAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.GetChildContentAsync();

            output.SetTagName("div");
            output.AddCssClass("input-group");

            // AspFor
            RenderInputGroupAspFor(context, output);

            // Control Id
            RenderControlId(context, output, "form-group");

            // Disabled & ReadOnly
            RenderVisability(context, output);

            // Help
            RenderHelpText(context, output);

            // Validation
            RenderValidation(context, output);

            // Horizontal
            RenderHorizontalForm(context, output);

            // Size
            RenderSize(context, output, "input-group");

            // Label
            RenderLabel(context, output);
        }

        protected void RenderInputGroupAspFor(TagHelperContext context, TagHelperOutput output)
        {
            if (AspFor != null)
            {
                if (string.IsNullOrEmpty(LabelText) && AspFor.Metadata.DisplayName != null)
                    LabelText = AspFor.Metadata.DisplayName;

                if (string.IsNullOrEmpty(HelpText) && AspFor.Metadata.Description != null)
                    HelpText = AspFor.Metadata.Description;
            }
        }
    }
}
