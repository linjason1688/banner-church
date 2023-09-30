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
using App.Application.Managements.SysSmsResults.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SysSmsResults.Queries.FindSysSmsResult
{
    /// <summary>
    /// 取得  SysSmsResult 單筆明細
    /// </summary>

    public class FindSysSmsResultRequest 
        : IRequest<SysSmsResultView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindSysSmsResultRequestHandler 
        : IRequestHandler<FindSysSmsResultRequest, SysSmsResultView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindSysSmsResultRequestHandler(
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
        public async Task<SysSmsResultView> Handle(
            FindSysSmsResultRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SysSmsResults
               //.Where(e => e.Id == request.Id)
               .ProjectTo<SysSmsResultView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
