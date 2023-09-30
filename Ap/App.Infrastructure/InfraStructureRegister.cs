using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.Application.Common.Configs;
using App.Application.Common.Interfaces;
using App.Infrastructure.Persistence;
using App.Infrastructure.Persistence.Plugins.SqlLog;
using App.Utility.Cryptos;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yozian.DependencyInjectionPlus;
using Yozian.Extension;

namespace App.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class InfraStructureRegister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IServiceCollection AddInfrastructure(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddDbContext<AppDbContext>(
                options =>
                {
                    // add sql config
                    var sqlConfig = configuration.GetSection(nameof(SqlConfig)).Get<SqlConfig>();

                    switch (sqlConfig.Provider)
                    {
                        case AppSqlProvider.MSSQL:
                            // we accept plaint text or encrypted text
                            var connectionString = AesCrypto.Instance.CompatibleDecrypt(sqlConfig?.Connection);

                            options.UseSqlServer(connectionString);

                            //
                            options.UseExceptionProcessor();

                            break;
                        case AppSqlProvider.InMemory:
                            options.UseInMemoryDatabase("ApplicationDb");

                            break;

                        default:
                            throw new ArgumentException("AppSqlProvider should be specified in sql config");
                    }

                    // options.UseLazyLoadingProxies();
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                    options.AddSqlCmdLogger();
                }
            );

            @this.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            @this.RegisterServicesOfAssembly(Assembly.GetExecutingAssembly());

#if DEBUG

            var devConfig = configuration.GetSection(nameof(DevConfig))
               .Get<DevConfig>();

            Console.WriteLine(
                "!!! Due to using MockService, Remove following services..."
            );

            @this
               .ToList()
               .GroupBy(x => x.ServiceType.Name)
               .ForEach(
                    (group, index) =>
                    {
                        var mockConfig = devConfig.MockServices.FirstOrDefault(x => x.InterfaceTypeName == group.Key);

                        if (null == mockConfig)
                        {
                            return;
                        }

                        if (mockConfig.Enable)
                        {
                            Console.WriteLine($"[{index + 1:d3}] Service Type [{group.Key}]");

                            group
                               .Where(e => !e.ImplementationType.Name.StartsWith("Mock"))
                               .ForEach(
                                    (sd, c) =>
                                    {
                                        Console.WriteLine($"\t({c + 1:d3})  {sd?.ImplementationType?.Name}");
                                        @this.Remove(sd);
                                    }
                                );
                        }
                        else
                        {
                            group
                               .Where(e => e.ImplementationType.Name.StartsWith("Mock"))
                               .ForEach(
                                    (sd, c) => { @this.Remove(sd); }
                                );
                        }
                    }
                );
#endif

            return @this;
        }
    }
}
