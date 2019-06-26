using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Modal
{
    public enum ModalDialogTagState
    {
        [EnumInfo("modal-default")]
        Default,

        [EnumInfo("modal-primary")]
        Primary,

        [EnumInfo("modal-success")]
        Success,

        [EnumInfo("modal-info")]
        Info,

        [EnumInfo("modal-warning")]
        Warning,

        [EnumInfo("modal-danger")]
        Danger,
    }
}
