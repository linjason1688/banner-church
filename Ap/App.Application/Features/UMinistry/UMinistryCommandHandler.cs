using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces;
using App.Application.Features.FindAccount;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.UMinistry
{
    public class UMinistryCommandHandler : IRequestHandler<UMinistryCommand, UMinistryCommandResponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<FindAccountCommandRequestHandler> logger;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public UMinistryCommandHandler(
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

        public async Task<UMinistryCommandResponse> Handle(UMinistryCommand request, CancellationToken cancellationToken)
        {
            await this.appDbContext.ExecuteTransactionAsync(async Task () =>
            {
                var entity = this.mapper.Map<Ministry>(request);
                await this.appDbContext.Ministries.AddAsync(entity, cancellationToken);
                var user = await this.appDbContext.SaveChangesAsync(cancellationToken);
                if (user <= 0)
                {
                    throw new MyBusinessException("新增失敗");
                }
                foreach(var resp in request.MinistryResps)
                {
                    resp.MinistryId = entity.Id;
                    var respView = await this.mediator.Send(resp); //Insert into MinistryResp
                    if (resp.MinistryRespUsers!=null)
                    {
                        foreach (var respUser in resp.MinistryRespUsers)
                        {
                            respUser.MinistryRespId = respView.Id;
                            await this.mediator.Send(respUser);  //Insert into MinistryRespUsers
                        }
                    }
                }
            });

            return new UMinistryCommandResponse
            {
                // FIXME: 未確定帳號取哪個欄位，先暫時抓 Identifier
                Name = request?.Name
            };
        }
    }
}
