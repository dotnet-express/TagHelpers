using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.ListGroup
{
    [TagHelperContext]
    [HtmlTargetElement("list-group")]
    public class ListGroupTagHelper : Bootstrap3TagHelper
    {
        public ListGroupTagHelper() : base()
        {
        }

        [HtmlAttributeName("active")]
        public bool IsActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsDisabled { get; set; }

        [HtmlAttributeNotBound]
        public bool IsRenderAsDiv { get; set; } = false;

        protected async override Task RenderAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.GetChildContentAsync();

            output.SetTagName("ul");
            output.AddCssClass("list-group");

            output.TagMode = TagMode.StartTagAndEndTag;

            if (IsRenderAsDiv)
                output.SetTagName("div");

            if (IsActive)
                output.AddCssClass("active");

            if (IsDisabled)
                output.AddCssClass("disabled");
        }
    }
}
