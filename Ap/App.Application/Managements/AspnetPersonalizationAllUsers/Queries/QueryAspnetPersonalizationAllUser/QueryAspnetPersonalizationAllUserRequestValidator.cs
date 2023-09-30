#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Queries.QueryAspnetPersonalizationAllUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetPersonalizationAllUserRequestValidator 
        : AbstractValidator<QueryAspnetPersonalizationAllUserRequest>
    {
        public QueryAspnetPersonalizationAllUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
