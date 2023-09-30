#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Queries.QueryVwAspnetWebPartStateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwAspnetWebPartStateUserRequestValidator 
        : AbstractValidator<QueryVwAspnetWebPartStateUserRequest>
    {
        public QueryVwAspnetWebPartStateUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
