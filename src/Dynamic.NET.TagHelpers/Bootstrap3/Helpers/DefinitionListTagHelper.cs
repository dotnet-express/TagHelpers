using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Helpers
{
    [OutputElementHint("dl")]
    [HtmlTargetElement("dl", Attributes = "horizontal")]
    public class DefinitionListTagHelper : Bootstrap3TagHelper
    {
        public DefinitionListTagHelper(): base()
        {
        }

        [HtmlAttributeName("horizontal")]
        public bool IsHorizontal { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            if (IsHorizontal)
                output.AddCssClass("dl-horizontal");
        }
    }
}
