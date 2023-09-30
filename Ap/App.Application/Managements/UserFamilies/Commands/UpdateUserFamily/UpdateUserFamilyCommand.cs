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
using App.Application.Managements.UserFamilies.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.UserFamilies.Commands.UpdateUserFamily
{
    /// <summary>
    /// 更新  UserFamily
    /// </summary>

    public class UpdateUserFamilyCommand : UserFamilyBase,IRequest<UserFamilyView>
    {

        //public long Id { get; set; }
        //public long UserId { get; set; }
        //public string RelativeType { get; set; }
        //public string Name { get; set; }
        public string Memo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserFamilyCommandHandler : IRequestHandler<UpdateUserFamilyCommand, UserFamilyView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateUserFamilyCommandHandler(
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
        public async Task<UserFamilyView> Handle(
            UpdateUserFamilyCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.UserFamilies.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<UserFamilyView>(entity);
        }
    }
}
