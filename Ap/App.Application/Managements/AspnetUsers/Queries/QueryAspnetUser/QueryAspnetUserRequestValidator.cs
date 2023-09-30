#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsers.Queries.QueryAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetUserRequestValidator 
        : AbstractValidator<QueryAspnetUserRequest>
    {
        public QueryAspnetUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
