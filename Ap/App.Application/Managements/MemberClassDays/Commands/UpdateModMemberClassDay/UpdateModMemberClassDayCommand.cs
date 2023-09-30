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
using App.Application.Managements.MemberClassDays.ModMemberClassDays.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.MemberClassDays.ModMemberClassDays.Commands.UpdateModMemberClassDay
{
    /// <summary>
    /// 更新  ModMemberClassDay
    /// </summary>

    public class UpdateModMemberClassDayCommand : ModMemberClassDayBase,IRequest<ModMemberClassDayView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateModMemberClassDayCommandHandler : IRequestHandler<UpdateModMemberClassDayCommand, ModMemberClassDayView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateModMemberClassDayCommandHandler(
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
            UpdateModMemberClassDayCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.ModMemberClassDays.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModMemberClassDayView>(entity);
        }
    }
}
