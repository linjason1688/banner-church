#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUsers.Queries.QuerySecUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QuerySecUserRequestValidator 
        : AbstractValidator<QuerySecUserRequest>
    {
        public QuerySecUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
