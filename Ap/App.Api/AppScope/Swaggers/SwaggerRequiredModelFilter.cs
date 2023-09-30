#region

using System.Collections.Generic;
using System.Linq;
using App.Domain.Entities;
using App.Utility.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerRequiredModelFilter : IDocumentFilter
    {
        // if any request dto want to make property ignore should be added
        private readonly List<string> exceptionList = new List<string>();

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // making all response properties are not nullable
            // for api generator!!

            swaggerDoc.Components
               .Schemas
               .Where(
                    s => !s.Key.Contains("Request")
                )
               .Where(s => !this.exceptionList.Contains(s.Key))
               .ForEach(
                    schema =>
                    {
                        var excludeProperties = new[]
                        {
                            nameof(EntityBase.HandledId).ToCamelCase(),
                            nameof(EntityBase.RowVersion).ToCamelCase(),
                            nameof(EntityBase.DateCreate).ToCamelCase(),
                            nameof(EntityBase.UserCreate).ToCamelCase(),
                            nameof(EntityBase.DateUpdate).ToCamelCase(),
                            nameof(EntityBase.UserUpdate).ToCamelCase()
                        };

                        schema.Value.Properties
                           .Where(p => !excludeProperties.Contains(p.Key))
                           .ForEach(
                                property =>
                                {
                                    schema.Value.Required.Add(property.Key);
                                    property.Value.Nullable = false;
                                }
                            );
                    }
                );
        }
    }
}
