#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetSchemaVersions.Queries.QueryAspnetSchemaVersion
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetSchemaVersionRequestValidator 
        : AbstractValidator<QueryAspnetSchemaVersionRequest>
    {
        public QueryAspnetSchemaVersionRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
