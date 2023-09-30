using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.Questionnaires.Commands.CreateQuestionnaire;
using App.Application.Managements.Questionnaires.Commands.DeleteQuestionnaire;
using App.Application.Managements.Questionnaires.Commands.UpdateQuestionnaire;
using App.Application.Managements.Questionnaires.Dtos;
using App.Application.Managements.Questionnaires.Queries.QueryQuestionnaire;
using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using App.Application.Managements.Questionnaires.Queries.FindQuestionnaire;
using System.Linq;
using App.Application.Managements.Organizations.Queries.FindOrganization;
using App.Application.Managements.Pastorals.Queries.FindPastoral;
using App.Application.Managements.QuestionnaireDetails.Queries.QueryQuestionnaireDetail;
using App.Application.Managements.Questionnaires.Queries.FetchAllQuestionnaire;
using System.Collections.Generic;
using App.Application.Managements.Pastorals.Commands.DeletePastoral;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 問卷主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class QuestionnaireController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;

        public QuestionnaireController(
            VerificationCodeService verificationCodeService,
            IAppDbContext appDbContext,
            IMapper mapper
        )
        {
            this.verificationCodeService = verificationCodeService;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }


        /// <summary>
        /// 建立問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("Questionnaire")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireView>> CreateQuestionnaire([FromBody] CreateQuestionnaireCommand request)
        {
            var data = await this.Mediator.Send(request);

            await this.LoadRelationObjs(data);

            return new ApiResponse<QuestionnaireView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createQuestionnaire")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireView>> PutQuestionnaire([FromBody] UpdateQuestionnaireCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<QuestionnaireView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createQuestionnaire")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<QuestionnaireView>>> FindQuestionnaire([FromQuery] QueryQuestionnaireRequest request)
        {

            var data = await this.Mediator.Send(request);

            foreach (var obj in data.Records)
            {
                await this.LoadRelationObjs(obj);
            }

            return new ApiResponse<Page<QuestionnaireView>>()
            {
                Data = data
            };

        }
        /// <summary>
        /// 查詢問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<QuestionnaireView>>> FetchQuestionnaires(
            [FromBody] FetchAllQuestionnaireRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<QuestionnaireView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createQuestionnaire")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireView>> DeleteQuestionnaire([FromBody] DeleteQuestionnaireCommand request)
        {

            var data = await this.Mediator.Send(request);

            return new ApiResponse<QuestionnaireView>()
            {
                //Data = data
            };

        }

        /// <summary>
        /// 刪除主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<int>> RemoveQuestionnaire([FromRoute] DeleteQuestionnaireCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }

        /// <summary>
        /// 以 Id 查詢問卷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QuestionnaireView>> GetQuestionnaire([FromRoute] FindQuestionnaireRequest request)
        {
            var data = await this.Mediator.Send(request);

            await this.LoadRelationObjs(data);

            return new ApiResponse<QuestionnaireView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢問卷列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<QuestionnaireView>>> QueryQuestionnaires(
            [FromBody] QueryQuestionnaireRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            foreach (var obj in data.Records)
            {
                await this.LoadRelationObjs(obj);
            }

            return new ApiResponse<Page<QuestionnaireView>>()
            {
                Data = data
            };
        }



        private async Task LoadRelationObjs(QuestionnaireView obj)
        {
            //Get Details
            obj.QuestionnaireDetailsViews = (await this.Mediator.Send(new QueryQuestionnaireDetailRequest
            {
                QuestionnaireId = obj.Id,
                Size = -1

            })).Records?.ToList();


            //If OrgaId > 0 then Query Organization
            if (obj.OrganizationId > 0)
            {
                var orgId = obj.OrganizationId;
                while (true)
                {
                    var Org = await this.Mediator.Send(new FindOrganizationRequest()
                    {
                        Id = orgId
                    });
                    if (Org != null)
                    {
                        obj.OrganizationViews.Add(Org);
                    }
                    orgId = Org.UpperOrganizationId;
                    if (orgId == 0)
                    {
                        break;
                    }
                }
            }

            //If PastoralId > 0 then Query Portal
            if (obj.PastoralId > 0)
            {
                var pasId = obj.PastoralId;
                while (true)
                {
                    var pas = await this.Mediator.Send(new FindPastoralRequest()
                    {
                        Id = pasId
                    });
                    if (pas != null)
                    {
                        obj.PastoralViews.Add(pas);
                    }
                    pasId = pas.UpperPastoralId;
                    if (pasId == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}

