#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Depts.Commands.UpdateDept
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateDeptCommandValidator 
        : AbstractValidator<UpdateDeptCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateDeptCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Dept, e => e.Name)
            //     );
        }
    }
}
