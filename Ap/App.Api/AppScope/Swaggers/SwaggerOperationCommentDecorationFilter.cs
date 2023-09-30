#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using App.Api.AppScope.Swaggers.DescriptionProviders;
using App.Application.Common.Dtos;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#endregion

namespace App.Api.AppScope.Swaggers
{
    /// <summary>
    /// 自動補充 文件說明
    /// </summary>
    public class SwaggerOperationCommentDecorationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var extraHints = new List<string>();

            // 處理動態 description
            var descriptionAttr = context.MethodInfo.GetCustomAttribute<SwaggerDescriptionAttribute>();

            if (null != descriptionAttr)
            {
                var provider = (IDescriptionProvider) Activator.CreateInstance(descriptionAttr.Provider);

                operation.Description = $"{operation.Description} \n {provider?.Description}";
            }

            var reqType = context.ApiDescription.ParameterDescriptions.FirstOrDefault()?.Type;

            if (null == reqType)
            {
                return;
            }

            //  補充動態排序查詢
            if (typeof(IDynamicSortable).IsAssignableFrom(reqType))
            {
                extraHints.Add("dynamic sort support");
            }

            // 檢查 attr
            // 語系
            if (null != reqType.GetCustomAttribute<LocalizableAttribute>())
            {
                extraHints.Add("language-header required");
            }

            if (!extraHints.Any())
            {
                return;
            }

            var hint = string.Join(", ", extraHints.Select(x => "*" + x));

            operation.Summary = $"{operation.Summary}  ({hint})";
        }
    }
}
