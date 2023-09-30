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
using App.Application.Managements.OrderInvoices.ModOrderInvoices.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.OrderInvoices.ModOrderInvoices.Queries.FindModOrderInvoice
{
    /// <summary>
    /// 取得  ModOrderInvoice 單筆明細
    /// </summary>

    public class FindModOrderInvoiceRequest 
        : IRequest<ModOrderInvoiceView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModOrderInvoiceRequestHandler 
        : IRequestHandler<FindModOrderInvoiceRequest, ModOrderInvoiceView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModOrderInvoiceRequestHandler(
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
        public async Task<ModOrderInvoiceView> Handle(
            FindModOrderInvoiceRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModOrderInvoices
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModOrderInvoiceView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}