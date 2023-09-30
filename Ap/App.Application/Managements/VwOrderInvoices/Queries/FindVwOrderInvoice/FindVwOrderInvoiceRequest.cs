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
using App.Application.Managements.VwOrderInvoices.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Queries.FindVwOrderInvoice
{
    /// <summary>
    /// 取得  VwOrderInvoice 單筆明細
    /// </summary>

    public class FindVwOrderInvoiceRequest 
        : IRequest<VwOrderInvoiceView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwOrderInvoiceRequestHandler 
        : IRequestHandler<FindVwOrderInvoiceRequest, VwOrderInvoiceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwOrderInvoiceRequestHandler(
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
        public async Task<VwOrderInvoiceView> Handle(
            FindVwOrderInvoiceRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwOrderInvoices
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwOrderInvoiceView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
