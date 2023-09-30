using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;
using App.Application.Features.CreateMinistryDef;
using App.Application.Features.FindAccount;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.UPastoral
{//#CreateAPI
    public class MinistryDefCommandHandler : IRequestHandler<UPastoralCommand, UPastoralResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindAccountCommandRequestHandler> logger;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public MinistryDefCommandHandler(
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

        public async Task<UPastoralResponse> Handle(UPastoralCommand request, CancellationToken cancellationToken)
        {
            var entity = this.mapper.Map<Pastoral>(request);

            await this.appDbContext.Pastorals.AddAsync(entity, cancellationToken);
            var user = await this.appDbContext.SaveChangesAsync(cancellationToken);

            if (user <= 0)
            {
                throw new MyBusinessException("新增失敗");
            }

            return new UPastoralResponse
            {
                // FIXME: 未確定帳號取哪個欄位，先暫時抓 Identifier
                Name = entity?.Name
            };
        }
    }
}
