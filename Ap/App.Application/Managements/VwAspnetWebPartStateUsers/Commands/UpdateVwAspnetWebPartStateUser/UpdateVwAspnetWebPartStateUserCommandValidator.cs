#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetWebPartStateUsers.Commands.UpdateVwAspnetWebPartStateUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwAspnetWebPartStateUserCommandValidator 
        : AbstractValidator<UpdateVwAspnetWebPartStateUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwAspnetWebPartStateUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwAspnetWebPartStateUser, e => e.Name)
            //     );
        }
    }
}
