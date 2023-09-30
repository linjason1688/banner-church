#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinisterGroups.ModMinisterGroups.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinisterGroups.ModMinisterGroups.Commands.CreateModMinisterGroup
{
    /// <summary>
    /// 建立 ModMinisterGroup
    /// </summary>

    public class CreateModMinisterGroupCommand :  ModMinisterGroupBase, IRequest<ModMinisterGroupView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMinisterGroupCommandHandler : IRequestHandler<CreateModMinisterGroupCommand, ModMinisterGroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMinisterGroupCommandHandler(
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
        public async Task<ModMinisterGroupView> Handle(
            CreateModMinisterGroupCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMinisterGroup>(command);

            await this.appDbContext.ModMinisterGroups.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMinisterGroupView>(entity);
        }
    }
}
