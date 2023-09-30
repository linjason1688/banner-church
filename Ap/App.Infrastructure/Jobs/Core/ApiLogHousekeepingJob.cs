#region

using System;
using System.Threading.Tasks;
using App.Application.Common.Configs;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Infrastructure.Services.HouseKeepers;
using Microsoft.Extensions.Logging;
using Quartz;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Jobs.Core
{
    [TransientService(typeof(IJob))]
    [DisallowConcurrentExecution]
    public class ApiLogHousekeepingJob : JobBase, IJob
    {
        private readonly ApiLogHouseKeeper housekeeper;

        private readonly HouseKeepingConfig houseKeepingConfig;
        private readonly ILogger logger;

        public override JobConfig JobConfig { get; }


        public ApiLogHousekeepingJob(
            ILogger<ApiLogHousekeepingJob> logger,
            IAppConfiguration appConfiguration,
            IHandleErrorService handleErrorService,
            ApiLogHouseKeeper housekeeper
        )
            : base(logger, handleErrorService)
        {
            this.logger = logger;
            this.housekeeper = housekeeper;

            var jobConfig = appConfiguration.ScheduleJobsConfig.Core.ApiLogHousekeepingJob;

            this.houseKeepingConfig = jobConfig;
            this.JobConfig = jobConfig;

            this.Order = jobConfig?.Order ?? 0;
        }

        protected override async Task DoWork()
        {
            var keepDays = this.houseKeepingConfig.KeepDays;

            if (!keepDays.HasValue)
            {
                throw new MyBusinessException("KeepDays should be provided in config!");
            }

            var targetDate = DateTime.Now.AddDays(-1 * keepDays.Value);

            var effectCount = await this.housekeeper.CleanupAsync(targetDate);

            this.logger.LogInformation("共清理 {@EffectCount} 筆 ApiAuditLog 資料!", effectCount);
        }
    }
}
