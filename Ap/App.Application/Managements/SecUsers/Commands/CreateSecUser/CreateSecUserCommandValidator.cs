#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SecUsers.Commands.CreateSecUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSecUserCommandValidator 
        : AbstractValidator<CreateSecUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSecUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SecUser, e => e.Name)
            //     );
        }
    }
}
