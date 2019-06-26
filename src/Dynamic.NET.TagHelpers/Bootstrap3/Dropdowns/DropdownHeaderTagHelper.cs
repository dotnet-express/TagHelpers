using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Dropdowns
{
    /// <summary>
    /// 
    /// </summary>
    [HtmlTargetElement("dropdown-header", ParentTag = "dropdown-menu")]
    public class DropdownHeaderTagHelper : Bootstrap3TagHelper
    {
        public DropdownHeaderTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("li");
            output.AddCssClass("dropdown-header");
        }
    }
}
