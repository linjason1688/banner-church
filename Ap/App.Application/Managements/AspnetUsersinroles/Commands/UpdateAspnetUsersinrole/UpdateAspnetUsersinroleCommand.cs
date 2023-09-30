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
using App.Application.Managements.AspnetUsersinroles.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.AspnetUsersinroles.Commands.UpdateAspnetUsersinrole
{
    /// <summary>
    /// 更新  AspnetUsersinrole
    /// </summary>

    public class UpdateAspnetUsersinroleCommand : AspnetUsersinroleBase,IRequest<AspnetUsersinroleView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetUsersinroleCommandHandler : IRequestHandler<UpdateAspnetUsersinroleCommand, AspnetUsersinroleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetUsersinroleCommandHandler(
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
        public async Task<AspnetUsersinroleView> Handle(
            UpdateAspnetUsersinroleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.AspnetUsersInRoles.FindOneAsync(
                //e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetUsersinroleView>(entity);
        }
    }
}
