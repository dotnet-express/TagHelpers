using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Panels
{
    /// <summary>
    /// Panel title tag helper.
    /// </summary>
    [HtmlTargetElement("panel-title", ParentTag = "panel-heading")]
    public class PanelTitleTagHelper : Bootstrap3TagHelper
    {
        public PanelTitleTagHelper()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("h3", cssClass: "panel-title");
        }
    }
}
