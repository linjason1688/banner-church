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
using App.Application.Managements.Privileges.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.Privileges.Queries.FindPrivilege
{
    /// <summary>
    /// 取得  Privilege 單筆明細
    /// </summary>

    public class FindPrivilegeRequest 
        : IRequest<PrivilegeView>
    {
    
        public Guid? Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindPrivilegeRequestHandler 
        : IRequestHandler<FindPrivilegeRequest, PrivilegeView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindPrivilegeRequestHandler(
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
        public async Task<PrivilegeView> Handle(
            FindPrivilegeRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .Privileges
               .Where(e => e.Id == request.Id)
               .ProjectTo<PrivilegeView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
