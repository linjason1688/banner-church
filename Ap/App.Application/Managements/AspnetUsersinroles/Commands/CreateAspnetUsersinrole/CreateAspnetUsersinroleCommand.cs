#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
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

namespace App.Application.Managements.AspnetUsersinroles.Commands.CreateAspnetUsersinrole
{
    /// <summary>
    /// 建立 AspnetUsersinrole
    /// </summary>

    public class CreateAspnetUsersinroleCommand :  AspnetUsersinroleBase, IRequest<AspnetUsersinroleView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetUsersinroleCommandHandler : IRequestHandler<CreateAspnetUsersinroleCommand, AspnetUsersinroleView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetUsersinroleCommandHandler(
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
            CreateAspnetUsersinroleCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<AspnetUsersInRole>(command);

            await this.appDbContext.AspnetUsersInRoles.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AspnetUsersinroleView>(entity);
        }
    }
}
