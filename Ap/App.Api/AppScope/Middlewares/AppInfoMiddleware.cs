#region

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

#endregion

namespace App.Api.AppScope.Middlewares
{
    public class AppInfoMiddleware
    {
        private readonly RequestDelegate next;

        public AppInfoMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Handled-Host", Environment.MachineName);

            await this.next(context);
        }
    }
}
