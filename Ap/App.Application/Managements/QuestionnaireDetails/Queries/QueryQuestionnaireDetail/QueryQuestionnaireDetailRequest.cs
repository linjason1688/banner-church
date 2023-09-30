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
using App.Application.Managements.QuestionnaireDetails.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.QuestionnaireDetails.Queries.QueryQuestionnaireDetail
{
    /// <summary>
    /// 分頁查詢 QuestionnaireDetail
    /// </summary>

    public class QueryQuestionnaireDetailRequest
        : PageableQuery, IRequest<Page<QuestionnaireDetailView>>
    {


        ///  <summary>
        ///問卷明細Id
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///問卷Id
        /// </summary>
        public long QuestionnaireId { get; set; }
        ///  <summary>
        ///上層問卷DetailId
        /// </summary>
        public long UpperQuestionnaireDetailId { get; set; }
        ///  <summary>
        ///問卷內容類型type=QuestionnaireDetailType顯示 namevalue存此欄位0：區段標題1：題目2：選項
        /// </summary>
        public string QuestionnaireDetailType { get; set; }
        ///  <summary>
        ///QuestionnaireType=1才可選問卷內容類型type=ComponentType顯示 namevalue存此欄位0：選擇(單選)1：選擇(多選)2：是非3：簡答
        /// </summary>
        public string ComponentType { get; set; }
        ///  <summary>
        ///顯示排序
        /// </summary>
        public int Sequence { get; set; }
        ///  <summary>
        ///元件描述假設QuestionnaireType=0此顯示區段標題假設QuestionnaireType=1此顯示該UpperQuestionnaireId.區段之Sequence題目名稱假設QuestionnaireType=2此顯示該UpperQuestionnaireId.區段之ComponentType選項之內容說明
        /// </summary>
        public string Name { get; set; }

        ///  <summary>
        ///描述
        /// </summary>
        public string Description { get; set; }





    }

    /// <summary>
    ///  分頁查詢 QuestionnaireDetail
    /// </summary>
    public class QueryQuestionnaireDetailRequestHandler
        : IRequestHandler<QueryQuestionnaireDetailRequest, Page<QuestionnaireDetailView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryQuestionnaireDetailRequestHandler(
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
        public async Task<Page<QuestionnaireDetailView>> Handle(
            QueryQuestionnaireDetailRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .QuestionnaireDetails
                .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//id
                .WhereWhen(Convert.ToInt64(request.QuestionnaireId) != 0, c => c.QuestionnaireId == request.QuestionnaireId)//QuestionnaireId
                .WhereWhen(Convert.ToInt64(request.UpperQuestionnaireDetailId) != 0, c => c.UpperQuestionnaireDetailId == request.UpperQuestionnaireDetailId)//UpperQuestionnaireDetailId
                .WhereWhenNotEmpty(request.QuestionnaireDetailType, c => c.QuestionnaireDetailType == request.QuestionnaireDetailType)
                .WhereWhenNotEmpty(request.ComponentType, c => c.ComponentType == request.ComponentType)
                .WhereWhen(request.Sequence != 0, c => c.Sequence == request.Sequence)
                .WhereWhenNotEmpty(request.Name, c => c.Name == request.Name)
                /*
                .WhereWhen(Convert.ToInt64(request.PastoralId) != 0, c => c.PastoralId == request.PastoralId)//
                .WhereWhen(Convert.ToInt64(request.CourseManagementTypeId ) != 0, c => c.CourseManagementTypeId == request.CourseManagementTypeId )//CourseManagementTypeId

                .WhereWhenNotEmpty(request.CourseManagementName.ToString(), c => c.CourseManagementName == request.CourseManagementName)
                .WhereWhenNotEmpty(request.CourseYear.ToString(), c => c.CourseYear == request.CourseYear)
                .WhereWhenNotEmpty(request.CourseSeason.ToString(), c => c.CourseSeason == request.CourseSeason)
                .WhereWhenNotEmpty(request.CourseClassNum.ToString(), c => c.CourseClassNum == request.CourseClassNum)
                .WhereWhenNotEmpty(request.CourseManagementNo.ToString(), c => c.CourseManagementNo == request.CourseManagementNo)
                .WhereWhenNotEmpty(request.CourseHomeworkDate.ToString(), c => c.CourseHomeworkDate == request.CourseHomeworkDate)
                */




                .ProjectTo<QuestionnaireDetailView>(this.mapper.ConfigurationProvider)
                .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
                .ToPageAsync(request);

        }
    }
}
