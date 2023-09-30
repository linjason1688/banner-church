#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ShoppingTracks.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ShoppingTracks.Commands.CreateShoppingTrack
{
    /// <summary>
    /// 建立 ShoppingTrack
    /// </summary>

    public class CreateShoppingTrackCommand :  ShoppingTrackBase, IRequest<ShoppingTrackView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateShoppingTrackCommandHandler : IRequestHandler<CreateShoppingTrackCommand, ShoppingTrackView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateShoppingTrackCommandHandler(
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
        public async Task<ShoppingTrackView> Handle(
            CreateShoppingTrackCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ShoppingTrack>(command);

            await this.appDbContext.ShoppingTracks.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ShoppingTrackView>(entity);
        }
    }
}
