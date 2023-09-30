using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Common.Behaviours
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly IClientInfoService clientInfoService;
        private readonly IDateTime dateTime;
        private readonly ILogger logger;

        /// <summary>
        /// 
        /// </summary>
        public LoggingBehaviour(
            ILogger<TRequest> logger,
            IAuthService authService,
            IClientInfoService clientInfoService,
            IAppDbContext appDbContext,
            IDateTime dateTime
        )
        {
            this.logger = logger;
            this.authService = authService;
            this.clientInfoService = clientInfoService;
            this.appDbContext = appDbContext;
            this.dateTime = dateTime;
        }


        /// <inheritdoc />
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            var requestName = typeof(TRequest).Name;
            var response = default(TResponse);

            var attr = request.GetType().GetCustomAttribute<MrLoggingAttribute>();

            try
            {
                response = await next();
            }
            finally
            {
                // check paging request or not
                if (null == attr)
                {
                    this.logger.LogDebug(
                        "MR-{Name} Input:\n  {@Request}\n Return:\n {@Response}",
                        requestName,
                        request,
                        response
                    );
                }
                else
                {
                    this.logger.LogDebug(
                        "MR-{Name} Input:\n  {@Request}\n Return:\n {@Response}",
                        requestName,
                        attr.IgnoreRequest ? "*Ignored*" : request,
                        attr.IgnoreResponse ? "*Ignored*" : response
                    );
                }
            }

            return response;
        }
    }
}
