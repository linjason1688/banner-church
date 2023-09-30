#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwPreOrders.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.VwPreOrders.Commands.CreateVwPreOrder
{
    /// <summary>
    /// 建立 VwPreOrder
    /// </summary>

    public class CreateVwPreOrderCommand :  VwPreOrderBase, IRequest<VwPreOrderView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateVwPreOrderCommandHandler : IRequestHandler<CreateVwPreOrderCommand, VwPreOrderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateVwPreOrderCommandHandler(
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
        public async Task<VwPreOrderView> Handle(
            CreateVwPreOrderCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<VwPreOrder>(command);

            await this.appDbContext.VwPreOrders.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<VwPreOrderView>(entity);
        }
    }
}
