#region

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AutoMapper.Internal;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yozian.Extension;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public class SwaggerEnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (!context.Type.IsEnum)
            {
                return;
            }

            schema.Enum.Clear();

            schema.Enum.AddRange(
                Enum.GetNames(context.Type)
                   .Select(n => new OpenApiString(n))
            );
            //  for int value display
            // schema.Enum.AddRange(
            //     Enum.GetValues(context.Type)
            //        .Cast<int>()
            //        .Select(n => new OpenApiInteger(n))
            // );

            schema.Format = "Int32";
            schema.Type = "enum";

            var descriptionType = typeof(DescriptionAttribute);

            // 補充 enum 資訊
            var mis = Enum.GetNames(context.Type)
               .Select(
                    n =>
                    {
                        var mi = context.Type.GetMember(n).FirstOrDefault(m => m.DeclaringType == context.Type);

                        var val = Convert.ChangeType(mi.GetMemberValue(null), Enum.GetUnderlyingType(context.Type));

                        var attr = mi?.GetCustomAttribute(descriptionType, false) as DescriptionAttribute;

                        return new
                        {
                            Value = val,
                            Name = n,
                            attr?.Description
                        };
                    }
                )
               .Where(x => x.Description != null);

            schema.Description = string.Join(", ", mis.Select(x => $"[{x.Value},{x.Name}]:{x.Description}"));
        }
    }
}
