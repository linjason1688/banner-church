#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetPersonalizationAllUsers.Commands.CreateAspnetPersonalizationAllUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetPersonalizationAllUserCommandValidator 
        : AbstractValidator<CreateAspnetPersonalizationAllUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetPersonalizationAllUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetPersonalizationAllUser, e => e.Name)
            //     );
        }
    }
}
