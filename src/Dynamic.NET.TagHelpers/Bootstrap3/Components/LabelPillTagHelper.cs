using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [HtmlTargetElement("label-pill")]
    public class LabelPillTagHelper : Bootstrap3TagHelper
    {
        public LabelPillTagHelper() : base()
        {

        }

        [HtmlAttributeName("color")]
        public LabelPillTagColor Color { get; set; } = LabelPillTagColor.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("span");
            output.AddCssClass("label");

            output.AddCssClass(Color.GetEnumInfo().Name);
        }
    }
}
