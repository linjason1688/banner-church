using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;

namespace App.Application.Features.PhoneAccount
{
    public sealed class PhoneAccountCommandRequestHandler : IRequestHandler<PhoneAccountCommand, PhoneAccountResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindAccountCommandRequestHandler> logger;

        public PhoneAccountCommandRequestHandler(
            IAppDbContext appDbContext,
            ILogger<FindAccountCommandRequestHandler> logger
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }

        public async Task<PhoneAccountResponse> Handle(PhoneAccountCommand request, CancellationToken cancellationToken)
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

            return new PhoneAccountResponse()
            {
                Account = user?.UserNo,
                Name = user?.Name,
                Phone = user != null ? request.Phone : null
            };
        }
    }
}
