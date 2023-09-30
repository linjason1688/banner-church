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
using App.Application.Managements.VwCheckInMemberClasses.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwCheckInMemberClasses.Queries.FindVwCheckInMemberClass
{
    /// <summary>
    /// 取得  VwCheckInMemberClass 單筆明細
    /// </summary>

    public class FindVwCheckInMemberClassRequest 
        : IRequest<VwCheckInMemberClassView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwCheckInMemberClassRequestHandler 
        : IRequestHandler<FindVwCheckInMemberClassRequest, VwCheckInMemberClassView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwCheckInMemberClassRequestHandler(
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
        public async Task<VwCheckInMemberClassView> Handle(
            FindVwCheckInMemberClassRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwCheckInMemberClasses
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwCheckInMemberClassView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
