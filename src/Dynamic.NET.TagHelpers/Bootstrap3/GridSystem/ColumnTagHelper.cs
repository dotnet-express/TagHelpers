using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic.NET.TagHelpers.Bootstrap3.GridSystem
{
    [HtmlTargetElement("column")]
    public class ColumnTagHelper : Bootstrap3TagHelper
    {
        public ColumnTagHelper() : base()
        {
        }

        public int SizeXs { get; set; }
        public int SizeSm { get; set; }
        public int SizeMd { get; set; }
        public int SizeLg { get; set; }

        public int OffsetXs { get; set; }
        public int OffsetSm { get; set; }
        public int OffsetMd { get; set; }
        public int OffsetLg { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";    // Replaces <column> with <div> tag

            RenderSize(output);
            RenderOffset(output);
        }

        private void RenderSize(TagHelperOutput output)
        {
            if (this.SizeXs > 0 && this.SizeXs <= 12) output.AddCssClass("col-xs-" + SizeXs);
            if (this.SizeSm > 0 && this.SizeSm <= 12) output.AddCssClass("col-sm-" + SizeSm);
            if (this.SizeMd > 0 && this.SizeMd <= 12) output.AddCssClass("col-md-" + SizeMd);
            if (this.SizeLg > 0 && this.SizeLg <= 12) output.AddCssClass("col-lg-" + SizeLg);

        }

        private void RenderOffset(TagHelperOutput output)
        {
            if (this.OffsetXs > 0 && this.OffsetXs <= 12) output.AddCssClass("col-xs-offset-" + OffsetXs);
            if (this.OffsetSm > 0 && this.OffsetSm <= 12) output.AddCssClass("col-sm-offset-" + OffsetSm);
            if (this.OffsetMd > 0 && this.OffsetMd <= 12) output.AddCssClass("col-md-offset-" + OffsetMd);
            if (this.OffsetLg > 0 && this.OffsetLg <= 12) output.AddCssClass("col-lg-offset-" + OffsetLg);
        }
    }
}
