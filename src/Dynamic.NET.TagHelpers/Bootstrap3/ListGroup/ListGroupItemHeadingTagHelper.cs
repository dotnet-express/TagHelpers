using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.ListGroup
{
    [HtmlTargetElement("list-group-item-heading", ParentTag = "list-group-item")]
    [HtmlTargetElement("list-group-item-heading", ParentTag = "list-group-link")]
    public class ListGroupItemHeadingTagHelper : Bootstrap3TagHelper
    {
        public ListGroupItemHeadingTagHelper()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("h4");
            output.AddCssClass("list-group-item-heading");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
