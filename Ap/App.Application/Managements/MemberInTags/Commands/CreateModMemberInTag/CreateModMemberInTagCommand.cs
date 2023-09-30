#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MemberInTags.ModMemberInTags.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberInTags.ModMemberInTags.Commands.CreateModMemberInTag
{
    /// <summary>
    /// 建立 ModMemberInTag
    /// </summary>

    public class CreateModMemberInTagCommand :  ModMemberInTagBase, IRequest<ModMemberInTagView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberInTagCommandHandler : IRequestHandler<CreateModMemberInTagCommand, ModMemberInTagView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberInTagCommandHandler(
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
        public async Task<ModMemberInTagView> Handle(
            CreateModMemberInTagCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberInTag>(command);

            await this.appDbContext.ModMemberInTags.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberInTagView>(entity);
        }
    }
}
