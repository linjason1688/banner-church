#region

using System.Linq;
using App.Utility.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerOperationIdFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var operationId = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
               .Union(context.MethodInfo.GetCustomAttributes(true))
               .OfType<SwaggerOperationAttribute>()
               .Select(a => a.OperationId)
               .FirstOrDefault();

            if (string.IsNullOrEmpty(operationId))
            {
                operationId = context.MethodInfo.Name.ToCamelCase();
            }

            operation.OperationId = operationId;
        }
    }
}
