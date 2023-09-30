#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ActivityWorks.ModActivityWorks.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ActivityWorks.ModActivityWorks.Commands.CreateModActivityWork
{
    /// <summary>
    /// 建立 ModActivityWork
    /// </summary>

    public class CreateModActivityWorkCommand :  ModActivityWorkBase, IRequest<ModActivityWorkView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModActivityWorkCommandHandler : IRequestHandler<CreateModActivityWorkCommand, ModActivityWorkView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModActivityWorkCommandHandler(
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
        public async Task<ModActivityWorkView> Handle(
            CreateModActivityWorkCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModActivityWork>(command);

            await this.appDbContext.ModActivityWorks.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModActivityWorkView>(entity);
        }
    }
}
