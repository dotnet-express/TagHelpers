using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Media
{
    public enum MediaObjectTagAlign
    {
        [EnumInfo("media-left")]
        Left,

        [EnumInfo("media-left media-top")]
        LeftTop,

        [EnumInfo("media-left media-middle")]
        LeftMiddle,

        [EnumInfo("media-left media-bottom")]
        LeftBottom,

        [EnumInfo("media-right")]
        Right,

        [EnumInfo("media-right media-top")]
        RightTop,

        [EnumInfo("media-right media-middle")]
        RightMiddle,

        [EnumInfo("media-right media-bottom")]
        RightBottom,
    }
}
