using System;
using Dynamic.NET.TagHelpers.Bootstrap3;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Box
{
    [OutputElementHint("div")]
    [HtmlTargetElement("box")]
    public class BoxTagHelper : AdminLTE2TagHelper
    {
        public BoxTagHelper() : base()
        {
        }

        [HtmlAttributeName("state")]
        public BoxTagState State { get; set; } = BoxTagState.None;

        [HtmlAttributeName("solid")]
        public bool IsSolid { get; set; } = false;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("box");

            // Solid & etc.
            RenderBorder(context, output);

            // Color
            RenderState(context, output);
        }

        private void RenderBorder(TagHelperContext context, TagHelperOutput output)
        {
            if (IsSolid)
                output.AddCssClass("box-solid");
        }

        private void RenderState(TagHelperContext context, TagHelperOutput output)
        {
            if (State != BoxTagState.None)
            {
                output.AddCssClass($"{State.GetEnumInfo().Name}");
            }
        }
    }
}
