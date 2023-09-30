#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetMemberships.Commands.CreateAspnetMembership
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetMembershipCommandValidator 
        : AbstractValidator<CreateAspnetMembershipCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetMembershipCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetMembership, e => e.Name)
            //     );
        }
    }
}
