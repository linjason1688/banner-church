#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Extensions;
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

namespace App.Application.Managements.ClassTerms.ModClassTerms.Commands.UpdateModClassTerm
{
    /// <summary>
    /// 更新  ModClassTerm
    /// </summary>

    public class UpdateModClassTermCommand : ModClassTermBase,IRequest<ModClassTermView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateModClassTermCommandHandler : IRequestHandler<UpdateModClassTermCommand, ModClassTermView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public UpdateModClassTermCommandHandler(
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
            UpdateModClassTermCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = await this.appDbContext.ModClassTerms.FindOneAsync(
                e => e.Id == command.Id,
                cancellationToken
            );

            entity = this.mapper.Map(command, entity);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ModClassTermView>(entity);
        }
    }
}
