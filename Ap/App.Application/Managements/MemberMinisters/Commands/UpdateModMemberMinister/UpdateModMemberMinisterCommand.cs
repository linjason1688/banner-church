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
using App.Application.Managements.MemberMinisters.ModMemberMinisters.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Commands.UpdateModMemberMinister
{
    /// <summary>
    /// 更新  ModMemberMinister
    /// </summary>

    public class UpdateModMemberMinisterCommand : ModMemberMinisterBase,IRequest<ModMemberMinisterView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberMinisterCommandHandler : IRequestHandler<UpdateModMemberMinisterCommand, ModMemberMinisterView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberMinisterCommandHandler(
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
        public async Task<ModMemberMinisterView> Handle(
            UpdateModMemberMinisterCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.ModMemberMinisters.FindOneAsync(
                //e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberMinisterView>(entity);
        }
    }
}
