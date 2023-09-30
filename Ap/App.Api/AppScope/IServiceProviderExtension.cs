#region

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Api.AppScope
{
    public static class IServiceProviderExtension
    {
        public static ILogger<T> CreateLogger<T>(this IServiceProvider @this)
        {
            return @this.GetService<ILoggerFactory>().CreateLogger<T>();
        }
    }
}
