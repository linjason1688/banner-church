#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryResps.Dtos;
using App.Application.Managements.MinistryRespUsers.Commands.CreateMinistryRespUser;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistryResps.Commands.CreateMinistryResp
{
    /// <summary>
    /// 建立 MinistryResp
    /// </summary>

    public class CreateMinistryRespCommand :  MinistryRespBase, IRequest<MinistryRespView>
    {
        /// <summary>
        /// 事工團職分明細
        /// </summary>
        public List<CreateMinistryRespUserCommand> MinistryRespUsers { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryRespCommandHandler : IRequestHandler<CreateMinistryRespCommand, MinistryRespView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryRespCommandHandler(
            IMapper mapper,
            IAppDbContext appDbContext
)
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<MinistryRespView> Handle(
            CreateMinistryRespCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MinistryResp>(command);

            await this.appDbContext.MinistryResps.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryRespView>(entity);
        }
    }
}
