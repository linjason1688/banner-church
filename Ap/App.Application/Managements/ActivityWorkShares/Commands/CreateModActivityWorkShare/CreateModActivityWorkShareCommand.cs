#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ActivityWorkShares.ModActivityWorkShares.Commands.CreateModActivityWorkShare
{
    /// <summary>
    /// 建立 ModActivityWorkShare
    /// </summary>

    public class CreateModActivityWorkShareCommand :  ModActivityWorkShareBase, IRequest<ModActivityWorkShareView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModActivityWorkShareCommandHandler : IRequestHandler<CreateModActivityWorkShareCommand, ModActivityWorkShareView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModActivityWorkShareCommandHandler(
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
        public async Task<ModActivityWorkShareView> Handle(
            CreateModActivityWorkShareCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModActivityWorkShare>(command);

            await this.appDbContext.ModActivityWorkShares.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModActivityWorkShareView>(entity);
        }
    }
}
