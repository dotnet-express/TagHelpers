using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [OutputElementHint("select")]
    [HtmlTargetElement("form-select", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class FormSelectTagHelper : FormControlTagHelper
    {
        public FormSelectTagHelper(IHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("select");
            output.AddCssClass("form-control");

            output.TagMode = TagMode.StartTagAndEndTag;

            //if (string.IsNullOrEmpty(InputType))
            //    InputType = "text";

            //output.Attributes.SetAttribute("type", InputType);

            // AspFor
            RenderAspFor(context, output);

            if (!string.IsNullOrEmpty(InputName))
                output.Attributes.SetAttribute("name", InputName);

            // Control Id
            RenderControlId(context, output, "form-select");

            // Disabled & ReadOnly
            RenderVisability(context, output);

            // Prepare for InputGroup tag helper
            PrepareForInputGroup(context, output);

            // InputGroupAppend
            RenderInputGroupAddons(context, output);

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
