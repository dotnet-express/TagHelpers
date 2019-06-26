using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Pagination
{
    public enum PagerSize
    {
        [EnumInfo("")]
        normal,

        [EnumInfo("pagination-lg")]
        large,

        [EnumInfo("pagination-sm")]
        small,
    }
}
