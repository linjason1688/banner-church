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
using App.Application.Managements.AspnetMemberships.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.AspnetMemberships.Queries.FindAspnetMembership
{
    /// <summary>
    /// 取得  AspnetMembership 單筆明細
    /// </summary>

    public class FindAspnetMembershipRequest 
        : IRequest<AspnetMembershipView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetMembershipRequestHandler 
        : IRequestHandler<FindAspnetMembershipRequest, AspnetMembershipView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindAspnetMembershipRequestHandler(
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
        public async Task<AspnetMembershipView> Handle(
            FindAspnetMembershipRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .AspnetMemberships
               //.Where(e => e.Id == request.Id)
               .ProjectTo<AspnetMembershipView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
