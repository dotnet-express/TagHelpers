using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Components
{
    public enum AlertTagStatus
    {
        [EnumInfo("alert-success")]
        Success,

        [EnumInfo("alert-info")]
        Info,

        [EnumInfo("alert-warning")]
        Warning,

        [EnumInfo("alert-danger")]
        Danger,
    }
}
