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
using App.Application.Managements.VwMemberClasses.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwMemberClasses.Queries.FindVwMemberClass
{
    /// <summary>
    /// 取得  VwMemberClass 單筆明細
    /// </summary>

    public class FindVwMemberClassRequest 
        : IRequest<VwMemberClassView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberClassRequestHandler 
        : IRequestHandler<FindVwMemberClassRequest, VwMemberClassView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwMemberClassRequestHandler(
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
        public async Task<VwMemberClassView> Handle(
            FindVwMemberClassRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwMemberClasses
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwMemberClassView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
