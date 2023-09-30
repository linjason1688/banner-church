#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Depts.Queries.FetchAllDept
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllDeptRequestValidator 
        : AbstractValidator<FetchAllDeptRequest>
    {
        public FetchAllDeptRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
