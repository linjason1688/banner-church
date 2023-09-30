using System;
using System.Collections.Generic;
using System.IO;
using App.Api.AppScope;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable(
                "MyAppRoot",
                AppDomain.CurrentDomain.BaseDirectory
            );

            PrepareFolders();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration(
                    (hostingContext, config) =>
                    {
                        config.ConfigJsonFileProvider(hostingContext.HostingEnvironment);

                        config.AddCommandLine(args);
                    }
                )
               .UseSerilog(
                    (hostingContext, loggerConfiguration) =>
                    {
                        loggerConfiguration
                           .ReadFrom.Configuration(hostingContext.Configuration)
                           .Enrich.WithMachineName();

                        // .Enrich.With<CallerEnricher>();
                    }
                )
               .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder

                            // .UseKestrel(options =>
                            //  {
                            //      //
                            //      options.AllowSynchronousIO = true;
                            //  })
                           .UseIISIntegration()
                           .ConfigureKestrel(
                                (context, options) =>
                                {
                                    // max to 256 MB
                                    options.Limits.MaxRequestBodySize = 1024 * 1024 * 256;
                                    options.AddServerHeader = false;
                                }
                            )
                           .CaptureStartupErrors(true)
                           .UseStartup<Startup>();
                    }
                );
        }

        public static void PrepareFolders()
        {
            var contentRoot = Directory.GetCurrentDirectory();

            var folders = new List<string>()
            {
                Path.Combine(contentRoot, "Logs"),
                Path.Combine(contentRoot, "Resources")
            };

            folders.ForEach(
                f =>
                {
                    if (!Directory.Exists(f))
                    {
                        Directory.CreateDirectory(f);
                    }
                }
            );
        }
    }
}
