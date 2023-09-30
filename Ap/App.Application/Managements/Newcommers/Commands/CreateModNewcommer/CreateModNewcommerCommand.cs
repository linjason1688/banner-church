#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Newcommers.ModNewcommers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Newcommers.ModNewcommers.Commands.CreateModNewcommer
{
    /// <summary>
    /// 建立 ModNewcommer
    /// </summary>

    public class CreateModNewcommerCommand :  ModNewcommerBase, IRequest<ModNewcommerView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModNewcommerCommandHandler : IRequestHandler<CreateModNewcommerCommand, ModNewcommerView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModNewcommerCommandHandler(
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
        public async Task<ModNewcommerView> Handle(
            CreateModNewcommerCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModNewcommer>(command);

            await this.appDbContext.ModNewcommers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModNewcommerView>(entity);
        }
    }
}
