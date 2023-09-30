#region

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerOperationIdFilterFile : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //
            var hasFormFile = context.ApiDescription
               .ActionDescriptor
               .Parameters
               .Any(w => w.ParameterType == typeof(IFormFile));

            if (!hasFormFile)
            {
                return;
            }

            var schema = new Dictionary<string, OpenApiSchema>
            {
                ["file"] = new OpenApiSchema
                {
                    Description = "Select file",
                    Type = "string",
                    Format = "binary"
                }
            };

            var content = new Dictionary<string, OpenApiMediaType>
            {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = schema
                    }
                }
            };

            operation.RequestBody = new OpenApiRequestBody()
            {
                Content = content
            };
        }
    }
}
