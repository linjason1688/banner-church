#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MemberClasses.ModMemberClasses.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberClasses.ModMemberClasses.Commands.CreateModMemberClass
{
    /// <summary>
    /// 建立 ModMemberClass
    /// </summary>

    public class CreateModMemberClassCommand :  ModMemberClassBase, IRequest<ModMemberClassView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassCommandHandler : IRequestHandler<CreateModMemberClassCommand, ModMemberClassView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassCommandHandler(
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
        public async Task<ModMemberClassView> Handle(
            CreateModMemberClassCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberClass>(command);

            await this.appDbContext.ModMemberClasses.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberClassView>(entity);
        }
    }
}
