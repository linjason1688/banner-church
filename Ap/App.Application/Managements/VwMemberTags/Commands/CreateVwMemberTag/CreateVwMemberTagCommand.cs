#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwMemberTags.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwMemberTags.Commands.CreateVwMemberTag
{
    /// <summary>
    /// 建立 VwMemberTag
    /// </summary>

    public class CreateVwMemberTagCommand :  VwMemberTagBase, IRequest<VwMemberTagView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMemberTagCommandHandler : IRequestHandler<CreateVwMemberTagCommand, VwMemberTagView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwMemberTagCommandHandler(
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
        public async Task<VwMemberTagView> Handle(
            CreateVwMemberTagCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwMemberTag>(command);

            await this.appDbContext.VwMemberTags.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwMemberTagView>(entity);
        }
    }
}
