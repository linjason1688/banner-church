#region

using System;
using System.Threading.Tasks;
using App.Application.Common.Interfaces.Services.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace App.Api.AppScope.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class HandleApiErrorFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var handleErrorService = context.HttpContext.RequestServices.GetService<IHandleErrorService>();

            if (null == handleErrorService)
            {
                throw new InvalidOperationException($"No implementation type of {nameof(IHandleErrorService)}");
            }

            var apiResponse = await handleErrorService.HandleErrorAsync(
                context.Exception
            );

            context.HttpContext.Response.StatusCode = (int) apiResponse.HttpStatusCode;

            if (!context.HttpContext.Response.Headers.ContainsKey("Error-Catcher"))
            {
                context.HttpContext.Response.Headers.Add("Error-Catcher", this.GetType().Name);
            }

            context.ExceptionHandled = true;

            context.Result = new JsonResult(apiResponse);
        }
    }
}
