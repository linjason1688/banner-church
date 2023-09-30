#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryResps.Dtos;
using App.Application.Managements.MinistryRespUsers.Commands.UpdateMinistryRespUser;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistryResps.Commands.UpdateMinistryResp
{
    /// <summary>
    /// 更新  MinistryResp
    /// </summary>

    public class UpdateMinistryRespCommand : MinistryRespBase,IRequest<MinistryRespView>
    {
    
        //public long Id { get; set; }
        /// <summary>
        /// 事工團職分明細
        /// </summary>
        public List<UpdateMinistryRespUserCommand> MinistryRespUsers { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryRespCommandHandler : IRequestHandler<UpdateMinistryRespCommand, MinistryRespView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryRespCommandHandler(
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
            UpdateMinistryRespCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.MinistryResps.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryRespView>(entity);
        }
    }
}
