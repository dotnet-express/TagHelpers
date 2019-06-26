using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [HtmlTargetElement("form-label")]
    public class FormLabelTagHelper : Bootstrap3TagHelper
    {
        public FormLabelTagHelper() : base () { }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public FormTagHelper FormContext { get; set; }

        [HtmlAttributeName("sr-only")]
        public bool SrOnly { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("label");

            output.TagMode = TagMode.StartTagAndEndTag;

            if (this.SrOnly) output.AddCssClass("sr-only");

            if (this.FormContext != null && this.FormContext.Layout == FormTagLayout.Horizontal)
            {
                output.AddCssClass("control-label");

                if (FormContext.LabelWidthXs > 0 && FormContext.LabelWidthXs < 12) output.AddCssClass($"col-xs-{FormContext.LabelWidthXs}");
                if (FormContext.LabelWidthSm > 0 && FormContext.LabelWidthSm < 12) output.AddCssClass($"col-sm-{FormContext.LabelWidthSm}");
                if (FormContext.LabelWidthMd > 0 && FormContext.LabelWidthMd < 12) output.AddCssClass($"col-md-{FormContext.LabelWidthMd}");
                if (FormContext.LabelWidthLg > 0 && FormContext.LabelWidthLg < 12) output.AddCssClass($"col-lg-{FormContext.LabelWidthLg}");
            }
        }
    }
}
