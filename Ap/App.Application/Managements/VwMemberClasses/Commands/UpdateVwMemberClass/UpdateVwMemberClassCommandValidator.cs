#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberClasses.Commands.UpdateVwMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwMemberClassCommandValidator 
        : AbstractValidator<UpdateVwMemberClassCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwMemberClassCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberClass, e => e.Name)
            //     );
        }
    }
}
