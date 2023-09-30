#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ErrCancels.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ErrCancels.Commands.CreateErrCancel
{
    /// <summary>
    /// 建立 ErrCancel
    /// </summary>

    public class CreateErrCancelCommand :  ErrCancelBase, IRequest<ErrCancelView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateErrCancelCommandHandler : IRequestHandler<CreateErrCancelCommand, ErrCancelView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateErrCancelCommandHandler(
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
        public async Task<ErrCancelView> Handle(
            CreateErrCancelCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ErrCancel>(command);

            await this.appDbContext.ErrCancels.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ErrCancelView>(entity);
        }
    }
}
