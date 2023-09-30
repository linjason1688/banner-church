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
using App.Application.Managements.MinistryDefs.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryDefs.Queries.FindMinistryDef
{
    /// <summary>
    /// 取得  MinistryDef 單筆明細
    /// </summary>

    public class FindMinistryDefRequest 
        : IRequest<MinistryDefView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryDefRequestHandler 
        : IRequestHandler<FindMinistryDefRequest, MinistryDefView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMinistryDefRequestHandler(
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
        public async Task<MinistryDefView> Handle(
            FindMinistryDefRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryDefs
               .Where(e => e.Id == request.Id)
               .ProjectTo<MinistryDefView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
