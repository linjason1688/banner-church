#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
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

namespace App.Application.Managements.Tags.ModTags.Commands.UpdateModTag
{
    /// <summary>
    /// 更新  ModTag
    /// </summary>

    public class UpdateModTagCommand : ModTagBase,IRequest<ModTagView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateModTagCommandHandler : IRequestHandler<UpdateModTagCommand, ModTagView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateModTagCommandHandler(
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
            UpdateModTagCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.ModTags.FindOneAsync(
                e => e.Id.ToString() == command.Id.ToString(),
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModTagView>(entity);
        }
    }
}
