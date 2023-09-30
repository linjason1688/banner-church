#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetProfiles.Queries.QueryAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetProfileRequestValidator 
        : AbstractValidator<QueryAspnetProfileRequest>
    {
        public QueryAspnetProfileRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
