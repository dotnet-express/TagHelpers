using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Helpers
{
    [HtmlTargetElement(Attributes = "pull-right")]
    [HtmlTargetElement(Attributes = "pull-left")]
    public class QuickFloatTagHelper : Bootstrap3TagHelper
    {
        public QuickFloatTagHelper(): base()
        {
        }

        [HtmlAttributeName("pull-left")]
        public bool IsPullLeft { get; set; }

        [HtmlAttributeName("pull-right")]
        public bool IsPullRight { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            if (IsPullLeft)
                output.AddCssClass("pull-left");

            if (IsPullRight)
                output.AddCssClass("pull-right");
        }

        public override int Order => -1000;
    }
}
