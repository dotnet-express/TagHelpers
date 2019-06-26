using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Panels
{
    /// <summary>
    /// Panel body tag helper.
    /// </summary>
    [HtmlTargetElement("panel-body", ParentTag = "panel")]
    public class PanelBodyTagHelper : Bootstrap3TagHelper
    {
        public PanelBodyTagHelper()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "panel-body");
        }
    }
}
