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
using App.Application.Managements.MinistryResps.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryResps.Queries.FindMinistryResp
{
    /// <summary>
    /// 取得  MinistryResp 單筆明細
    /// </summary>

    public class FindMinistryRespRequest 
        : IRequest<MinistryRespView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryRespRequestHandler 
        : IRequestHandler<FindMinistryRespRequest, MinistryRespView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMinistryRespRequestHandler(
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
        public async Task<MinistryRespView> Handle(
            FindMinistryRespRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryResps
               .Where(e => e.Id == request.Id)
               .ProjectTo<MinistryRespView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
