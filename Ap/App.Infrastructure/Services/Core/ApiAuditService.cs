using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Domain.Entities.Core;
using App.Utility.Extensions;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Core
{
    [ScopedService]
    public class ApiAuditService
    {
        private readonly IAppDbContext appDbContext;
        private readonly AppStore appStore;
        private readonly IAuthService authService;
        private readonly IDateTime dateTime;
        private readonly ILogger logger;


        public ApiAuditService(
            ILogger<ApiAuditService> logger,
            IDateTime dateTime,
            IAppDbContext appDbContext,
            IAuthService authService,
            AppStore appStore
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
            this.dateTime = dateTime;
            this.authService = authService;
            this.appStore = appStore;
        }


        public void AddLog(ApiActionInfo info)
        {
            // try to figure out the identity, some may not have been authorized!
            var identity = this.authService.Identity ?? new UserIdentity();

            // mapping to entity
            var auditLog = new ApiAuditLog()
            {
                HandledId = info.HandledId,
                Account = identity?.Account,
                Name = identity?.Name,

                //
                SourceIp = info.SourceIp,
                HttpMethod = info.HttpMethod,
                RequestPath = info.RequestPath,
                RequestQueryString = info.RequestQueryString,
                RequestHeaders = info.RequestHeaders,
                ResponseStatusCode = info.ResponseStatusCode,
                RequestBody = info.RequestBody,
                ResponseBody = info.ResponseBody,
                TimeElapsed = info.TimeElapsed,
                DateCreate = this.dateTime.Now,
                UserCreate = this.authService.Identity?.Account
            };

            // save
            this.appStore.ApiLogQueue.Enqueue(auditLog);
        }


        public async Task FlushLogsAsync(CancellationToken cancellationToken = default)
        {
            const int batchCount = 100;

            var totalCount = await this.appStore.ApiLogQueue
               .BatchConsumeAllAsync(
                    batchCount,
                    async (items, ct) =>
                    {
                        await this.appDbContext.ApiAuditLog.AddRangeAsync(items, ct);

                        await this.appDbContext.SaveChangesAsync(cancellationToken);
                    },
                    cancellationToken
                );
        }
    }
}
