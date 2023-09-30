using System;
using App.Application.Common.Configs;
using App.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Impl
{
    /// <summary>
    /// </summary>
    [ScopedService(typeof(IAppConfiguration))]
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfiguration configuration;

        public AppConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public AppConfig AppConfig => this.getConfig<AppConfig>();

        public SqlConfig SqlConfig => this.getConfig<SqlConfig>();


        public DevConfig DevConfig => this.getConfig<DevConfig>();

        public ScheduleJobsConfig ScheduleJobsConfig => this.getConfig<ScheduleJobsConfig>();

        private T getConfig<T>()
        {
            var section = typeof(T).Name;

            var config = this.configuration.GetSection(section).Get<T>();

            if (config is null)
            {
                throw new Exception($"Missing configuration section of [{typeof(T).Name}] !!");
            }

            return config;
        }
    }
}
