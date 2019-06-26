using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [TagHelperContext]
    [HtmlTargetElement("form")]
    public class FormTagHelper : Bootstrap3TagHelper
    {
        public FormTagHelper(IHtmlGenerator htmlGenerator) : base()
        {
            HtmlGenerator = htmlGenerator;
        }

        [HtmlAttributeNotBound]
        public IHtmlGenerator HtmlGenerator { get; set; }

        [HtmlAttributeName("layout")]
        public FormTagLayout Layout { get; set; } = FormTagLayout.Vertical;

        [HtmlAttributeName("label-width-xs")]
        public int LabelWidthXs { get; set; }

        [HtmlAttributeName("label-width-sm")]
        public int LabelWidthSm { get; set; }

        [HtmlAttributeName("label-width-md")]
        public int LabelWidthMd { get; set; }

        [HtmlAttributeName("label-width-lg")]
        public int LabelWidthLg { get; set; }

        [HtmlAttributeName("form-validation")]
        public bool IsNeedValidation { get; set; }

        [HtmlAttributeName("form-validation-messages")]
        public bool IsNeedValidationMessages { get; set; }

        [HtmlAttributeName("form-validation-summary")]
        public bool IsNeedValidationSummary { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.AddCssClass("form");

            RenderLabelWidth(context, output);

            RenderLayout(context, output);

            RenderValidationSummary(context, output);
        }

        private void RenderLabelWidth(TagHelperContext context, TagHelperOutput output)
        {
            if (Layout == FormTagLayout.Horizontal)
            {
                if (LabelWidthXs == 0) LabelWidthXs = 2;
                if (LabelWidthSm == 0) LabelWidthSm = 2;
                if (LabelWidthMd == 0) LabelWidthMd = 2;
                if (LabelWidthLg == 0) LabelWidthLg = 2;
            }
        }

        private void RenderLayout(TagHelperContext context, TagHelperOutput output)
        {
            if(Layout != FormTagLayout.Vertical)
                output.AddCssClass($"form-{Layout.GetEnumInfo().Name}");
        }

        protected void RenderValidationSummary(TagHelperContext context, TagHelperOutput output)
        {
            if (IsNeedValidationSummary)
            {
                TagBuilder builder1 = HtmlGenerator.GenerateValidationSummary(ViewContext, false, "", "span", new { @class = "help-block" });
                TagBuilder builder2 = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
                builder2.AddCssClass("form-group");
                builder2.AddCssClass("has-error");
                builder2.InnerHtml.AppendHtml(builder1);
                output.PostContent.AppendHtml(builder2);
            }
        }
    }
}
