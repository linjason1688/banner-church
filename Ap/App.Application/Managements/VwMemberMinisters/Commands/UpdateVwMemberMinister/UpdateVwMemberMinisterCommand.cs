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
using App.Application.Managements.VwMemberMinisters.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwMemberMinisters.Commands.UpdateVwMemberMinister
{
    /// <summary>
    /// 更新  VwMemberMinister
    /// </summary>

    public class UpdateVwMemberMinisterCommand : VwMemberMinisterBase,IRequest<VwMemberMinisterView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwMemberMinisterCommandHandler : IRequestHandler<UpdateVwMemberMinisterCommand, VwMemberMinisterView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateVwMemberMinisterCommandHandler(
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
        public async Task<VwMemberMinisterView> Handle(
            UpdateVwMemberMinisterCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.VwMemberMinisters.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwMemberMinisterView>(entity);
        }
    }
}
