using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Entities.Features;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Impl
{
    /// <summary>
    /// </summary>
    [ScopedService(typeof(IAppCacheService))]
    public class AppCacheService : IAppCacheService
    {
        private const int EXPIRED_MINUTES = 0;

        private readonly IAppDbContext appDbContext;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IMemoryCache memoryCache;

        /// <summary>
        /// 
        /// </summary>
        public AppCacheService(
            IMapper mapper,
            ILogger<AppCacheService> logger,
            IMemoryCache memoryCache,
            IAppDbContext appDbContext
        )
        {
            this.mapper = mapper;
            this.logger = logger;
            this.memoryCache = memoryCache;
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// 取得部門 tree
        /// </summary>
        /// <param name="forceReload"></param>
        /// <returns></returns>
        public async Task<string> GetItemAsync(bool forceReload = false)
        {
            return await this.FetchAsync(
                () =>
                {
                    return Task.FromResult(string.Empty);
                },
                60,
                forceReload
            );
        }

        /// <inheritdoc />
        public async Task<List<Privilege>> GetPrivilegesAsync(
            bool forceReload = false,
            CancellationToken cancellationToken = default
        )
        {
            return await this.FetchAsync(
                async () =>
                {
                    var data =
                        await this.appDbContext.Privileges
                           .ToListAsync(cancellationToken);

                    return data;
                },
                EXPIRED_MINUTES,
                forceReload,
                cancellationToken
            );
        }


        /// <inheritdoc />
        public async Task<List<RolePrivilegeMapping>> GetRolePrivilegeMappingAsync(
            bool forceReload = false,
            CancellationToken cancellationToken = default
        )
        {
            return await this.FetchAsync(
                async () =>
                {
                    var data =
                        await this.appDbContext.RolePrivilegeMappings
                           .Where(x => x.Enable)
                           .ToListAsync(cancellationToken);

                    return data;
                },
                EXPIRED_MINUTES,
                forceReload,
                cancellationToken
            );
        }

        private async Task<T> FetchAsync<T>(
            Func<Task<T>> fetcher,
            int expiredMinutes,
            bool forceReload = false,
            CancellationToken cancellationToken = default,
            string cacheKey = ""
        )
        {
            try
            {
                if (string.IsNullOrEmpty(cacheKey))
                {
                    cacheKey = typeof(T).FullName;
                }

                if (forceReload)
                {
                    this.memoryCache.Remove(cacheKey);
                }

                return await this.memoryCache
                   .GetOrCreateAsync(
                        cacheKey,
                        e =>
                        {
                            return Task.Run(
                                async () =>
                                {
                                    var data = await fetcher();

                                    e.SetValue(data);
                                    e.SetAbsoluteExpiration(DateTime.Now.AddMinutes(expiredMinutes));

                                    return data;
                                }
                            );
                        }
                    );
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, cacheKey);

                throw;
            }
        }
    }
}
