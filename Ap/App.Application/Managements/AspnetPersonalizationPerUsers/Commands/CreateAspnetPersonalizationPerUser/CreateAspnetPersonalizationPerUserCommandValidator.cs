#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Commands.CreateAspnetPersonalizationPerUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetPersonalizationPerUserCommandValidator 
        : AbstractValidator<CreateAspnetPersonalizationPerUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetPersonalizationPerUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetPersonalizationPerUser, e => e.Name)
            //     );
        }
    }
}
