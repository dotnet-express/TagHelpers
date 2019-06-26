using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Box
{
    /// <summary>
    /// 
    /// </summary>
    public enum BoxTagState
    {
        [EnumInfo("")]
        None,

        [EnumInfo("box-default")]
        Default,

        [EnumInfo("box-primary")]
        Primary,

        [EnumInfo("box-success")]
        Success,

        [EnumInfo("box-info")]
        Info,

        [EnumInfo("box-warning")]
        Warning,

        [EnumInfo("box-danger")]
        Danger,
    }
}
