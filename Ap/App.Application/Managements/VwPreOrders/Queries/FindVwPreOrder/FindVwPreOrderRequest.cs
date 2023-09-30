#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwPreOrders.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwPreOrders.Queries.FindVwPreOrder
{
    /// <summary>
    /// 取得  VwPreOrder 單筆明細
    /// </summary>

    public class FindVwPreOrderRequest 
        : IRequest<VwPreOrderView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwPreOrderRequestHandler 
        : IRequestHandler<FindVwPreOrderRequest, VwPreOrderView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwPreOrderRequestHandler(
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
            FindVwPreOrderRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwPreOrders
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwPreOrderView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
