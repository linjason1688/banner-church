#region

using System;

#endregion

namespace App.Api.AppScope.Swaggers
{
    /// <summary>
    /// to specify client api method name
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SwaggerOperationAttribute : Attribute
    {
        public string OperationId { get; }

        /// <summary>
        /// default will use the method(decorated) name in camelCase
        /// </summary>
        /// <param name="operationId"></param>
        public SwaggerOperationAttribute(string operationId = "")
        {
            this.OperationId = operationId;
        }
    }
}
