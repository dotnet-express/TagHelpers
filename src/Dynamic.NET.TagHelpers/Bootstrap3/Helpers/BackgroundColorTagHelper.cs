using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Helpers
{
    [HtmlTargetElement(Attributes = "bg-color")]
    public class BackgroundColorTagHelper : Bootstrap3TagHelper
    {
        public BackgroundColorTagHelper() : base()
        {
        }

        [HtmlAttributeName("bg-color")]
        public string Color { get; set; } = BackgroundColor.None;


        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            if (Color != BackgroundColor.None)
            {
                output.AddCssClass(BackgroundColor.Parse(Color), true);
            }
        }

        public override int Order => 1000;
    }
}
