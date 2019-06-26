using Dynamic.NET.TagHelpers.Attributes;
using Dynamic.NET.TagHelpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Dynamic.NET.TagHelpers
{
    public abstract class DynamicTagHelper : TagHelper
    {
        public DynamicTagHelper()
        {

        }

        [HtmlAttributeNotBound]
        [HtmlAttributeName("dth-disabled")]
        public bool IsTagHelperDisabled { get; set; } = false;

        [HtmlAttributeNotBound]
        public string TagName { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeNotBound]
        public IUrlHelper UrlHelper { get; set; }

        public override void Init(TagHelperContext context)
        {
            SetContext(this, context);
            BindContext(this, context);
            BindProperties();

            base.Init(context);
        }

        /// <inheritdoc />
        /// <remarks>Set stop flag for processing, if <see cref="IsTagHelperEnable"/> is <c>false</c></remarks>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            PreProcess(context, output);

            if (!IsTagHelperDisabled)
            {
                PreRender(context, output);
                await this.RenderAsync(context, output);
                PostRender(context, output);
            }
            else
            {
                TagHelperAttribute[] attributes = context.AllAttributes.ToArray();
                for (int i = 0; i < attributes.Length; i++)
                {
                    output.CopyHtmlAttribute(attributes[i].Name, context);
                }
            }

            PostProcess(context, output);
        }

        protected virtual void PreProcess(TagHelperContext context, TagHelperOutput output)
        {
            TagName = context.TagName;
            //TagName = TagName.Parse(TagPrefix, context.TagName);
        }

        protected virtual void PreRender(TagHelperContext context, TagHelperOutput output)
        {
            
        }

        protected virtual async Task RenderAsync(TagHelperContext context, TagHelperOutput output)
        {
            await Task.Run(() => Render(context, output));
        }

        protected virtual void Render(TagHelperContext context, TagHelperOutput output)
        {
            /// This is body for synchronous method for rendering tag helper
        }

        protected virtual void PostRender(TagHelperContext context, TagHelperOutput output)
        {

        }

        protected virtual void PostProcess(TagHelperContext context, TagHelperOutput output)
        {

        }

        private void BindProperties()
        {
            // IUrlHelper
            IUrlHelperFactory urlHelperFactory = ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            UrlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

        }

        private void BindContext(object target, TagHelperContext context)
        {
            foreach (var propertyInfo in target.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(pi => pi.HasCustomAttribute<BindTagHelperContextAttribute>()))
            {
                var attr = propertyInfo.GetCustomAttribute<BindTagHelperContextAttribute>();
                if (string.IsNullOrEmpty(attr.Key))
                {
                    var contextItem = context.GetContextItem(propertyInfo.PropertyType, attr.UseInherited);
                    if (contextItem != null)
                        propertyInfo.SetValue(target, contextItem);
                    if (attr.RemoveContext)
                        context.RemoveContextItem(propertyInfo.PropertyType, attr.UseInherited);
                }
                else
                {
                    propertyInfo.SetValue(target, context.GetContextItem(propertyInfo.PropertyType, attr.Key));
                    if (attr.RemoveContext)
                        context.RemoveContextItem(attr.Key);
                }
            }
        }

        private void SetContext(object target, TagHelperContext context)
        {
            var targetType = target.GetType();
            var attr = targetType.GetTypeInfo().GetCustomAttribute<TagHelperContextAttribute>();
            if (attr != null)
            {
                if (string.IsNullOrEmpty(attr.Key))
                {
                    context.SetContextItem(attr.Type ?? targetType, target);
                }
                else
                {
                    context.SetContextItem(attr.Key, target);
                }
            }
        }
    }
}
