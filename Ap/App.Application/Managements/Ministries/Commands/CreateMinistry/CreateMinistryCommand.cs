#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Ministries.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Ministries.Commands.CreateMinistry
{
    /// <summary>
    /// 建立 Ministry
    /// </summary>

    public class CreateMinistryCommand :  MinistryBase, IRequest<MinistryView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryCommandHandler : IRequestHandler<CreateMinistryCommand, MinistryView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryCommandHandler(
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
        public async Task<MinistryView> Handle(
            CreateMinistryCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<Ministry>(command);

            await this.appDbContext.Ministries.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryView>(entity);
        }
    }
}
