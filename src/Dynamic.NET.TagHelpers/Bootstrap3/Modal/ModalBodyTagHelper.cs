using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Modal
{
    /// <summary>
    /// Modal body tag helper
    /// </summary>
    [HtmlTargetElement("modal-body", ParentTag = "modal-dialog")]
    public class ModalBodyTagHelper : Bootstrap3TagHelper
    {
        public ModalBodyTagHelper()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "modal-body");
        }
    }
}
