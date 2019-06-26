using Dynamic.NET.TagHelpers.Bootstrap3;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [HtmlTargetElement("form-static")]
    public class FormStaticTagHelper : FormControlTagHelper
    {
        public FormStaticTagHelper(IHtmlGenerator htmlGenerator) : base(htmlGenerator)
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";

            output.AddCssClass("form-control-static");

            // Control Id
            RenderControlId(context, output, "form-static");

            // Validation
            RenderValidation(context, output);

            // Help
            RenderHelpText(context, output);

            // Horizontal
            RenderHorizontalForm(context, output);

            // Size
            RenderSize(context, output);

            // Label
            RenderLabel(context, output);

            //RenderForExpression(context, output);
        }
    }
}
