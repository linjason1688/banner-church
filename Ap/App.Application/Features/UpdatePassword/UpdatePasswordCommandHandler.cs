using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Exceptions;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using App.Application.Services;
using App.Utility.Cryptos;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, UpdatePasswordCommandResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private readonly AccountVerifyService accountVerifyService;
        private readonly ICrypto crypto;

        public UpdatePasswordCommandHandler(
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

        public async Task<UpdatePasswordCommandResponse> Handle(
            UpdatePasswordCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await this.appDbContext.Users
               .Where(c => c.Id == request.UserId)
               .FindOneAsync(cancellationToken);

            if (user == null)
            {
                throw new MyBusinessException("查無此帳號");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                throw new MyBusinessException("新密碼不能為空!");
            }

            var salt = this.crypto.Decrypt(user.PasswordSalt);
            var oldPw = user.Password;

            user.Password = this.crypto.EncodePassword(request.Password, salt);

            if (oldPw == user.Password)
            {
                throw new MyBusinessException("新密碼和舊密碼不能相同!");
            }

            var count = await this.appDbContext.SaveChangesAsync(cancellationToken);

            if (count <= 0)
            {
                throw new MyBusinessException("修改密碼保存失敗，請聯繫管理員！");
            }

            return new UpdatePasswordCommandResponse
            {
                Result = true
            };
        }
    }
}
