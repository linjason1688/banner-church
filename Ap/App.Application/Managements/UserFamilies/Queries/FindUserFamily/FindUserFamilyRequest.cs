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
using App.Application.Managements.UserFamilies.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserFamilies.Queries.FindUserFamily
{
    /// <summary>
    /// 取得  UserFamily 單筆明細
    /// </summary>

    public class FindUserFamilyRequest 
        : IRequest<UserFamilyView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindUserFamilyRequestHandler 
        : IRequestHandler<FindUserFamilyRequest, UserFamilyView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindUserFamilyRequestHandler(
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
        public async Task<UserFamilyView> Handle(
            FindUserFamilyRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserFamilies
               .Where(e => e.Id == request.Id)
               .ProjectTo<UserFamilyView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
