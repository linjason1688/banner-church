#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Spi;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Jobs
{
    [SingletonService]
    public class QuartzManageService
    {
        private readonly bool hasInitialized = false;
        private readonly IJobFactory jobFactory;
        private readonly ILogger logger;
        private readonly object root = new object();
        private readonly ISchedulerFactory schedulerFactory;

        private readonly IServiceProvider serviceProvider;

        private IScheduler scheduler;

        public QuartzManageService(
            IHostApplicationLifetime hostLifetime,
            IServiceProvider serviceProvider,
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            ILogger<QuartzManageService> logger
        )
        {
            this.serviceProvider = serviceProvider;
            this.schedulerFactory = schedulerFactory;
            this.jobFactory = jobFactory;
            this.logger = logger;

            hostLifetime.ApplicationStarted.Register(this.Initialize);
            hostLifetime.ApplicationStopping.Register(this.ShutDown, true);
        }


        private void ShutDown()
        {
            this.logger.LogInformation("Stopping Quartz jobs....");
            this.scheduler.Shutdown().GetAwaiter().GetResult();
            this.logger.LogInformation("Stopping Quartz jobs completed!");
        }

        private void Initialize()
        {
            if (this.hasInitialized)
            {
                return;
            }

            Task.Run(this.RegisterJobsAsync)
               .GetAwaiter()
               .GetResult();
        }

        private async Task RegisterJobsAsync()
        {
            this.logger.LogInformation("register jobs");
            this.scheduler = await this.schedulerFactory.GetScheduler();
            this.scheduler.JobFactory = this.jobFactory;

            var scope = this.serviceProvider.CreateScope();

            var jobs = scope.ServiceProvider.GetServices<IJob>()
               .Select(x => x as JobBase)
               .OrderBy(x => x?.Order)
               .ToList();

            var jobsToRunAtStartup = new List<IJobDetail>();

            foreach (var job in jobs)
            {
                var typeName = job.GetType().Name;

                // 無 config 者 不需建立 job
                if (null == job.JobConfig || !job.JobConfig.Enable)
                {
                    this.logger.LogInformation(
                        "Job {@TypeName} {@Name} is disabled! SKIP to register!",
                        typeName,
                        job?.JobConfig?.Name
                    );

                    continue;
                }

                var jobDetail = this.CreateJob(job);
                var jobTrigger = this.CreateTrigger(job);
                var firstTriggeredAt = await this.scheduler.ScheduleJob(jobDetail, jobTrigger);
                var triggeredAt = firstTriggeredAt.ToLocalTime();

                this.logger.LogInformation(
                    "***** ({@Order}) Register Job {@TypeName}: {@Name}, first triggered at: {@TriggeredAt}",
                    job.JobConfig.Order,
                    typeName,
                    job.JobConfig.Name,
                    triggeredAt.ToString("yyyy-MM-dd HH:mm:ss")
                );

                if (job.JobConfig.StartAtStartup)
                {
                    jobsToRunAtStartup.Add(jobDetail);
                }
            }

            await this.scheduler.Start();

            this.logger.LogInformation("scheduling jobs completed!");

            jobsToRunAtStartup.ForEach(
                job => { this.scheduler.TriggerJob(job.Key); }
            );
        }

        private IJobDetail CreateJob(JobBase job)
        {
            var config = job.JobConfig;

            var jobType = job.GetType();

            return JobBuilder
               .Create(jobType)
               .WithIdentity(jobType.FullName)
               .WithDescription(config.Description)
               .Build();
        }

        private ITrigger CreateTrigger(JobBase job)
        {
            var config = job.JobConfig;

            var jobType = job.GetType();

            return TriggerBuilder
               .Create()
               .WithIdentity($"{jobType.FullName}.trigger")
               .WithCronSchedule(config.CronExpression)
               .WithDescription(config.Description)
               .Build();
        }
    }
}
