using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    /// <summary>
    /// Embed responsiveitem tag helper
    /// </summary>
    [HtmlTargetElement("iframe", ParentTag = "embed-responsive")]
    [HtmlTargetElement("embed", ParentTag = "embed-responsive")]
    [HtmlTargetElement("video", ParentTag = "embed-responsive")]
    [HtmlTargetElement("object", ParentTag = "embed-responsive")]
    public class EmbedResponsiveItemTagHelper : Bootstrap3TagHelper
    {
        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo(TagName, "embed-responsive-item");
        }
    }
}
