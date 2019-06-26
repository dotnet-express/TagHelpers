using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Buttons
{
    [HtmlTargetElement("btn-flat", Attributes = "size")]
    public class ButtonSizeTagHelper : Bootstrap3.Buttons.ButtonSizeTagHelper
    {
        public ButtonSizeTagHelper() : base()
        {
        }
    }
}
