#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Attributes;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Common.Interfaces.Services;
using App.Application.Managements.VwMemberTags.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.VwMemberTags.Queries.FetchAllVwMemberTag
{
    /// <summary>
    /// 查詢  VwMemberTag 所有資料
    /// </summary>

    public class FetchAllVwMemberTagRequest 
        : IRequest<List<VwMemberTagView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwMemberTagHandler 
        : IRequestHandler<FetchAllVwMemberTagRequest, List<VwMemberTagView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllVwMemberTagHandler(
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
        public async Task<List<VwMemberTagView>> Handle(
            FetchAllVwMemberTagRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .VwMemberTags
               .ApplyLimitConstraint(request)
               .ProjectTo<VwMemberTagView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
