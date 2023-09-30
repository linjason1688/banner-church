#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetSchemaVersions.Queries.FindAspnetSchemaVersion
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetSchemaVersionRequestValidator 
        : AbstractValidator<FindAspnetSchemaVersionRequest>
    {
        public FindAspnetSchemaVersionRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
