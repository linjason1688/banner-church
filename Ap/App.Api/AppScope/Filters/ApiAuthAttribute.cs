#region

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Dtos.Services;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Filters
{
    /// <summary>
    /// global filter
    /// </summary>
    public class ApiAuthAttribute : Attribute, IAsyncAuthorizationFilter, IOrderedFilter
    {
        private static readonly Type allowAnonymousType = typeof(AllowAnonymousAttribute);

        public static string ApiKeyHeaderName => "api-caller-key";

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                if (descriptor.ControllerTypeInfo.GetCustomAttributes().Any(f => f.GetType() == allowAnonymousType))
                {
                    return;
                }

                if (descriptor.MethodInfo.CustomAttributes.Any(f => f.AttributeType == allowAnonymousType))
                {
                    return;
                }
            }

            var request = context.HttpContext.Request;
            var provider = context.HttpContext.RequestServices;
            var authService = provider.GetService<IAuthService>();

            var apiKey = request.Headers.SafeGet(ApiKeyHeaderName);

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new MyBusinessException(ResponseCodes.IdentityUnAuthorized);
            }

            var ipAddress = context.HttpContext.GetClientIpAddress();

            await authService.ValidateSessionAsync(new ValidateSessionRequest());
        }

        public int Order { get; } = 0;
    }
}
