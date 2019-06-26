using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    /// <summary>
    /// Navbar tag helper.
    /// </summary>
    /// <remarks>
    /// Navbars are responsive meta components that serve as navigation headers for your application or site. 
    /// They begin collapsed (and are toggleable) in mobile views and become horizontal as the available viewport width increases.
    /// </remarks>
    [TagHelperContext]
    [HtmlTargetElement("navbar")]
    public class NavbarTagHelper : Bootstrap3TagHelper
    {
        public NavbarTagHelper() : base()
        {
        }

        [HtmlAttributeName("id")]
        public string ControlId { get; set; }

        [HtmlAttributeName("collapsible")]
        public bool IsCollapsible { get; set; }

        [HtmlAttributeName("inverse")]
        public bool IsInverse { get; set; }

        [HtmlAttributeName("position")]
        public NavbarTagPosition Position { get; set; } = NavbarTagPosition.Default;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("nav");

            output.AddCssClass("navbar");
            output.AddCssClass("navbar-default");

            output.AddCssClass("container-fluid");

            // ControlId
            RenderControlId(context, output);

            RenderPosition(context, output);

            RenderTheme(context, output);
        }

        

        public void RenderControlId(TagHelperContext context, TagHelperOutput output)
        {
            RenderControlId(context, output, "navbar");
        }

        public void RenderControlId(TagHelperContext context, TagHelperOutput output, string prefix)
        {
            if (string.IsNullOrEmpty(ControlId))
            {
                ControlId = $"{prefix}-{Guid.NewGuid().ToString("N")}";
            }

            output.Attributes.SetAttribute("id", ControlId);
        }

        private void RenderPosition(TagHelperContext context, TagHelperOutput output)
        {
            if (Position != NavbarTagPosition.Default)
                output.AddCssClass(Position.GetEnumInfo().Name);
        }

        private void RenderTheme(TagHelperContext context, TagHelperOutput output)
        {
            if (IsInverse)
                output.AddCssClass("navbar-inverse");
        }
    }
}
