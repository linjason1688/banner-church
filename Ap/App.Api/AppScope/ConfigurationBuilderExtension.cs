using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace App.Api.AppScope
{
    /// <summary>
    /// </summary>
    public static class ConfigurationBuilderExtension
    {
        public static void ConfigJsonFileProvider(this IConfigurationBuilder @this, IHostEnvironment env)
        {
            @this.AddEnvironmentVariables();

            var includingConfigNames = new List<string>()
            {
                "logger",
                "sql",
                "job",
                "devSupports"
            };

            // default
            @this.AddJsonFile("appsettings.json", false, true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

            includingConfigNames.ForEach(
                name =>
                {
                    // default required & optional by env 
                    @this.AddJsonFile($"appsettings-{name}.json", true, true)
                       .AddJsonFile($"appsettings-{name}.{env.EnvironmentName}.json", true, true);
                }
            );
        }
    }
}
