#region

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.UserCourses.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.UserCourses.Queries.QueryUserCourse
{
    /// <summary>
    /// 分頁查詢 UserCourse
    /// </summary>

    public class QueryUserCourseRequest
        : PageableQuery, IRequest<Page<UserCourseView>>
    {

        /// <summary>
        ///  課程名稱
        /// </summary>
        public string CourseName { get; set; }


        ///  <summary>
        ///Organization.Id
        /// </summary>
        public long? OrganizationId { get; set; }

        /// <summary>
        ///  組織名稱
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        ///  主任牧師名稱
        /// </summary>
        public string PastorName { get; set; }

        ///  <summary>
        ///代號/梯次
        /// </summary>
        public string ScheduleNo { get; set; }

        ///  <summary>
        ///附件類別對應type=ClassDay顯示 namevalue存此欄位1：一2：二….
        /// </summary>
        public string ClassDay { get; set; }

        ///  <summary>
        ///開始時間
        /// </summary>
        public string ClassTimeS { get; set; }
        ///  <summary>
        ///結束時間
        /// </summary>
        public string ClassTimeE { get; set; }
        ///  <summary>
        ///地點
        /// </summary>
        public string Place { get; set; }

        ///  <summary>
        ///課程類別CourseManagementType.Id
        /// </summary>
        public long? CourseManagementTypeId { get; set; }

        ///  <summary>
        ///課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }


        ///  <summary>
        ///課程作業繳交日期
        /// </summary>
        public DateTime HomeworkDate { get; set; }

        ///  <summary>
        ///課程標題
        /// </summary>
        public string Title { get; set; }
        ///  <summary>
        ///課程內容描述
        /// </summary>
        public string Description { get; set; }
        ///  <summary>
        ///課程狀態對應type=CourseManagementStatus顯示 namevalue存此欄位0：關閉1：開啟
        /// </summary>
        public string CourseManagementStatus { get; set; }

        /// <summary>
        /// 課程類別編號
        /// </summary>
        public string CourseManagementTypeNo { get; set; }

        /// <summary>
        /// 課程類別名稱
        /// </summary>
        public string CourseManagementTypeName { get; set; }

        /// <summary>
        /// 開課狀態 : 0 - 未開，1 - 上課中，2 - 結束
        /// </summary>
        public string CourseStatus { get; set; }

        /// <summary>
        /// 開課班級與時段
        /// </summary>
        public string CourseClassSchedule { get; set; }



        ///  <summary>
        ///年度 屆別
        /// </summary>
        public string Year { get; set; }

        ///  <summary>
        ///名稱
        /// </summary>
        public string Name { get; set; }

        ///  <summary>
        ///梯次
        /// </summary>
        public string ClassNum { get; set; }

        ///  <summary>
        ///季
        /// </summary>
        public string Season { get; set; }



        ///  <summary>
        ///開課日起
        /// </summary>
        public DateTime? OpenDateS { get; set; }

        ///  <summary>
        ///開課日迄
        /// </summary>
        public DateTime? OpenDateE { get; set; }




        ///  <summary>
        ///報名日期(線上)
        /// </summary>
        public DateTime? SignUpDateS { get; set; }
        ///  <summary>
        ///報名截止日(線上)
        /// </summary>
        public DateTime? SignUpDateE { get; set; }


        ///  <summary>
        ///報名日期(臨櫃)
        /// </summary>
        public DateTime? CounterSignUpDateS { get; set; }
        ///  <summary>
        ///報名截止日(臨櫃)
        /// </summary>
        public DateTime? CounterSignUpDateE { get; set; }


        /// <summary>
        /// 用戶 Id
        /// </summary>
        public long? UserId { get; set; }
    }

    /// <summary>
    ///  分頁查詢 UserCourse
    /// </summary>
    public class QueryUserCourseRequestHandler
        : IRequestHandler<QueryUserCourseRequest, Page<UserCourseView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserCourseRequestHandler(
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
        public async Task<Page<UserCourseView>> Handle(
            QueryUserCourseRequest request,
            CancellationToken cancellationToken
        )
        {
            var filteredCourses = this.appDbContext.Courses
               .WhereWhen(request.OrganizationId.HasValue, c => c.OrganizationId == request.OrganizationId && c.OrganizationId!=0)//堂點
               .WhereWhenNotEmpty(request.CourseName, c => c.Name == request.CourseName)//課程名稱
               .WhereWhenNotEmpty(request.Year, c => c.Year == request.Year)//年度
               .WhereWhenNotEmpty(request.Season, c => c.Season == request.Season)//季
               .WhereWhenNotEmpty(request.ClassNum, c => c.ClassNum == request.ClassNum)//梯次
               .WhereWhen(request.SignUpDateS.HasValue, c => c.SignUpDateS >= request.SignUpDateS) //報名日起
               .WhereWhen(request.SignUpDateE.HasValue, c => c.SignUpDateE <= request.SignUpDateE) //報名日迄
               .WhereWhen(request.OpenDateS.HasValue, c => c.OpenDateS >= request.OpenDateS)//開課日期起日
               .WhereWhen(request.OpenDateE.HasValue, c => c.OpenDateE <= request.OpenDateE)//開課日期迄日
            ;

            var filterCourseManagements = this.appDbContext.CourseManagements
                    .WhereWhen(request.CourseManagementTypeId.HasValue, c => c.CourseManagementTypeId == request.CourseManagementTypeId)//課程類別
                ;

            var filterUserCourses = this.appDbContext.UserCourses
                   .WhereWhen(request.UserId.HasValue,c => c.UserId == request.UserId) //課程類別
                ;

            var lst = from uc in filterUserCourses
                      join c in filteredCourses on uc.CourseId equals c.Id into sub1
                      from result1 in sub1.DefaultIfEmpty()
                      join o in this.appDbContext.Organizations on result1.OrganizationId equals o.Id into sub2
                      from result2 in sub2.DefaultIfEmpty()
                      join cts in this.appDbContext.CourseTimeSchedules on result1.Id equals cts.CourseId into sub3
                      from result3 in sub3.DefaultIfEmpty()
                      join cm in filterCourseManagements on result1.CourseManagementId equals cm.Id into sub4
                      from result4 in sub4.DefaultIfEmpty()
                      join cmt in this.appDbContext.CourseManagementTypes on result4.CourseManagementTypeId equals cmt.Id into sub5
                      from result5 in sub5.DefaultIfEmpty()
                      select new UserCourseView
                      {
                          Id = uc.Id,
                          UserId = uc.UserId,
                          CourseId = uc.CourseId,
                          AttendanceType = uc.AttendanceType,
                          AttendanceDate = uc.AttendanceDate,
                          CourseName = result1!.Name,
                          OpenDateS = result1 == null ? default : result1.OpenDateS,
                          OpenDateE = result1 == null ? default : result1.OpenDateE,
                          OrganizationId = result2!.Id,
                          OrganizationName = result2!.Name,
                          PastorName = result2!.PastorName,
                          ScheduleNo = result3!.ScheduleNo,
                          ClassDay = result3!.ClassDay,
                          ClassTimeS = result3!.ClassTimeS,
                          ClassTimeE = result3!.ClassTimeE,
                          Place = result3!.Place,
                          CourseManagementTypeId = result4!.CourseManagementTypeId,
                          CourseManagementNo = result4!.CourseManagementNo,
                          HomeworkDate = result4!.HomeworkDate,
                          Title = result4!.Title,
                          Description = result4!.Description,
                          CourseManagementTypeNo = result5!.CourseManagementTypeNo,
                          CourseManagementStatus = result4!.CourseManagementStatus,
                          CourseManagementTypeName = result5!.Name,
                          CourseStatus = "1",
                          Season = result1!.Season,
                          ClassNum = result1!.ClassNum,
                          CourseTimeScheduleId = result3.Id,
                          CourseClassSchedule = result1 != null && result3 != null
                                                ? result1.ClassNum + result3.ClassTimeS + "-" + result3.ClassTimeE
                                                : "",
                      };
        

            return await lst.ToList().AsQueryable()
               .ProjectTo<UserCourseView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);
        }
    }
}
