#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Tags.ModTags.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Tags.ModTags.Commands.CreateModTag
{
    /// <summary>
    /// 建立 ModTag
    /// </summary>

    public class CreateModTagCommand :  ModTagBase, IRequest<ModTagView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModTagCommandHandler : IRequestHandler<CreateModTagCommand, ModTagView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModTagCommandHandler(
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
        public async Task<ModTagView> Handle(
            CreateModTagCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModTag>(command);

            await this.appDbContext.ModTags.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModTagView>(entity);
        }
    }
}
