using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    public enum LabelPillTagColor
    {
        [EnumInfo("label-default")]
        Default,

        [EnumInfo("label-primary")]
        Primary,

        [EnumInfo("label-success")]
        Success,

        [EnumInfo("label-info")]
        Info,

        [EnumInfo("label-warning")]
        Warning,

        [EnumInfo("label-danger")]
        Danger,
    }
}
