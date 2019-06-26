using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Helpers
{
    [HtmlTargetElement("text-muted")]
    [HtmlTargetElement("text-primary")]
    [HtmlTargetElement("text-success")]
    [HtmlTargetElement("text-info")]
    [HtmlTargetElement("text-warning")]
    [HtmlTargetElement("text-danger")]
    [HtmlTargetElement(Attributes = "text-color")]
    public class TextColorTagHelper : Bootstrap3TagHelper
    {
        public TextColorTagHelper() : base()
        {
        }

        [HtmlAttributeName("tag-name")]
        public string RealTagName { get; set; } = "p";

        [HtmlAttributeName("text-color")]
        public string Color { get; set; } = TextColor.Primary;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            if (context.TagName.StartsWith("text-"))
            {
                output.SetTagName(RealTagName);
                output.AddCssClass(context.TagName);
            }
            else
            {
                if (Color.IsNotNullOrEmpty())
                {
                    output.AddCssClass(TextColor.Parse(Color), true);
                }
            }
        }

        public override int Order => -1000;
    }
}
