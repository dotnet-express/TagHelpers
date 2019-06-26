using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Tables
{
    [HtmlTargetElement("table")]
    public class TableTagHelper: TagHelper
    {
        [HtmlAttributeName("state")]
        public TableTagState State { get; set; } = TableTagState.Basic;

        [HtmlAttributeName("responsive")]
        public bool IsResponsive { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            return base.ProcessAsync(context, output);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";

            output.AddCssClass("table");

            if (State != TableTagState.Basic)
                output.AddCssClass($"{this.State.GetEnumInfo().Name}");

            if (this.IsResponsive)
                output.AddCssClass("table-responsive");

        }
    }
}
