#region

using Microsoft.AspNetCore.Builder;

#endregion

namespace App.Api.AppScope.Middlewares
{
    public static class MiddlewareRegister
    {
        public static IApplicationBuilder UseMyMiddlewares(this IApplicationBuilder @this)
        {
            @this.UseMiddleware(typeof(MyMetricsMiddleware));
            @this.UseMiddleware(typeof(AppInfoMiddleware));
            @this.UseMiddleware(typeof(ApiLogMiddleware));
            @this.UseMiddleware(typeof(ErrorHandlerMiddleware));

            return @this;
        }
    }
}
