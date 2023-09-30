#region

using System;
using System.Linq;
using App.Utility.Extensions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerIgnorePropertySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;

            if (schema?.Properties == null || schema.Properties.Count == 0 || type == null)
            {
                return;
            }

            var modelType = context.Type;

            var jsonIgnoreAttrName = nameof(JsonIgnoreAttribute);

            modelType.GetProperties()
               .Where(
                    prop =>
                    {
                        return prop.GetCustomAttributes(true)
                           .Select(attr => attr as Attribute)
                           .Any(attr => attr?.GetType().Name == jsonIgnoreAttrName);
                    }
                )
               .ForEach(
                    prop => { schema.Properties.Remove(prop.Name.ToCamelCase()); }
                );
        }
    }
}
