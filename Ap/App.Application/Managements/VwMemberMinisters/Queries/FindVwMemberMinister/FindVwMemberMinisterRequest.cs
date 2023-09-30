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
using App.Application.Managements.VwMemberMinisters.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwMemberMinisters.Queries.FindVwMemberMinister
{
    /// <summary>
    /// 取得  VwMemberMinister 單筆明細
    /// </summary>

    public class FindVwMemberMinisterRequest 
        : IRequest<VwMemberMinisterView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberMinisterRequestHandler 
        : IRequestHandler<FindVwMemberMinisterRequest, VwMemberMinisterView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwMemberMinisterRequestHandler(
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
        public async Task<VwMemberMinisterView> Handle(
            FindVwMemberMinisterRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwMemberMinisters
               .Where(e => e.Id == request.Id)
               .ProjectTo<VwMemberMinisterView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
