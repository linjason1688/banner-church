#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.Careers.ModCareers.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.Careers.ModCareers.Commands.CreateModCareer
{
    /// <summary>
    /// 建立 ModCareer
    /// </summary>

    public class CreateModCareerCommand :  ModCareerBase, IRequest<ModCareerView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModCareerCommandHandler : IRequestHandler<CreateModCareerCommand, ModCareerView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModCareerCommandHandler(
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
        public async Task<ModCareerView> Handle(
            CreateModCareerCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModCareer>(command);

            await this.appDbContext.ModCareers.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModCareerView>(entity);
        }
    }
}
