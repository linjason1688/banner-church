#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using App.Application.Common.Constants;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace App.Api.AppScope.Filters
{
    /// <summary>
    /// apply to who is annotated
    /// </summary>
    public class AuthAttribute : Attribute, IAsyncAuthorizationFilter, IOrderedFilter
    {
        /// <summary>
        /// 
        /// </summary>
        private static string JwtCookieKey => "_i_banner_z_";

        /// <summary>
        /// 
        /// </summary>
        public int Order { get; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public static string JwtHeaderName => "authorization";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="MyBusinessException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;
            var provider = context.HttpContext.RequestServices;
            var authService = provider.GetService<IAuthService>();

            if (this.SkipAuthValidate(context.ActionDescriptor))
            {
                return;
            }

            // response add refresh-token
            if (null == authService)
            {
                throw new InvalidOperationException("Invalid Perform Authorization");
            }

            // 同一個 req 驗一次即可
            //if (authService.Authorized)
            //{
            //    return;
            //}

            //
#if DEBUG

            // if (authService.IsPrivilegeFree)
            // {
            //     return;
            // }
#endif

            if (!request.Headers.TryGetValue(JwtHeaderName, out var jwt))
            {
                if (request.Cookies.TryGetValue(JwtCookieKey, out var jwtSecondSrc))
                {
                    jwt = jwtSecondSrc;
                }
            }

            if (string.IsNullOrEmpty(jwt))
            {
                throw new MyBusinessException(ResponseCodes.IdentityUnAuthorized);
            }

           

            var state = await authService.RetrievingProfileOfJwtAsync(jwt);

            if (state.ReIssuedToken)
            {
                response.Headers.TryAdd(JwtHeaderName, state.JwtToken);

                //
                WriteJwtTokenToCookie(response, state.JwtToken);
            }
        }

        private bool SkipAuthValidate(ActionDescriptor actionDescriptor)
        {
            // 非 action 則為 class (controller) 上的 attr 
            if (actionDescriptor is not ControllerActionDescriptor descriptor)
            {
                return false;
            }

            // action 任一有 AllowAnonymousAttribute 即 skip
            var hasAllowAnonymous = descriptor.EndpointMetadata
               .OfType<AllowAnonymousAttribute>()
               .Any();

            if (hasAllowAnonymous)
            {
                return true;
            }

            var hasAuthAttr = descriptor.EndpointMetadata.OfType<AuthAttribute>().Any();

            if (hasAuthAttr)
            {
                return false;
            }

            // controller 有 AllowAnonymousAttribute 即 skip
            hasAllowAnonymous = descriptor.ControllerTypeInfo
               .GetCustomAttributes()
               .OfType<AllowAnonymousAttribute>()
               .Any();

            if (hasAllowAnonymous)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="token"></param>
        public static void WriteJwtTokenToCookie(HttpResponse response, string token)
        {
            response.Cookies.Append(
                JwtCookieKey,
                token,
                new CookieOptions
                {
                    SameSite = SameSiteMode.None,
                    HttpOnly = true,
                    MaxAge = TimeSpan.FromMinutes(
#if DEBUG
                        1200
#else
                        20
#endif
                    ),
                    IsEssential = true
                }
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        public static void RemoveJwtTokenCookie(HttpResponse response)
        {
            response.Cookies.Delete(JwtCookieKey);
        }
    }
}
