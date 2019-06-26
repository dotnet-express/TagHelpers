using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Panels
{
    /// <summary>
    /// Panel footer tag helper.
    /// </summary>
    [HtmlTargetElement("panel-footer", ParentTag = "panel")]
    public class PanelFooterTagHelper : Bootstrap3TagHelper
    {
        public PanelFooterTagHelper()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "panel-footer");
        }
    }
}
