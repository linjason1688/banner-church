using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Exceptions;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using App.Application.Features.SendVerificationCode;
using App.Application.Services;
using App.Utility.Cryptos;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension;

namespace App.Application.Features.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordCommandResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly AccountVerifyService accountVerifyService;
        private readonly ICrypto crypto;

        public ResetPasswordCommandHandler(
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
            this.crypto = AesCrypto.Instance;
        }

        public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            //this.accountVerifyService.Verify(request.account, request.Token);
            var user = await this.appDbContext.Users.
                WhereWhen(request.ResetType == PasswordResetType.Email, e => e.Email1 == request.Email1)
               .WhereWhen(request.ResetType == PasswordResetType.Sms, e => e.CellPhone == request.CellPhone)
               .FindOneAsync(cancellationToken);

            //FIXME 修改 user 密碼
            if (user == null)
            {
                if (!string.IsNullOrEmpty(request.Email1))
                {
                    throw new MyBusinessException("查無此電子郵件對應帳號");
                }
                else
                {
                    throw new MyBusinessException("查無此手機號碼對應帳號");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(request.Password) && string.IsNullOrEmpty(request.OldPassword))
                {
                    throw new MyBusinessException("新密碼和舊密碼不能為空!");
                }
                var salt = this.crypto.Decrypt(user.PasswordSalt);
                var oldPW = this.crypto.EncodePassword(request.OldPassword, salt);
                if (oldPW != user.Password)
                {
                    throw new MyBusinessException("舊密碼輸入錯誤，請再確認!");
                }
                
                user.Password = this.crypto.EncodePassword(request.Password, salt);
                var count = await this.appDbContext.SaveChangesAsync(cancellationToken);
                if (count <= 0)
                {
                    throw new MyBusinessException("修改密碼保存失敗，請聯繫管理員！");
                }

                
                //string resetToken = await UserManager.GeneratePasswordResetTokenAsync(model.Id);
                //IdentityResult passwordChangeResult = await UserManager.ResetPasswordAsync(model.Id, resetToken, model.NewPassword);
            }


            return new ResetPasswordCommandResponse
            {
                Result = true
            };
        }
    }
}
