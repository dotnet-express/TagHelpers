using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Panels
{
    /// <summary>
    /// Panels tag helper.
    /// </summary>
    [HtmlTargetElement("panel")]
    public class PanelTagHelper : Bootstrap3TagHelper
    {
        public PanelTagHelper()
        {
        }

        /// <summary>
        /// Contextual state alternatives for <panel></panel> tag helper
        /// </summary>
        /// <remarks>
        /// Like other components, easily make a panel more meaningful to a particular context by adding any of the contextual state classes.
        /// </remarks>
        [HtmlAttributeName("state")]
        public PanelTagState State { get; set; } = PanelTagState.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagInfo("div", cssClass: "panel");

            output.AddCssClass(State.GetEnumInfo().Name);
        }
    }
}
