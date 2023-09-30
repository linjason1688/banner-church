#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserExpertises.Queries.QueryUserExpertise
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserExpertiseRequestValidator 
        : AbstractValidator<QueryUserExpertiseRequest>
    {
        public QueryUserExpertiseRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
