using System;
using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3
{
    public abstract class Bootstrap3TagHelper : DynamicTagHelper
    {
        public Bootstrap3TagHelper() : base()
        {

        }

        protected override Task RenderAsync(TagHelperContext context, TagHelperOutput output)
        {
            return base.RenderAsync(context, output);
        }

    }
}
