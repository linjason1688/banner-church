using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace App.Api.AppScope.Health
{
    /// <summary>
    /// </summary>
    public class SqlServerChecker : IHealthCheck
    {
        private readonly IAppDbContext appDbContext;

        public SqlServerChecker(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            var state = this.appDbContext.IsAvailable() ? HealthStatus.Healthy : HealthStatus.Degraded;

            var health = new HealthCheckResult(
                state,
                "sql status",
                data: new Dictionary<string, object>()
            );

            return Task.FromResult(health);
        }
    }
}
