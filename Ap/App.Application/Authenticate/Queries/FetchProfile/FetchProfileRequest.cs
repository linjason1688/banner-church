#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Authenticate.Dtos;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Authenticate.Queries.FetchProfile
{
    /// <summary>
    /// </summary>
    public class FetchProfileRequest
        : IRequest<UserProfile>
    {
    }

    /// <summary>
    /// </summary>
    public class FetchProfileRequestHandler
        : IRequestHandler<FetchProfileRequest, UserProfile>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        /// <summary>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="appDbContext"></param>
        /// <param name="authService"></param>
        public FetchProfileRequestHandler(
            ILogger<FetchProfileRequestHandler> logger,
            IMapper mapper,
            IAppDbContext appDbContext,
            IAuthService authService
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.authService = authService;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UserProfile> Handle(
            FetchProfileRequest request,
            CancellationToken cancellationToken
        )
        {
            return Task.FromResult(
                this.mapper.Map<UserProfile>(this.authService.Identity)
            );
        }
    }
}
