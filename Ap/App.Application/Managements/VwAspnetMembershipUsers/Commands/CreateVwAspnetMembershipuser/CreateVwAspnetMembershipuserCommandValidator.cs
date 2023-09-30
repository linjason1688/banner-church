#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Commands.CreateVwAspnetMembershipuser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwAspnetMembershipuserCommandValidator 
        : AbstractValidator<CreateVwAspnetMembershipuserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwAspnetMembershipuserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetMembershipuser, e => e.Name)
            //     );
        }
    }
}
