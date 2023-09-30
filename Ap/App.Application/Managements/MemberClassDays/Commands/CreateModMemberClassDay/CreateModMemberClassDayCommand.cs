#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.MemberClassDays.ModMemberClassDays.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays.Commands.CreateModMemberClassDay
{
    /// <summary>
    /// 建立 ModMemberClassDay
    /// </summary>

    public class CreateModMemberClassDayCommand :  ModMemberClassDayBase, IRequest<ModMemberClassDayView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassDayCommandHandler : IRequestHandler<CreateModMemberClassDayCommand, ModMemberClassDayView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassDayCommandHandler(
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
        public async Task<ModMemberClassDayView> Handle(
            CreateModMemberClassDayCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModMemberClassDay>(command);

            await this.appDbContext.ModMemberClassDays.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberClassDayView>(entity);
        }
    }
}
