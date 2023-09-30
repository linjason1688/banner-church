#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using App.Api.AppScope.Filters;
using App.Application.Common.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

#endregion

namespace App.Api.AppScope.Swaggers
{
    public static class SwaggerRegister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterSwagger(this IServiceCollection @this)
        {
            // 加個 operation filter for postman 吧…
            @this.AddSwaggerGen(
                c =>
                {
                    c.AddSecurityDefinition(
                        "JWT_Authorization",
                        new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Name = AuthAttribute.JwtHeaderName,
                            Description = "Api Authorization ([ /auth/do ]登入後取得之 jwt token)"
                        }
                    );

                    c.AddSecurityDefinition(
                        "Example-id-1",
                        new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Name = "Example-id-1",
                            Description = "EX1"
                        }
                    );

                    c.AddSecurityDefinition(
                        "example-id-2",
                        new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Name = "example-id-2",
                            Description = "locale"
                        }
                    );

                    // Make sure swagger UI requires a Bearer token specified
                    var securityRequirements = new List<OpenApiSecurityRequirement>()
                    {
                        new OpenApiSecurityRequirement()
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Name = "JWT_Authorization",
                                    In = ParameterLocation.Header,
                                    Reference = new OpenApiReference
                                    {
                                        Id = "JWT_Authorization",
                                        Type = ReferenceType.SecurityScheme
                                    }
                                },
                                new string[]
                                {
                                }
                            }
                        },
                        new OpenApiSecurityRequirement()
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Name = "Example-id-1",
                                    In = ParameterLocation.Header,
                                    Reference = new OpenApiReference
                                    {
                                        Id = "Example-id-1",
                                        Type = ReferenceType.SecurityScheme
                                    }
                                },
                                new string[]
                                {
                                }
                            }
                        },
                        new OpenApiSecurityRequirement()
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Name = "example-id-2",
                                    In = ParameterLocation.Header,
                                    Reference = new OpenApiReference
                                    {
                                        Id = "example-id-2",
                                        Type = ReferenceType.SecurityScheme
                                    }
                                },
                                new string[]
                                {
                                }
                            }
                        }
                    };

                    securityRequirements.ForEach(c.AddSecurityRequirement);
                    c.CustomSchemaIds(type =>
                        {
                            var attr = (SwaggerCustomIdAttribute) type.GetCustomAttribute(typeof(SwaggerCustomIdAttribute));
                            return attr == null ? DefaultSchemaIdSelector(type) : attr.Id;
                        }
                    );
                    c.SwaggerDoc(
                        SwaggerDefinitionConvention.FeatureName,
                        new OpenApiInfo
                        {
                            Title = "Feature",
                            Version = "v1"
                        }
                    );

                    c.SwaggerDoc(
                        SwaggerDefinitionConvention.ManagementName,
                        new OpenApiInfo
                        {
                            Title = "Management",
                            Version = "v1"
                        }
                    );

                    c.DescribeAllParametersInCamelCase();

                    // Set the comment path for the Swagger JSON and UI.
                    var xmlPathList = new List<string>()
                    {
                        Path.Combine(AppContext.BaseDirectory, "App.Api.xml"),
                        Path.Combine(AppContext.BaseDirectory, "App.Application.xml"),
                        Path.Combine(AppContext.BaseDirectory, "App.Domain.xml")
                    };

                    // load all docs
                    xmlPathList.ForEach(
                        path => { c.IncludeXmlComments(path); }
                    );

                    c.UseOneOfForPolymorphism();

                    c.SchemaGeneratorOptions.IgnoreObsoleteProperties = true;
                    c.SwaggerGeneratorOptions.DescribeAllParametersInCamelCase = true;
                    c.SchemaGeneratorOptions.SupportNonNullableReferenceTypes = true;

                    // register filters
                    c.OperationFilter<SwaggerOperationIdFilter>();
                    c.OperationFilter<SwaggerOperationCommentDecorationFilter>();
                    c.OperationFilter<SwaggerOperationIdFilterFile>();

                    c.OperationFilter<SwaggerOperationHeadersFilter>();

                    c.DocumentFilter<SwaggerLowerPathDocFilter>();

                    c.DocumentFilter<SwaggerRequiredModelFilter>();

                    c.SchemaFilter<SwaggerIgnorePropertySchemaFilter>();

                    c.SchemaFilter<SwaggerEnumSchemaFilter>();

                    c.SchemaFilter<SwaggerApiDecorationPropertySchemaFilter>();
                }
            );

            @this.AddSwaggerGenNewtonsoftSupport();

            return @this;
        }

        private static string DefaultSchemaIdSelector(Type modelType)
        {
            if (!modelType.IsConstructedGenericType)
            {
                return modelType.Name.Replace("[]", "Array");
            }

            var prefix = modelType.GetGenericArguments()
               .Select(DefaultSchemaIdSelector)
               .Aggregate((previous, current) => previous + current);

            return prefix + modelType.Name.Split('`').First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder @this, ILogger logger = null)
        {
            logger?.LogInformation("swagger enabled!");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            @this.UseSwagger(
                c =>
                {
                    c.PreSerializeFilters.Add(
                        SwaggerMyPreSerializeFilters.PostmanRequiredHeaderAddOn
                    );
                }
            );

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            @this.UseSwaggerUI(
                c =>
                {
                    c.DocumentTitle = "Api Doc";

                    // for those who version is not default 1 should be annotated with [ApiExplorerSettings(GroupName = "v{n}")]

                    c.SwaggerEndpoint(
                        $"/swagger/{SwaggerDefinitionConvention.FeatureName}/swagger.json",
                        "Feature"
                    );

                    c.SwaggerEndpoint(
                        $"/swagger/{SwaggerDefinitionConvention.ManagementName}/swagger.json",
                        "Management"
                    );

                    c.DefaultModelRendering(ModelRendering.Example);

                    c.EnableValidator();
                    c.DocExpansion(DocExpansion.List);
                    c.DisplayOperationId();
                    c.EnableFilter();
                    c.DefaultModelExpandDepth(5);
                    c.DisplayRequestDuration();
                    c.EnableDeepLinking();
                    c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                }
            );

            return @this;
        }
    }
}
