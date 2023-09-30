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
using App.Application.Managements.VwAspnetMembershipUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Queries.FindVwAspnetMembershipuser
{
    /// <summary>
    /// 取得  VwAspnetMembershipuser 單筆明細
    /// </summary>

    public class FindVwAspnetMembershipuserRequest 
        : IRequest<VwAspnetMembershipuserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetMembershipuserRequestHandler 
        : IRequestHandler<FindVwAspnetMembershipuserRequest, VwAspnetMembershipuserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwAspnetMembershipuserRequestHandler(
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
        public async Task<VwAspnetMembershipuserView> Handle(
            FindVwAspnetMembershipuserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwAspnetMembershipUsers
               //.Where(e => e.Id == request.Id)
               .ProjectTo<VwAspnetMembershipuserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
