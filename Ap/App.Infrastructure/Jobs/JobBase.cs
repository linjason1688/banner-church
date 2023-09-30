#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using App.Application.Common.Configs;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services.Core;
using App.Infrastructure.Jobs.Core;
using Microsoft.Extensions.Logging;
using Quartz;

#endregion

namespace App.Infrastructure.Jobs
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class JobBase
    {
        private readonly IHandleErrorService handleErrorService;
        private readonly ILogger logger;

        private readonly string IgnoreJobTypes = string.Join(
            ",",
            new List<string>()
            {
                nameof(ApiAuditLogJob),
                nameof(ExceptionLogJob)
            }
        );

        private readonly string typeName;

        /// <summary>
        /// 
        /// </summary>
        public abstract JobConfig JobConfig { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Order { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="handleErrorService"></param>
        protected JobBase(
            ILogger logger,
            IHandleErrorService handleErrorService
        )
        {
            this.typeName = this.GetType().Name;
            this.logger = logger;
            this.handleErrorService = handleErrorService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public virtual async Task Execute(IJobExecutionContext context)
        {
            await this.SafeExecute(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private async Task SafeExecute(IJobExecutionContext context)
        {
            try
            {
                var name = $"{this.typeName} ({this.JobConfig.Name})";

                var watch = new Stopwatch();

                watch.Start();

                this.Debug("Job Start: [{@Name}]", name);

                await this.DoWork();

                watch.Stop();

                this.Debug(
                    "Job Completed: [{@Name}], Time Elapsed: {@TotalMilliseconds} (ms)",
                    name,
                    watch.Elapsed.TotalMilliseconds.ToString("F1")
                );

                if (context.NextFireTimeUtc.HasValue)
                {
                    var nextTime = context.NextFireTimeUtc.Value.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    this.Debug("Job [{@Name}] next execution at {@NextTime}", name, nextTime);
                }
            }
            catch (MyBusinessException bex)
            {
                // do nothing
                this.logger.LogWarning("{@Message}", bex.Message);
            }
            catch (Exception ex)
            {
                var id = Guid.NewGuid();
                this.logger.LogWarning("Job Error: [{@Name}] ({@Id})", this.JobConfig.Name, id.ToString());
                await this.handleErrorService.HandleErrorAsync(ex);
            }
        }


        private void Debug(string message, params string[] arguments)
        {
            if (this.IgnoreJobTypes.Contains(this.typeName))
            {
                return;
            }

            this.logger.LogDebug(message, arguments);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract Task DoWork();
    }
}
