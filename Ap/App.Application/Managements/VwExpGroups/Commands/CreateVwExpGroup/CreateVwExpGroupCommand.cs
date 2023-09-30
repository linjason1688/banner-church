#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwExpGroups.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwExpGroups.Commands.CreateVwExpGroup
{
    /// <summary>
    /// 建立 VwExpGroup
    /// </summary>

    public class CreateVwExpGroupCommand :  VwExpGroupBase, IRequest<VwExpGroupView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwExpGroupCommandHandler : IRequestHandler<CreateVwExpGroupCommand, VwExpGroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwExpGroupCommandHandler(
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
        public async Task<VwExpGroupView> Handle(
            CreateVwExpGroupCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwExpGroup>(command);

            await this.appDbContext.VwExpGroups.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwExpGroupView>(entity);
        }
    }
}
