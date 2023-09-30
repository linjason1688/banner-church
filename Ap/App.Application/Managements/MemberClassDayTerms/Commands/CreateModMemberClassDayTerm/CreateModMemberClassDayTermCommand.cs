#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberClassDayTerms.ModMemberClassDayTerms.Commands.CreateModMemberClassDayTerm
{
    /// <summary>
    /// 建立 ModMemberClassDayTerm
    /// </summary>

    public class CreateModMemberClassDayTermCommand :  ModMemberClassDayTermBase, IRequest<ModMemberClassDayTermView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassDayTermCommandHandler : IRequestHandler<CreateModMemberClassDayTermCommand, ModMemberClassDayTermView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassDayTermCommandHandler(
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
        public async Task<ModMemberClassDayTermView> Handle(
            CreateModMemberClassDayTermCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberClassDayTerm>(command);

            await this.appDbContext.ModMemberClassDayTerms.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberClassDayTermView>(entity);
        }
    }
}
