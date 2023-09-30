#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Departments.ModDepartments.Commands.DeleteModDepartment
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModDepartmentCommandValidator 
        : AbstractValidator<DeleteModDepartmentCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModDepartmentCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
