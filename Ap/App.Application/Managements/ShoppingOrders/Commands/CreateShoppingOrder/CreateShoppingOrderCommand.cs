#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ShoppingOrders.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ShoppingOrders.Commands.CreateShoppingOrder
{
    /// <summary>
    /// 建立 ShoppingOrder
    /// </summary>

    public class CreateShoppingOrderCommand :  ShoppingOrderBase, IRequest<ShoppingOrderView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateShoppingOrderCommandHandler : IRequestHandler<CreateShoppingOrderCommand, ShoppingOrderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateShoppingOrderCommandHandler(
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
        public async Task<ShoppingOrderView> Handle(
            CreateShoppingOrderCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ShoppingOrder>(command);

            await this.appDbContext.ShoppingOrders.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ShoppingOrderView>(entity);
        }
    }
}
