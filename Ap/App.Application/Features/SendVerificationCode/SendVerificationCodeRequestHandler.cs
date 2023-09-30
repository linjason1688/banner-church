using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using App.Application.Features.SendVerificationCode;
using App.Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.ResetPassword
{
    public class SendVerificationCodeHandler : IRequestHandler<SendVerificationCodeRequest, SendVerificationCodeResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly AccountVerifyService accountVerifyService;

        public SendVerificationCodeHandler(
            IAppDbContext appDbContext,
            ILogger<FindAccountCommandRequestHandler> logger,
            IMapper mapper,
            IMediator mediator,
            AccountVerifyService accountVerifyService 
        )
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.mediator = mediator;
            this.accountVerifyService = accountVerifyService;
        }

        public async Task<SendVerificationCodeResponse> Handle(SendVerificationCodeRequest request, CancellationToken cancellationToken)
        {
            //FIXME 檢核帳號是否存在 Email or Cellphone

            var verification = await accountVerifyService.CreateVerification(request.Account, cancellationToken);
            
            //FIXME 依 SMS or Email 發送通知
            return new SendVerificationCodeResponse
            {
#if DEBUG
                Token = verification.Token
#else
                Token = request.Account
#endif
            };
        }
    }
}
