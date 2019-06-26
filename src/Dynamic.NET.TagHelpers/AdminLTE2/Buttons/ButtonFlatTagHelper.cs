using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Bootstrap3;
using Dynamic.NET.TagHelpers.Bootstrap3.Buttons;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Buttons
{
    [HtmlTargetElement("btn-flat")]
    public class ButtonFlatTagHelper : Bootstrap3.Buttons.ButtonTagHelper
    {
        public ButtonFlatTagHelper() : base()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            base.Render(context, output);

            output.AddCssClass(ButtonColor.Default);
        }
    }
}
