using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Interfaces;
using App.Application.Features.FindConfig.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;

namespace App.Application.Features.FindConfig.Commands
{
    public class FindConfigCommandRequestHandler : IRequestHandler<FindConfigCommand, FindConfigResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindConfigCommandRequestHandler> logger;

        public FindConfigCommandRequestHandler(
            IAppDbContext appDbContext,
            ILogger<FindConfigCommandRequestHandler> logger
        )
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }

        public async Task<FindConfigResponse> Handle(FindConfigCommand request, CancellationToken cancellationToken)
        {
            // FIXME: 查詢的表格需加上非會員的資訊
            var systemconfig =
                await this.appDbContext.SystemConfigs
                   .WhereWhen(!string.IsNullOrEmpty(request.Type), e => e.Type == request.Type)
                   .WhereWhen(!string.IsNullOrEmpty(request.Name), e => e.Name == request.Name)
                  
                   .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return new FindConfigResponse
            {
                // FIXME: 未確定帳號取哪個欄位，先暫時抓 Identifier
                Type = systemconfig?.Type,
                Value = systemconfig?.Value,
                Name = systemconfig?.Name,                
            };
        }
    }
}
