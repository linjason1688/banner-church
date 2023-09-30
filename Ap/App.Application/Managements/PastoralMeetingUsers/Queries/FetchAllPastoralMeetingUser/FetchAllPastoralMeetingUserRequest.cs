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
using App.Application.Managements.PastoralMeetingUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Queries.FetchAllPastoralMeetingUser
{
    /// <summary>
    /// 查詢  PastoralMeetingUser 所有資料
    /// </summary>

    public class FetchAllPastoralMeetingUserRequest 
        : IRequest<List<PastoralMeetingUserView>>, ILimitedFetch
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
    public class FetchAllPastoralMeetingUserHandler 
        : IRequestHandler<FetchAllPastoralMeetingUserRequest, List<PastoralMeetingUserView>>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FetchAllPastoralMeetingUserHandler(
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
        public async Task<List<PastoralMeetingUserView>> Handle(
            FetchAllPastoralMeetingUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .PastoralMeetingUsers
               .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id

               .ApplyLimitConstraint(request)
               .ProjectTo<PastoralMeetingUserView>(this.mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
