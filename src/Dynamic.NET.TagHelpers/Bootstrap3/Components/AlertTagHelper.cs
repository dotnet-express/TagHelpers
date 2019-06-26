using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    [HtmlTargetElement("alert")]
    [HtmlTargetElement("alert-success")]
    [HtmlTargetElement("alert-info")]
    [HtmlTargetElement("alert-warning")]
    [HtmlTargetElement("alert-danger")]
    public class AlertTagHelper : Bootstrap3TagHelper
    {
        public AlertTagHelper() : base()
        {
        }

        [HtmlAttributeName("status")]
        public AlertTagStatus Status { get; set; } = AlertTagStatus.Info;

        [HtmlAttributeName("dismissible")]
        public bool Dismissible { get; set; } = false;

        [HtmlAttributeName("disable-link-styling")]
        public bool DisableLinkStyling { get; set; } = false;

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("div");
            output.AddCssClass("alert");

            if (TagName == "alert")
                output.AddCssClass(Status.GetEnumInfo().Name);
            else
                output.AddCssClass(context.TagName);

            output.Attributes.SetAttribute("role", "alert");

            if (Dismissible)
            {
                output.AddCssClass("alert-dismissible");

                TagBuilder button = new TagBuilder("button") { TagRenderMode = TagRenderMode.Normal };
                button.MergeAttribute("type", "button");
                button.AddCssClass("close");
                button.MergeAttribute("data-dismiss", "alert");
                button.InnerHtml.AppendHtml("&times;");

                output.PreContent.AppendHtml(button);
            }

            RenderLinks(context, output);
        }

        private void RenderLinks(TagHelperContext context, TagHelperOutput output)
        {
            if (!DisableLinkStyling)
            {
                var content = output.GetChildContentAsync(true).Result;
                var pattern = @"<a(?!.+class.*=.*"".*(alert-link\s|alert-link""))[^>]*>*";
                output.Content.SetHtmlContent(Regex.Replace(content.GetContent(), pattern, RenderLink));
            }
        }

        private string RenderLink(Match match)
        {
            string startTagText = match.ToString();
            if (startTagText.Contains("class=\""))
                return startTagText.Replace("class=\"", "class=\"alert-link ");

            return "<a class=\"alert-link\"" + startTagText.Substring(2);

        }
    }
}
