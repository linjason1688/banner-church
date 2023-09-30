#region

using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Extensions;
using App.Application.Common.Interfaces;
using App.Application.Managements.Questionnaires.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using System;

#endregion

namespace App.Application.Managements.Questionnaires.Queries.QueryQuestionnaire
{
    /// <summary>
    /// 分頁查詢 Questionnaire
    /// </summary>
    public class QueryQuestionnaireRequest
        : PageableQuery, IRequest<Page<QuestionnaireView>>
    {
        ///  <summary>
        ///問卷Id
        /// </summary>
        public long? Id { get; set; }
        ///  <summary>
        ///問卷堂點類別        type=QuestionnaireJoinLocation       顯示 name     value存此欄位0：堂點
        /// </summary>
        public string QuestionnaireJoinLocation { get; set; }
        ///  <summary>
        ///問卷類型type=QuestionnaireType顯示 namevalue存此欄位0：課程問卷 1:服事徵召 2:一般問卷
        /// </summary>       
        public string QuestionnaireType { get; set; }

        ///  <summary>
        ///問卷名稱
        /// </summary>
        public string Name { get; set; }

        ///  <summary>
        ///問卷說明
        /// </summary>
        public string Description { get; set; }

        ///  <summary>
        ///指定堂點
        /// </summary>
        public long? OrganizationId { get; set; }
        ///  <summary>
        ///指定牧區
        /// </summary>
        public long? PastoralId { get; set; }
        ///  <summary>
        ///指定課程分類
        /// </summary>
        public long? CourseManagementTypeId { get; set; }
        ///  <summary>
        ///指定課程名稱
        /// </summary>
        public string CourseManagementName { get; set; }
        ///  <summary>
        ///指定年度
        /// </summary>
        public string CourseYear { get; set; }
        ///  <summary>
        ///指定季
        /// </summary>
        public string CourseSeason { get; set; }
        ///  <summary>
        ///指定梯次
        /// </summary>
        public string CourseClassNum { get; set; }
        ///  <summary>
        ///指定課程代碼
        /// </summary>
        public string CourseManagementNo { get; set; }
        ///  <summary>
        ///作業繳交日期起 courseHomeworkDate
        /// </summary>
        public DateTime? DateRangeS { get; set; }

        ///  <summary>
        ///作業繳交日期迄courseHomeworkDate
        /// </summary>
        public DateTime? DateRangeE { get; set; }

    }

    /// <summary>
    ///  分頁查詢 Questionnaire
    /// </summary>
    public class QueryQuestionnaireRequestHandler
        : IRequestHandler<QueryQuestionnaireRequest, Page<QuestionnaireView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryQuestionnaireRequestHandler(
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
        public async Task<Page<QuestionnaireView>> Handle(
            QueryQuestionnaireRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
                .Questionnaires
               
                .WhereWhen(Convert.ToInt64(request.Id) != 0, c => c.Id == request.Id)
                .WhereWhenNotEmpty(request.QuestionnaireJoinLocation, c => c.QuestionnaireJoinLocation == request.QuestionnaireJoinLocation)
                .WhereWhenNotEmpty(request.QuestionnaireType, c => c.QuestionnaireType == request.QuestionnaireType)
                .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name)
       
                .WhereWhen(Convert.ToInt64(request.CourseManagementTypeId) != 0, c => c.CourseManagementTypeId == request.CourseManagementTypeId)
                .WhereWhen(Convert.ToInt64(request.PastoralId) != 0, c => c.PastoralId == request.PastoralId)
                .WhereWhenNotEmpty(request.CourseManagementName, c => c.CourseManagementName == request.CourseManagementName)
                .WhereWhenNotEmpty(request.CourseYear, c => c.CourseYear == request.CourseYear)
                .WhereWhenNotEmpty(request.CourseSeason, c => c.CourseSeason == request.CourseSeason)
                .WhereWhenNotEmpty(request.CourseClassNum, c => c.CourseClassNum == request.CourseClassNum)
                .WhereWhenNotEmpty(request.CourseManagementNo, c => c.CourseManagementNo == request.CourseManagementNo)

                .WhereWhen(request.DateRangeS != default, c => c.CourseHomeworkDate >= request.DateRangeS)
                .WhereWhen(request.DateRangeE != default, c => c.CourseHomeworkDate <= request.DateRangeE)
                .ProjectTo<QuestionnaireView>(this.mapper.ConfigurationProvider)
                .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                .ToPageAsync(request);
        }
    }
}
