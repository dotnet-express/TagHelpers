using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamic.NET.TagHelpers.Bootstrap3.Forms
{
    public static class InputTypeConstants
    {
        public static readonly List<string> CheckTypes = new List<string> { "checkbox" };
        public static readonly List<string> RadioTypes = new List<string> { "radio" };
        public static readonly List<string> ButtonTypes = new List<string> { "submit", "reset", "button" };
        public static readonly List<string> InputTypes = new List<string> { "text", "password", "datetime", "datetime-local", "date", "month", "time", "week", "number", "email", "url", "search", "tel", "color" };
        public static readonly List<string> RangeTypes = new List<string> { "range" };
        public static readonly List<string> FileTypes = new List<string> { "file" };
    }
}
