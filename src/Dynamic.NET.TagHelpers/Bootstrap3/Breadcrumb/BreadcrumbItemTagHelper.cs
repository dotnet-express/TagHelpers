using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Breadcrumb
{
    [OutputElementHint("li")]
    [HtmlTargetElement("breadcrumb-item", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class BreadcrumbItemTagHelper : Bootstrap3TagHelper
    {
        public BreadcrumbItemTagHelper() : base()
        {
            
        }

        [HtmlAttributeName("active")]
        public bool IsActive { get; set; }

        [HtmlAttributeName("label")]
        public string Label { get; set; }

        [HtmlAttributeName("href")]
        public string Href { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("li");
            output.TagMode = TagMode.StartTagAndEndTag;

            if (!string.IsNullOrEmpty(Label))
                output.Content.SetContent(Label);

            RenderLink(context, output);
        }


        private void RenderLink(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Href))
            { 
                TagBuilder builder = new TagBuilder("a") { TagRenderMode = TagRenderMode.Normal };
                builder.MergeAttribute("href", UrlHelper.Content(Href));
                output.WrapContentInside(builder);
            }

            if (IsActive)
                output.AddCssClass("active");
        }
    }
}
