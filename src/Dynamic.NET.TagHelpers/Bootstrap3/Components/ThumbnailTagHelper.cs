using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [HtmlTargetElement("thumbnail")]
    public class ThumbnailTagHelper : Bootstrap3TagHelper
    {
        public ThumbnailTagHelper() : base()
        {
        }

        [HtmlAttributeName("url")]
        public string Url { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("thumbnail");

            if (Url.IsNotNullOrEmpty())
            {
                output.SetTagName("a");
                output.MergeAttribute("href", Url);
            }
        }
    }
}
