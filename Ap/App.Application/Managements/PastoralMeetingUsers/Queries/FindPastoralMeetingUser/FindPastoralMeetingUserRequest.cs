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
using App.Application.Managements.PastoralMeetingUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Queries.FindPastoralMeetingUser
{
    /// <summary>
    /// 取得  PastoralMeetingUser 單筆明細
    /// </summary>

    public class FindPastoralMeetingUserRequest 
        : IRequest<PastoralMeetingUserView>
    {
    
        public long Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FindPastoralMeetingUserRequestHandler 
        : IRequestHandler<FindPastoralMeetingUserRequest, PastoralMeetingUserView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindPastoralMeetingUserRequestHandler(
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
        public async Task<PastoralMeetingUserView> Handle(
            FindPastoralMeetingUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .PastoralMeetingUsers
               .Where(e => e.Id == request.Id)
               .ProjectTo<PastoralMeetingUserView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);
        }
    }
}
