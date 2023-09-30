#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwCheckInMemberClasses.Commands.CreateVwCheckInMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwCheckInMemberClassCommandValidator 
        : AbstractValidator<CreateVwCheckInMemberClassCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwCheckInMemberClassCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwCheckInMemberClass, e => e.Name)
            //     );
        }
    }
}
