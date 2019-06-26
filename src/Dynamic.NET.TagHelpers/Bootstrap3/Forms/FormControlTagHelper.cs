using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    [OutputElementHint("input")]
    [HtmlTargetElement("form-control", TagStructure = TagStructure.WithoutEndTag)]
    public class FormControlTagHelper : Bootstrap3TagHelper
    {
        public FormControlTagHelper(IHtmlGenerator htmlGenerator) : base()
        {
            HtmlGenerator = htmlGenerator;
        }

        [HtmlAttributeNotBound]
        public IHtmlGenerator HtmlGenerator { get; set; }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public FormTagHelper FormContext { get; set; }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public FormGroupTagHelper FormGroupContext { get; set; }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public InputGroupTagHelper InputGroupContext { get; set; }

        [BindTagHelperContext]
        [HtmlAttributeNotBound]
        public InputGroupAddonTagHelper InputGroupAddonContext { get; set; }

        [HtmlAttributeName("id")]
        public string ControlId { get; set; }

        [HtmlAttributeName("type")]
        public string InputType { get; set; }

        [HtmlAttributeName("name")]
        public string InputName { get; set; }

        [HtmlAttributeName("label-text")]
        public string LabelText { get; set; }

        [HtmlAttributeName("help-text")]
        public string HelpText { get; set; }

        [HtmlAttributeName("size")]
        public FormControlSize Size { get; set; } = FormControlSize.Default;

        [HtmlAttributeName("asp-for")]
        public ModelExpression AspFor { get; set; }

        [HtmlAttributeNotBound]
        public bool IsFormHorizontal { get; set; }

        [HtmlAttributeName("read-only")]
        public bool IsReadOnly { get; set; }

        [HtmlAttributeName("disabled")]
        public bool IsDisabled { get; set; }

        [HtmlAttributeName("form-validation")]
        public bool? IsNeedValidation { get; set; }

        [HtmlAttributeName("form-validation-message")]
        public bool? IsNeedValidationMessage { get; set; }

        [HtmlAttributeName("input-group-prepend")]
        public string InputGroupPrependText { get; set; }

        [HtmlAttributeName("input-group-append")]
        public string InputGroupAppendText { get; set; }

        [HtmlAttributeNotBound]
        protected TagHelperOutput MvcTagHelperOutput { get; set; }

        public override void Init(TagHelperContext context)
        {
            base.Init(context);
        }

        protected override void PreRender(TagHelperContext context, TagHelperOutput output)
        {
            base.PreRender(context, output);

            if (IsNeedValidation == null && FormContext != null && this.FormContext.IsNeedValidation)
            {
                IsNeedValidation = FormContext.IsNeedValidation;
            }

            if (IsNeedValidationMessage == null && FormContext != null && this.FormContext.IsNeedValidationMessages)
            {
                IsNeedValidationMessage = FormContext.IsNeedValidationMessages;
            }

            if (FormContext != null && FormContext.Layout == FormTagLayout.Horizontal)
            {
                IsFormHorizontal = true;
            }
        }

        protected override void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.SetTagName("input");
            output.AddCssClass("form-control");

            output.TagMode = TagMode.SelfClosing;

            if (string.IsNullOrEmpty(InputType))
                InputType = "text";

            output.Attributes.SetAttribute("type", InputType);

            // AspFor
            RenderAspFor(context, output);          

            if (!string.IsNullOrEmpty(InputName))
                output.Attributes.SetAttribute("name", InputName);

            // Control Id
            RenderControlId(context, output, "form-ctrl");

            // Disabled & ReadOnly
            RenderVisability(context, output);
            
            // Prepare for InputGroup tag helper
            PrepareForInputGroup(context, output);

            // InputGroupAppend
            RenderInputGroupAddons(context, output);

            // Help
            RenderHelpText(context, output);

            // Validation
            RenderValidation(context, output);

            // Horizontal
            RenderHorizontalForm(context, output);

            // Size
            RenderSize(context, output);

            // Label
            RenderLabel(context, output);
        }

        public void RenderControlId(TagHelperContext context, TagHelperOutput output)
        {
            RenderControlId(context, output, "form-ctrl");
        }

        public void RenderControlId(TagHelperContext context, TagHelperOutput output, string prefix)
        {
            if (string.IsNullOrEmpty(ControlId))
            {
                ControlId = $"{prefix}-{Guid.NewGuid().ToString("N")}";
            }

            output.MergeAttribute("id", ControlId);
        }

        protected void RenderVisability(TagHelperContext context, TagHelperOutput output)
        {
            if (IsDisabled)
                output.Attributes.SetAttribute("disabled", null);

            if (IsReadOnly)
                output.Attributes.SetAttribute("readonly", null);
        }

        protected void PrepareForInputGroup(TagHelperContext context, TagHelperOutput output)
        {
            if (InputGroupContext != null)
            {
                if (LabelText.IsNotNullOrEmpty())
                {
                    InputGroupContext.LabelText = LabelText;
                    LabelText = null;
                }
                
                if (HelpText.IsNotNullOrEmpty())
                {
                    InputGroupContext.HelpText = HelpText;
                    HelpText = null;
                }

                if (AspFor != null)
                {
                    if (IsNeedValidation.GetValueOrDefault() || IsNeedValidationMessage.GetValueOrDefault())
                    {
                        InputGroupContext.AspFor = AspFor;
                        InputGroupContext.MvcTagHelperOutput = MvcTagHelperOutput;

                        InputGroupContext.IsNeedValidation = IsNeedValidation;
                        InputGroupContext.IsNeedValidationMessage = IsNeedValidationMessage;

                        IsNeedValidationMessage = false;
                    }
                }

                if (IsFormHorizontal)
                {
                    InputGroupContext.IsFormHorizontal = IsFormHorizontal;
                    IsFormHorizontal = false;
                }
            }
        }

        protected void RenderInputGroupAddons(TagHelperContext context, TagHelperOutput output)
        {
            if (InputGroupContext != null && InputGroupPrependText.IsNotNullOrEmpty())
            {
                TagBuilder builder = new TagBuilder("span") { TagRenderMode = TagRenderMode.Normal };
                builder.AddCssClass("input-group-addon");
                builder.InnerHtml.Append(InputGroupPrependText);
                output.PreElement.AppendHtml(builder);
            }

            if (InputGroupContext != null && InputGroupAppendText.IsNotNullOrEmpty())
            {
                TagBuilder builder = new TagBuilder("span") { TagRenderMode = TagRenderMode.Normal };
                builder.AddCssClass("input-group-addon");
                builder.InnerHtml.Append(InputGroupAppendText);
                output.PostElement.AppendHtml(builder);
            }
        }

        protected void RenderAspFor(TagHelperContext context, TagHelperOutput output)
        {
            if (AspFor != null)
            {
                var buffer = new TagHelperOutput("input", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

                var helper = new InputTagHelper(HtmlGenerator);
                helper.ViewContext = ViewContext;
                helper.For = AspFor;
                //helper.InputTypeName = InputType;
                helper.Init(context);
                helper.Process(context, buffer);

                MvcTagHelperOutput = buffer;
                Debug.WriteLine(MvcTagHelperOutput.ToTagHelperContent().GetContent());

                foreach (TagHelperAttribute attr in buffer.Attributes)
                {
                    if (!attr.Name.StartsWith("data-"))
                    {
                        output.MergeAttribute(attr.Name, attr.Value);
                    }          
                }

                if (string.IsNullOrEmpty(LabelText))
                {
                    LabelText = AspFor.Metadata.DisplayName ?? AspFor.Metadata.PropertyName;
                }

                if (string.IsNullOrEmpty(HelpText))
                {
                    HelpText = AspFor.Metadata.Description;
                }
            }
        }

        protected void RenderValidation(TagHelperContext context, TagHelperOutput output)
        {
            if (AspFor != null)
            {
                if (IsNeedValidation.GetValueOrDefault())
                {
                    foreach (TagHelperAttribute attr in MvcTagHelperOutput.Attributes)
                    {
                        if (attr.Name.StartsWith("data-"))
                        {
                            output.MergeAttribute(attr.Name, attr.Value);
                        }
                    }
                }

                if (IsNeedValidationMessage.GetValueOrDefault())
                {
                    //var builder = HtmlGenerator.GenerateValidationMessage(ViewContext, AspFor.ModelExplorer, AspFor.Name, null, "", new { @class = "help-block" });

                    var builder = new TagBuilder("div") { TagRenderMode = TagRenderMode.Normal };
                    builder.AddCssClass("help-block");
                    builder.AddCssClass("invalid-feedback");
                    builder.MergeAttribute("data-valmsg-for", AspFor.Name);
                    builder.MergeAttribute("data-valmsg-replace", "true");

                    // Error Message
                    var modelState = ViewContext.ViewData.ModelState.FirstOrDefault(k => k.Key == AspFor.Metadata.PropertyName).Value;
                    if (modelState != null && modelState.ValidationState == ModelValidationState.Invalid)
                    {
                        builder.AddCssClass("field-validation-error");
                        builder.InnerHtml.Append(modelState.Errors.FirstOrDefault()?.ErrorMessage);
                    }
                    else
                    {
                        builder.AddCssClass("field-validation-valid");
                    }

                    output.PostElement.AppendHtml(builder);
                }
            }
        }

        protected void RenderHelpText(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(HelpText))
            {
                TagBuilder helpTag = new TagBuilder("p");
                helpTag.AddCssClass("text-muted");
                helpTag.InnerHtml.Append(HelpText);

                output.PostElement.AppendHtml(helpTag);
            }
        }

        protected void RenderHorizontalForm(TagHelperContext context, TagHelperOutput output)
        {
            RenderHorizontalForm(context, output, false);
        }

        protected void RenderHorizontalForm(TagHelperContext context, TagHelperOutput output, bool useOffsets)
        {
            if (IsFormHorizontal)
            {
                TagBuilder wrapper = new TagBuilder("div") { TagRenderMode = TagRenderMode.StartTag };

                if (FormContext.LabelWidthXs == 0 && FormContext.LabelWidthSm == 0 && FormContext.LabelWidthMd == 0 && FormContext.LabelWidthLg == 0)
                    FormContext.LabelWidthSm = 2;

                if (FormContext.LabelWidthXs > 0 && FormContext.LabelWidthXs < 12) wrapper.AddCssClass($"col-xs-{12 - FormContext.LabelWidthXs}");
                if (FormContext.LabelWidthSm > 0 && FormContext.LabelWidthSm < 12) wrapper.AddCssClass($"col-sm-{12 - FormContext.LabelWidthSm}");
                if (FormContext.LabelWidthMd > 0 && FormContext.LabelWidthMd < 12) wrapper.AddCssClass($"col-md-{12 - FormContext.LabelWidthMd}");
                if (FormContext.LabelWidthLg > 0 && FormContext.LabelWidthLg < 12) wrapper.AddCssClass($"col-lg-{12 - FormContext.LabelWidthLg}");

                if (useOffsets)
                {
                    if (FormContext.LabelWidthXs > 0 && FormContext.LabelWidthXs < 12) wrapper.AddCssClass($"col-xs-offset-{FormContext.LabelWidthXs}");
                    if (FormContext.LabelWidthSm > 0 && FormContext.LabelWidthSm < 12) wrapper.AddCssClass($"col-sm-offset-{FormContext.LabelWidthSm}");
                    if (FormContext.LabelWidthMd > 0 && FormContext.LabelWidthMd < 12) wrapper.AddCssClass($"col-md-offset-{FormContext.LabelWidthMd}");
                    if (FormContext.LabelWidthLg > 0 && FormContext.LabelWidthLg < 12) wrapper.AddCssClass($"col-lg-offset-{FormContext.LabelWidthLg}");
                }

                output.WrapOutside(wrapper);
            }
        }

        protected void RenderSize(TagHelperContext context, TagHelperOutput output)
        {
            RenderSize(context, output, "input");
        }

        protected void RenderSize(TagHelperContext context, TagHelperOutput output, string prefix)
        {
            if (Size != FormControlSize.Default)
                output.AddCssClass($"{prefix}-{Size.GetEnumInfo().Name}");
        }

        protected void RenderLabel(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(LabelText))
            {

                TagBuilder builder = new TagBuilder("label");
                builder.MergeAttribute("for", ControlId, false);

                builder.InnerHtml.Append(LabelText);

                if (this.FormContext != null && this.FormContext.Layout == FormTagLayout.Horizontal)
                {
                    builder.AddCssClass("control-label");

                    if (FormContext.LabelWidthXs > 0 && FormContext.LabelWidthXs < 12) builder.AddCssClass($"col-xs-{FormContext.LabelWidthXs}");
                    if (FormContext.LabelWidthSm > 0 && FormContext.LabelWidthSm < 12) builder.AddCssClass($"col-sm-{FormContext.LabelWidthSm}");
                    if (FormContext.LabelWidthMd > 0 && FormContext.LabelWidthMd < 12) builder.AddCssClass($"col-md-{FormContext.LabelWidthMd}");
                    if (FormContext.LabelWidthLg > 0 && FormContext.LabelWidthLg < 12) builder.AddCssClass($"col-lg-{FormContext.LabelWidthLg}");
                }

                output.PreElement.Prepend(builder);
            }
        }
    }
}
