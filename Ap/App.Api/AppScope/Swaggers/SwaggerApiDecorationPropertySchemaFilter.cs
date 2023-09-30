#region

using System.Linq;
using App.Application.Common.Attributes.Support;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerApiDecorationPropertySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;

            context.MemberInfo?.GetCustomAttributes(typeof(ApiPropertyDecorationAttribute), true)
               .Select(x => x as ApiPropertyDecorationAttribute)
               .ForEach(
                    attr =>
                    {
                        if (string.IsNullOrEmpty(schema.Description))
                        {
                            schema.Description = $"{attr.Hint}";
                        }
                        else
                        {
                            schema.Description += $"\n ({attr.Hint})";
                        }
                    }
                );
        }
    }
}
