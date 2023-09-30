#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Departments.ModDepartments.Queries.FindModDepartment
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModDepartmentRequestValidator 
        : AbstractValidator<FindModDepartmentRequest>
    {
        public FindModDepartmentRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
