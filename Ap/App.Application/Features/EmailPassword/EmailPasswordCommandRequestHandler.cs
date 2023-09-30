using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using App.Utility.Cryptos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;

namespace App.Application.Features.EmailPassword
{
    public sealed class EmailPasswordCommandRequestHandler : IRequestHandler<EmailPasswordCommand, EmailPasswordResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<EmailPasswordCommandRequestHandler> logger;
        private readonly ICrypto crypto;
        public EmailPasswordCommandRequestHandler(
            IAppDbContext appDbContext,
            ILogger<EmailPasswordCommandRequestHandler> logger
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
            this.crypto = AesCrypto.Instance;
        }

        public async Task<EmailPasswordResponse> Handle(EmailPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await this.appDbContext.Users
                                 .WhereWhen(!string.IsNullOrEmpty(request.Email),
                                             e => e.Email1 == request.Email || e.Email2 == request.Email)
                                 .FirstOrDefaultAsync(cancellationToken);
            var pw = "";
            if (user != null)
            {
                var salt = this.crypto.Decrypt(user.PasswordSalt);
                int seek = unchecked((int) DateTime.Now.Ticks);
                var rand = new Random(seek);
                pw = rand.Next(100000, 1000000).ToString();
                user.Password = this.crypto.EncodePassword(pw, salt);
                await this.appDbContext.SaveChangesAsync(cancellationToken);
            }


            return new EmailPasswordResponse()
            {
                Account = user?.UserNo,
                Name = user?.Name,
                Email = user != null ? request.Email : null,
                Password = pw
                
            };
        }
    }
}
