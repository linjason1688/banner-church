#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPersonalizationPerUsers.Commands.UpdateAspnetPersonalizationPerUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetPersonalizationPerUserCommandValidator 
        : AbstractValidator<UpdateAspnetPersonalizationPerUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetPersonalizationPerUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetPersonalizationPerUser, e => e.Name)
            //     );
        }
    }
}
