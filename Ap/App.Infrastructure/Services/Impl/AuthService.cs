using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Dtos.Services;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Infrastructure.Dtos.Services;
using Azure.Core;
using Microsoft.Extensions.Logging;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService(typeof(IAuthService))]
    public class AuthService : IAuthService
    {
#if DEBUG
        private const int RefreshTokenMinutes = 600;
#else
        // prod 低於 10min 過期時，則重發
        private const int RefreshTokenMinutes = 60;
#endif

        private readonly IClientInfoService clientInfoService;
        private readonly IAppConfiguration configuration;
        private readonly IDateTime dateTime;
        private readonly IJwtManager<IdentityJwtPayload> jwtManager;
        private readonly ILogger<AuthService> logger;
        private readonly IAppDbContext appDbContext;
        //private readonly ILogger<FindAccountCommandRequestHandler> logger;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jwtManager"></param>
        /// <param name="configuration"></param>
        /// <param name="clientInfoService"></param>
        /// <param name="dateTime"></param>
        public AuthService(
            ILogger<AuthService> logger,
            IJwtManager<IdentityJwtPayload> jwtManager,
            IAppConfiguration configuration,
            IClientInfoService clientInfoService,
            IDateTime dateTime
        )
        {
            this.logger = logger;
            this.jwtManager = jwtManager;
            this.configuration = configuration;
            this.clientInfoService = clientInfoService;
            this.dateTime = dateTime;
            this.appDbContext = appDbContext;
        }

        /// <inheritdoc />
        public bool IsPrivilegeFree => true;

        // TODO: change logic here
        /// <inheritdoc />
        public bool Authorized => string.IsNullOrEmpty(this.Identity?.Account);

        /// <inheritdoc />
        public UserIdentity Identity { get; private set; }

        /// <inheritdoc />
        public Task<SignInResult> SignInAsync(
            SignIn sign,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            // TODO: implement signIn process
            //在這邊加上查 Memebership User MOD_MEMBER, 然後把資訊填到 SignInResult
            var SignInResults = new SignInResult();

            //SignInResults=

            var membership =
                this.appDbContext.ModMembers;
            /*      .Where(m => string.IsNullOrWhiteSpace(m.Identifier.ToString()) ==this.Identity.Account.ToString())
                  .FirstOrDefaultAsync(cancellationToken: cancellationToken);*/
            if (membership != null)
            {
                //SignInResults.Account = membership[0].Account;
                //SignInResults.Name = membership.Name;
            }
            

            return Task.FromResult(SignInResults);
        }


        /// <inheritdoc />
        public Task ValidateSessionAsync(ValidateSessionRequest request)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<string> GenerateJwtAsync(
            UserIdentity identity = null,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            if (null != identity)
            {
                this.Identity = identity;
            }

            this.Identity.Version = UserIdentity.IVersion;

            var payLoad = new IdentityJwtPayload()
            {
                User = this.Identity,
            };

            payLoad.SetExpiredAt(DateTime.Now.AddMinutes(RefreshTokenMinutes));

            return this.jwtManager.EncodeAsync(payLoad, cancellationToken);
        }

        // TODO: 
        /// <inheritdoc />
        public async Task<RetrieveProfileState> RetrievingProfileOfJwtAsync(
            string jwt,
            CancellationToken cancellationToken
        )
        {
            var payload = await this.jwtManager.DecodeAsync(jwt, cancellationToken: cancellationToken);
            this.Identity = payload.User;

            if (this.Identity.Version != UserIdentity.IVersion)
            {
                throw new MyBusinessException(ResponseCodes.IdentityUnAuthorized, "Version Expired");
            }

            var ts = payload.ExpiredDateTimeAt - this.dateTime.Now;

            var state = new RetrieveProfileState
            {
                ReIssuedToken = ts.Minutes is > 0 and < RefreshTokenMinutes
            };

            if (state.ReIssuedToken)
            {
                state.JwtToken = await this.GenerateJwtAsync(this.Identity, cancellationToken);
            }

            return state;
        }

        /// <inheritdoc />
        public Task<bool> HasPrivilegeForAsync(string action, string controller)
        {
            return Task.FromResult(true);
        }
    }
}
