using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Components
{
    [HtmlTargetElement("callout")]
    [HtmlTargetElement("callout-success")]
    [HtmlTargetElement("callout-info")]
    [HtmlTargetElement("callout-warning")]
    [HtmlTargetElement("callout-danger")]
    public class CalloutTagHelper : AdminLTE2TagHelper
    {
        public CalloutTagHelper() : base()
        {
        }

        [HtmlAttributeName("status")]
        public CalloutTagStatus Status { get; set; } = CalloutTagStatus.Info;

        [HtmlAttributeName("dismissible")]
        public bool Dismissible { get; set; } = false;

        [HtmlAttributeName("disable-link-styling")]
        public bool DisableLinkStyling { get; set; } = false;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("callout");

            if (TagName == "callout")
                output.AddCssClass(Status.GetEnumInfo().Name);
            else
                output.AddCssClass(context.TagName);

            output.Attributes.SetAttribute("role", "alert");

        }
    }
}
