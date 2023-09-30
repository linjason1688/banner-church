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
using App.Application.Managements.MinistryMeetingUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Queries.FindMinistryMeetingUser
{
    /// <summary>
    /// 取得  MinistryMeetingUser 單筆明細
    /// </summary>

    public class FindMinistryMeetingUserRequest 
        : IRequest<MinistryMeetingUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindMinistryMeetingUserRequestHandler 
        : IRequestHandler<FindMinistryMeetingUserRequest, MinistryMeetingUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMinistryMeetingUserRequestHandler(
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
        public async Task<MinistryMeetingUserView> Handle(
            FindMinistryMeetingUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .MinistryMeetingUsers
               .Where(e => e.Id == request.Id)
               .ProjectTo<MinistryMeetingUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
