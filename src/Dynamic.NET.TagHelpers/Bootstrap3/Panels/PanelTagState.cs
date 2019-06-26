using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Panels
{

    public enum PanelTagState
    {
        [EnumInfo("panel-default")]
        Default,

        [EnumInfo("panel-primary")]
        Primary,

        [EnumInfo("panel-success")]
        Success,

        [EnumInfo("panel-info")]
        Info,

        [EnumInfo("panel-warning")]
        Warning,

        [EnumInfo("panel-danger")]
        Danger,
    }
}
