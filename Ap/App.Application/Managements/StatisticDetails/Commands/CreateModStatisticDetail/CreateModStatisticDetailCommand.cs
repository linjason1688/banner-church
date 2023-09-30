#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.StatisticDetails.ModStatisticDetails.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Commands.CreateModStatisticDetail
{
    /// <summary>
    /// 建立 ModStatisticDetail
    /// </summary>

    public class CreateModStatisticDetailCommand :  ModStatisticDetailBase, IRequest<ModStatisticDetailView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModStatisticDetailCommandHandler : IRequestHandler<CreateModStatisticDetailCommand, ModStatisticDetailView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModStatisticDetailCommandHandler(
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
        public async Task<ModStatisticDetailView> Handle(
            CreateModStatisticDetailCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModStatisticDetail>(command);

            await this.appDbContext.ModStatisticDetails.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModStatisticDetailView>(entity);
        }
    }
}
