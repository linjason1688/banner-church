#region

using System.Linq;
using App.Utility.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerLowerPathDocFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // transform pascalCase Path to camelCase!! (NOT ALL IN Lowercase....)
            var apiPaths = new OpenApiPaths();

            swaggerDoc.Paths.ForEach(
                kv =>
                {
                    var camelCasePath = string.Join(
                        "/",
                        kv.Key
                           .Split("/")
                           .Select(sector => sector.ToCamelCase())
                    );

                    apiPaths.Add(camelCasePath, kv.Value);
                }
            );

            swaggerDoc.Paths = apiPaths;
        }
    }
}
