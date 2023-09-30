#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberClasses.Queries.QueryVwMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwMemberClassRequestValidator 
        : AbstractValidator<QueryVwMemberClassRequest>
    {
        public QueryVwMemberClassRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
