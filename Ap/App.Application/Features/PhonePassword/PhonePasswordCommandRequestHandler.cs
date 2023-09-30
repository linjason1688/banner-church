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

namespace App.Application.Features.PhonePassword
{
    public sealed class PhonePasswordCommandRequestHandler : IRequestHandler<PhonePasswordCommand, PhonePasswordResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<PhonePasswordCommandRequestHandler> logger;
        private readonly ICrypto crypto;
        public PhonePasswordCommandRequestHandler(
            IAppDbContext appDbContext,
            ILogger<PhonePasswordCommandRequestHandler> logger
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
            this.crypto = AesCrypto.Instance;
        }

        public async Task<PhonePasswordResponse> Handle(PhonePasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.Phone.First() == '+')
            {
                request.Phone = request.Phone.Substring(1);
            }
            else if (request.Phone.First() == '0')
            {
                request.Phone = "886" + request.Phone.Substring(1);
            }

            var user = await this.appDbContext.Users
                                 .WhereWhen(!string.IsNullOrEmpty(request.Phone),
                                             e => e.CellPhone == request.Phone || 
                                                  e.CellAreaCode1 + e.CellPhone1 == request.Phone || 
                                                  e.CellAreaCode2 + e.CellPhone2 == request.Phone)
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


            return new PhonePasswordResponse()
            {
                Account = user?.UserNo,
                Name = user?.Name,
                Phone = user != null ? request.Phone : null,
                Password = pw
                
            };
        }
    }
}
