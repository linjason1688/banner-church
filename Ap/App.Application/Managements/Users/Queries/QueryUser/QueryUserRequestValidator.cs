#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Users.Queries.QueryUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserRequestValidator 
        : AbstractValidator<QueryUserRequest>
    {
        public QueryUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
