using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Tables
{
    public enum TableTagState
    {
        [EnumInfo("")]
        Basic,

        [EnumInfo("table-striped")]
        Striped,

        [EnumInfo("table-bordered")]
        Bordered,

        [EnumInfo("table-hover")]
        Hover,

        [EnumInfo("table-condensed")]
        Condensed,
    }
}
