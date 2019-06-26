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
    [TagHelperContext]
    [HtmlTargetElement("pagination")]
    [HtmlTargetElement("pager")]
    public class PagerTagHelper : Bootstrap3TagHelper
    {
        public PagerTagHelper() : base()
        {
        }

        [HtmlAttributeName("size")]
        public PagerSize Size { get; set; } = PagerSize.normal;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("ul");

            output.AddCssClass((TagName == "pager") ? "pager" : "pagination");

            if (Size != PagerSize.normal)
                output.AddCssClass(Size.GetEnumInfo().Name);

            TagBuilder wrapper = new TagBuilder("nav") { TagRenderMode = TagRenderMode.Normal };
            output.WrapOutside(wrapper);
        }
    }
}
