using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.ListGroup
{
    [HtmlTargetElement("list-group-button", ParentTag = "list-group")]
    public class ListGroupButtonTagHelper : ListGroupLinkTagHelper
    {
        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            base.Render(context, output);

            output.SetTagName("button");
            output.MergeAttribute("type", "button");
            output.Attributes.RemoveAll("href");

            if (IsDisabled)
            {
                output.MergeAttribute("disabled", null);
            }
                
        }
    }
}
