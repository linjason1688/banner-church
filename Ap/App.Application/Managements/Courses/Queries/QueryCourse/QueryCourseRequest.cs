#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Courses.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using System.Linq;
using App.Application.Managements.CourseAppendixs.Dtos;
using Microsoft.EntityFrameworkCore;
using App.Application.Managements.CoursePrices.Dtos;
using App.Application.Managements.CourseTimeSchedules.Dtos;
using App.Application.Managements.CourseTimeScheduleTeachers.Dtos;
using App.Application.Managements.CourseManagementFilters.Dtos;
using App.Domain.Entities.Features;
using App.Application.Managements.Questionnaires.Dtos;
using App.Application.Managements.CourseOrganizations.Dtos;
using App.Application.Managements.Organizations.Dtos;

#endregion

namespace App.Application.Managements.Courses.Queries.QueryCourse
{
    /// <summary>
    /// 分頁查詢 Course
    /// </summary>
    public class QueryCourseRequest
        : PageableQuery, IRequest<Page<CourseView>>
    {
        /// <summary>
        /// id
        /// </summary>
        public long? Id { get; set; }

        ///  <summary>
        ///課程類別CourseManagement.Id
        /// </summary>
        public long? CourseManagementId { get; set; }

        ///  <summary>
        ///Organization.Id
        /// </summary>
        public long? OrganizationId { get; set; }

        ///  <summary>
        ///Questionnaire.Id 問卷Id
        /// </summary>
        public long? QuestionnaireId { get; set; }

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
        ///開課日
        /// </summary>
        public DateTime? OpenDate { get; set; }

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

        ///  <summary>
        ///優惠報名截止日
        /// </summary>
        public DateTime? DiscountSignUpDate { get; set; }

        ///  <summary>
        ///報名方式對應type=CourseSignUpType顯示 namevalue存此欄位0：一般臨櫃1：網路報名
        /// </summary>
        public string CourseSignUpType { get; set; }

        ///  <summary>
        ///最少志願數
        /// </summary>
        public int WishCount { get; set; }

        ///  <summary>
        ///是否需要推薦對應type=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string NeedRecommend { get; set; }

        ///  <summary>
        ///新朋友可報名對應type=IsYN顯示 namevalue存此欄位0：N1：Y
        /// </summary>
        public string AcceptNewMember { get; set; }

        ///  <summary>
        ///課程說明/資格
        /// </summary>
        public string Description { get; set; }

        ///  <summary>
        ///上課堂數
        /// </summary>
        public int CourseCount { get; set; }

        ///  <summary>
        ///報名名額
        /// </summary>
        public int Quota { get; set; }

        ///  <summary>
        ///結業狀態對應type=GraduationType顯示 namevalue存此欄位0：未結業1：已結業 2:-
        /// </summary>
        public string GraduationType { get; set; }

        ///  <summary>
        ///作業繳交日期
        /// </summary>
        public DateTime HomeworkDate { get; set; }

        /// <summary>
        /// 查尋字串
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// 課程型態：實體、線上
        /// </summary>
        public List<string> CourseType { get; set; }

        /// <summary>
        /// 開課日期起日
        /// </summary>
        public DateTime? OpenDateS { get; set; }

        /// <summary>
        /// 開課日期迄日
        /// </summary>
        public DateTime? OpenDateE { get; set; }

        /// <summary>
        /// 開課堂點
        /// </summary>
        public List<long> Organizations { get; set; }


        /// <summary>
        /// ModeConditions：經典課程0         最新課程：1 要有幾天內建的資料當條件?   即將結束課程：2 要判斷 報名結束幾天內的條件?
        /// </summary>
        /// <remarks>
        /// 經典課程0
        /// 最新課程：1 要有幾天內建的資料當條件?
        /// 即將結束課程：2 要判斷 報名結束幾天內的條件?
        /// </remarks>
        public string SearchModeConditions { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusCd { get; set; }


        ///  <summary>
        ///課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }


        ///  <summary>
        ///課程標題
        /// </summary>
        public string CourseManagementTitle { get; set; }

        ///  <summary>
        ///課程內容描述
        /// </summary>
        public string CourseManagementDescription { get; set; }

        /// <summary>
        /// CourseIsFilter：是否有擋修 0否 1是
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public string CourseIsFilter { get; set; }

    }

    /// <summary>
    ///  分頁查詢 Course
    /// </summary>
    public class QueryCourseRequestHandler
        : IRequestHandler<QueryCourseRequest, Page<CourseView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryCourseRequestHandler(
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
        public async Task<Page<CourseView>> Handle(
            QueryCourseRequest request,
            CancellationToken cancellationToken
        )
        {


            var main = this.appDbContext.Courses



              .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//教會開課主檔
              .WhereWhen(Convert.ToInt64(request.CourseManagementId) > 0, c => c.CourseManagementId == request.CourseManagementId)//課程類別CourseManagement.Id
              .WhereWhen(Convert.ToInt64(request.OrganizationId) > 0, c => c.OrganizationId == request.OrganizationId)

              .WhereWhenNotEmpty(request.Year, c => c.Year == request.Year)//屆別

              .WhereWhenNotEmpty(request.Season, c => c.Season == request.Season)//
              .WhereWhenNotEmpty(request.ClassNum, c => c.ClassNum == request.ClassNum)//



              .WhereWhen(request.OpenDateS != null, c => c.OpenDateS == request.OpenDateS)//開課日期起
              .WhereWhen(request.OpenDateE != null, c => c.OpenDateE == request.OpenDateE)//開課日期迄


              .WhereWhen(request.Organizations != null && request.Organizations.Any(), c => request.Organizations.Contains(c.OrganizationId.Value))
              .WhereWhen(request.SignUpDateS != null, c => c.SignUpDateS == request.SignUpDateS)//報名日期
              .WhereWhen(request.SignUpDateE != null, c => c.SignUpDateE == request.SignUpDateE)//報名截止日



              .WhereWhen(request.CounterSignUpDateS != null, c => c.CounterSignUpDateS == request.CounterSignUpDateS)//報名日期(臨櫃)
              .WhereWhen(request.CounterSignUpDateE != null, c => c.CounterSignUpDateE == request.CounterSignUpDateE)//報名截止日(臨櫃)
              .WhereWhen(request.DiscountSignUpDate != null, c => c.DiscountSignUpDate == request.DiscountSignUpDate)//優惠報名截止日
              .WhereWhenNotEmpty(request.CourseSignUpType, c => c.CourseSignUpType == request.CourseSignUpType)//報名方式對應type=CourseSignUpType顯示 namevalue存此欄位0：一般臨櫃1：網路報名
              .WhereWhen(request.WishCount != 0, c => c.WishCount == request.WishCount)//最少志願數
              .WhereWhenNotEmpty(request.NeedRecommend, c => c.NeedRecommend == request.NeedRecommend)//是否需要推薦對應type=IsYN顯示 namevalue存此欄位0：N1：Y
              .WhereWhenNotEmpty(request.AcceptNewMember, c => c.AcceptNewMember == request.AcceptNewMember)//新朋友可報名對應type=IsYN顯示 namevalue存此欄位0：N1：Y
              .WhereWhenNotEmpty(request.Description, c => c.Description == request.Description)//課程說明/資格
              .WhereWhen(request.CourseCount != 0, c => c.CourseCount == request.CourseCount)//上課堂數
              .WhereWhen(request.Quota != 0, c => c.Quota == request.Quota)//報名名額
                                                                           //.WhereWhenNotEmpty(request.SearchText, c => c.Name.Contains(request.SearchText))
              .WhereWhenNotEmpty(request.Name, c => c.Name.Contains(request.Name))
              .WhereWhenNotEmpty(request.StatusCd, c => c.StatusCd == request.StatusCd)
              .WhereWhenNotEmpty(request.GraduationType, c => c.GraduationType == request.GraduationType); //結業狀態


            var Mst = this.appDbContext.CourseManagements
              .WhereWhenNotEmpty(request.CourseManagementNo, c => c.CourseManagementNo == request.CourseManagementNo)
              .WhereWhenNotEmpty(request.CourseManagementTitle, c => c.Title == request.CourseManagementTitle)
              .WhereWhenNotEmpty(request.CourseManagementDescription, c => c.Description == request.CourseManagementDescription);
            var CMFst = this.appDbContext.CourseManagementFilters;
            var CMFCst = this.appDbContext.CourseManagementFilterCourses;
            var CMFPst = this.appDbContext.CourseManagementFilterPastorals;
            var CMFRst = this.appDbContext.CourseManagementFilterResps;

            //另外回傳的View資料要加上CourseManagement.CourseManagementNo 永久課程代碼
            //另外回傳的View資料要加上CourseManagement.Title              永久課程分類
            //另外回傳的View資料要加上CourseManagement.Description        永久課程名稱
            //toFixed
            if (!string.IsNullOrEmpty(request.CourseManagementNo) || !string.IsNullOrEmpty(request.CourseManagementTitle) || !string.IsNullOrEmpty(request.CourseManagementDescription))
            {
                main.WhereWhen(Mst.Count() > 0, c => c.CourseManagementId.HasValue &&
                                                     Mst.Select(c => c.Id).Contains(c.CourseManagementId.Value));
            }

            //main.CourseManagementId 要包含在 CMFst.Id or CMFCst.Id  or CMFPst.Id  or CMFRst.Id
            main.WhereWhen(request.CourseIsFilter == "1",
                           c => c.CourseManagementId.HasValue &&
                                (CMFst.Select(c => c.Id).Contains(c.CourseManagementId.Value) ||
                                 CMFCst.Select(c => c.Id).Contains(c.CourseManagementId.Value) ||
                                 CMFPst.Select(c => c.Id).Contains(c.CourseManagementId.Value) ||
                                 CMFRst.Select(c => c.Id).Contains(c.CourseManagementId.Value)));




            //再抓取CourseManagemantFilter
            var CourseManagemantFilterLst =
                this.appDbContext.CourseManagementFilters
                             .Where(f => main.Select(c => c.CourseManagementFilterId).Contains(f.Id)).FirstOrDefault();


            // ModeConditions：經典課程0         最新課程：1 要有幾天內建的資料當條件?   即將結束課程：2 要判斷 報名結束幾天內的條件?
            if (!string.IsNullOrEmpty(request.SearchModeConditions))
            {
                if (request.SearchModeConditions == "0")
                {
                }

                else if (request.SearchModeConditions == "1")
                {
                    var NewCourseDate = DateTime.Now.AddDays(5);//五天內新建的課程
                    main.WhereWhen(request.SearchModeConditions == "1", c => c.DateCreate <= NewCourseDate && c.DateCreate >= DateTime.Now);
                }
                else if (request.SearchModeConditions == "2")
                {
                    var NewCourseDate = DateTime.Now.AddDays(5);//即將報名結束五天的課程
                    main.WhereWhen(request.SearchModeConditions == "2", c => c.SignUpDateE <= NewCourseDate && c.SignUpDateS <= DateTime.Now);
                }
            }


            var sodLst = from x in this.appDbContext.ShoppingOrderDetails
                                       .Where(c => main.Select(c => c.Id).Contains(c.CourseId))
                         group x by new { x.CourseId } into g
                         select new
                         {
                             CourseId = g.Key.CourseId,
                             SignUpCount = (int?) g.Count(),
                             PaymentCount = (int?) g.Count(c => c.OrderDetailStatus != "0")
                         };

            var usrLst = from x in this.appDbContext.UserCourses
                           .Where(c => main.Select(c => c.Id).Contains(c.CourseId))
                         group x by new { x.CourseId } into g
                         select new
                         {
                             CourseId = g.Key.CourseId,
                             StudentCount = (int?) g.Count()
                         };





            var crmLst = this.appDbContext.CourseManagements
                             .Where(c => main.Select(c => c.CourseManagementId).Contains(c.Id));

            var crmtLst = this.appDbContext.CourseManagementTypes
                 .Where(c => crmLst.Select(c => c.CourseManagementTypeId).Contains(c.Id));


            var ctsLst = await this.appDbContext.CourseTimeSchedules
                                   .Where(c => main.Select(c => c.Id).Contains(c.CourseId))
                                   .ProjectTo<CourseTimeScheduleView>(this.mapper.ConfigurationProvider)
                                   .ToListAsync(cancellationToken);

            var teaLst = await this.appDbContext.CourseTimeScheduleTeachers
                         .Where(c => ctsLst.Select(c => c.Id).Contains(c.CourseTimeScheduleId))
                         .ProjectTo<CourseTimeScheduleTeacherView>(this.mapper.ConfigurationProvider)
                         .ToListAsync(cancellationToken);
            ctsLst.ForEach(c => c.CourseTimeScheduleTeachers =
                                teaLst.Where(d => d.CourseTimeScheduleId == c.Id).ToList());

            //CourseOrganizationView
            var orgLst = await this.appDbContext.CourseOrganizations
                                   .Where(c => main.Select(c => c.Id).Contains(c.CourseId))
                                   .ProjectTo<CourseOrganizationView>(this.mapper.ConfigurationProvider)
                                   .ToListAsync(cancellationToken);

            var orgArr = await this.appDbContext.Organizations
                       .Where(c => orgLst.Select(d => d.OrganizationId).Distinct().Contains(c.Id))
                       .ProjectTo<OrganizationView>(this.mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);
            foreach (var org in orgLst)
            {
                org.organization = orgArr.FirstOrDefault(c => c.Id == org.OrganizationId);
            }


            var prsLst = await this.appDbContext.CoursePrices
                                   .Where(c => main.Select(c => c.Id).Contains(c.CourseId))
                                   .ProjectTo<CoursePriceView>(this.mapper.ConfigurationProvider)
                                   .ToListAsync(cancellationToken);

            var cadLst = await this.appDbContext.CourseAppendixs
                       .Where(c => main.Select(c => c.Id).Contains(c.CourseId))
                       .ProjectTo<CourseAppendixBase>(this.mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);
            //確認是否有擋修條件
            var isFilterCourse = "0";
            if (CMFst.Count() > 0 || CMFCst.Count() > 0 || CMFPst.Count() > 0 || CMFRst.Count() > 0)
            {
                isFilterCourse = "1"; //有擋修
            }

            var result = from m in main
                         join sod in sodLst on m.Id equals sod.CourseId into lst1
                         from sod in lst1.DefaultIfEmpty()
                             //join cts in ctsLst on m.Id equals cts.CourseId into lst2
                             //from cts in lst2.DefaultIfEmpty()
                         join usr in usrLst on m.Id equals usr.CourseId into lst3
                         from usr in lst3.DefaultIfEmpty()
                         join crm in crmLst on m.CourseManagementId equals crm.Id into lst4
                         from crm in lst4.DefaultIfEmpty()

                         join crmt in crmtLst on crm.CourseManagementTypeId equals crmt.Id                          
                         into lst5
                         from crmt in lst5.DefaultIfEmpty()

                             //join price in this.appDbContext.CoursePrices on m.Id equals price.CourseId into lst5
                             //from coursePrices in lst5.DefaultIfEmpty()
                         select new CourseView
                         {
                             Id = m.Id,
                             DateCreate = m.DateCreate,
                             CourseManagementId = m.CourseManagementId.Value,
                             OrganizationId = m.OrganizationId.Value,
                             QuestionnaireId = m.QuestionnaireId,
                             Year = m.Year,
                             Name = m.Name,
                             ClassNum = m.ClassNum,
                             Season = m.Season,
                             OpenDateS = m.OpenDateS,
                             OpenDateE = m.OpenDateE,
                             SignUpDateS = m.SignUpDateS,
                             SignUpDateE = m.SignUpDateE,
                             DiscountSignUpDate = m.DiscountSignUpDate,
                             CourseSignUpType = m.CourseSignUpType,
                             WishCount = m.WishCount,
                             NeedRecommend = m.NeedRecommend,
                             AcceptNewMember = m.AcceptNewMember,
                             Description = m.Description,
                             //CourseCount = c.CourseCount,
                             Quota = m.Quota,
                             GraduationType = m.GraduationType,
                             SpecialRequirement = m.SpecialRequirement,
                             GraduationQualification = m.GraduationQualification,
                             CourseContext = m.CourseContext,
                             HomeworkDate = m.HomeworkDate,
                             StatusCd = m.StatusCd,
                             SignUpCount = sod.SignUpCount ?? 0,
                             PaymentCount = sod.PaymentCount ?? 0,
                             StudentCount = usr.StudentCount ?? 0,
                             CourseManagementTitle = crm.Title,
                             CourseManagementNo = crm.CourseManagementNo,
                             CourseManagementDescription = crm.Description,
                             CourseIsFilter = isFilterCourse,
                             CourseManagementTypeName= crmt.Name,
                             
                             
                             //關聯子表
                             CourseManagementFilter = CourseManagemantFilterLst != null ? this.mapper.Map<CourseManagementFilterView>(CourseManagemantFilterLst) : null,                 

                         };
           
            var fin = await result
                            .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                            .ToPageAsync(request);

            foreach (var obj in fin.Records)
            {


                obj.CourseOrganizations=orgLst.Where(c => c.CourseId == obj.Id).ToList();
                obj.CoursePrices = prsLst.Where(c => c.CourseId == obj.Id).ToList();
                var lst = ctsLst.Where(c => c.CourseId == obj.Id).ToList();
                obj.CourseTimeSchedules = lst;
                obj.CourseInformations = string.Join("<BR>", lst.Select(c => $"{c.Place} {c.ClassDay} {c.ClassTimeS} {c.ClassTimeE}"));

                obj.CourseAppendices = cadLst.Where(c => c.CourseId == obj.Id).ToList();
                ////FIXME: 改為查 Course
                //obj.CourseAppendices = new List<CourseAppendixBase>
                //{
                //    new(0, "3", "0eb3d85d-54c9-4432-b4fc-0e52a18568e8"),
                //    new(0, "2", "29e84221-af60-4f20-9824-e44715b5351a"),
                //};
            }
            return fin;

            //return await this.appDbContext
            //   .Courses
            //   .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id)//教會開課主檔
            //   .WhereWhen(Convert.ToInt64(request.CourseManagementId) != 0, c => c.CourseManagementId == request.CourseManagementId)//課程類別CourseManagement.Id
            //   .WhereWhen( Convert.ToInt64(request.OrganizationId) != 0, c => c.OrganizationId == request.OrganizationId)
            //   .WhereWhenNotEmpty(request.Year, c => c.Year == request.Year)//屆別
            //   .WhereWhen(request.OpenDate != null, c => c.OpenDate == request.OpenDate)//開課日
            //   .WhereWhen(request.SignUpDateS != null, c => c.SignUpDateS == request.SignUpDateS)//報名日期
            //   .WhereWhen(request.SignUpDateE != null, c => c.SignUpDateE == request.SignUpDateE)//報名截止日
            //   .WhereWhen(request.DiscountSignUpDate != null, c => c.DiscountSignUpDate == request.DiscountSignUpDate)//優惠報名截止日
            //   .WhereWhenNotEmpty(request.CourseSignUpType, c => c.CourseSignUpType == request.CourseSignUpType)//報名方式對應type=CourseSignUpType顯示 namevalue存此欄位0：一般臨櫃1：網路報名
            //   .WhereWhen(request.WishCount != 0, c => c.WishCount == request.WishCount)//最少志願數
            //   .WhereWhenNotEmpty(request.NeedRecommend, c => c.NeedRecommend == request.NeedRecommend)//是否需要推薦對應type=IsYN顯示 namevalue存此欄位0：N1：Y
            //   .WhereWhenNotEmpty(request.AcceptNewMember, c => c.AcceptNewMember == request.AcceptNewMember)//新朋友可報名對應type=IsYN顯示 namevalue存此欄位0：N1：Y
            //   .WhereWhenNotEmpty(request.Description, c => c.Description == request.Description)//課程說明/資格
            //   .WhereWhen(request.CourseCount != 0, c => c.CourseCount == request.CourseCount)//上課堂數
            //   .WhereWhen(request.Quota != 0, c => c.Quota == request.Quota)//報名名額
            //   .WhereWhenNotEmpty(request.GraduationType, c => c.GraduationType == request.GraduationType)//結業狀態
            //   .WhereWhenNotEmpty(request.Season, c => c.Season == request.Season)//季
            //   .WhereWhenNotEmpty(request.ClassNum, c => c.ClassNum == request.ClassNum)//梯次
            //   .ProjectTo<CourseView>(this.mapper.ConfigurationProvider)
            //   .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
            //   .ToPageAsync(request);
        }
    }
}
