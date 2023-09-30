#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Departments.ModDepartments.Commands.UpdateModDepartment
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModDepartmentCommandValidator 
        : AbstractValidator<UpdateModDepartmentCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModDepartmentCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModDepartment, e => e.Name)
            //     );
        }
    }
}
