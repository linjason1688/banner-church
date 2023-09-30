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

namespace App.Application.Features.EmailAccount
{
    public sealed class EmailAccountCommandRequestHandler : IRequestHandler<EmailAccountCommand, EmailAccountResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindAccountCommandRequestHandler> logger;

        public EmailAccountCommandRequestHandler(
            IAppDbContext appDbContext,
            ILogger<FindAccountCommandRequestHandler> logger
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }

        public async Task<EmailAccountResponse> Handle(EmailAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await this.appDbContext.Users
                                 .WhereWhen(!string.IsNullOrEmpty(request.Email),
                                             e => e.Email1 == request.Email || e.Email2 == request.Email)
                                 .FirstOrDefaultAsync(cancellationToken);

            return new EmailAccountResponse()
            {
                Account = user?.UserNo,
                Name = user?.Name,
                Email = user != null ? request.Email : null
            };
        }
    }
}
