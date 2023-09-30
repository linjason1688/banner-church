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
using App.Application.Managements.ClassTimes.ModClassTimes.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.ClassTimes.ModClassTimes.Queries.FetchAllModClassTime
{
    /// <summary>
    /// 查詢  ModClassTime 所有資料
    /// </summary>

    public class FetchAllModClassTimeRequest 
        : IRequest<List<ModClassTimeView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModClassTimeHandler 
        : IRequestHandler<FetchAllModClassTimeRequest, List<ModClassTimeView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllModClassTimeHandler(
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
        public async Task<List<ModClassTimeView>> Handle(
            FetchAllModClassTimeRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .ModClassTimes
               .ApplyLimitConstraint(request)
               .ProjectTo<ModClassTimeView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
