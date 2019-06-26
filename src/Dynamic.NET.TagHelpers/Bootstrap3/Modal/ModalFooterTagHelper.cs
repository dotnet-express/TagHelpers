using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Modal
{
    /// <summary>
    /// Modal footer tag helper.
    /// </summary>
    [HtmlTargetElement("modal-footer", ParentTag = "modal-dialog")]
    public class ModalFooterTagHelper : Bootstrap3TagHelper
    {
        public ModalFooterTagHelper()
        {
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "modal-footer");
        }
    }
}
