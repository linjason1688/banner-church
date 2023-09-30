#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserSocieties.Commands.UpdateUserSociety
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserSocietyCommandValidator 
        : AbstractValidator<UpdateUserSocietyCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserSocietyCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserSociety, e => e.Name)
            //     );
        }
    }
}
