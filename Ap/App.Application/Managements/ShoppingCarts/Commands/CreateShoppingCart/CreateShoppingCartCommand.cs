#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.ShoppingCarts.Dtos;
using App.Domain.Constants;
using App.Domain.Entities.Core;
using App.Domain.Entities.Features;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Application.Managements.ShoppingCarts.Commands.CreateShoppingCart
{
    /// <summary>
    /// 建立 ShoppingCart
    /// </summary>

    public class CreateShoppingCartCommand :  ShoppingCartBase, IRequest<ShoppingCartView>
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public CreateShoppingCartCommandHandler(
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
        public async Task<ShoppingCartView> Handle(
            CreateShoppingCartCommand command,
            CancellationToken cancellationToken
        )
        {
            var entity = this.mapper.Map<ShoppingCart>(command);

            await this.appDbContext.ShoppingCarts.AddAsync(entity, cancellationToken);

            await this.appDbContext.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<ShoppingCartView>(entity);
        }
    }
}
