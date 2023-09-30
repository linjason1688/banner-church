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

namespace App.Application.Managements.VwMemberMinisters.Commands.DeleteVwMemberMinister
{
    /// <summary>
    /// 刪除  VwMemberMinister
    /// </summary>

    public class DeleteVwMemberMinisterCommand : IRequest<Unit>
    {
    
        public int Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwMemberMinisterCommandHandler : IRequestHandler<DeleteVwMemberMinisterCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;


        /// <summary>
        /// 
        /// </summary>
        public DeleteVwMemberMinisterCommandHandler(
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
            DeleteVwMemberMinisterCommand command,
            CancellationToken cancellationToken
        )
        {
            await this.appDbContext.VwMemberMinisters.RemoveAsync(
                new VwMemberMinister()
                {
                    Id = command.Id
                }
            );

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
