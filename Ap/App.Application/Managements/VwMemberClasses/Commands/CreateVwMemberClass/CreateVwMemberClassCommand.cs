#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwMemberClasses.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwMemberClasses.Commands.CreateVwMemberClass
{
    /// <summary>
    /// 建立 VwMemberClass
    /// </summary>

    public class CreateVwMemberClassCommand :  VwMemberClassBase, IRequest<VwMemberClassView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMemberClassCommandHandler : IRequestHandler<CreateVwMemberClassCommand, VwMemberClassView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwMemberClassCommandHandler(
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
        public async Task<VwMemberClassView> Handle(
            CreateVwMemberClassCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwMemberClass>(command);

            await this.appDbContext.VwMemberClasses.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwMemberClassView>(entity);
        }
    }
}
