using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Buttons
{
    [OutputElementHint("button")]
    [HtmlTargetElement("button", Attributes = "size")]
    [HtmlTargetElement("btn-default", Attributes = "size")]
    [HtmlTargetElement("btn-primary", Attributes = "size")]
    [HtmlTargetElement("btn-success", Attributes = "size")]
    [HtmlTargetElement("btn-info", Attributes = "size")]
    [HtmlTargetElement("btn-warning", Attributes = "size")]
    [HtmlTargetElement("btn-danger", Attributes = "size")]
    [HtmlTargetElement("btn-link", Attributes = "size")]
    [HtmlTargetElement("btn-block", Attributes = "size")]
    public class ButtonSizeTagHelper : Bootstrap3TagHelper
    {
        public ButtonSizeTagHelper() : base()
        {
        }

        [HtmlAttributeName("size")]
        public string Size { get; set; } = ButtonSize.Normal;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.AddCssClass("btn");

            if (!Size.Equals(ButtonSize.Normal))
                output.AddCssClass(ButtonSize.Parse(Size));
        }

        public override int Order => 500;
    }
}
