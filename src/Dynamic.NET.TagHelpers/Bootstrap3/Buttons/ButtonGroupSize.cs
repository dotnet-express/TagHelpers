using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Buttons
{
    public enum ButtonGroupSize
    {
        [EnumInfo("")]
        Normal,

        [EnumInfo("btn-group-lg")]
        Large,

        [EnumInfo("btn-group-sm")]
        Small,

        [EnumInfo("btn-group-xs")]
        ExtraSmall,
    }
}
