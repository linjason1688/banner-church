#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetSchemaVersions.Queries.FetchAllAspnetSchemaVersion
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllAspnetSchemaVersionRequestValidator 
        : AbstractValidator<FetchAllAspnetSchemaVersionRequest>
    {
        public FetchAllAspnetSchemaVersionRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
