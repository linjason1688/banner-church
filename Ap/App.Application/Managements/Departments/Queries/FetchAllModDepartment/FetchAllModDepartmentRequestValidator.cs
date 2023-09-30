#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Departments.ModDepartments.Queries.FetchAllModDepartment
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModDepartmentRequestValidator 
        : AbstractValidator<FetchAllModDepartmentRequest>
    {
        public FetchAllModDepartmentRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
