using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using App.Utility;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Common.Behaviours
{
    /// <summary>
    /// 
    /// </summary>
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private const int THRESHOLD_MILLISECONDS = 3000;
        private readonly ILogger<TRequest> logger;
        private readonly Stopwatch timer;

        /// <summary>
        /// 
        /// </summary>
        public PerformanceBehaviour(
            ILogger<TRequest> logger
        )
        {
            this.timer = new Stopwatch();

            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            var result = await PerformanceUtility.ExecuteAsync(
                async () => await next()
            );

            var response = result.Data;

            var elapsedMilliseconds = result.ElapsedMilliseconds;

            if (elapsedMilliseconds <= THRESHOLD_MILLISECONDS)
            {
                return response;
            }

            var requestName = typeof(TRequest).Name;

            this.logger.LogWarning(
                "MR-Handler: {Name} [{ElapsedMilliseconds:F3} (ms)] {@Request}",
                requestName,
                elapsedMilliseconds,
                request
            );

            return response;
        }
    }
}
