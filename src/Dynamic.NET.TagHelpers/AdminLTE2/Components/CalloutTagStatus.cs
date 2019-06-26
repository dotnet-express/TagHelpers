using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Components
{
    public enum CalloutTagStatus
    {
        [EnumInfo("callout-success")]
        Success,

        [EnumInfo("callout-info")]
        Info,

        [EnumInfo("callout-warning")]
        Warning,

        [EnumInfo("callout-danger")]
        Danger,
    }
}
