using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Media
{
    [HtmlTargetElement("media-object", ParentTag = "media")]
    public class MediaObjectTagHelper : Bootstrap3TagHelper
    {
        public MediaObjectTagHelper() : base()
        {
        }

        [HtmlAttributeName("href")]
        public string Href { get; set; }

        [HtmlAttributeName("align")]
        public MediaObjectTagAlign Align { get; set; } = MediaObjectTagAlign.LeftTop;

        [HtmlAttributeName("height")]
        public string Height { get; set; }

        [HtmlAttributeName("width")]
        public string Width { get;  set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("img");
            output.AddCssClass("media-object");

            output.TagMode = TagMode.SelfClosing;

            if (Href.IsNotNullOrEmpty())
            {
                TagBuilder link = new TagBuilder("a") { TagRenderMode = TagRenderMode.Normal };
                link.MergeAttribute("href", Href);

                output.WrapOutside(link);
            }

            if (Height.IsNotNullOrEmpty())
            {
                output.AddCssStyle("height", Height);
            }

            if (Width.IsNotNullOrEmpty())
            {
                output.AddCssStyle("width", Width);
            }

            TagBuilder wrapper = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
            wrapper.AddCssClass(Align.GetEnumInfo().Name);

            output.WrapOutside(wrapper);
        }
    }
}
