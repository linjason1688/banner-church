#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserSocieties.Queries.QueryUserSociety
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserSocietyRequestValidator 
        : AbstractValidator<QueryUserSocietyRequest>
    {
        public QueryUserSocietyRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
