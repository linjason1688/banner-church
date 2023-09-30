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
using App.Application.Managements.UserQuestionnaires.Dtos;
using App.Domain.Constants;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yozian.Extension.Pagination;
using Yozian.Extension;
using App.Application.Managements.Questionnaires.Dtos;
using RestEase.Implementation;

#endregion

namespace App.Application.Managements.UserQuestionnaires.Queries.QueryUserQuestionnaire
{
    /// <summary>
    /// 分頁查詢 UserQuestionnaire
    /// </summary>

    public class QueryUserQuestionnaireRequest
        : PageableQuery, IRequest<Page<UserQuestionnaireView>>
    {

        ///  <summary>
        ///會員填寫問卷.id
        /// </summary>
        public long? Id { get; set; }


        ///  <summary>
        ///問卷.id
        /// </summary>
        public long? QuestionnaireId { get; set; }

        ///  <summary>
        ///User.id
        /// </summary>
        public long? UserId { get; set; }

        ///  <summary>
        ///問卷產生預設0
        ///問卷類型
        ///type=QuestionnaireWriteType
        ///顯示 name
        ///value存此欄位
        ///0：未填寫
        ///1：已填寫
        /// </summary>        
        public string QuestionnaireWriteType { get; set; }

        ///  <summary>
        ///居住區域
        ///type=QuestionnaireGoArea
        ///顯示 name
        ///value存此欄位
        ///0：台中
        ///1：台北
        ///2：高雄
        /// </summary>
        public string QuestionnaireGoArea { get; set; }

        ///  <summary>
        ///滿意度
        ///type=Satisfaction
        ///顯示 name
        ///value存此欄位
        ///1：1
        ///2：2
        ///3：3
        ///4：4
        ///5：5
        /// </summary>
        public string Satisfaction { get; set; }

        ///  <summary>
        ///評價
        ///type=Satisfaction
        ///顯示 name
        ///value存此欄位
        ///1：1
        ///2：2
        ///3：3
        ///4：4
        ///5：5
        /// </summary>
        public string Evaluation { get; set; }

        ///  <summary>
        ///填寫問卷日期
        /// </summary>
        public DateTime? WriteQuestionnaireDate { get; set; }

        ///  <summary>
        ///問卷類型type=QuestionnaireType顯示 namevalue存此欄位0：課程問卷 1:服事徵召 2:一般問卷
        /// </summary>       
        public string QuestionnaireType { get; set; }

    }

