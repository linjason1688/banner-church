#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Ministers.ModMinisters.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Ministers.ModMinisters.Commands.CreateModMinister
{
    /// <summary>
    /// 建立 ModMinister
    /// </summary>

    public class CreateModMinisterCommand :  ModMinisterBase, IRequest<ModMinisterView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMinisterCommandHandler : IRequestHandler<CreateModMinisterCommand, ModMinisterView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMinisterCommandHandler(
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
        public async Task<ModMinisterView> Handle(
            CreateModMinisterCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMinister>(command);

            await this.appDbContext.ModMinisters.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMinisterView>(entity);
        }
    }
}
