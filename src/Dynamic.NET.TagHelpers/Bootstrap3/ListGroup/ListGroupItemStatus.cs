using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.ListGroup
{
    public enum ListGroupItemStatus
    {
        [EnumInfo("")]
        Default,

        [EnumInfo("list-group-item-success")]
        Success,

        [EnumInfo("list-group-item-info")]
        Info,

        [EnumInfo("list-group-item-warning")]
        Warning,

        [EnumInfo("list-group-item-danger")]
        Danger,
    }
}
