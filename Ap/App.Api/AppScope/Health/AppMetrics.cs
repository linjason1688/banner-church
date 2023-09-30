using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Infrastructure;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace App.Api.AppScope.Health
{
    /// <summary>
    /// </summary>
    public class AppMetrics : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            var health = new HealthCheckResult(
                HealthStatus.Healthy,
                "global app information",
                data: new Dictionary<string, object>()
                {
                    {
                        "commit", BuildVersion.Version
                    },
                    {
                        "is64BitProcess", Environment.Is64BitProcess
                    }
                }
            );

            return Task.FromResult(health);
        }
    }
}
