#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.LessionPrices.ModLessionPrices.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Commands.CreateModLessionPrice
{
    /// <summary>
    /// 建立 ModLessionPrice
    /// </summary>

    public class CreateModLessionPriceCommand :  ModLessionPriceBase, IRequest<ModLessionPriceView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionPriceCommandHandler : IRequestHandler<CreateModLessionPriceCommand, ModLessionPriceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionPriceCommandHandler(
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
        public async Task<ModLessionPriceView> Handle(
            CreateModLessionPriceCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModLessionPrice>(command);

            await this.appDbContext.ModLessionPrices.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModLessionPriceView>(entity);
        }
    }
}
