using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.ListGroup
{
    [HtmlTargetElement("list-group-item-text", ParentTag = "list-group-item")]
    [HtmlTargetElement("list-group-item-text", ParentTag = "list-group-link")]
    public class ListGroupItemTextTagHelper : Bootstrap3TagHelper
    {
        public ListGroupItemTextTagHelper()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("p");
            output.AddCssClass("list-group-item-text");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
