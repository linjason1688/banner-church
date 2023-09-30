#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MinistryDefs.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MinistryDefs.Commands.CreateMinistryDef
{
    /// <summary>
    /// 建立 MinistryDef
    /// </summary>

    public class CreateMinistryDefCommand :  MinistryDefBase, IRequest<MinistryDefView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryDefCommandHandler : IRequestHandler<CreateMinistryDefCommand, MinistryDefView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryDefCommandHandler(
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
        public async Task<MinistryDefView> Handle(
            CreateMinistryDefCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<MinistryDef>(command);

            await this.appDbContext.MinistryDefs.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<MinistryDefView>(entity);
        }
    }
}
