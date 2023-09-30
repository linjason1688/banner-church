#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Depts.Commands.CreateDept
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateDeptCommandValidator 
        : AbstractValidator<CreateDeptCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateDeptCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Dept, e => e.Name)
            //     );
        }
    }
}
