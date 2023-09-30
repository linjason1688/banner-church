using System;

namespace App.Api.AppScope.Swaggers
{
    /// <summary>
    /// 供動態新增 swagger description 使用
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SwaggerDescriptionAttribute : Attribute
    {
        public Type Provider { get; set; }
    }
}
