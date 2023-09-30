#region

using System.Threading.Tasks;
using App.Application.Common.Configs;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Infrastructure.Services.Core;
using Microsoft.Extensions.Logging;
using Quartz;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.Jobs.Core
{
    [TransientService(typeof(IJob))]
    [DisallowConcurrentExecution]
    public class ApiAuditLogJob : JobBase, IJob
    {
        private readonly ApiAuditService apiAuditService;
        private readonly ILogger logger;

        public override JobConfig JobConfig { get; }


        public ApiAuditLogJob(
            ILogger<ApiAuditLogJob> logger,
            IAppConfiguration appConfiguration,
            IHandleErrorService handleErrorService,
            ApiAuditService apiAuditService
        )
            : base(logger, handleErrorService)
        {
            this.logger = logger;
            this.apiAuditService = apiAuditService;

            var jobConfig = appConfiguration.ScheduleJobsConfig.Core.ApiAuditLogJob;

            this.JobConfig = jobConfig;

            this.Order = jobConfig?.Order ?? 0;
        }

        protected override async Task DoWork()
        {
            await this.apiAuditService.FlushLogsAsync();
        }
    }
}
