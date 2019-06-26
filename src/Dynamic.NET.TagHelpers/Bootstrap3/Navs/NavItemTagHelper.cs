using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navs
{
    [OutputElementHint("a")]
    [HtmlTargetElement("nav-item", ParentTag = "nav-tabs")]
    [HtmlTargetElement("nav-item", ParentTag = "nav-pills")]
    public class NavItemTagHelper : Bootstrap3TagHelper
    {
        public NavItemTagHelper() : base()
        {
        }

        [HtmlAttributeName("tab-pane")]
        public string TabPaneId { get; set; }

        [HtmlAttributeName("active")]
        public bool IsItemActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsItemDisabled { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("a");

            if (!context.AllAttributes.ContainsName("href"))
                output.Attributes.SetAttribute("href", "#");

            if (TabPaneId.IsNotNullOrEmpty())
            {
                if (!TabPaneId.StartsWith("#")) TabPaneId = "#" + TabPaneId;

                if (!context.AllAttributes.ContainsName("href"))
                    output.Attributes.SetAttribute("href", "#");

                output.Attributes.SetAttribute("data-toggle", "tab");
                output.Attributes.SetAttribute("data-target", TabPaneId);

                // ARIA
                output.Attributes.SetAttribute("role", "tab");
            }

            TagBuilder wrapper = new TagBuilder("li") { TagRenderMode = TagRenderMode.Normal };
            if (IsItemActive) wrapper.AddCssClass("active");
            if (IsItemDisabled) wrapper.AddCssClass("disabled");
            CheckQuickFloat(context, output, wrapper);
            output.WrapOutside(wrapper);
        }

        private void CheckQuickFloat(TagHelperContext context, TagHelperOutput output, TagBuilder wrapper)
        {
            if (context.AllAttributes.ContainsName("pull-left"))
            {
                var isPullLeft = (bool)context.AllAttributes["pull-left"].Value;
                if (isPullLeft)
                {
                    output.RemoveCssClass("pull-left");
                    wrapper.AddCssClass("pull-left");
                }
            }

            if (context.AllAttributes.ContainsName("pull-right"))
            {
                var isPullRight = (bool)context.AllAttributes["pull-right"].Value;
                if (isPullRight)
                {
                    output.RemoveCssClass("pull-right");
                    wrapper.AddCssClass("pull-right");
                }
            }
        }
    }
}
