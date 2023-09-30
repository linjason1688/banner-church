using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Application.Managements.MessageInformations.Commands.CreateMessageInformation;
using App.Application.Managements.MessageInformations.Commands.DeleteMessageInformation;
using App.Application.Managements.MessageInformations.Commands.UpdateMessageInformation;
using App.Application.Managements.MessageInformations.Dtos;
using App.Application.Managements.MessageInformations.Queries.QueryMessageInformation;
using Yozian.Extension.Pagination;
using App.Application.Managements.MessageInformations.Queries.FindMessageInformation;
using App.Application.Managements.MessageInformations.Queries.FetchAllMessageInformation;
using System.Collections.Generic;
using App.Application.Managements.MessageInformations.Commands.DeleteMessageInformation;
using App.Application.Managements.OrganizationUsers.Queries.FetchAllOrganizationUser;
using App.Application.Managements.MessageInformationUsers.Commands.CreateMessageInformationUser;
using App.Application.Managements.Users.Queries.QueryUser;
using App.Application.Managements.Users.Queries.FindUser;
using MediatR;
using App.Application.Managements.MessageInformationUsers.Queries.QueryMessageInformationUser;
using App.Application.Managements.MessageInformationUsers.Commands.DeleteMessageInformationUser;
using System.Runtime.CompilerServices;
using System;
using App.Application.Managements.MessageInformations.Queries.QueryUserForInformation;
using AutoMapper;
using App.Domain.Entities.Features;
using System.Linq;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// 訊息管理/通知
    /// </summary>
    [Route("api/[controller]")]

    [Auth]
    public class MessageInformationController : ApiControllerBase
    {
        private readonly IMapper mapper;

        public MessageInformationController(IMapper mapper)
        {
            this.mapper = mapper;
        }


        /// <summary>
        /// 建立訊息管理檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationView>> CreateMessageInformation(
            [FromBody] CreateMessageInformationCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            //自動生成明細
            if (data != null && data.Id > 0 && data.OrganizationId != 0)
            {
                await CreateDetail(data);
            }


            return new ApiResponse<MessageInformationView>()
            {
                Data = data
            };
        }

        private async Task CreateDetail(MessageInformationView data)
        {
            if (data == null)
            {
                return;
            }


            var lineCount = 0;
            var smsCount = 0;
            var emailCount = 0;

            var userLst = await this.Mediator.Send(this.mapper.Map<QueryUserForInformationRequest>(data));
            foreach(var obj in userLst)
            {
                await this.Mediator.Send(new CreateMessageInformationUserCommand()
                {
                    MessageInformationId = data.Id,
                    UserId = obj.Id,
                    LineId = obj.LineId,
                    SMS = obj.CellPhone,
                    Email = obj.Email1,
                    StatusCd = "1"
                });
                if (string.IsNullOrEmpty(obj.LineId) == false)
                {
                    lineCount++;
                }
                else if(string.IsNullOrEmpty(obj.LineId) == true && string.IsNullOrEmpty(obj.Email1) == false)
                {
                    emailCount++;
                }
                else
                {
                    smsCount++;
                }
            }

            await this.Mediator.Send(new UpdateMessageInformationCommand()
            {
                Id = data.Id,
                SendLineCounter = lineCount,
                SendSMSCounter = smsCount,
                SendEmailCounter = emailCount
            });
        }

        /// <summary>
        /// 建立明細
        /// </summary>
        /// <param name="messageInformationId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        private async Task CreateDetail(long messageInformationId, long organizationId)
        {
            var orgUserLst = await this.Mediator.Send(new FetchAllOrganizationUserRequest()
            {
                OrganizationId = organizationId
            });
            foreach (var obj in orgUserLst)
            {
                var user = await this.Mediator.Send(new FindUserRequest()
                {
                    Id = obj.UserId
                });
                if (user != null)
                {
                    await this.Mediator.Send(new CreateMessageInformationUserCommand()
                    {
                        MessageInformationId = messageInformationId,
                        UserId = user.Id,
                        LineId = user.LineId,
                        StatusCd = "1"
                    });
                }
            }
            return;
        }

        /// <summary>
        /// 刪除明細
        /// </summary>
        /// <param name="messageInformationId"></param>
        /// <returns></returns>
        private async Task RemoveDetail(long messageInformationId)
        {
            var oldDetail = (await this.Mediator.Send(new QueryMessageInformationUserRequest()
            {
                Size = -1,
                MessageInformationId = messageInformationId
            })).Records;
            foreach (var obj in oldDetail)
            {
                await this.Mediator.Send(new DeleteMessageInformationUserCommand()
                {
                    Id = obj.Id
                });
            }
        }

        /// <summary>
        /// 修改訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationView>> PutMessageInformation(
            [FromBody] UpdateMessageInformationCommand request
        )
        {
            var data = await this.Mediator.Send(request);

            if (data != null && data.Id > 0 && data.OrganizationId > 0)
            {
                await RemoveDetail(data.Id);

                await CreateDetail(data);

            }

            return new ApiResponse<MessageInformationView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 查詢訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MessageInformationView>>> FindMessageInformation(
            [FromQuery] QueryMessageInformationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MessageInformationView>>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<MessageInformationView>>> FetchMessageInformations(
            [FromBody] FetchAllMessageInformationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<MessageInformationView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除訊息管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationView>> DeleteMessageInformation(
            [FromBody] DeleteMessageInformationCommand request
        )
        {

            //先刪除明細
            await RemoveDetail(request.Id);
            
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MessageInformationView>()
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
        public async Task<ApiResponse<int>> RemoveMessageInformation([FromRoute] DeleteMessageInformationCommand request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<int>()
            {
                Data = 1
            };
        }
        /// <summary>
        /// 以 Id 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("{id:int}")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<MessageInformationView>> GetMessageInformationOfId(
            [FromRoute] FindMessageInformationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<MessageInformationView>()
            {
                Data = data
            };
        }


        /// <summary>
        /// 查詢列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("query")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<MessageInformationView>>> QueryMessageInformations(
            [FromBody] QueryMessageInformationRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<MessageInformationView>>()
            {
                Data = data
            };
        }
    }
}
