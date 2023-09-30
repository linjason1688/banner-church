#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Depts.Queries.QueryDept
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryDeptRequestValidator 
        : AbstractValidator<QueryDeptRequest>
    {
        public QueryDeptRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
