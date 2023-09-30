#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Queries.QueryAspnetPersonalizationPerUser
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryAspnetPersonalizationPerUserRequestValidator 
        : AbstractValidator<QueryAspnetPersonalizationPerUserRequest>
    {
        public QueryAspnetPersonalizationPerUserRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
