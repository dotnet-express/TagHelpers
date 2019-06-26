using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Layout
{
    [TagHelperContext]
    [HtmlTargetElement("body")]
    public class BodyTagHelper : AdminLTE2TagHelper
    {
        public BodyTagHelper() : base()
        {
        }

        [HtmlAttributeName("layout")]
        public BodyLayout Layout { get; set; } = BodyLayout.Fixed;

        [HtmlAttributeName("skin")]
        public BodySkin Skin { get; set; } = BodySkin.None;

        [HtmlAttributeName("sidebar-mini")]
        public bool IsSideBarMini { get; set; } = true;

        [HtmlAttributeName("sidebar-collapse")]
        public bool IsSideCollapse { get; set; } = false;

        [HtmlAttributeNotBound()]
        public bool IsNeedWrapper { get; set; } = true;

        protected override async Task RenderAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Layout
            RenderLayout(context, output);

            // Skin
            RenderSkin(context, output);

            // SideBar
            RenderSideBar(context, output);

            // Load content 
            await output.LoadChildContentAsync();

            if (IsNeedWrapper)
            {
                // Add wrapper <div class="wrapper"> ... </div> into body content
                TagBuilder wrapper = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
                wrapper.AddCssClass("wrapper");
                output.Content.Wrap(wrapper);
            }
        }

        private void RenderLayout(TagHelperContext context, TagHelperOutput output)
        {
            output.AddCssClass($"{Layout.GetEnumInfo().Name}");
        }

        private void RenderSkin(TagHelperContext context, TagHelperOutput output)
        {
            if (Skin != BodySkin.None)
                output.AddCssClass($"{Skin.GetEnumInfo().Name}");
        }

        private void RenderSideBar(TagHelperContext context, TagHelperOutput output)
        {
            if (IsSideBarMini)
                output.AddCssClass("sidebar-mini");

            if (IsSideCollapse)
                output.AddCssClass("sidebar-collapse");
        }
    }
}
