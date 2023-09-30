#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetProfiles.Queries.QueryVwAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetProfileRequestValidator 
        : AbstractValidator<QueryVwAspnetProfileRequest>
    {
        public QueryVwAspnetProfileRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
