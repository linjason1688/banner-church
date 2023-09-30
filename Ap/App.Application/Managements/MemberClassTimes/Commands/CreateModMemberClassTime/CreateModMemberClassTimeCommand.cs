#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberClassTimes.ModMemberClassTimes.Commands.CreateModMemberClassTime
{
    /// <summary>
    /// 建立 ModMemberClassTime
    /// </summary>

    public class CreateModMemberClassTimeCommand :  ModMemberClassTimeBase, IRequest<ModMemberClassTimeView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassTimeCommandHandler : IRequestHandler<CreateModMemberClassTimeCommand, ModMemberClassTimeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassTimeCommandHandler(
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
        public async Task<ModMemberClassTimeView> Handle(
            CreateModMemberClassTimeCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberClassTime>(command);

            await this.appDbContext.ModMemberClassTimes.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberClassTimeView>(entity);
        }
    }
}
