using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Buttons
{
    [OutputElementHint("div")]
    [HtmlTargetElement("btn-group")]
    [HtmlTargetElement("btn-group-vertical")]
    public class ButtonGroupTagHelper : Bootstrap3TagHelper
    {
        public ButtonGroupTagHelper() : base()
        {
        }

        [HtmlAttributeName("size")]
        public ButtonGroupSize ButtonGroupSize { get; set; } = ButtonGroupSize.Normal;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass(context.TagName);

            output.Attributes.SetAttribute("role", "group");

            if (this.ButtonGroupSize != ButtonGroupSize.Normal)
                output.AddCssClass(this.ButtonGroupSize.GetEnumInfo().Name);

        }
    }
}
