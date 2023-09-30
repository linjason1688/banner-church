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
using App.Application.Managements.SysSeedIdentities.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Queries.FindSysSeedIdentity
{
    /// <summary>
    /// 取得  SysSeedIdentity 單筆明細
    /// </summary>

    public class FindSysSeedIdentityRequest 
        : IRequest<SysSeedIdentityView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindSysSeedIdentityRequestHandler 
        : IRequestHandler<FindSysSeedIdentityRequest, SysSeedIdentityView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindSysSeedIdentityRequestHandler(
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
        public async Task<SysSeedIdentityView> Handle(
            FindSysSeedIdentityRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SysSeedIdentities
               //.Where(e => e.Id == request.Id)
               .ProjectTo<SysSeedIdentityView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
