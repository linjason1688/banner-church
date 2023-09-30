#region

using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using App.Application.Common.Exceptions;
using App.Infrastructure;
using App.Infrastructure.DevSupports;
using App.Infrastructure.Jobs;
using App.Infrastructure.Persistence;
using App.Infrastructure.Services.Impl;
using App.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Api.AppScope
{
    /// <summary>
    /// init or some configurations
    /// </summary>
    public static class IAppExtension
    {
        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        public static void PrintRuntimeInformation(this IApplicationBuilder @this)
        {
            var env = @this.ApplicationServices.GetService<IWebHostEnvironment>();
            var logger = @this.ApplicationServices.CreateLogger<Startup>();

            logger.LogInformation("Running in Env: [{@EnvironmentName}]", env!.EnvironmentName);

            logger.LogInformation("=============git commit: {@Commit} ", BuildVersion.Version);

            var address = @this.ServerFeatures.Get<IServerAddressesFeature>();

            logger.LogInformation("url: {@Addresses}", string.Join(" , ", address.Addresses));

#if DEBUG
            logger.LogWarning(
                "**ATTENTION** Api is built with **DEBUG** mode, plz use **RELEASE* for production environment!"
            );
#endif
        }


        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder @this, string path)
        {
            @this.UseHealthChecks(
                path,
                new HealthCheckOptions
                {
                    AllowCachingResponses = false,
                    ResponseWriter = async (context, report) =>
                    {
                        var result = new
                        {
                            State = report.Status.ToString(),
                            report.Entries
                        };

                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(Serialization.Serialize(result));
                    }
                }
            );

            return @this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="MyBusinessException"></exception>
        public static IApplicationBuilder CheckSqlStatus(this IApplicationBuilder @this)
        {
            @this.ExecuteWithScope(
                    scope =>
                    {
                        var logger = scope.ServiceProvider.CreateLogger<Startup>();
                        logger.LogInformation("Start to Validate SQL Connection");

                        var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

                        if (null == dbContext)
                        {
                            throw new MyBusinessException($"di failed for {nameof(AppDbContext)}");
                        }

                        try
                        {
                            if (dbContext.Database.IsInMemory())
                            {
                                logger.LogWarning("Current using In-Memory SQL !!");

                                return Task.CompletedTask;
                            }

                            dbContext.Database.ExecuteSqlRaw("SELECT 1");

                            logger.LogInformation("Validate SQL Connection Pass!");
                        }
                        catch (Exception ex)
                        {
                            logger.LogCritical(ex, "SQL Server is unavailable!");
                        }

                        return Task.CompletedTask;
                    }
                )
               .GetAwaiter()
               .GetResult();

            return @this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IApplicationBuilder InitScheduleJobs(this IApplicationBuilder @this)
        {
            var quartzManageService = @this.ApplicationServices.GetService<QuartzManageService>();

            return @this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IApplicationBuilder RunOneTimeSetups(this IApplicationBuilder @this)
        {
            using var scope = @this.ApplicationServices.CreateScope();

            var service = scope.ServiceProvider.GetService<AppSetupService>();

            try
            {
                service.InitAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.CreateLogger<Startup>();

                logger.LogWarning(ex, "RunOneTimeSetups failed");
            }

            return @this;
        }

        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="env"></param>
        /// <param name="folderName">於 wwwroot 底下 之 folder name</param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigSpaHost(
            this IApplicationBuilder @this,
            IWebHostEnvironment env,
            string folderName,
            int port = 8080
        )
        {
            var logger = @this.ApplicationServices.CreateLogger<Startup>();

            var spaFolderPath = Path.Combine(env.ContentRootPath, "wwwroot", folderName);

            if (env.IsDevelopment())
            {
                logger.LogInformation("Spa proxy to dev server!");

                @this.UseSpa(
                    spa =>
                    {
#if DEBUG
                        spa.UseProxyToSpaDevelopmentServer($"http://localhost:{port}");
#endif
                    }
                );

                return @this;
            }

            logger.LogInformation("Host spa files at: {@SpaFolderPath}", spaFolderPath);

            if (!Directory.Exists(spaFolderPath))
            {
                logger.LogWarning("Spa folder does NOT exits, system will auto create one!");
                Directory.CreateDirectory(spaFolderPath);
            }

            @this.UseSpaStaticFiles(
                new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(spaFolderPath)
                }
            );

            @this.UseSpa(
                spa =>
                {
                    // put compiled out in wwwroot
                    spa.Options.DefaultPage = "/index.html";

                    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions()
                    {
                        FileProvider = new PhysicalFileProvider(spaFolderPath)
                    };
                }
            );

            return @this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        public static void ExecuteDevSupports(this IApplicationBuilder @this)
        {
            using var scope = @this.ApplicationServices.CreateScope();

            var fixtureManager = scope.ServiceProvider.GetService<DevSupportManager>();

            fixtureManager?.ProcessFixturesAsync()
               .ConfigureAwait(true)
               .GetAwaiter()
               .GetResult();
        }

        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="executor"></param>
        /// <returns></returns>
        public static Task ExecuteWithScope(this IApplicationBuilder @this, Func<IServiceScope, Task> executor)
        {
            using var scope = @this.ApplicationServices.CreateScope();

            return executor(scope);
        }
    }
}
