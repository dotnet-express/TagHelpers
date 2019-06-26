using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    /// <summary>
    /// Embed responsive container tag helper.
    /// </summary>
    [HtmlTargetElement("embed-responsive")]
    public class EmbedResponsiveTagHelper : Bootstrap3TagHelper
    {
        public EmbedResponsiveTagHelper()
        {
        }

        [HtmlAttributeName("ratio")]
        public EmbedResponsiveTagRatio Ratio { get; set; } = EmbedResponsiveTagRatio.Ratio16by9;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "embed-responsive");

            output.AddCssClass(Ratio.GetEnumInfo().Name);
        }
    }
}
