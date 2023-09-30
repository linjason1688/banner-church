#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using App.Application.Common.Interfaces.Services.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace App.Api.AppScope
{
    public static class HttpContextExtension
    {
        private static readonly List<string> possibleIpHeaders = new List<string>()
        {
            "HTTP_CLIENT_IP",
            "HTTP_X_FORWARDED_FOR",
            "HTTP_X_FORWARDED",
            "HTTP_FORWARDED_FOR",
            "HTTP_FORWARDED",
            "X-Forwarded-For"
        };

        public static string GetClientIpAddress(this HttpContext @this)
        {
            var ipValue = string.Empty;

            foreach (var header in possibleIpHeaders)
            {
                ipValue = @this.Request.Headers[header].FirstOrDefault();

                if (!string.IsNullOrEmpty(ipValue))
                {
                    break;
                }
            }

            if (IPAddress.TryParse(ipValue ?? string.Empty, out var ip))
            {
                return ipValue;
            }

            return @this.Connection.RemoteIpAddress.ToString();
        }

        public static Guid GetRequestHandledId(this HttpContext @this)
        {
            var scopeContext = @this.RequestServices.GetService<IScopeContextService>();

            if (null == scopeContext)
            {
                throw new Exception("FAIL to get IScopeContextService");
            }

            return scopeContext.TransactionId;
        }
    }
}
