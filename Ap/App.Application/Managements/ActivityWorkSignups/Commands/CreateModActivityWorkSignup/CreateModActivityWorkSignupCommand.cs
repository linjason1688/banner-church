#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Commands.CreateModActivityWorkSignup
{
    /// <summary>
    /// 建立 ModActivityWorkSignup
    /// </summary>

    public class CreateModActivityWorkSignupCommand :  ModActivityWorkSignupBase, IRequest<ModActivityWorkSignupView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModActivityWorkSignupCommandHandler : IRequestHandler<CreateModActivityWorkSignupCommand, ModActivityWorkSignupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModActivityWorkSignupCommandHandler(
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
        public async Task<ModActivityWorkSignupView> Handle(
            CreateModActivityWorkSignupCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModActivityWorkSignup>(command);

            await this.appDbContext.ModActivityWorkSignups.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModActivityWorkSignupView>(entity);
        }
    }
}
