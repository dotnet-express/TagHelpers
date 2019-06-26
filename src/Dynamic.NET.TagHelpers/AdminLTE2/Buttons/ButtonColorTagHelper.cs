using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Buttons
{
    /// <summary>
    /// AdminLTE 2. Button Color Tag Helper
    /// </summary>
    [OutputElementHint("button")]
    [HtmlTargetElement("btn-flat", Attributes = "color")]
    public class ButtonColorTagHelper : Bootstrap3.Buttons.ButtonColorTagHelper
    {
        public ButtonColorTagHelper() : base()
        {
        }
    }
}
