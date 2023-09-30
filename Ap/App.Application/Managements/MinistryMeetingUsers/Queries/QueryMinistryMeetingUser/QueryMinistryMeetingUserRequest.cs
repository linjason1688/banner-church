#region

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.MinistryMeetingUsers.Dtos;
using AutoMapper;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using App.Domain.Entities.Features;
using App.Application.Managements.MinistryMeetings.Dtos;

#endregion

namespace App.Application.Managements.MinistryMeetingUsers.Queries.QueryMinistryMeetingUser
{
    /// <summary>
    /// 分頁查詢 MinistryMeetingUser
    /// </summary>

    public class QueryMinistryMeetingUserRequest
        : PageableQuery, IRequest<Page<MinistryMeetingUserView>>
    {

        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// MinistryMeeting.Id
        /// </summary>
        public long? MinistryMeetingId { get; set; }


        /// <summary>
        /// User.Id
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 是否聚會出席狀態        對應SystemConfig        type = MeetAttendanceType顯示 namevalue存此欄位0：尚未開課1：已出席2:未出席
        /// </summary>
        /// 
        public int? AttendanceType { get; set; }


        /// <summary>
        /// MinistryDef.Name
        /// </summary>
        public string MinistryDefName { get; set; }


        /// <summary>
        /// MinistryDef.Id
        /// </summary>
        public long? MinistryDefId { get; set; }



        /// <summary>
        /// Ministry.Id
        /// </summary>
        public long? MinistryId { get; set; }

        /// <summary>
        /// Ministry.Name
        /// </summary>
        public string MinistryName { get; set; }

        /// <summary>
        /// MinistryResp.Name
        /// </summary>
        public string MinistryRespName { get; set; }

        /// <summary>
        /// MeetingDayS
        /// </summary>
        public DateTime? MeetingDayS { get; set; }

        /// <summary>
        /// MeetingDayS
        /// </summary>
        public DateTime? MeetingDayE { get; set; }

        /// <summary>
        /// 異動紀錄
        /// </summary>
        public int? MinistryRespUserStatus { get; set; }



    }

    /// <summary>
    ///  分頁查詢 MinistryMeetingUser
    /// </summary>
    public class QueryMinistryMeetingUserRequestHandler
        : IRequestHandler<QueryMinistryMeetingUserRequest, Page<MinistryMeetingUserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryMinistryMeetingUserRequestHandler(
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
        public async Task<Page<MinistryMeetingUserView>> Handle(
            QueryMinistryMeetingUserRequest request,
            CancellationToken cancellationToken
        )
        {

            var filter1 = this.appDbContext.MinistryDefs
                   .WhereWhenNotEmpty(request.MinistryDefName?.ToString(), c => c.Name == request.MinistryDefName) //MinistryDefName =>MinistryDef.Name
                   ;
            var filter2 = this.appDbContext.Ministries
                .WhereWhenNotEmpty(request.MinistryName?.ToString(), c => c.Name == request.MinistryName)
            .WhereWhen(Convert.ToInt64(request.MinistryId) != 0, c => c.Id == request.MinistryId);

            var filter3 = this.appDbContext.MinistryResps
                    .WhereWhenNotEmpty(request.MinistryRespName?.ToString(), c => c.Name == request.MinistryRespName)
                    ;

            var filter4 = this.appDbContext.MinistryMeetingUsers
               
                .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
               ;

            var filter5 = this.appDbContext.MinistryRespUsers
                //.WhereWhen(request.UserId > 0, c => c.UserId == request.UserId)
                .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
                                                                                                //
               ;

            #region 子表查詢，先Join一個IQueryable<MinistryMeetingUserView>，再加條件
            var lst = from mmu in filter4
                      join mm in this.appDbContext.MinistryMeetings on mmu.MinistryMeetingId equals mm.Id into subR
                      from result1 in subR.DefaultIfEmpty()
                      join m in filter2 on result1.MinistryId equals m.Id into subU
                      from result2 in subU.DefaultIfEmpty()
                      join md in filter1 on result2.MinistryDefId equals md.Id into subOu
                      from result3 in subOu.DefaultIfEmpty()
                      join mr in filter3 on result1.MinistryId equals mr.MinistryId into sub4
                      from result4 in sub4.DefaultIfEmpty()
                      join mru in filter5 on new { a = result4.Id, b = mmu.UserId }
                      equals new { a = mru.MinistryRespId, b = mru.UserId } into sub5  //and mru.userId=mmu.UserId
                      from result5 in sub5.DefaultIfEmpty()
                      select new MinistryMeetingUserView
                      {
                          Id = mmu.Id,
                          MinistryDefId = result2 != null ? result2.MinistryDefId : 0, 
                          MinistryMeetingId = mmu.Id,
                          UserId = mmu.UserId,
                          MeetAttendanceType = mmu.MeetAttendanceType,
                          MinistryRespUserStatus =  result5 != null ? result5.MinistryRespUserStatus.ToString() : null,
                          MinistryDefName = result3 != null ? result3.Name : null,
                          MinistryName = result2 != null ? result2.Name : null,
                          MinistryRespName = result4 != null ?  result4.Name : null,
                          MeetingDay = result1 != null ?  result1.MeetingDay: default,
                          MinistryId= result2 != null ? result2.Id : 0,
                          DateCreate = mmu.DateCreate,
                          UserCreate = mmu.UserCreate,
                          DateUpdate = mmu.DateUpdate,
                          UserUpdate = mmu.UserUpdate,
                          MeetingAddress = result1.MeetingAddress,
                          MeetingTime = result1.MeetingTime,
                          MeetingDayOfWeek = result1.MeetingDayOfWeek,
                      };

           return await lst
                    .WhereWhen(request.Id.HasValue, c => c.Id == request.Id)
                    .WhereWhen(request.MinistryMeetingId.HasValue, c => c.MinistryMeetingId == request.MinistryMeetingId)
                    .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)
                    .WhereWhen(request.AttendanceType != null, c => c.MeetAttendanceType == request.AttendanceType)
                    .WhereWhenNotEmpty(request.MinistryDefName?.ToString(), c => c.MinistryDefName == request.MinistryDefName)
                    .WhereWhen(request.MinistryDefId.HasValue, c => c.MinistryDefId == request.MinistryDefId.Value)
                    .WhereWhen(request.MeetingDayS.HasValue, c => c.MeetingDay >= request.MeetingDayS) //會議日期起
                    .WhereWhen(request.MeetingDayE.HasValue, c => c.MeetingDay <= request.MeetingDayE) //會議日期迄
                    .WhereWhenNotEmpty(request.MinistryName, c => c.MinistryName == request.MinistryName)
                    .WhereWhenNotEmpty(request.MinistryRespName, c => c.MinistryRespName == request.MinistryRespName)
                    .WhereWhen(request.MinistryId.HasValue, c => c.MinistryId == request.MinistryId)
                    .WhereWhenNotEmpty(request.MinistryRespUserStatus?.ToString(), c => c.MinistryRespUserStatus == request.MinistryRespUserStatus.ToString())
                    .Distinct()
                    .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                    .ToPageAsync(request);
            #endregion
        }
    }
}
