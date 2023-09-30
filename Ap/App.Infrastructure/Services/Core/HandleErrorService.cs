using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services.Core;
using App.Domain.Entities.Core;
using App.Utility;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestEase;
using Yozian.DependencyInjectionPlus.Attributes;
using Yozian.Extension;

namespace App.Infrastructure.Services.Core
{
    [ScopedService(typeof(IHandleErrorService))]
    public class HandleErrorService : IHandleErrorService
    {
        private static readonly List<string> filterOutNamespaces = new List<string>
        {
            "System",
            "Microsoft",
            "Swashbuckle.AspNetCore",
            "App.Metrics.AspNetCore",
            "MediatR",
            "App.Application.Common.Behaviours"
        };

        private readonly AppStore appStore;

        private readonly ILogger logger;
        private readonly IScopeContextService scopeContextService;

        public HandleErrorService(
            ILogger<HandleErrorService> logger,
            AppStore appStore,
            IScopeContextService scopeContextService
        )
        {
            this.logger = logger;
            this.appStore = appStore;
            this.scopeContextService = scopeContextService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public Task<ApiResponse<object>> HandleErrorAsync(
            Exception ex
        )
        {
            var handledId = this.scopeContextService.TransactionId;
            var apiResponse = new ApiResponse<object>
            {
                HandledId = handledId.ToString(),
                HttpStatusCode = HttpStatusCode.BadRequest
            };

            var stackTrace = ex.DumpDetail(
                f =>
                {
                    // here we filter out the useless frames
                    var klass = f.GetMethod()?.DeclaringType;

                    if (null == klass || string.IsNullOrEmpty(klass.FullName))
                    {
                        return false;
                    }

                    return !filterOutNamespaces
                       .Any(
                            x => klass.FullName.StartsWith(x)
                        );
                }
            );

            switch (ex)
            {
                // 此 error 之 httpStatusCode 由 MyBusinessException default & Error 指定
                case MyBusinessException mbe:
                    apiResponse.Code = mbe.Code ?? ResponseCodes.GeneralBusinessError.Code;
                    apiResponse.Message = mbe.Message;
                    apiResponse.HttpStatusCode = (HttpStatusCode) mbe.HttpStatusCode;

#if DEBUG
                    apiResponse.Data = mbe.ExtraData;

#endif
                    break;

                case ValidationException mve:
                    var vErr = ResponseCodes.ValidationError;
                    apiResponse.Code = vErr.Code;

                    // 
                    apiResponse.Message = mve.Errors.Any()
                        ? mve.Errors
                           .Select(e => $"{e.PropertyName}:{e.ErrorMessage}")
                           .FlattenToString("\r\n")
                        : mve.Message;

                    apiResponse.DetailMessage = mve.Data;

                    break;

                case ExternalServiceException ese:
                    apiResponse.Code = ese.Code ?? ResponseCodes.ExternalServiceError.Code;
                    apiResponse.Message = ese.Message;

                    this.logger.LogError(ese, "{@Message}", ese.Message);

#if DEBUG
                    apiResponse.DetailMessage = stackTrace;

#endif
                    break;

                case AutoMapperMappingException amme:
                    apiResponse.Code = ResponseCodes.UnexpectedError.Code;
                    apiResponse.Message = ex.Message;

#if DEBUG
                    apiResponse.DetailMessage = stackTrace;
#endif

                    this.logger.LogError(amme, "{@Message}", amme.Message);

                    break;

                case ApiException aex:

                    apiResponse.Code = ResponseCodes.ExternalServiceError.Code;
                    apiResponse.Message = aex.Message;
#if DEBUG
                    apiResponse.DetailMessage = aex.Content;
#endif

                    var apiData = aex.Data;

                    apiData.Add("responseBody", aex.Content);

                    this.logger.LogWarning(ex, "{@ApiResponse}", apiResponse);

                    break;

                default:

                    var uErr = ResponseCodes.UnexpectedError;
                    apiResponse.Code = uErr.Code;
                    apiResponse.Message = $"{uErr.Message}({apiResponse.HandledId})";

                    apiResponse.TxnTime = DateTime.Now;
                    apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;

#if DEBUG
                    apiResponse.DetailMessage = stackTrace;
#endif

                    this.logger.LogCritical(ex, "{@ApiResponse}", apiResponse);

                    break;
            }

            // 正常例外指的是較不重要的 ex
            apiResponse.IsNormalException = ex is MyBusinessException or ValidationException;

            if (apiResponse.IsNormalException)
            {
                return Task.FromResult(apiResponse);
            }

            // save to db
            var exLog = new ExceptionLog()
            {
                HandledId = handledId,
                MachineName = Environment.MachineName,
                Message = ex.Message.LimitLength(1000),
                Source = ex.Source.LimitLength(1000),
                StackTrace = stackTrace,
                ExtraData = Serialization.Serialize(ex.Data)
            };

            this.appStore.ExceptionLogQueue.Enqueue(exLog);

            return Task.FromResult(apiResponse);
        }
    }
}
