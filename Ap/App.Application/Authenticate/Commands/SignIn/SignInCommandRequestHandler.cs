using System.Threading;
using System.Threading.Tasks;
using App.Application.Authenticate.Dtos;
using App.Application.Common.Dtos;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Common.Interfaces.Services.Core;
using App.Utility.Cryptos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Application.Authenticate.Commands.SignIn
{
    /// <summary>
    /// </summary>
    public class SignInCommandRequestHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IAuthService authService;
        private readonly IClientInfoService clientInfoService;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IVerifyService verifyService;
        private readonly ISignInService signInService;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly ICrypto crypto;

        /// <summary>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="appDbContext"></param>
        /// <param name="authService"></param>
        public SignInCommandRequestHandler(
            ILogger<SignInCommandRequestHandler> logger,
            IMapper mapper,
            IAppDbContext appDbContext,
            IAuthService authService,
            IVerifyService verifyService,
            IClientInfoService clientInfoService,
            ISignInService signInService
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.appDbContext = appDbContext;
            this.authService = authService;
            this.verifyService = verifyService;
            this.clientInfoService = clientInfoService;
            this.signInService = signInService;
            this.crypto = AesCrypto.Instance;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SignInResponse> Handle(
            SignInCommand request,
            CancellationToken cancellationToken
        )
        {
            //FIXME: 先不驗證 Code
            this.verifyService.Verify(request.VerificationCode, request.VerificationToken);
            var signIn = this.mapper.Map<Common.Dtos.Services.SignIn>(request);
            var signInResult = await this.signInService.SignInAsync(signIn, cancellationToken);
            var identity = new UserIdentity();

            // TODO: 補上 account,roles,isAdmin等相關眝位

            



            var aspnetUser = await this.appDbContext.AspnetUsers.FirstOrDefaultAsync(
                e => e.UserName == request.Account,
                cancellationToken
            );
            //20230418 登入=>可用_帳號跟身分證字號登入 #136
            var user = await this.appDbContext.Users.FirstOrDefaultAsync(
                e => e.UserNo == request.Account
                    //|| e.Name == request.Account
                    //|| e.Email1 == request.Account
                    //|| e.Email2 == request.Account
                    || e.IdNumber == request.Account,
                    //|| e.CellPhone == request.Account
                    //|| e.CellPhone1 == request.Account
                    //|| e.CellPhone2 == request.Account,
                cancellationToken
            );


            if (user == null && aspnetUser == null)
            {
                throw new MyBusinessException("帳號密碼不存在");
            }
            else
            {
                identity.PastoralId = user.PastoralId;
                
            }

            //Check request password
            var salt = this.crypto.Decrypt(user.PasswordSalt);
            var password = this.crypto.EncodePassword(request.Password, salt);

            if (user.Password != password)
            {
                throw new MyBusinessException("帳號密碼不存在");
            }

            identity.Account = user.UserNo;
            var jwt = await this.authService.GenerateJwtAsync(identity, cancellationToken);
            
            return new SignInResponse
            {
                Jwt = jwt,
                User = this.mapper.Map<UserProfile>(user)
            };
        }
    }
}
