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
using App.Application.Managements.LessionCategorys.ModLessionCategorys.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.LessionCategorys.ModLessionCategorys.Queries.FetchAllModLessionCategory
{
    /// <summary>
    /// 查詢  ModLessionCategory 所有資料
    /// </summary>

    public class FetchAllModLessionCategoryRequest 
        : IRequest<List<ModLessionCategoryView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModLessionCategoryHandler 
        : IRequestHandler<FetchAllModLessionCategoryRequest, List<ModLessionCategoryView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllModLessionCategoryHandler(
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
        public async Task<List<ModLessionCategoryView>> Handle(
            FetchAllModLessionCategoryRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModLessionCategories
               .ApplyLimitConstraint(request)
               .ProjectTo<ModLessionCategoryView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
