using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    [TransientService]
    public class AppSetupService
    {
        private readonly ILogger logger;
        private readonly IEnumerable<IOneTimeSetup> services;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="services"></param>
        public AppSetupService(
            ILogger<AppSetupService> logger,
            IEnumerable<IOneTimeSetup> services
        )
        {
            this.logger = logger;
            this.services = services;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task InitAsync()
        {
            foreach (var service in this.services)
            {
                await service.SetupAsync();
            }
        }
    }
}
