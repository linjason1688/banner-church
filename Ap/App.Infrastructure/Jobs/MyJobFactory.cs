#region

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Spi;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Jobs
{
    [SingletonService(typeof(IJobFactory))]
    public class MyJobFactory : IJobFactory
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;

        public MyJobFactory(
            IServiceProvider serviceProvider,
            ILogger<MyJobFactory> logger
        )
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var scope = this.serviceProvider.CreateScope();

            return scope.ServiceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
            // do nothing
        }
    }
}
