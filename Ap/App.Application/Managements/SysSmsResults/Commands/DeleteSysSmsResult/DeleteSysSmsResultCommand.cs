#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App.Application.Common.Extensions;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.SysSmsResults.Commands.DeleteSysSmsResult
{
    /// <summary>
    /// 刪除  SysSmsResult
    /// </summary>

    public class DeleteSysSmsResultCommand : IRequest<Unit>
    {
    
        public int Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysSmsResultCommandHandler : IRequestHandler<DeleteSysSmsResultCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteSysSmsResultCommandHandler(
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
        public async Task<Unit> Handle(
            DeleteSysSmsResultCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.SysSmsResults.RemoveAsync(
                new SysSmsResult()
                {
                    //Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
