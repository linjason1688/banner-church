#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Preorders.ModPreorders.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Preorders.ModPreorders.Commands.CreateModPreorder
{
    /// <summary>
    /// 建立 ModPreorder
    /// </summary>

    public class CreateModPreorderCommand :  ModPreorderBase, IRequest<ModPreorderView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModPreorderCommandHandler : IRequestHandler<CreateModPreorderCommand, ModPreorderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModPreorderCommandHandler(
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
        public async Task<ModPreorderView> Handle(
            CreateModPreorderCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModPreorder>(command);

            await this.appDbContext.ModPreorders.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModPreorderView>(entity);
        }
    }
}
