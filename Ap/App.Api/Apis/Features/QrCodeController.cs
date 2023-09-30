using System.Threading.Tasks;
using App.Api.AppScope.Filters;
using App.Api.AppScope.Swaggers;
using App.Application.Common.Dtos;

using App.Infrastructure.Services.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App.Application.Managements.QrCodes.Commands.CreateQrCode;
using App.Application.Managements.QrCodes.Commands.DeleteQrCode;
using App.Application.Managements.QrCodes.Commands.UpdateQrCode;
using App.Application.Managements.QrCodes.Dtos;
using App.Application.Managements.QrCodes.Queries.QueryQrCode;

using MediatR;

using Yozian.Extension.Pagination;
using App.Application.Common.Interfaces;
using AutoMapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.Collections.Generic;

using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using App.Application.Managements.QrCodes.Queries.FindQrCode;
using System.Diagnostics.Metrics;
using App.Utility.Cryptos;
using App.Domain.Entities.Features;
using System;
using App.Application.Managements.Users.Queries.FindUser;
using App.Application.Managements.QrCodes.Queries.FetchAllQrCode;
using App.Application.Managements.QrCodes.Commands.DeleteQrCode;
using App.Application.Common.Exceptions;
using System.Linq;
using App.Application.Managements.UserCourses.Queries.FindUserCourse;
using App.Application.Managements.UserCourses.Commands.UpdateUserCourse;
using App.Application.Managements.MinistryMeetingUsers.Queries.FindMinistryMeetingUser;
using App.Application.Managements.MinistryMeetingUsers.Commands.UpdateMinistryMeetingUser;

namespace App.Api.Apis.Features
{
    /// <summary>
    /// QrCode主檔
    /// </summary>
    [Route("api/[controller]")]
    
    [Auth]
    public class QrCodeController : ApiControllerBase
    {
        private readonly VerificationCodeService verificationCodeService;

        private readonly IAppDbContext appDbContext;

        private readonly IMapper mapper;
        private readonly ICrypto crypto;

        public QrCodeController(
            VerificationCodeService verificationCodeService,
            IAppDbContext appDbContext,
            IMapper mapper
        )
        {
            this.verificationCodeService = verificationCodeService;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.crypto = AesCrypto.Instance;
        }


        /// <summary>
        /// 建立QrCode主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        //[Route("QrCode")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QrCodeView>> CreateQrCode([FromBody] CreateQrCodeCommand request)
        {
            var user = await this.Mediator.Send(new FindUserRequest() { Id = request.UserId });
            //User.PasswordSalt是加密的令牌，先解密
            var salt = this.crypto.Decrypt(user.PasswordSalt);
            var comKey = $"{request.ReferenceType}||{request.ReferenceId}||{request.UserId}";
            request.GenerateCode = this.crypto.EncodePassword(comKey, salt);
            request.GenerateCode = request.GenerateCode.Replace("+", "").Replace("/", "").Replace("=", "");
            var data = await this.Mediator.Send(request);
            return new ApiResponse<QrCodeView>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 修改QrCode主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPut]
        //[Route("createQrCode")]  
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QrCodeView>> PutQrCode([FromBody] UpdateQrCodeCommand request)
        {
            var user = await this.Mediator.Send(new FindUserRequest() { Id = request.UserId });
            //User.PasswordSalt是加密的令牌，先解密
            var salt = this.crypto.Decrypt(user.PasswordSalt);
            var comKey = $"{request.ReferenceType}||{request.ReferenceId}||{request.UserId}";
            request.GenerateCode = this.crypto.EncodePassword(comKey, salt);

            var data = await this.Mediator.Send(request);

            return new ApiResponse<QrCodeView>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢QrCode主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        //[Route("createQrCode")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<Page<QrCodeView>>> FindQrCode([FromQuery] QueryQrCodeRequest request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<Page<QrCodeView>>()
            {
                Data = data
            };

        }

