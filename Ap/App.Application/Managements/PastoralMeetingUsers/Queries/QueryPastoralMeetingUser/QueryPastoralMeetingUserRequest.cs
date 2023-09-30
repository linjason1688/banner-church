#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using App.Domain.Entities.Features;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.PastoralMeetingUsers.Queries.QueryPastoralMeetingUser
{
    /// <summary>
    /// 分頁查詢 PastoralMeetingUser
    /// </summary>

    public class QueryPastoralMeetingUserRequest 
        : PageableQuery, IRequest<Page<PastoralMeetingUserView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// PastoralMeeting.Id
        /// </summary>
        public long PastoralMeetingId { get; set; }



        /// <summary>
        /// User.Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 是否聚會出席狀態        對應SystemConfig        type = MeetAttendanceType顯示 namevalue存此欄位0：尚未開課1：已出席2:未出席
        /// </summary>
        public int MeetAttendanceType { get; set; }
    }

    /// <summary>
    ///  分頁查詢 PastoralMeetingUser
    /// </summary>
    public class QueryPastoralMeetingUserRequestHandler 
        : IRequestHandler<QueryPastoralMeetingUserRequest, Page<PastoralMeetingUserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryPastoralMeetingUserRequestHandler(
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
        public async Task<Page<PastoralMeetingUserView>> Handle(
            QueryPastoralMeetingUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .PastoralMeetingUsers
               .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)////會員出席聚會狀態.id
               .WhereWhen(Convert.ToInt64(request.PastoralMeetingId ) != 0, c => c.PastoralMeetingId == request.PastoralMeetingId )////PastoralMeeting.Id
                .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id

                .WhereWhenNotEmpty(request.MeetAttendanceType.ToString(), c => c.MeetAttendanceType == request.MeetAttendanceType)//是否聚會出席狀態對應SystemConfigtype = MeetAttendanceType顯示 namevalue存此欄位0：尚未開課1：已出席2:未出席"

               .ProjectTo<PastoralMeetingUserView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
