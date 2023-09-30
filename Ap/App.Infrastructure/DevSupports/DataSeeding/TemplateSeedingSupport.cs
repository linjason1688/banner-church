using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Infrastructure.Persistence;
using App.Infrastructure.Supports;
using AutoMapper;
using EFCore.BulkExtensions;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.DevSupports.DataSeeding
{
    /// <summary>
    /// </summary>
    [TransientService(typeof(IDevSupport))]
    public class TemplateSeedingSupport : DevSupportBase, IDevSupport
    {
        private readonly AppDbContext appDbContext;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="appDbContext"></param>
        public TemplateSeedingSupport(
            IMapper mapper,
            ILogger<TemplateSeedingSupport> logger,
            AppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.logger = logger;
            this.appDbContext = appDbContext;
        }


        /// <inheritdoc />
        public async Task Process(Dictionary<string, object> options, CancellationToken cancellationToken = default)
        {
            // var count = await this.appDbContext
            //    .Enitity
            //    .Where(e => e.Creator == DataSeedingSupport.Creator)
            //    .BatchDeleteAsync(cancellationToken);
            //
            // this.logger.LogDebug("Total Deleted: {@Count}", count);
        }
    }
}
