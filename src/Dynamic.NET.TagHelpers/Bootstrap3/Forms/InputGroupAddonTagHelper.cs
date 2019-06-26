using System;
using System.Collections.Generic;
using System.Text;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [TagHelperContext]
    [OutputElementHint("div")]
    [HtmlTargetElement("input-group-addon", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class InputGroupAddonTagHelper : Bootstrap3TagHelper
    {
        public InputGroupAddonTagHelper() : base()
        {
        }

        [HtmlAttributeName("text")]
        public string Text { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("span");
            output.AddCssClass("input-group-addon");

            output.TagMode = TagMode.StartTagAndEndTag;

            RenderText(context, output);
        }

        private void RenderText(TagHelperContext context, TagHelperOutput output)
        {
            if (Text.IsNotNullOrEmpty())
            {
                output.Content.SetContent(Text);
            }
        }
    }
}
