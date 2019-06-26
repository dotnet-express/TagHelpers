using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    /// <summary>
    /// Well tag helper.
    /// </summary>
    /// <remarks>
    /// Use the well as a simple effect on an element to give it an inset effect.
    /// </remarks>
    [HtmlTargetElement("well")]
    public class WellTagHelper : Bootstrap3TagHelper
    {
        public WellTagHelper()
        {
        }

        [HtmlAttributeName("size")]
        public WellTagSize Size { get; set; } = WellTagSize.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "well");

            output.AddCssClass(Size.GetEnumInfo().Name);
        }
    }
}
