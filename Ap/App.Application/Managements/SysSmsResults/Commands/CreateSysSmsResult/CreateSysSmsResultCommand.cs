#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.SysSmsResults.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysSmsResults.Commands.CreateSysSmsResult
{
    /// <summary>
    /// 建立 SysSmsResult
    /// </summary>

    public class CreateSysSmsResultCommand :  SysSmsResultBase, IRequest<SysSmsResultView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateSysSmsResultCommandHandler : IRequestHandler<CreateSysSmsResultCommand, SysSmsResultView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateSysSmsResultCommandHandler(
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
        public async Task<SysSmsResultView> Handle(
            CreateSysSmsResultCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<SysSmsResult>(command);

            await this.appDbContext.SysSmsResults.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<SysSmsResultView>(entity);
        }
    }
}
