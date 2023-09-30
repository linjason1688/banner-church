#region

using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public static class SwaggerMyPreSerializeFilters
    {
        /// <summary>
        /// request should add querystring -> ?client=postman
        /// </summary>
        /// <param name="document"></param>
        /// <param name="request"></param>
        public static void PostmanRequiredHeaderAddOn(OpenApiDocument document, HttpRequest request)
        {
            // 供 產 postman 使用, 若用 open api generate typescript client 請 comment 掉
            var client = request.Query["client"].FirstOrDefault();

            if (string.IsNullOrEmpty(client))
            {
                return;
            }

            var headerFilter = new SwaggerOperationHeadersFilter();

            document.Paths.Values
               .SelectMany(api => api.Operations)
               .Select(kv => kv.Value)
               .ForEach(
                    operation => { headerFilter.Apply(operation, null); }
                );

            // we should clear all 
            document.SecurityRequirements.Clear();
        }
    }
}
