#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Statistics.ModStatistics.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Statistics.ModStatistics.Commands.CreateModStatistic
{
    /// <summary>
    /// 建立 ModStatistic
    /// </summary>

    public class CreateModStatisticCommand :  ModStatisticBase, IRequest<ModStatisticView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModStatisticCommandHandler : IRequestHandler<CreateModStatisticCommand, ModStatisticView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModStatisticCommandHandler(
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
        public async Task<ModStatisticView> Handle(
            CreateModStatisticCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModStatistic>(command);

            await this.appDbContext.ModStatistics.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModStatisticView>(entity);
        }
    }
}
