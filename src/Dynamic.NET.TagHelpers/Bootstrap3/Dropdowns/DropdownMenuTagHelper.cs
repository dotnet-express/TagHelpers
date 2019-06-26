using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Dropdowns
{
    [OutputElementHint("div")]
    [HtmlTargetElement("dropdown-menu")]
    public class DropdownMenuTagHelper : Bootstrap3TagHelper
    {
        public DropdownMenuTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("ul");
            output.AddCssClass("dropdown-menu");

            // Menu Alignment
            if (context.AllAttributes.ContainsName("align") && context.AllAttributes["align"].Value.ToString() == "right")
                output.AddCssClass("dropdown-menu-right");

            output.AddCssClass(context.TagName);
        }
    }
}
