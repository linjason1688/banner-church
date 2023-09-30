#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces.Services;
using App.Infrastructure.DevSupports.DataSeeding;
using App.Infrastructure.Services.Impl;
using App.Utility.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

#endregion

namespace App.Infrastructure.DevSupports
{
    [TransientService]
    public class DevSupportManager
    {
        private readonly IAuthService authService;
        private readonly IClientInfoService clientInfoService;
        private readonly IAppConfiguration configService;
        private readonly IHostEnvironment environment;
        private readonly ILogger<DevSupportManager> logger;
        private readonly IEnumerable<IDevSupport> supports;

        public DevSupportManager(
            ILogger<DevSupportManager> logger,
            IEnumerable<IDevSupport> supports,
            AppConfiguration configService,
            IHostEnvironment environment,
            IAuthService authService,
            IClientInfoService clientInfoService
        )
        {
            this.logger = logger;
            this.supports = supports;
            this.configService = configService;
            this.environment = environment;
            this.authService = authService;
            this.clientInfoService = clientInfoService;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task ProcessFixturesAsync()
        {
            var devConfig = this.configService.DevConfig;

            // 
            if (this.environment.IsProduction())
            {
                if (devConfig.EnableSupportsInProduction)
                {
                    this.logger.LogWarning("Support are enabled in Production env....");
                }
                else
                {
                    // 正常 prod 不應該執行 supports
                    return;
                }
            }

#if DEBUG

            // 自動 binding 目前 user
            var jwt = await this.authService.GenerateJwtAsync(
                new UserIdentity
                {
                    Version = UserIdentity.IVersion,
                    Id = Guid.Empty,
                    Account = DataSeedingHelper.Creator,
                    LastLoginIp = "::1",
                    Mocked = false,
                    ActualName = "admin",
                    ActualNickName = "admin",
                    ActualEmployeeId = "admin",
                    ActualDeptName = "App",
                    ActualDeptId = "App"
                }
            );

            await this.authService.RetrievingProfileOfJwtAsync(jwt);

            this.clientInfoService.SetClientInfo(
                new ClientRequestInfo
                {
                    IpAddress = null,
                    DeviceInfo = new DeviceInfo()
                }
            );
#endif

            var composites = this.supports
               .LeftOuterJoin(
                    devConfig.DevSupports,
                    s => s.Name,
                    c => c.Name,
                    (s, c) => new
                    {
                        Support = s,
                        Config = c
                    }
                )
               .OrderBy(x => x.Config?.ExecutionOrder)
               .ToList();

            foreach (var composite in composites)
            {
                var support = composite.Support;
                var state = composite.Config;

                var name = support.Name;

                if (state == null)
                {
                    this.logger.LogWarning(@"{Name} support not provided in config!!", name);

                    continue;
                }

                if (!state.Enable)
                {
                    this.logger.LogWarning("{Name} support is disabled, skip to execute!", name);

                    continue;
                }

                try
                {
                    this.logger.LogInformation("start to execute {Name}", name);

                    await support.Process(state.Options);

                    this.logger.LogInformation("complete execution of {Name}", name);
                }
                catch (Exception ex)
                {
                    this.logger.LogInformation(ex, "error !! {Name}", name);
                }
            }
        }
    }
}
