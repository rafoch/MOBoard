using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace MOBoard.Common.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(httpContext.User.Claims.SingleOrDefault(x => x.Type == "id")?.Value);
        }

    }
}