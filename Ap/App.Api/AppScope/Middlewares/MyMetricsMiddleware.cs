#region

using System.Threading.Tasks;
using App.Infrastructure;
using Microsoft.AspNetCore.Http;

#endregion

namespace App.Api.AppScope.Middlewares
{
    public class MyMetricsMiddleware
    {
        private readonly RequestDelegate next;

        public MyMetricsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context /* other dependencies */)
        {
            context.Response.Headers.Add("x-app-version", BuildVersion.Version);

            await this.next(context);
        }
    }
}
