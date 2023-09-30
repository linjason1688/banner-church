using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.ChildSignUp
{
    public class ChildSignUpCommandHandler : IRequestHandler<ChildSignUpCommand, ChildSignUpCommandResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindAccountCommandRequestHandler> logger;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public ChildSignUpCommandHandler(
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
        }

        public async Task<ChildSignUpCommandResponse> Handle(ChildSignUpCommand request, CancellationToken cancellationToken)
        {
            var entity = this.mapper.Map<User>(request);

            await this.appDbContext.Users.AddAsync(entity, cancellationToken);
            var user = await this.appDbContext.SaveChangesAsync(cancellationToken);

            if (user <= 0)
            {
                throw new MyBusinessException("新增失敗");
            }

            return new ChildSignUpCommandResponse
            {
                // FIXME: 未確定帳號取哪個欄位，先暫時抓 Identifier
                Account = entity?.Name
            };
        }
    }
}
