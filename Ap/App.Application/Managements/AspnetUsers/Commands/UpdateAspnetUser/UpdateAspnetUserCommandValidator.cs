#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsers.Commands.UpdateAspnetUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetUserCommandValidator 
        : AbstractValidator<UpdateAspnetUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetUser, e => e.Name)
            //     );
        }
    }
}
