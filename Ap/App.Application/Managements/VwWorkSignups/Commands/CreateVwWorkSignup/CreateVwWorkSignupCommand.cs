#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwWorkSignups.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwWorkSignups.Commands.CreateVwWorkSignup
{
    /// <summary>
    /// 建立 VwWorkSignup
    /// </summary>

    public class CreateVwWorkSignupCommand :  VwWorkSignupBase, IRequest<VwWorkSignupView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwWorkSignupCommandHandler : IRequestHandler<CreateVwWorkSignupCommand, VwWorkSignupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwWorkSignupCommandHandler(
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
        public async Task<VwWorkSignupView> Handle(
            CreateVwWorkSignupCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwWorkSignup>(command);

            await this.appDbContext.VwWorkSignups.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwWorkSignupView>(entity);
        }
    }
}
