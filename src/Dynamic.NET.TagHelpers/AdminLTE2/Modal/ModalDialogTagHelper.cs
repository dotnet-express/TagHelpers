using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Modal
{
    /// <summary>
    /// Modal dialog tag helper.
    /// </summary>
    [HtmlTargetElement("modal-dialog", Attributes = "state")]
    public class ModalDialogTagHelper : AdminLTE2TagHelper
    {
        public ModalDialogTagHelper()
        {
        }

        [HtmlAttributeName("state")]
        public ModalDialogTagState State { get; set; } = ModalDialogTagState.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.AddCssClass(State.GetEnumInfo().Name);
        }
    }
}
