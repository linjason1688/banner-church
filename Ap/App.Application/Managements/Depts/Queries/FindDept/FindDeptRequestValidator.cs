#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Depts.Queries.FindDept
{
    /// <summary>
    /// 
    /// </summary>
    public class FindDeptRequestValidator 
        : AbstractValidator<FindDeptRequest>
    {
        public FindDeptRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
