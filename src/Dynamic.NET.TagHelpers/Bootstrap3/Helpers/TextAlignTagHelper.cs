using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Helpers
{
    [HtmlTargetElement(Attributes = "text-align")]
    public class TextAlignTagHelper : Bootstrap3TagHelper
    {
        public TextAlignTagHelper(): base()
        {
        }

        [HtmlAttributeName("text-align")]
        public string Alignment { get; set; } = TextAlign.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            if (Alignment.IsNotNullOrEmpty())
            {
                if (Alignment != TextAlign.Default)
                    output.AddCssClass(TextAlign.Parse(Alignment));
            }
        }
    }
}
