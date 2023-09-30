#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Areas.ModAreas.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Areas.ModAreas.Commands.CreateModArea
{
    /// <summary>
    /// 建立 ModArea
    /// </summary>

    public class CreateModAreaCommand :  ModAreaBase, IRequest<ModAreaView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModAreaCommandHandler : IRequestHandler<CreateModAreaCommand, ModAreaView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModAreaCommandHandler(
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
        public async Task<ModAreaView> Handle(
            CreateModAreaCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModArea>(command);

            await this.appDbContext.ModAreas.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModAreaView>(entity);
        }
    }
}
