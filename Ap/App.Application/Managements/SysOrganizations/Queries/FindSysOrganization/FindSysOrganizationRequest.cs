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
using App.Application.Managements.SysOrganizations.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SysOrganizations.Queries.FindSysOrganization
{
    /// <summary>
    /// 取得  SysOrganization 單筆明細
    /// </summary>

    public class FindSysOrganizationRequest 
        : IRequest<SysOrganizationView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindSysOrganizationRequestHandler 
        : IRequestHandler<FindSysOrganizationRequest, SysOrganizationView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindSysOrganizationRequestHandler(
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
        public async Task<SysOrganizationView> Handle(
            FindSysOrganizationRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SysOrganizations
               //.Where(e => e.Id == request.Id)
               .ProjectTo<SysOrganizationView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