        /// <summary>
        /// 查詢QR
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpPost]
        [Route("fetch")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<List<QrCodeView>>> FetchQrCodes(
            [FromBody] FetchAllQrCodeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<List<QrCodeView>>()
            {
                Data = data
            };
        }

        /// <summary>
        /// 刪除QrCode主檔
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpDelete]
        //[Route("createQrCode")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QrCodeView>> DeleteQrCode([FromBody] DeleteQrCodeCommand request)
        {

            var data = await this.Mediator.Send(request);


            return new ApiResponse<QrCodeView>()
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
        public async Task<ApiResponse<int>> RemoveQrCode([FromRoute] DeleteQrCodeCommand request)
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
        public async Task<ApiResponse<QrCodeView>> GetQrCode([FromRoute] FindQrCodeRequest request)
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<QrCodeView>()
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
        public async Task<ApiResponse<Page<QrCodeView>>> QueryQrCodes(
            [FromBody] QueryQrCodeRequest request
        )
        {
            var data = await this.Mediator.Send(request);

            return new ApiResponse<Page<QrCodeView>>()
            {
                Data = data
            };


            /*
            var salt = this.crypto.GenerateSalt(12);
            var GenCode = "";

            //新增逻辑
            var entity = this.mapper.Map<QrCode>(request);
            entity.UserId = 12;//request.UserId;
            entity.ReferenceId = 2;//request.RefferenceId;
            entity.ReferenceType = 3;//request.RefferenceType;

            string CombineString = entity.RefferenceType.ToString() + "||" + entity.RefferenceId.ToString() + "||" + entity.UserId.ToString();
            GenCode = this.crypto.EncodePassword(CombineString, salt);
            entity.GenerateCode = GenCode;


            //
            var APIURL = "https://gamma.jetsion.com/API/SystemConfig/configs?GenerateCode=1231231321";
            var GenQRString = "https://chart.googleapis.com/chart?chs=120x120&cht=qr&chl=" + APIURL + "&choe=UTF-8&chld=M|2";

            //await this.appDbContext.QrCodes.AddAsync(entity);
            */


        }

        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("show")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QrCodeView>> ShowQrCode(int referenceId,
                                                                         int referencetype,
                                                                         int userid)
        {
            var request = new QueryQrCodeRequest()
            {
                ReferenceId = referenceId,
                ReferenceType = referencetype,
                UserId = userid
            };
            var data = (await this.Mediator.Send(request)).Records.FirstOrDefault();
            if (data != null)
            {
                var APIURL = $"https://gamma.jetsion.com/API/QrCode/Sign?GenerateCode={data.GenerateCode}";
                var GenQRString = "https://chart.googleapis.com/chart?chs=120x120&cht=qr&chl=" + APIURL + "&choe=UTF-8&chld=M|2";
                data.GenerateCode = GenQRString;
            }
            return new ApiResponse<QrCodeView>()
            {
                Data = data
            };
        }


        [SwaggerOperation]
        [ApiLogIgnoreBody(IgnoreRequestBody = true)]
        [HttpGet]
        [Route("Sign")]
        [ResponseCache(NoStore = true, Duration = -1)]
        public async Task<ApiResponse<QrCodeView>> SignIdQrCode([FromQuery] string generateCode)
        {
            var request = new QueryQrCodeRequest()
            {
                GenerateCode = generateCode
            };

            var data = (await this.Mediator.Send(request)).Records.FirstOrDefault();
            if (data == null)
            {
                throw new MyBusinessException("QrCode非法，掃碼失敗！");
            }
            //Modify status
            var obj = this.mapper.Map<UpdateQrCodeCommand>(data);
            obj.RegisterStatus = 1;
            obj.RegisterTime = DateTime.Now;
            data = await this.Mediator.Send(obj);

            if (obj.ReferenceType == 4)
            {
                var ucView = await this.Mediator.Send(new FindUserCourseRequest() { Id = obj.ReferenceId });
                var ucObj = this.mapper.Map<UpdateUserCourseCommand>(ucView);
                ucObj.AttendanceType = "1";
                ucObj.AttendanceDate = DateTime.Now;
                await this.Mediator.Send(ucObj);
            }else  if (obj.ReferenceType == 5)
            {
                    var ucView = await this.Mediator.Send(new FindMinistryMeetingUserRequest() { Id = obj.ReferenceId });
                    var ucObj = this.mapper.Map<UpdateMinistryMeetingUserCommand>(ucView);
                    ucObj.MeetAttendanceType = 1;
                    await this.Mediator.Send(ucObj);
             }


            return new ApiResponse<QrCodeView>()
            {
                Data = data
            };
        }




    }
}

