#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Commands.UpdateAspnetPersonalizationAllUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetPersonalizationAllUserCommandValidator 
        : AbstractValidator<UpdateAspnetPersonalizationAllUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetPersonalizationAllUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetPersonalizationAllUser, e => e.Name)
            //     );
        }
    }
}
