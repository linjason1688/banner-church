#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsers.Queries.QueryVwAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetUserRequestValidator 
        : AbstractValidator<QueryVwAspnetUserRequest>
    {
        public QueryVwAspnetUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
