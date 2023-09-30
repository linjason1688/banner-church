using Microsoft.Extensions.DependencyInjection;

namespace App.Api.AppScope.Health
{
    /// <summary>
    /// </summary>
    public static class HealthRegister
    {
        public static IServiceCollection AddMyHealthChecks(this IServiceCollection @this)
        {
            @this.AddHealthChecks()
               .AddCheck<AppMetrics>(nameof(AppMetrics))
               .AddCheck<SqlServerChecker>(nameof(SqlServerChecker));

            return @this;
        }
    }
}
