using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using App.Domain.Entities.Features;
using App.Utility.Cryptos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpCommandResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindAccountCommandRequestHandler> logger;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        private readonly ICrypto crypto;

        public SignUpCommandHandler(
            IAppDbContext appDbContext,
            ILogger<FindAccountCommandRequestHandler> logger,
            IMapper mapper,
            IMediator mediator
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
            this.mapper = mapper;
            this.mediator = mediator;
            this.crypto = AesCrypto.Instance;
        }

        public async Task<SignUpCommandResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            return await this.appDbContext.ExecuteTransactionAsync(async Task<SignUpCommandResponse> () =>
            {
                //暂时把IsOldMember条件留着
                if (!request.Id.HasValue)
                {
                    //新增逻辑
                    var entity = this.mapper.Map<User>(request);
                    entity.UserId = Guid.NewGuid().ToString().ToUpper();
                    var salt = this.crypto.GenerateSalt(12);
                    entity.PasswordSalt = this.crypto.Encrypt(salt);
                    entity.Password = string.IsNullOrEmpty(entity.Password) ? "123456" : entity.Password;
                    entity.Password = this.crypto.EncodePassword(entity.Password, salt);
                    await this.appDbContext.Users.AddAsync(entity);

                    var count = await this.appDbContext.SaveChangesAsync(cancellationToken);
                    if (count <= 0)
                    {
                        throw new MyBusinessException("保存失敗");
                    }
                }
                else
                {
                    //修改逻辑
                    //fix: 使用Id条件
                    var user = await this.appDbContext.Users.FirstOrDefaultAsync(c => c.Id == request.Id);
                    if (user == null)
                    {
                        throw new MyBusinessException($"用户Id:{request.Id} 不存在，無法寫入檔案！");
                    }
                    request.Password = user.Password;    //这里不能修改密码，把DB中的密码和令牌写到Request
                    request.PasswordSalt = user.PasswordSalt; //下在Mapping时，相当于不改密码和令牌

                    if (user != null)
                    {
                        //先删除明细表
                        this.appDbContext.UserFamilies.RemoveRange(
                            await this.appDbContext.UserFamilies.Where(c => c.UserId == user.Id).ToListAsync()
                        );
                        this.appDbContext.UserContacts.RemoveRange(
                            await this.appDbContext.UserContacts.Where(c => c.UserId == user.Id).ToListAsync()
                        );
                        this.appDbContext.UserExpertises.RemoveRange(
                            await this.appDbContext.UserExpertises.Where(c => c.UserId == user.Id).ToListAsync()
                        );
                        this.appDbContext.UserBankAccounts.RemoveRange(
                            await this.appDbContext.UserBankAccounts.Where(c => c.UserId == user.Id).ToListAsync()
                        );

                        this.appDbContext.UserSocieties.RemoveRange(
                          await this.appDbContext.UserSocieties.Where(c => c.UserId == user.Id).ToListAsync()
                      );
                    }

                    request.UserContacts.ForEach(c => c.Id = 0);
                    request.UserExpertises.ForEach(c => c.Id = 0);
                    request.UserFamilies.ForEach(c => c.Id = 0);
                    request.UserBankAccounts.ForEach(c => c.Id = 0);
                    request.UserSocieties.ForEach(c => c.Id = 0);

                    user = await this.appDbContext.Users.FirstOrDefaultAsync(c => c.Id == request.Id);
                    user = this.mapper.Map(request, user); //再Mapping输入的新明细与主表
                    //修改时，存在没有任何变量调整 EntityState.Unchanged，不去判定影响行数
                    await this.appDbContext.SaveChangesAsync(cancellationToken);

                }

                return new SignUpCommandResponse()
                {
                    Account = request.UserNo

                };
            });

            #region 原邏輯只有新增代碼
            //var entity = this.mapper.Map<User>(request);
            //await this.appDbContext.Users.AddAsync(entity, cancellationToken);
            //var user = await this.appDbContext.SaveChangesAsync(cancellationToken);

            //if (user <= 0)
            //{
            //    throw new MyBusinessException("新增失敗");
            //}

            //return new SignUpCommandResponse
            //{
            //    // FIXME: 未確定帳號取哪個欄位，先暫時抓 Identifier
            //    Account = entity?.Name
            //};
            #endregion
        }
    }
}
