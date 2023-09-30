#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetUsers.Commands.UpdateVwAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetUserCommandValidator 
        : AbstractValidator<UpdateVwAspnetUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetUser, e => e.Name)
            //     );
        }
    }
}
