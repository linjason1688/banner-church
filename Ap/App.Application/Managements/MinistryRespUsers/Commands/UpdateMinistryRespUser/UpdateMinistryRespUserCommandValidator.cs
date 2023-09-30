#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryRespUsers.Commands.UpdateMinistryRespUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryRespUserCommandValidator 
        : AbstractValidator<UpdateMinistryRespUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryRespUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryRespUser, e => e.Name)
            //     );
        }
    }
}
