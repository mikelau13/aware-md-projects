using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Utilities
{
    public static class RequestComingFromExtensions
    {
        public static IApplicationBuilder RequestComingFrom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestComingFromMiddleware>();
        }
    }
}
