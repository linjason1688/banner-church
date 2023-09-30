using System;
using System.Diagnostics;
using App.Api.AppScope;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Health;
using App.Api.AppScope.Middlewares;
using App.Api.AppScope.Swaggers;
using App.Application;
using App.Infrastructure;
using App.Utility.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace App.Api
{
    /// <summary>
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }

        /// <summary>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(this.Configuration);

            services.AddApplication();

            services.AddMemoryCache();

            services.Configure<FormOptions>(
                x =>
                {
                    // MAX TO 30 MB
                    var maxLimit = 1024 * 1024 * 30;
                    x.ValueLengthLimit = maxLimit;
                    x.MultipartBodyLengthLimit = maxLimit * 10; // In case of multipart
                    x.MultipartHeadersLengthLimit = maxLimit;
                }
            );

            services.AddHttpContextAccessor();

            //
            services.AddRouting(
                options =>
                {
                    // we ignore the lowercaseUrls, we transform in swagger filter
                    // options.LowercaseUrls = true;
                }
            );

            services.Configure<ApiBehaviorOptions>(
                options => { options.SuppressModelStateInvalidFilter = true; }
            );

            services.AddControllersWithViews(
                    mvcOptions =>
                    {
                        // global filer
                        mvcOptions.Filters.Add<HandleApiErrorFilter>();

                        // mvcOptions.Filters.Add<ApiKeyAuthAttribute>();
                        mvcOptions.Filters.Add<ApiModelValidGuard>();

                        mvcOptions.Conventions.Add(new SwaggerDefinitionConvention());
                    }
                )

                // should install nuget libs
                // .AddRazorRuntimeCompilation()
               .ConfigureApiBehaviorOptions(
                    options => { options.SuppressModelStateInvalidFilter = true; }
                )
               .AddNewtonsoftJson(
                    options =>
                    {
#if DEBUG // just for developing use
                        options.SerializerSettings.Error += (sender, error) =>
                        {
                            Debug.WriteLine(error.ErrorContext.Error.Message);
                        };
#endif
                        options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

#if DEBUG
                        options.SerializerSettings.Formatting = Formatting.Indented;
#else
                        // for better performance
                        options.SerializerSettings.Formatting = Formatting.None;
#endif

                        options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
                        options.SerializerSettings.ContractResolver = new MyCamelCaseResolver();
                        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

                        // add additional converters
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    }
                );

            services.RegisterSwagger();

            services.AddMyHealthChecks();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="logger"></param>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILogger<Startup> logger
        )
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOptions();

            app.PrintRuntimeInformation();

            app.UseStaticFiles();

            app.ConfigureSwagger(logger);

            app.UseMyMiddlewares();

            app.UseRouting();

            app.UseForwardedHeaders(
                new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor
                        | ForwardedHeaders.XForwardedProto
                        | ForwardedHeaders.XForwardedHost
                }
            );

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        "default",
                        "{controller=Home}/{action=Index}/{id?}"
                    );
                }
            );

            app.UseHealthCheck("/health");

            // do some init checks
            app.CheckSqlStatus();

            app.ConfigSpaHost(env, "app-web-client");

            logger.LogInformation("Is64BitProcess: {@Is64BitProcess}", Environment.Is64BitProcess);

            app.RunOneTimeSetups();

            app.ExecuteDevSupports();

            app.InitScheduleJobs();

            logger.LogInformation("API is ready to rock !");
        }
    }
}
