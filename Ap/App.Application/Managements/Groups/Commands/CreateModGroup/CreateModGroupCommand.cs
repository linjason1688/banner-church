#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Groups.ModGroups.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Groups.ModGroups.Commands.CreateModGroup
{
    /// <summary>
    /// 建立 ModGroup
    /// </summary>

    public class CreateModGroupCommand :  ModGroupBase, IRequest<ModGroupView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModGroupCommandHandler : IRequestHandler<CreateModGroupCommand, ModGroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModGroupCommandHandler(
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
        public async Task<ModGroupView> Handle(
            CreateModGroupCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModGroup>(command);

            await this.appDbContext.ModGroups.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModGroupView>(entity);
        }
    }
}
