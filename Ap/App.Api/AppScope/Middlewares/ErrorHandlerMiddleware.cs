#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos;
using App.Application.Common.Interfaces.Services.Core;
using App.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#endregion

namespace App.Api.AppScope.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private static readonly List<string> filterOutNamespaces = new List<string>
        {
            "System.Runtime",
            "System.Threading",
            "Swashbuckle.AspNetCore",
            "Microsoft.AspNetCore.StaticFiles"
        };

        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context /* other dependencies */)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await this.handleExceptionAsync(context, ex);
            }
        }

        private async Task handleExceptionAsync(HttpContext context, Exception exception)
        {
            var apiResponse = new ApiResponse<object>();

            try
            {
                var handleErrorService = context.RequestServices.GetService<IHandleErrorService>();

                if (null == handleErrorService)
                {
                    throw new InvalidOperationException($"No implementation type of {nameof(IHandleErrorService)}");
                }

                apiResponse = await handleErrorService.HandleErrorAsync(exception);
                

                context.Response.StatusCode = (int) apiResponse.HttpStatusCode;

                if (!context.Response.Headers.ContainsKey("Error-Catcher"))
                {
                    context.Response.Headers.Add("Error-Catcher", this.GetType().Name);
                }
            }
            catch (Exception ex)
            {
                var guid = Guid.NewGuid().ToString();

                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;

                apiResponse = new ApiResponse<object>()
                {
                    HandledId = guid,
                    Code = ResponseCodes.UnexpectedError.Code,
                    Message = ResponseCodes.UnexpectedError.Message,
                    TxnTime = DateTime.Now
                };

                var logger = context.RequestServices.CreateLogger<ApiLogMiddleware>();

                logger.LogCritical(ex, "HandledId: {@HandledId}", guid);
            }
            finally
            {
                context.Response.StatusCode = (int) apiResponse.HttpStatusCode;

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(Serialization.Serialize(apiResponse));
            }
        }
    }
}
