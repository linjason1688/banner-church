#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Expgroups.ModExpgroups.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Commands.CreateModExpgroup
{
    /// <summary>
    /// 建立 ModExpgroup
    /// </summary>

    public class CreateModExpgroupCommand :  ModExpgroupBase, IRequest<ModExpgroupView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModExpgroupCommandHandler : IRequestHandler<CreateModExpgroupCommand, ModExpgroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModExpgroupCommandHandler(
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
        public async Task<ModExpgroupView> Handle(
            CreateModExpgroupCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModExpgroup>(command);

            await this.appDbContext.ModExpgroups.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModExpgroupView>(entity);
        }
    }
}
