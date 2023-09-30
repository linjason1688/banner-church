#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Commands.CreateModMemberMinister
{
    /// <summary>
    /// 建立 ModMemberMinister
    /// </summary>

    public class CreateModMemberMinisterCommand :  ModMemberMinisterBase, IRequest<ModMemberMinisterView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberMinisterCommandHandler : IRequestHandler<CreateModMemberMinisterCommand, ModMemberMinisterView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberMinisterCommandHandler(
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
            CreateModMemberMinisterCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberMinister>(command);

            await this.appDbContext.ModMemberMinisters.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberMinisterView>(entity);
        }
    }
}
