#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetMemberships.Commands.UpdateAspnetMembership
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetMembershipCommandValidator 
        : AbstractValidator<UpdateAspnetMembershipCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetMembershipCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetMembership, e => e.Name)
            //     );
        }
    }
}
