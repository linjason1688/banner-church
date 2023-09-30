#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Departments.ModDepartments.Commands.CreateModDepartment
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModDepartmentCommandValidator 
        : AbstractValidator<CreateModDepartmentCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModDepartmentCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModDepartment, e => e.Name)
            //     );
        }
    }
}
