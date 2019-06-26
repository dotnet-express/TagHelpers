using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    public enum ProgressBarTagColor
    {
        [EnumInfo("")]
        Default,

        [EnumInfo("progress-bar-primary")]
        Primary,

        [EnumInfo("progress-bar-success")]
        Success,

        [EnumInfo("progress-bar-info")]
        Info,

        [EnumInfo("progress-bar-warning")]
        Warning,

        [EnumInfo("progress-bar-danger")]
        Danger,
    }
}
