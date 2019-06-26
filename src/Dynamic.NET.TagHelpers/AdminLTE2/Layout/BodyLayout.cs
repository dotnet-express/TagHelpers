using Dynamic.NET.TagHelpers.Attributes;

namespace Dynamic.NET.TagHelpers.AdminLTE2.Layout
{
    public enum BodyLayout
    {
        [EnumInfo("fixed")]
        Fixed,

        [EnumInfo("layout-boxed")]
        Boxed,

        [EnumInfo("layout-top-nav")]
        TopNav,
    }
}
