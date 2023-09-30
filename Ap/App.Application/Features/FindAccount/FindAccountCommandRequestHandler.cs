using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;

namespace App.Application.Features.FindAccount
{
    public class FindAccountCommandRequestHandler : IRequestHandler<FindAccountCommand, FindAccountResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindAccountCommandRequestHandler> logger;

        public FindAccountCommandRequestHandler(
            IAppDbContext appDbContext,
            ILogger<FindAccountCommandRequestHandler> logger
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }

        public async Task<FindAccountResponse> Handle(FindAccountCommand request, CancellationToken cancellationToken)
        {
            // FIXME: 查詢的表格需加上非會員的資訊
            var member =
                await this.appDbContext.ModMembers
                   .WhereWhen(!string.IsNullOrEmpty(request.Email), e => e.Email == request.Email)
                   .WhereWhen(!string.IsNullOrEmpty(request.MobileNo), e => e.BizPhone == request.MobileNo)
                   .FirstOrDefaultAsync(cancellationToken);
            
            return await Task.FromResult(
                new FindAccountResponse
                {
                    Account = member?.Identifier    
                }
            );
        }
    }
}
