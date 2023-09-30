#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Newses.ModNewses.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Newses.ModNewses.Commands.CreateModNews
{
    /// <summary>
    /// 建立 ModNews
    /// </summary>

    public class CreateModNewsCommand :  ModNewsBase, IRequest<ModNewsView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModNewsCommandHandler : IRequestHandler<CreateModNewsCommand, ModNewsView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModNewsCommandHandler(
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
        public async Task<ModNewsView> Handle(
            CreateModNewsCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModNews>(command);

            await this.appDbContext.ModNews.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModNewsView>(entity);
        }
    }
}
