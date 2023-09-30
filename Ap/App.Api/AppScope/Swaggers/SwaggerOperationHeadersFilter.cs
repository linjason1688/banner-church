#region

using System.Linq;
using App.Application.Common.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerOperationHeadersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attr = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
               .Union(context.MethodInfo.GetCustomAttributes(true))
               .OfType<LocalizedConstraintAttribute>()
               .FirstOrDefault();

            if (null == attr)
            {
                return;
            }

            operation.Description = $"[localized] \n {operation.Description}";

            // operation.Parameters.Add(
            //     new OpenApiParameter()
            //     {
            //         Name = "dmp-Language",
            //         In = ParameterLocation.Header,
            //         Description = "locale",
            //         Required = true,
            //         Schema = new OpenApiSchema
            //         {
            //             Type = "string",
            //             Default = new OpenApiString("zh-TW")
            //         }
            //     }
            // );
        }
    }
}
