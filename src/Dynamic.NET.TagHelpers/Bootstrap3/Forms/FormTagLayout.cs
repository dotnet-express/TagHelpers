﻿using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    public enum FormTagLayout
    {
        [EnumInfo("vertical")]
        Vertical,

        [EnumInfo("inline")]
        Inline,

        [EnumInfo("horizontal")]
        Horizontal,
    }
}
