#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PoorMansTSqlFormatterRedux;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting;
using Yozian.Extension;

#endregion

namespace App.Infrastructure.Persistence.Plugins.SqlLog
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbContextOptionsBuilderExtension
    {
        /**
         * factory to reuse (prevent multiple log files...)
         */
        private static readonly Dictionary<string, LoggerFactory> LoggerFactories = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        public static void AddSqlCmdLogger(this DbContextOptionsBuilder @this)
        {
            var contextName = @this.Options.ContextType.Name.Replace("DbContext", "");

            if (LoggerFactories.ContainsKey(contextName))
            {
                @this.UseLoggerFactory(LoggerFactories.SafeGet(contextName));

                return;
            }

            var ignoreTables = GetIgnoreEntities(@this.Options.ContextType);
            var loggerFactory = new LoggerFactory();

            var loggerConfig = new LoggerConfiguration()
               .WriteTo
               .File(
                    new SqlCommandFormatter(ignoreTables),
                    Path.Combine(
                        Directory
                           .GetCurrentDirectory(),
                        $"Logs/SqlCommands/{contextName}-Executed-Cmd-.log"
                    ),
                    LogEventLevel.Debug,
                    rollingInterval: RollingInterval.Hour
                )
               .Filter
               .ByIncludingOnly(
                    e =>
                    {
                        if (!e.Properties.TryGetValue("EventId", out var sqlEvent))
                        {
                            return false;
                        }

                        try
                        {
                            var evt = JObject.Parse(sqlEvent.ToString());

                            var name = (evt.GetValue("Name") ?? "").Value<string>();

                            return name.StartsWith("Microsoft.EntityFrameworkCore.Database.Command");
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                );

            var logger = loggerConfig.CreateLogger();

            var serilogProvider = new SerilogLoggerProvider(logger);

            loggerFactory.AddProvider(serilogProvider);

            if (!LoggerFactories.ContainsKey(contextName))
            {
                LoggerFactories.Add(contextName, loggerFactory);
            }
            else
            {
                loggerFactory = LoggerFactories.SafeGet(contextName);
            }

            @this.UseLoggerFactory(loggerFactory);
        }

        private static List<string> GetIgnoreEntities(Type contextType)
        {
            return contextType.GetProperties()
               .Where(
                    e =>
                    {
                        var pt = e.PropertyType;

                        if (!pt.IsGenericType)
                        {
                            return false;
                        }

                        var genericType = pt.GetGenericTypeDefinition();

                        var isDbSet = genericType == typeof(DbSet<>);

                        if (!isDbSet)
                        {
                            return false;
                        }

                        var entityType = e.PropertyType.GenericTypeArguments.FirstOrDefault();

                        if (null == entityType)
                        {
                            return false;
                        }

                        return typeof(ILogEntity).IsAssignableFrom(entityType);
                    }
                )
               .Select(e => e.PropertyType.GenericTypeArguments.First().Name)
               .ToList();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SqlCommandFormatter : ITextFormatter
    {
        private readonly List<string> ignoreTables;

        private static readonly Regex doubleQuotesRegex = new Regex("^\"|\"$");

        /// <summary>
        /// 
        /// </summary>
        public SqlCommandFormatter(List<string> ignoreTables)
        {
            this.ignoreTables = ignoreTables;
        }

        /// <inheritdoc />
        public void Format(LogEvent logEvent, TextWriter output)
        {
            try
            {
                if (!logEvent.Properties.ContainsKey("commandText"))
                {
                    return;
                }

                var key = "commandText";

                var cmd = logEvent.Properties.First(p => p.Key.Equals(key));

                var cmdText = doubleQuotesRegex.Replace(cmd.Value.ToString(), "");
#if DEBUG

                // 開發期間對 ignore insert 操作
                if (cmdText.Contains("INSERT INTO") || cmdText.Contains("MERGE"))
                {
                    return;
                }
#endif
                if (this.ignoreTables.Any(x => cmdText.Contains($"INSERT INTO [{x}]")))
                {
                    return;
                }

#if DEBUG
                var formatted = SqlFormattingManager.DefaultFormat(cmdText);
#else
                    var formatted = cmdText;
#endif

                // logEvent.AddOrUpdateProperty(new LogEventProperty(key, new ScalarValue(formatted)));

                output.WriteLine($"{DateTime.Now:HH:mm:ss.fff} ({Environment.MachineName}) [{logEvent.Level}]:");
                logEvent.Properties
                   .Where(p => "elapsed,parameters,commandTimeout".Contains(p.Key))
                   .ForEach(
                        p =>
                        {
                            output.Write(p.Key + ": ");
                            output.WriteLine(doubleQuotesRegex.Replace(p.Value.ToString(), ""));
                        }
                    );

                output.WriteLine(formatted);
                output.WriteLine(string.Empty);
            }
            catch (Exception ex)
            {
                // do nothing
                Debug.Print(ex.Message);
            }
        }
    }
}
