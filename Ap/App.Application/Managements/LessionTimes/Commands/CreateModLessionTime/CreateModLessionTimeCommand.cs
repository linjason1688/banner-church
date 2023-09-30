#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.LessionTimes.ModLessionTimes.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.LessionTimes.ModLessionTimes.Commands.CreateModLessionTime
{
    /// <summary>
    /// 建立 ModLessionTime
    /// </summary>

    public class CreateModLessionTimeCommand :  ModLessionTimeBase, IRequest<ModLessionTimeView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModLessionTimeCommandHandler : IRequestHandler<CreateModLessionTimeCommand, ModLessionTimeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModLessionTimeCommandHandler(
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
        public async Task<ModLessionTimeView> Handle(
            CreateModLessionTimeCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModLessionTime>(command);

            await this.appDbContext.ModLessionTimes.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModLessionTimeView>(entity);
        }
    }
}
