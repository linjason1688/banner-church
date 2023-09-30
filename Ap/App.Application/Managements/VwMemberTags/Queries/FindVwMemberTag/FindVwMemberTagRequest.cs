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
using App.Application.Managements.VwMemberTags.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwMemberTags.Queries.FindVwMemberTag
{
    /// <summary>
    /// 取得  VwMemberTag 單筆明細
    /// </summary>

    public class FindVwMemberTagRequest 
        : IRequest<VwMemberTagView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberTagRequestHandler 
        : IRequestHandler<FindVwMemberTagRequest, VwMemberTagView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindVwMemberTagRequestHandler(
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
        public async Task<VwMemberTagView> Handle(
            FindVwMemberTagRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwMemberTags
               //.Where(e => e.Id == request.Id)
               .ProjectTo<VwMemberTagView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
