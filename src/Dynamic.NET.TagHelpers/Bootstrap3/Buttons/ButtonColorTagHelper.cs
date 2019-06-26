using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Buttons
{
    [OutputElementHint("button")]
    [HtmlTargetElement("button", Attributes = "color")]
    [HtmlTargetElement("btn-link", Attributes = "color")]
    [HtmlTargetElement("btn-block", Attributes = "color")]
    [HtmlTargetElement("dropdown-btn", Attributes = "color")]
    [HtmlTargetElement("dropdown-btn-flat", Attributes = "color")]
    public class ButtonColorTagHelper : Bootstrap3TagHelper
    {
        public ButtonColorTagHelper() : base()
        {
        }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public ButtonTagHelper ButtonContext { get; set; }

        [HtmlAttributeName("color")]
        public string Color { get; set; } = ButtonColor.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.AddCssClass("btn");

            if (Color != ButtonColor.Default)
                output.RemoveCssClass(ButtonColor.Default);

            if (context.TagName.Equals("btn-link"))
                output.RemoveCssClass("btn-link");

            output.AddCssClass(ButtonColor.Parse(Color));
        }

        public override int Order => 100;
    }
}
