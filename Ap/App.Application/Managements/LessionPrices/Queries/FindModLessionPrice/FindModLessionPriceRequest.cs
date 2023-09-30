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
using App.Application.Managements.LessionPrices.ModLessionPrices.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.LessionPrices.ModLessionPrices.Queries.FindModLessionPrice
{
    /// <summary>
    /// 取得  ModLessionPrice 單筆明細
    /// </summary>

    public class FindModLessionPriceRequest 
        : IRequest<ModLessionPriceView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModLessionPriceRequestHandler 
        : IRequestHandler<FindModLessionPriceRequest, ModLessionPriceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModLessionPriceRequestHandler(
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
        public async Task<ModLessionPriceView> Handle(
            FindModLessionPriceRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModLessionPrices
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModLessionPriceView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
