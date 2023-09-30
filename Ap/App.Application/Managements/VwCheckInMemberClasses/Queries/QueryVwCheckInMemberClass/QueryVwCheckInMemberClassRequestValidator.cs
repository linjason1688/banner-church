#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCheckInMemberClasses.Queries.QueryVwCheckInMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwCheckInMemberClassRequestValidator 
        : AbstractValidator<QueryVwCheckInMemberClassRequest>
    {
        public QueryVwCheckInMemberClassRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
