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
using App.Application.Managements.SysOrgUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.SysOrgUsers.Queries.FindSysOrgUser
{
    /// <summary>
    /// 取得  SysOrgUser 單筆明細
    /// </summary>

    public class FindSysOrgUserRequest 
        : IRequest<SysOrgUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindSysOrgUserRequestHandler 
        : IRequestHandler<FindSysOrgUserRequest, SysOrgUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindSysOrgUserRequestHandler(
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
        public async Task<SysOrgUserView> Handle(
            FindSysOrgUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .SysOrgUsers
               //.Where(e => e.Id == request.Id)
               .ProjectTo<SysOrgUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}