#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SecUsers.Commands.UpdateSecUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSecUserCommandValidator 
        : AbstractValidator<UpdateSecUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSecUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SecUser, e => e.Name)
            //     );
        }
    }
}
