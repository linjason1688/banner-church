#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwGroups.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwGroups.Commands.CreateVwGroup
{
    /// <summary>
    /// 建立 VwGroup
    /// </summary>

    public class CreateVwGroupCommand :  VwGroupBase, IRequest<VwGroupView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwGroupCommandHandler : IRequestHandler<CreateVwGroupCommand, VwGroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwGroupCommandHandler(
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
        public async Task<VwGroupView> Handle(
            CreateVwGroupCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwGroup>(command);

            await this.appDbContext.VwGroups.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwGroupView>(entity);
        }
    }
}
