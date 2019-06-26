using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.ListGroup
{
    [HtmlTargetElement("list-group-link", ParentTag = "list-group")]
    public class ListGroupLinkTagHelper : ListGroupItemTagHelper
    {
        public ListGroupLinkTagHelper() : base()
        {
        }

       

        [HtmlAttributeName("href")]
        public string Href { get; set; }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public ListGroupTagHelper ListGroupContext { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            base.Render(context, output);

            output.SetTagName("a");

            if (ListGroupContext != null && ListGroupContext.IsRenderAsDiv != true)
                ListGroupContext.IsRenderAsDiv = true;

            if (!IsDisabled)
            {
                if (Href.IsNullOrEmpty()) Href = "#";
                output.Attributes.SetAttribute("href", UrlHelper.Content(Href));
            }
            else
            {
                output.MergeAttribute("href", "javascript:void(0)");
            }
        }
    }
}
