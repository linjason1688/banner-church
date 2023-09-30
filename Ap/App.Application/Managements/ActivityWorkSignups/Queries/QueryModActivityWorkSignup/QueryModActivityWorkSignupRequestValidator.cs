#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Queries.QueryModActivityWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModActivityWorkSignupRequestValidator 
        : AbstractValidator<QueryModActivityWorkSignupRequest>
    {
        public QueryModActivityWorkSignupRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
