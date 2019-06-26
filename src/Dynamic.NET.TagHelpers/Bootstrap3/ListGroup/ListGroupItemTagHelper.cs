using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.ListGroup
{
    [HtmlTargetElement("list-group-item", ParentTag = "list-group")]
    public class ListGroupItemTagHelper : Bootstrap3TagHelper
    {
        public ListGroupItemTagHelper() : base()
        {
        }

        [HtmlAttributeName("active")]
        public bool IsActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsDisabled { get; set; }

        [HtmlAttributeName("status")]
        public ListGroupItemStatus ItemStatus { get; set; } = ListGroupItemStatus.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("li");
            output.AddCssClass("list-group-item");

            output.TagMode = TagMode.StartTagAndEndTag;

            if (ItemStatus != ListGroupItemStatus.Default)
                output.AddCssClass(ItemStatus.GetEnumInfo().Name);

            if (IsActive)
                output.AddCssClass("active");

            if (IsDisabled)
                output.AddCssClass("disabled");
        }
    }
}
