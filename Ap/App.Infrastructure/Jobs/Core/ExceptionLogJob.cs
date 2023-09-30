#region

using System.Threading.Tasks;
using App.Application.Common.Configs;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Infrastructure.Services.Core;
using App.Utility.Extensions;
using Microsoft.Extensions.Logging;
using Quartz;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Jobs.Core
{
    [TransientService(typeof(IJob))]
    [DisallowConcurrentExecution]
    public class ExceptionLogJob : JobBase, IJob
    {
        private readonly IAppDbContext appDbContext;
        private readonly AppStore appStore;
        private readonly ILogger logger;

        public override JobConfig JobConfig { get; }


        public ExceptionLogJob(
            ILogger<ExceptionLogJob> logger,
            IAppConfiguration appConfiguration,
            IHandleErrorService handleErrorService,
            IAppDbContext appDbContext,
            AppStore appStore
        )
            : base(logger, handleErrorService)
        {
            this.logger = logger;
            this.appDbContext = appDbContext;
            this.appStore = appStore;

            var jobConfig = appConfiguration.ScheduleJobsConfig.Core.ExceptionLogJob;

            this.JobConfig = jobConfig;

            this.Order = jobConfig?.Order ?? 0;
        }

        protected override async Task DoWork()
        {
            const int batchSize = 100;
            var totalCount = await this.appStore.ExceptionLogQueue
               .BatchConsumeAllAsync(
                    batchSize,
                    async (items, ct) =>
                    {
                        await this.appDbContext.ExceptionLog.AddRangeAsync(items, ct);

                        await this.appDbContext.SaveChangesAsync(ct);
                    }
                );

            if (totalCount > 0)
            {
                this.logger.LogInformation("Flush ex logs counts: {@Count}", totalCount);
            }
        }
    }
}
