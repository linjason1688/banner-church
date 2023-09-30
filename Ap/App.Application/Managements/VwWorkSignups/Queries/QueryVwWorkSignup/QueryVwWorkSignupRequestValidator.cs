#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwWorkSignups.Queries.QueryVwWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwWorkSignupRequestValidator 
        : AbstractValidator<QueryVwWorkSignupRequest>
    {
        public QueryVwWorkSignupRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
