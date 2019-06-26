using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    public enum FormGroupState
    {
        [EnumInfo("")]
        None,

        [EnumInfo("has-warning")]
        Warning,

        [EnumInfo("has-error")]
        Error,

        [EnumInfo("has-success")]
        Success,
    }
}
