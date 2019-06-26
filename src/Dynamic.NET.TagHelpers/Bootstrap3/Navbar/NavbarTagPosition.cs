using Dynamic.NET.TagHelpers.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Navbar
{
    public enum NavbarTagPosition
    {
        [EnumInfo("")]
        Default,

        [EnumInfo("navbar-fixed-top")]
        FixedTop,

        [EnumInfo("navbar-fixed-bottom")]
        FixedBottom,

        [EnumInfo("navbar-static-top")]
        StaticTop
    }
}
