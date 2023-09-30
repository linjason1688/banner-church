#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Queries.QueryMinistryRespUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryMinistryRespUserRequestValidator 
        : AbstractValidator<QueryMinistryRespUserRequest>
    {
        public QueryMinistryRespUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
