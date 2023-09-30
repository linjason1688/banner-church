#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserPastoralCares.Queries.QueryUserPastoralCare
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserPastoralCareRequestValidator 
        : AbstractValidator<QueryUserPastoralCareRequest>
    {
        public QueryUserPastoralCareRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
