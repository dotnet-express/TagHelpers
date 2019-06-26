using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Pagination
{
    [HtmlTargetElement("pager-item", ParentTag = "pagination")]
    [HtmlTargetElement("pager-item", ParentTag = "pager")]
    [HtmlTargetElement("pager-prev", ParentTag = "pagination")]
    [HtmlTargetElement("pager-prev", ParentTag = "pager")]
    [HtmlTargetElement("pager-next", ParentTag = "pagination")]
    [HtmlTargetElement("pager-next", ParentTag = "pager")]
    public class PagerItemTagHelper : Bootstrap3TagHelper
    {
        public PagerItemTagHelper() : base()
        {
        }

        [HtmlAttributeName("active")]
        public bool IsItemActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsItemDisabled { get; set; }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public PagerTagHelper PaginationContext { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");

            output.TagMode = TagMode.StartTagAndEndTag;

            if (!context.AllAttributes.ContainsName("href"))
                output.Attributes.SetAttribute("href", "#");

            RenderPrevNext(context, output);

            TagBuilder wrapper = new TagBuilder("li") { TagRenderMode = TagRenderMode.Normal };
            if (IsItemActive) wrapper.AddCssClass("active");
            if (IsItemDisabled) wrapper.AddCssClass("disabled");
            if (PaginationContext != null && PaginationContext.TagName == "pager") {
                if (TagName == "pager-prev") wrapper.AddCssClass("previous");
                if (TagName == "pager-next") wrapper.AddCssClass("next");
            }
            output.WrapOutside(wrapper);
        }

        private void RenderPrevNext(TagHelperContext context, TagHelperOutput output)
        {
            if (context.TagName != "pager-prev" && context.TagName != "pager-next") return;

            if (context.TagName == "pager-prev" && !context.AllAttributes.ContainsName("noarrow"))
            {
                TagBuilder span = new TagBuilder("span") { TagRenderMode = TagRenderMode.Normal };
                var text = (PaginationContext != null && PaginationContext.TagName == "pager") ? "&larr;" : "&laquo;";
                span.InnerHtml.AppendHtml(text + "&nbsp;");
                output.PreContent.AppendHtml(span);
            }

            if (context.TagName == "pager-next" && !context.AllAttributes.ContainsName("noarrow"))
            {
                TagBuilder span = new TagBuilder("span") { TagRenderMode = TagRenderMode.Normal };
                var text = (PaginationContext != null && PaginationContext.TagName == "pager") ? "&rarr;" : "&raquo;";
                span.InnerHtml.AppendHtml(text + "&nbsp;");
                output.PreContent.AppendHtml(span);
            }
        }
    }
}
