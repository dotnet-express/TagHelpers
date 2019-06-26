using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [HtmlTargetElement("progress-bar")]
    public class ProgressBarTagHelper : Bootstrap3TagHelper
    {
        public ProgressBarTagHelper() : base()
        {
        }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public ProgressStackTagHelper ProgressStackContext { get; set; }

        [HtmlAttributeName("value")]
        public uint Value { get; set; }

        [HtmlAttributeName("labeled")]
        public bool IsLabeled { get; set; }

        [HtmlAttributeName("color")]
        public ProgressBarTagColor Color { get; set; } = ProgressBarTagColor.Default;

        [HtmlAttributeName("striped")]
        public bool IsStriped { get; set; }

        [HtmlAttributeName("animated")]
        public bool IsAnimated { get; set; }

        [HtmlAttributeName("vertical")]
        public bool IsVertical { get; set; }

        [HtmlAttributeName("height")]
        public uint Height { get; set; } = 0;

        [HtmlAttributeName("width")]
        public uint Width { get; set; } = 0;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("progress-bar");

            output.TagMode = TagMode.StartTagAndEndTag;

            // Value
            if (Value > 100) Value = 100;

            output.MergeAttribute("aria-valuemin", "0");
            output.MergeAttribute("aria-valuemax", "100");
            output.MergeAttribute("aria-valuenow", Value.ToString());
            output.MergeAttribute("role", "progressbar");

            if (IsVertical)
                output.AddCssStyle("height", Value.ToString() + "%");
            else
                output.AddCssStyle("width", Value.ToString() + "%");


            // Color
            if (Color != ProgressBarTagColor.Default)
            {
                output.AddCssClass(this.Color.GetEnumInfo().Name);
            }

            // Label
            if (this.IsLabeled)
            {
                output.AddCssStyle("min-width", "3em");
                output.PreContent.Append(Value.ToString() + "%");
            }

            // Animated and Striped
            if (this.IsAnimated)
            {
                output.AddCssClass("progress-bar-striped");
                output.AddCssClass("active");
            }
            else if (this.IsStriped)
            {
                output.AddCssClass("progress-bar-striped");
            }

            if (ProgressStackContext == null)
            {
                TagBuilder wrapper = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
                wrapper.AddCssClass("progress");

                if (IsVertical)
                {
                    
                    if (Height == 0) Height = 200;
                    if (Width == 0) Width = 30;

                    //wrapper.AddCssClass("vertical");

                    wrapper.AddCssStyle("position", "relative");
                    wrapper.AddCssStyle("display", "inline-block");
                    wrapper.AddCssStyle("height", Height + "px");
                    wrapper.AddCssStyle("width", Width + "px");

                    output.AddCssStyle("width", "100%");
                    output.AddCssStyle("position", "absolute");
                    output.AddCssStyle("bottom", "0");

                }
                else
                {
                    if (this.Height > 0)
                        wrapper.AddCssStyle("height", Height + "px");
                }

                output.WrapOutside(wrapper);
            }
        }
    }
}