    /// <summary>
    ///  分頁查詢 UserQuestionnaire
    /// </summary>
    public class QueryUserQuestionnaireRequestHandler
        : IRequestHandler<QueryUserQuestionnaireRequest, Page<UserQuestionnaireView>>
    {
        private readonly IMapper mapper;

        private readonly IAppDbContext appDbContext;

        /// <summary>
        /// 
        /// </summary>
        public QueryUserQuestionnaireRequestHandler(
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
        public async Task<Page<UserQuestionnaireView>> Handle(
            QueryUserQuestionnaireRequest request,
            CancellationToken cancellationToken
        )
        {

            var main = this.appDbContext.UserQuestionnaires
.WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//Id
.WhereWhen(Convert.ToInt64(request.QuestionnaireId) > 0, c => c.QuestionnaireId == request.QuestionnaireId)//QuestionnaireId                                                                                                 
.WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
.WhereWhenNotEmpty(request.QuestionnaireWriteType, c => c.QuestionnaireWriteType == request.QuestionnaireWriteType)//問卷產生預設0問卷類型type=QuestionnaireWriteType顯示 namevalue存此欄位0：未填寫1：已填寫
.WhereWhenNotEmpty(request.QuestionnaireGoArea, c => c.QuestionnaireGoArea == request.QuestionnaireGoArea)//居住區域type=QuestionnaireGoArea顯示 namevalue存此欄位0：台中1：台北2：高雄
.WhereWhenNotEmpty(request.Satisfaction, c => c.Satisfaction == request.Satisfaction)//滿意度type=Satisfaction顯示 namevalue存此欄位1：12：23：34：45：5
.WhereWhenNotEmpty(request.Evaluation, c => c.Evaluation == request.Evaluation)//評價type=Evaluation顯示 namevalue存此欄位1：12：23：34：45：5   
.WhereWhen(request.WriteQuestionnaireDate != default, c => c.WriteQuestionnaireDate == request.WriteQuestionnaireDate);//問卷日期
           
            
            //QuestionnaireType顯示
            var ThisQuestionnaires = this.appDbContext.Questionnaires.WhereWhenNotEmpty(request.QuestionnaireType, c => c.QuestionnaireType == request.QuestionnaireType);

            var filterIds = (from so in ThisQuestionnaires
                                  select new { so.Id }).AsEnumerable();

            main = main.Where(p => filterIds.Any(p2 => Convert.ToInt64(p2.Id) == Convert.ToInt64(p.QuestionnaireId)));
         
            var lst = from uq in main
                      join q in ThisQuestionnaires on uq.QuestionnaireId equals q.Id into subR


            from result1 in subR.DefaultIfEmpty()
                      select new UserQuestionnaireView
                      {
                          Id = uq.Id,
                          HandledId = uq.HandledId,
                          DateCreate = uq.DateCreate,
                          UserCreate = uq.UserCreate,
                          DateUpdate = uq.DateUpdate,
                          UserUpdate = uq.UserUpdate,
                          QuestionnaireId = uq.QuestionnaireId,
                          UserId = uq.UserId,
                          QuestionnaireWriteType = uq.QuestionnaireWriteType,
                          QuestionnaireGoArea = uq.QuestionnaireGoArea,
                          Satisfaction = uq.Satisfaction,
                          Evaluation = uq.Evaluation,
                          WriteQuestionnaireDate = uq.WriteQuestionnaireDate,
                          Comment = uq.Comment,
                          Questionnaire = result1 != null ? this.mapper.Map<QuestionnaireView>(result1) : null,   //关联子表
                      };

            
            return await lst
               // .ProjectTo<UserQuestionnaireView>(this.mapper.ConfigurationProvider)
               .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
               .ToPageAsync(request);


            //return await this.appDbContext
            //   .UserQuestionnaires
            //   .WhereWhen(Convert.ToInt64(request.Id) > 0, c => c.Id == request.Id)//會員填寫問卷狀態.id
            //    .WhereWhen(Convert.ToInt64(request.QuestionnaireId) != 0, c => c.QuestionnaireId == request.QuestionnaireId)//Questionnaire.id
            //    .WhereWhen(Convert.ToInt64(request.UserId) > 0, c => c.UserId == request.UserId)//User.Id
            //    .WhereWhenNotEmpty(request.QuestionnaireWriteType, c => c.QuestionnaireWriteType == request.QuestionnaireWriteType)//問卷產生預設0問卷類型type=QuestionnaireWriteType顯示 namevalue存此欄位0：未填寫1：已填寫
            //    .WhereWhenNotEmpty(request.QuestionnaireGoArea, c => c.QuestionnaireGoArea == request.QuestionnaireGoArea)//居住區域type=QuestionnaireGoArea顯示 namevalue存此欄位0：台中1：台北2：高雄
            //    .WhereWhenNotEmpty(request.Satisfaction, c => c.Satisfaction == request.Satisfaction)//滿意度type=Satisfaction顯示 namevalue存此欄位1：12：23：34：45：5
            //    .WhereWhenNotEmpty(request.Evaluation, c => c.Evaluation == request.Evaluation)//評價type=Evaluation顯示 namevalue存此欄位1：12：23：34：45：5   
            //     .WhereWhen(request.WriteQuestionnaireDate != default, c => c.WriteQuestionnaireDate == request.WriteQuestionnaireDate)//問卷日期
            //   .ProjectTo<UserQuestionnaireView>(this.mapper.ConfigurationProvider)
            //   .ApplySortProperties(request, CommonSortProperty.CreatedAtDescending)
            //   .ToPageAsync(request);

        }
    }
}
