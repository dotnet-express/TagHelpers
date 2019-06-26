using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Dropdowns
{
    /// <summary>
    /// The divider element represents a divider to separate series of links in a dropdown menu
    /// </summary>
    [HtmlTargetElement("dropdown-divider", ParentTag = "dropdown-menu", TagStructure = TagStructure.WithoutEndTag)]
    public class DropdownDividerTagHelper : Bootstrap3TagHelper
    {
        public DropdownDividerTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("li");
            output.AddCssClass("divider");

            output.Attributes.SetAttribute("role", "separator");
        }
    }
}
