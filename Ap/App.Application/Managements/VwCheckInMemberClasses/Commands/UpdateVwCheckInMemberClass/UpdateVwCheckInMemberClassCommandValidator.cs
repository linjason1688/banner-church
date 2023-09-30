#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCheckInMemberClasses.Commands.UpdateVwCheckInMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwCheckInMemberClassCommandValidator 
        : AbstractValidator<UpdateVwCheckInMemberClassCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwCheckInMemberClassCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwCheckInMemberClass, e => e.Name)
            //     );
        }
    }
}
