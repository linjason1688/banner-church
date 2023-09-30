#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwOrderInvoices.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwOrderInvoices.Queries.FetchAllVwOrderInvoice
{
    /// <summary>
    /// 查詢  VwOrderInvoice 所有資料
    /// </summary>

    public class FetchAllVwOrderInvoiceRequest 
        : IRequest<List<VwOrderInvoiceView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwOrderInvoiceHandler 
        : IRequestHandler<FetchAllVwOrderInvoiceRequest, List<VwOrderInvoiceView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllVwOrderInvoiceHandler(
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
        public async Task<List<VwOrderInvoiceView>> Handle(
            FetchAllVwOrderInvoiceRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwOrderInvoices
               .ApplyLimitConstraint(request)
               .ProjectTo<VwOrderInvoiceView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
