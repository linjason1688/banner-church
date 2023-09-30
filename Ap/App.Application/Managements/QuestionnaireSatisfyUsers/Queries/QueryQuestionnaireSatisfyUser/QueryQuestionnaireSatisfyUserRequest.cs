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
using App.Application.Managements.QuestionnaireSatisfyUsers.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;

#endregion

namespace App.Application.Managements.QuestionnaireSatisfyUsers.Queries.QueryQuestionnaireSatisfyUser
{
    /// <summary>
    /// 分頁查詢 QuestionnaireSatisfyUser
    /// </summary>

    public class QueryQuestionnaireSatisfyUserRequest
        : PageableQuery, IRequest<Page<QuestionnaireSatisfyUserView>>
    {

        ///  <summary>
        ///會員出席聚會狀態.id
        /// </summary>
        public long Id { get; set; }
        ///  <summary>
        ///Questionnaire.id 問卷Id
        /// </summary>
        public long QuestionnaireId { get; set; }
        ///  <summary>
        ///User.Id
        /// </summary>
        public long UserId { get; set; }
        ///  <summary>
        ///問卷產生預設0        問卷類型        type = QuestionnaireWriteType顯示 namevalue存此欄位0：未填寫1：已填寫
        /// </summary>
        public string QuestionnaireWriteType { get; set; }
        ///  <summary>
        ///居住區域        type=QuestionnaireGoArea        顯示 name        value存此欄位0：台中1：台北2：高雄
        /// </summary>
        public string QuestionnaireGoArea { get; set; }
        ///  <summary>
        ///滿意度        type=Satisfaction        顯示 name       value存此欄位1：1 2：2 3：3 4：4 5：5
        /// </summary>
        public string Satisfaction { get; set; }
        ///  <summary>
        ///評價        type=Evaluation        顯示 name       value存此欄位1：1 2：2 3：3 4：4 5：5
        /// </summary>
        public string Evaluation { get; set; }
        ///  <summary>
        ///問卷日期
        /// </summary>
        public string WriteQuestionnaireDate { get; set; }
    }

    /// <summary>
    ///  分頁查詢 QuestionnaireSatisfyUser
    /// </summary>
    public class QueryQuestionnaireSatisfyUserRequestHandler
        : IRequestHandler<QueryQuestionnaireSatisfyUserRequest, Page<QuestionnaireSatisfyUserView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryQuestionnaireSatisfyUserRequestHandler(
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
        public async Task<Page<QuestionnaireSatisfyUserView>> Handle(
            QueryQuestionnaireSatisfyUserRequest request,
            CancellationToken cancellationToken
        )
        {
            return await this.appDbContext
               .QuestionnaireSatisfyUsers
                .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)                        
                .WhereWhen(Convert.ToInt64(request.QuestionnaireId) > 0, c => c.QuestionnaireId == request.QuestionnaireId)//Questionnaire.id                        
                .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)                        
                .WhereWhenNotEmpty(request.QuestionnaireWriteType, c => c.QuestionnaireWriteType == request.QuestionnaireWriteType)//問卷產生預設0問卷類型type = QuestionnaireWriteType顯示 namevalue存此欄位0：未填寫1：已填寫                        
                .WhereWhenNotEmpty(request.QuestionnaireGoArea, c => c.QuestionnaireGoArea == request.QuestionnaireGoArea)//居住區域type = QuestionnaireGoArea顯示 namevalue存此欄位0：台中1：台北2：高雄                        
                .WhereWhenNotEmpty(request.Satisfaction, c => c.Satisfaction == request.Satisfaction)//滿意度type = Satisfaction顯示 namevalue存此欄位1：1 2：2 3：3 4：4 5：5                        
                .WhereWhenNotEmpty(request.Evaluation, c => c.Evaluation == request.Evaluation)//評價type = Evaluation顯示 namevalue存此欄位1：1 2：2 3：3 4：4 5：5                         
                .WhereWhenNotEmpty(request.WriteQuestionnaireDate, c => c.WriteQuestionnaireDate == request.WriteQuestionnaireDate)//問卷日期
               .ProjectTo<QuestionnaireSatisfyUserView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);

        }
    }
}
