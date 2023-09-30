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
using App.Application.Managements.VwAspnetWebPartStateUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Queries.FindVwAspnetWebPartStateUser
{
    /// <summary>
    /// 取得  VwAspnetWebPartStateUser 單筆明細
    /// </summary>

    public class FindVwAspnetWebPartStateUserRequest 
        : IRequest<VwAspnetWebPartStateUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwAspnetWebPartStateUserRequestHandler 
        : IRequestHandler<FindVwAspnetWebPartStateUserRequest, VwAspnetWebPartStateUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwAspnetWebPartStateUserRequestHandler(
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
        public async Task<VwAspnetWebPartStateUserView> Handle(
            FindVwAspnetWebPartStateUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwAspnetWebPartStateUsers
               //.Where(e => e.Id == request.Id)
               .ProjectTo<VwAspnetWebPartStateUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
