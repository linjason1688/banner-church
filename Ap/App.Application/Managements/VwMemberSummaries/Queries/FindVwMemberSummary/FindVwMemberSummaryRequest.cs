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
using App.Application.Managements.VwMemberSummaries.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Queries.FindVwMemberSummary
{
    /// <summary>
    /// 取得  VwMemberSummary 單筆明細
    /// </summary>

    public class FindVwMemberSummaryRequest 
        : IRequest<VwMemberSummaryView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberSummaryRequestHandler 
        : IRequestHandler<FindVwMemberSummaryRequest, VwMemberSummaryView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwMemberSummaryRequestHandler(
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
        public async Task<VwMemberSummaryView> Handle(
            FindVwMemberSummaryRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwMemberSummaries
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwMemberSummaryView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
