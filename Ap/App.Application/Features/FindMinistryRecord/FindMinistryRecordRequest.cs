using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Ministries.Dtos;
using App.Application.Managements.Ministries.Queries.FindMinistry;
using App.Application.Managements.MinistryDefs.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension;

namespace App.Application.Features.FindMinistryRecord
{
    public class FindMinistryRecordRequest : IRequest<MinistryRecordView>
    {
        /// <summary>
        /// 事工團分類
        /// </summary>
        public string MinistryDefName { get; set; }


        /// <summary>
        /// 事工團名稱
        /// </summary>
        public string MinistryName { get; set; }

        /// <summary>
        /// 出席狀態
        /// </summary>
        public int? MeetAttendanceType { get; set; }

        /// <summary>
        /// 事工團異動記錄
        /// </summary>
        public int? MinistryRespUserStatus { get; set; }

        /// <summary>
        /// 出席日期
        /// </summary>
        public DateTime? MeetingDayS { get; set; }

        /// <summary>
        /// 出席日期
        /// </summary>
        public DateTime? MeetingDayE { get; set; }
    }

    public class FindMinistryRecordRequestHandler
       : IRequestHandler<FindMinistryRecordRequest, MinistryRecordView>
    {
        private readonly IMapper mapper;
        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public FindMinistryRecordRequestHandler(
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
        public async Task<MinistryRecordView> Handle(
            FindMinistryRecordRequest request,
            CancellationToken cancellationToken
        )
        {
            var lst = from m in this.appDbContext.Ministries
                      join mr in this.appDbContext.MinistryResps on m.Id equals mr.MinistryId into mrs
                      from mr in mrs.DefaultIfEmpty()
                      join mru in this.appDbContext.MinistryRespUsers on mr.Id equals mru.MinistryRespId into mrus
                      from mru in mrus.DefaultIfEmpty()
                      join md in this.appDbContext.MinistryDefs on m.MinistryDefId equals md.Id into mds
                      from md in mds.DefaultIfEmpty()
                      select new
                      {
                          MinistryId = m.Id,
                          MinistryName = m.Name,
                          MinistryRespID = mr.Id,
                          MinistryRespName = mr.Name,
                          MinistryDefId = m.MinistryDefId,
                          MinistryDefNo = md.MinistryDefNo,
                          MinistryDefName = md.Name,
                          MinistryRespUserStatus = mru.MinistryRespUserStatus,
                          HandledId = m.HandledId,
                          DateCreate = m.DateCreate,
                          UserCreate = m.UserCreate,
                          DateUpdate = m.DateUpdate,
                          UserUpdate = m.UserUpdate,
                      };

            var fin = from m in lst
                      join mm in this.appDbContext.MinistryMeetings on m.MinistryId equals mm.MinistryId into mms
                      from mm in mms.DefaultIfEmpty()
                      join mmu in this.appDbContext.MinistryMeetingUsers on mm.Id equals mmu.MinistryMeetingId into mmus
                      from mmu in mmus.DefaultIfEmpty()
                      select new MinistryRecordView()
                      {
                          // Id = m.MinistryId,
                          MinistryDefName = m.MinistryDefName,  //事工團分類
                          MinistryName = m.MinistryName,        // 事工團名稱
                          MinistryRespName = m.MinistryRespName,    //事工團職分名稱
                          MeetAttendanceType = mmu.MeetAttendanceType,  //出席狀態
                          MinistryRespUserStatus = m.MinistryRespUserStatus, //事工團異動記錄
                          MeetingDay = mm.MeetingDay,
                          HandledId = m.HandledId,
                          DateCreate = m.DateCreate,
                          UserCreate = m.UserCreate,
                          DateUpdate = m.DateUpdate,
                          UserUpdate = m.UserUpdate,
                      };
            return await fin
                .WhereWhenNotEmpty(request.MinistryDefName, c => c.MinistryDefName == request.MinistryDefName)
                .WhereWhenNotEmpty(request.MinistryName, c => c.MinistryDefName == request.MinistryName)
                .WhereWhen(request.MeetAttendanceType.HasValue, c => c.MeetAttendanceType == request.MeetAttendanceType)
                .WhereWhen(request.MinistryRespUserStatus.HasValue, c => c.MinistryRespUserStatus == request.MinistryRespUserStatus)
                .WhereWhen(request.MeetingDayS.HasValue, c=>c.MeetingDay >= request.MeetingDayS.Value)
                .WhereWhen(request.MeetingDayE.HasValue, c => c.MeetingDay >= request.MeetingDayE.Value)
                .ProjectTo<MinistryRecordView>(this.mapper.ConfigurationProvider)
               .FindOneAsync(cancellationToken);





            //return await this.appDbContext
            //   .Ministries
            //   .Where(e => e.Id == request.Id)
            //   .ProjectTo<MinistryView>(this.mapper.ConfigurationProvider)
            //   .FindOneAsync(cancellationToken);
        }
    }
}
