using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Bootstrap3;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    
    [OutputElementHint("div")]
    [HtmlTargetElement("form-group")]
    public class FormGroupTagHelper : Bootstrap3TagHelper
    {
        public FormGroupTagHelper(IHtmlGenerator htmlGenerator) : base()
        {
            HtmlGenerator = htmlGenerator;
        }

        [HtmlAttributeNotBound]
        public IHtmlGenerator HtmlGenerator { get; set; }

        [HtmlAttributeName("state")]
        public FormGroupState State { get; set; } = FormGroupState.None;

        [HtmlAttributeName("size")]
        public FormGroupSize Size { get; set; } = FormGroupSize.Default;

        [HtmlAttributeName("form-validation-summary")]
        public bool IsNeedValidationSummary { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");    // Replaces <bs3:form-group> with <div> tag
            output.AddCssClass("form-group");
            output.TagMode = TagMode.StartTagAndEndTag;

            // Validation Summary
            RenderValidationSummary(context, output);

            // Size
            RenderSize(context, output);

            // State
            RenderState(context, output);
        }

        protected void RenderSize(TagHelperContext context, TagHelperOutput output)
        {
            if (this.Size != FormGroupSize.Default)
                output.AddCssClass($"{this.Size.GetEnumInfo().Name}");
        }

        private void RenderState(TagHelperContext context, TagHelperOutput output)
        {
            if (State != FormGroupState.None)
            {
                output.AddCssClass($"{this.State.GetEnumInfo().Name}");
            }

            if (output.Attributes.ContainsName("has-feedback"))
                output.AddCssClass("has-feedback");
        }

        protected void RenderValidationSummary(TagHelperContext context, TagHelperOutput output)
        {
            if (IsNeedValidationSummary)
            {
                TagBuilder builder = HtmlGenerator.GenerateValidationSummary(ViewContext, false, "", "span", new { @class = "help-block" });
                output.PostContent.AppendHtml(builder);

                State = FormGroupState.Error;
            }
        }

    }
}
