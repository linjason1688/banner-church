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
using App.Application.Managements.UserExpertises.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.UserExpertises.Queries.FetchAllUserExpertise
{
    /// <summary>
    /// 查詢  UserExpertise 所有資料
    /// </summary>

    public class FetchAllUserExpertiseRequest 
        : IRequest<List<UserExpertiseView>>, ILimitedFetch
    {
        /// <inheritdoc />
    
        public int? Limit { get; set; }
        /// <summary>
        /// User.Id
        /// </summary>
        public long? UserId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserExpertiseHandler 
        : IRequestHandler<FetchAllUserExpertiseRequest, List<UserExpertiseView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllUserExpertiseHandler(
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
        public async Task<List<UserExpertiseView>> Handle(
            FetchAllUserExpertiseRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .UserExpertises
               .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id

               .ApplyLimitConstraint(request)
               .ProjectTo<UserExpertiseView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
