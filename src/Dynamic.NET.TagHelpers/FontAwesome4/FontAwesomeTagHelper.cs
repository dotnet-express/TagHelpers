using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.FontAwesome4
{
    [HtmlTargetElement(Attributes = "fa-icon")]
    public class FontAwesomeTagHelper : DynamicTagHelper
    {
        public FontAwesomeTagHelper() : base()
        {
        }

        public override int Order => -1000;

        [HtmlAttributeName("fa-icon")]
        public string IconName { get; set; }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            if (IconName.IsNullOrEmpty())
            {
                TagHelperAttribute attr = context.AllAttributes.First(a => a.Name.StartsWith("fa-"));
                if (attr != null)
                {
                    output.Attributes.Remove(attr);
                    IconName = attr.Name;
                }
            }

            if (IconName.IsNotNullOrEmpty())
            {
                if (!IconName.StartsWith("fa-")) IconName = $"fa-{IconName}";

                output.TagMode = TagMode.StartTagAndEndTag;

                TagBuilder builder = new TagBuilder("i") { TagRenderMode = TagRenderMode.Normal };
                builder.AddCssClass(IconName);
                builder.AddCssClass("fa");

                output.PreContent.AppendHtml(builder);
                output.PreContent.Append(" ");
            }
        }
    }
}
