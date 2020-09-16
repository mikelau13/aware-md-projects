using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Utilities
{
    public class RequestComingFromMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestComingFromMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestComingFromMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            Utilities.UserAgentHelper.LogUserAgent(context.Request.Path, context.Request.Method, context.Request.Headers["User-Agent"], _logger);

            await _next(context);
        }
    }
}
