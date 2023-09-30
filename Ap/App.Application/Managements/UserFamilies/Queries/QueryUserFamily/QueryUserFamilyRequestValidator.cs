#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserFamilies.Queries.QueryUserFamily
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserFamilyRequestValidator 
        : AbstractValidator<QueryUserFamilyRequest>
    {
        public QueryUserFamilyRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
