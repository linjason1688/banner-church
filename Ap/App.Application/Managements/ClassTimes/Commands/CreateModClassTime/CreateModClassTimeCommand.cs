#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ClassTimes.ModClassTimes.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Commands.CreateModClassTime
{
    /// <summary>
    /// 建立 ModClassTime
    /// </summary>

    public class CreateModClassTimeCommand :  ModClassTimeBase, IRequest<ModClassTimeView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassTimeCommandHandler : IRequestHandler<CreateModClassTimeCommand, ModClassTimeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModClassTimeCommandHandler(
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
        public async Task<ModClassTimeView> Handle(
            CreateModClassTimeCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModClassTime>(command);

            await this.appDbContext.ModClassTimes.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModClassTimeView>(entity);
        }
    }
}
