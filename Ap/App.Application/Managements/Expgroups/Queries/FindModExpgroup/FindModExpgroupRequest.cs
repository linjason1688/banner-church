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
using App.Application.Managements.Expgroups.ModExpgroups.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Queries.FindModExpgroup
{
    /// <summary>
    /// 取得  ModExpgroup 單筆明細
    /// </summary>

    public class FindModExpgroupRequest 
        : IRequest<ModExpgroupView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindModExpgroupRequestHandler 
        : IRequestHandler<FindModExpgroupRequest, ModExpgroupView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindModExpgroupRequestHandler(
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
        public async Task<ModExpgroupView> Handle(
            FindModExpgroupRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModExpgroups
               .Where(e => e.Id == request.Id)
               .ProjectTo<ModExpgroupView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
