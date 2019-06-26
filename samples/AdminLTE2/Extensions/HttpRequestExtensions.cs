using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.WebApplication1
{
    public static class HttpRequestExtensions
    {
        public static bool IsPjax(this HttpRequest request)
        {
            return !IsNotPjax(request);
        }

        public static bool IsNotPjax(this HttpRequest request)
        {
            var header = request.Headers.FirstOrDefault(x => x.Key.Equals("X-PJAX", StringComparison.OrdinalIgnoreCase));
            return (header.Value == StringValues.Empty);
        }


    }
}
