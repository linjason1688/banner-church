#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ClassTerms.ModClassTerms.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Commands.CreateModClassTerm
{
    /// <summary>
    /// 建立 ModClassTerm
    /// </summary>

    public class CreateModClassTermCommand :  ModClassTermBase, IRequest<ModClassTermView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateModClassTermCommandHandler : IRequestHandler<CreateModClassTermCommand, ModClassTermView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateModClassTermCommandHandler(
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
        public async Task<ModClassTermView> Handle(
            CreateModClassTermCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ModClassTerm>(command);

            await this.appDbContext.ModClassTerms.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModClassTermView>(entity);
        }
    }
}
