using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Dropdowns
{
    [HtmlTargetElement("dropdown-item", ParentTag = "dropdown-menu")]
    public class DropdownItemTagHelper : Bootstrap3TagHelper
    {
        public DropdownItemTagHelper() : base()
        {
        }

        [HtmlAttributeName("href")]
        public string Href { get; set; } = "#";

        [HtmlAttributeName("disabled")]
        public bool IsDisabled { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");

            output.Attributes.SetAttribute("href", Href);
            
            TagBuilder wrapper = new TagBuilder("li") { TagRenderMode = TagRenderMode.Normal };
            if (IsDisabled)
                wrapper.AddCssClass("disabled");
            output.WrapOutside(wrapper);

        }
    }
}
