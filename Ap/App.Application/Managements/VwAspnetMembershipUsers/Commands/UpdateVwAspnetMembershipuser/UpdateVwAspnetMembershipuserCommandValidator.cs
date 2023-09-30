#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Commands.UpdateVwAspnetMembershipuser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetMembershipuserCommandValidator 
        : AbstractValidator<UpdateVwAspnetMembershipuserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetMembershipuserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetMembershipuser, e => e.Name)
            //     );
        }
    }
}
