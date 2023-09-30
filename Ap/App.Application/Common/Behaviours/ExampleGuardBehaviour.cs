using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces.Services;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace App.Application.Common.Behaviours
{
    /// <summary>
    /// example guard
    /// </summary>
    public class ExampleGuardBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IClientInfoService clientInfoService;
        private readonly ILogger<TRequest> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientInfoService"></param>
        public ExampleGuardBehaviour(
            ILogger<TRequest> logger,
            IClientInfoService clientInfoService
        )
        {
            this.logger = logger;
            this.clientInfoService = clientInfoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var attr = typeof(TRequest).GetCustomAttribute<LocalizedConstraintAttribute>();

            if (null == attr)
            {
                return Task.CompletedTask;
            }

            var ci = this.clientInfoService.ClientInfo;

            if (ci == null || string.IsNullOrEmpty(ci.ExampleHeaderKeyX))
            {
                // throw new MyBusinessException("header 缺少 ExampleHeaderKeyX");
            }

            return Task.CompletedTask;
        }
    }
}
